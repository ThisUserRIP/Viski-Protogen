# Viski-Protogen | Unturned External/Internal Hybrid (Crack)

This repository contains a modified and redistributed version of the **Protogen cheat**, referred to as **Viski-Protogen**. It represents a partially decompiled, altered, and restructured build intended for reverse engineering, analysis, and low-level experimentation.

The project combines characteristics of both **external and internal injection paradigms**, targeting the Unity (Mono) runtime used by *Unturned*.

---

## ⚠️ MANDATORY DISCLAIMER (READ BEFORE USE)

### NO LIABILITY
The author of this repository assume **zero responsibility** for any of the following:

- Account bans (including permanent bans via BattlEye)
- Hardware bans (HWID flags)
- System instability, crashes, or data loss
- Malware false positives or actual damage caused by misuse

All usage is performed strictly at your own risk.

---

### NO RESPONSIBILITY / NO PUNISHMENT CLAUSE
By accessing or using any files within this repository, you explicitly acknowledge:

- You are fully responsible for your actions  
- You understand the risks of modifying or interacting with protected software  
- The repository author does not enforce usage restrictions and assumes no consequences  

---

### END OF LIFE NOTICE
This project is considered:

**FINAL / ARCHIVED / DISCONTINUED**

- No updates will be released  
- No bug fixes will be provided  
- No support or maintenance will occur  
- No compatibility updates for future game versions  

This is a static snapshot of the project in its current state.

---

### SECURITY WARNING
Due to the nature of the project:

- Files may trigger antivirus or endpoint protection systems  
- Code may contain obfuscation artifacts, broken logic, or unsafe constructs  
- Execution without inspection is strongly discouraged  

**Manual deobfuscation and verification is strongly recommended before any use.**

---

## 🛠 Project Overview & Technical Details

**Viski-Protogen** is implemented primarily in:

- C# (.NET Framework)  
- Targeting Unity Mono runtime  
- Interfacing with Unturned's Assembly-CSharp  

This project is a **cracked / reconstructed version** of the Protogen cheat, modified to expose internal functionality and bypass original protections.

---

## ⚙️ Architecture & Behavior

### Hybrid Model

The project demonstrates traits of both:

**Internal logic:**
- Injected DLL interacting with Unity runtime  
- Direct access to in-game objects and memory  

**External patterns:**
- Auxiliary control logic  
- Separation between loader and payload components  

---

### Core Components

- **Viski_Slayed.dll**
  - Main compiled cheat module  
  - Contains runtime hooks and feature logic  

- **Viski.sln / .csproj**
  - Visual Studio project files  
  - Used for rebuilding or modifying the project  

- **Viski/**
  - Core source code  
  - Feature modules and game interaction logic  

---

## 🧠 Functional Capabilities (Inferred)

Based on structure and known Protogen implementations:

- ESP (player visuals, distance tracking)  
- Player data access (position, health, transforms)  
- Unity object traversal (GameObject iteration)  
- Memory interaction (read/write, hooks)  

---

## 🔐 Obfuscation & Code State

The codebase shows:

- Partial or broken deobfuscation  
- Flattened or unreadable control flow  
- Renamed or stripped symbols  

### Important:
- Code is not clean  
- Logic may be incomplete  
- Some parts may be intentionally corrupted  

**Full cleanup and deobfuscation is required before meaningful use.**

---

## 🛡 Anti-Cheat & Detection Notice

*Unturned* uses **BattlEye (BE)**.

### Detection Risk:
- HIGH probability of detection  
- Signature-based and heuristic triggers likely  

### Possible Consequences:
- Instant ban  
- Delayed ban  
- HWID flagging  

---

### Testing Recommendations

- Do NOT use on main accounts  
- Use isolated/test environments only  
- Avoid protected servers  
- Assume detection without additional protection  

---

## 📂 Project Structure

```
Viski-Protogen/
│
├── Viski/
│   ├── Source code
│   ├── Logic modules
│   └── Feature implementations
│
├── Viski.sln
├── Viski.csproj
│
├── Viski_Slayed.dll
│   └── Compiled binary
│
└── Additional artifacts
```

---

## 📜 Development Status

**STATUS: DISCONTINUED**

- No active development  
- No updates planned  
- No support provided  

This repository serves only as:

- Archive  
- Research material  
- Reverse engineering reference  

---

## 🔍 Intended Use

- Reverse engineering practice  
- Unity/Mono internals study  
- Obfuscation analysis  
- Cheat architecture research  

---

## ⚠️ Final Notes

- Expect instability  
- Expect incomplete features  
- Expect anti-cheat detection  

This project is provided strictly "as is".

---

**End of README**
