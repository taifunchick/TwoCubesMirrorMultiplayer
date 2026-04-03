# 🌐 Two Cubes Online | Mirror Networking Demo

> Simple multiplayer demo: move a red cube on one client, watch the blue cube follow on another. Video in the Media folder.

[![Unity](https://img.shields.io/badge/Unity-2021.3+-000.svg?logo=unity)](https://unity.com)
[![Mirror](https://img.shields.io/badge/Mirror-Networking-blue)](https://mirror-networking.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

---

## 🎯 What it does

- 🔴 **Local player**: Control a red cube with WASD
- 🔵 **Remote player**: See a blue cube that syncs in real-time
- 🌐 **Network**: Uses Mirror Networking with KCP Transport
- 🎨 **Smoothing**: Lerp interpolation reduces jitter from lag

---

## ⚙️ Requirements

- Unity 2021.3 LTS or newer
- Mirror package (install via git: `https://github.com/vis2k/Mirror.git`)

---

## 🚀 Quick Start

1. **Install Mirror** via Package Manager
2. **Open scene**: `Scenes/NetworkScene.unity`
3. **Setup NetworkManager**:
   - Add component → `KCP Transport` (click "Add Transport" button)
   - Assign `Player.prefab` to **Player Prefab** and **Spawn Prefabs**
4. **Test locally**:
   - Build the project (`File → Build Settings → Build`)
   - Run Unity Editor + built executable
   - Editor: click **Host** | Build: click **Client**
5. Move the red cube — the blue one follows! 🎉

---
