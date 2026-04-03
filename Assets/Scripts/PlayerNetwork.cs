using UnityEngine;
using Mirror;

public class PlayerNetwork : NetworkBehaviour
{
    [Header("Settings")]
    public float speed = 5f;
    public Color localPlayerColor = Color.red;
    public Color remotePlayerColor = Color.blue;

    private CharacterController controller;
    private Vector3 velocity;

    private float lastSendTime;
    public float sendInterval = 0.1f;

    [SyncVar(hook = nameof(OnPositionChanged))]
    private Vector3 networkPosition;

    [SyncVar(hook = nameof(OnRotationChanged))]
    private Quaternion networkRotation;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<Renderer>().material.color = localPlayerColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = remotePlayerColor;
        }
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        velocity = new Vector3(horizontal, 0, vertical) * speed;
        controller.Move(velocity * Time.deltaTime);

        if (Time.time - lastSendTime > sendInterval)
        {
            CmdUpdatePosition(transform.position, transform.rotation);
            lastSendTime = Time.time;
        }
    }

    void LateUpdate()
    {
        if (!isLocalPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, networkRotation, Time.deltaTime * 10);
        }
    }

    [Command]
    void CmdUpdatePosition(Vector3 pos, Quaternion rot)
    {
        networkPosition = pos;
        networkRotation = rot;
    }

    void OnPositionChanged(Vector3 oldPos, Vector3 newPos)
    {
        networkPosition = newPos;
    }

    void OnRotationChanged(Quaternion oldRot, Quaternion newRot)
    {
        networkRotation = newRot;
    }
}