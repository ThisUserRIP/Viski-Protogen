# 🍸 Viski-Protogen (Cracked)

**C# Managed Internal Framework (Mono overrides)** for **Unturned**.

The project is implemented entirely in **C#** and operates in **Unity Mono environments**.
A precompiled build is included in the repository:

```
Viski_Slayed.dll
```

Repository:

```
https://github.com/ThisUserRIP/Viski-Protogen
```

---

# 📦 Project Overview

Viski-Protogen provides a modular internal runtime for experimenting with gameplay mechanics and runtime manipulation inside **Unity Mono builds**.

The repository contains:

* full **C# source project**
* **precompiled DLL**
* custom **UI system**
* feature modules grouped by category

The codebase was **reconstructed through reverse engineering**, therefore parts of the project may still contain:

* partially restored logic
* obfuscated structures
* redundant code paths

Additional cleanup and optimization may be required before building or extending the project.

---

# ✨ Features

## 🎯 Aimbot

* Aimbot
* Silent Aim
* Limb targeting (`AimbotLimb`)
* FOV control
* Smoothing
* Visibility check
* Trigger / Auto-shoot

---

## 👁 Visuals

* Full ESP

  * players
  * items
  * vehicles
* Chams
* Glow rendering
* Tracers
* Backtrack visualization

---

## ⚔ Combat & Movement

* Spinbot
* Vehicle Spinbot
* Silent action components

  * `SilentComponent`
  * `SilentCoroutines`
* Weapon behavior overrides

  * `OV_UseableGun`
* Instant interaction modules

  * `OV_UseableMelee`
  * `OV_UseableStructure`

---

## 🧰 Misc Systems

* HWID changer
* Spy mode (player follow system)
* Discord integration

  * webhook support
  * rich presence
* Config system

  * save / load
* Notification window system

---

## 🖥 User Interface

The project includes a fully custom menu system.

### Menu Tabs

| Tab         | Purpose                 |
| ----------- | ----------------------- |
| AimbotTab   | targeting configuration |
| VisualsTab  | ESP and rendering       |
| MiscTab     | extra utilities         |
| HotkeyTab   | key bindings            |
| PlayersTab  | player list interaction |
| SettingsTab | global configuration    |

---

# ⚙️ How to Build

Clone the repository:

```bash
git clone https://github.com/ThisUserRIP/Viski-Protogen.git
cd Viski-Protogen
```

Open the solution in **Visual Studio 2022**.

Required workload:

```
.NET Desktop Development
C# tools
```

### Build Configuration

```
Configuration: Release
Platform: Any CPU (or x64)
```

Compile the solution:

```
Build → Viski_Slayed.dll
```

A precompiled version of the DLL is already included in the repository root.

---

# 🚀 Usage

1. Launch **Unturned**.
2. Inject the compiled DLL into the running process.
3. Open the menu using the configured hotkey.
4. Configure features through the UI tabs.
5. Save settings using the configuration system.

Hotkeys can be customized inside **HotkeyTab**.

---

# 🧠 Development Notes

Because the project was reconstructed through reverse engineering:

* parts of the codebase contain **obfuscation artifacts**
* some methods were **recovered from compiled assemblies**
* naming may be partially reconstructed

Before building or modifying the project it is recommended to:

* clean unused or duplicated code
* refactor obfuscated methods
* optimize runtime logic
* rebuild configuration structures if necessary

This helps improve stability and maintainability of the project.

---

# ⚠️ Anti-Cheat Detection Note

The project interacts directly with the runtime of **Unturned**.

Because of this:

* server-side protection systems may detect abnormal behavior
* runtime modifications may trigger anti-cheat mechanisms
* some features may be incompatible with certain servers

Detection risk depends on:

* server configuration
* anti-cheat system used
* feature configuration

Use and testing should be performed in controlled environments.

---

# 📌 Notes

* Designed for **Unity Mono builds**
* Requires correct runtime compatibility
* Offsets and behavior may change with game updates
* Some modules may require further optimization

---

# 📜 License

The project is provided **as-is** for development, experimentation, and reverse engineering research.

# ⚠️ Disclaimer

Use at your own risk.

The author (**ThisUserRIP**) assumes **no responsibility** for:

* account bans
* data loss
* crashes
* misuse of the software
* legal consequences

This project is intended **only for educational and research purposes**.

