# 🧩 3D Puzzle Platformer – C# Scripts Documentation

## 🎮 Overview
This folder contains all **C# scripts** powering the logic and interactivity of the **3D Puzzle Platformer** game.  
The project is built in **Unity** using **C#**, combining physics-based movement, camera controls, triggers, and puzzle mechanics to create an immersive player experience.

These scripts work together to handle:
- Smooth player movement and jumping
- Camera following and rotation
- Puzzle logic and object interactions
- Game progression, UI feedback, and respawning

---

## 🧠 Script Descriptions

### 🧍‍♂️ Player Scripts
**`PlayerMovement.cs`**  
Handles all player input and movement logic. Includes walking, jumping, double-jump (if enabled), and air control. Uses Unity’s `CharacterController` for smooth physics interaction.  

**`PlayerController.cs`**  
Serves as the main hub script controlling player states (Idle, Moving, Jumping, Interacting). It coordinates animation triggers and communicates with puzzle objects.  

---

### 🎥 Camera Scripts
**`CameraFollow.cs`**  
Keeps the camera smoothly following the player using linear interpolation. Adjustable offset and damping values for smooth transitions.  

**`CameraController.cs`**  
Handles rotation around the player and input-based camera movement. Prevents clipping and maintains visibility in narrow spaces.

---

### 🧩 Puzzle Scripts
**`PressurePlate.cs`**  
Detects when the player or movable objects stand on it and triggers linked puzzle actions (like opening doors or activating platforms).  

**`MovingPlatform.cs`**  
Moves between waypoints when activated by puzzles or switches. Can use linear or smooth motion interpolation.  

**`DoorTrigger.cs`**  
Handles opening and closing doors based on puzzle conditions. Integrates with `PuzzleManager` to check states.  

**`PuzzleManager.cs`**  
Coordinates puzzle states across multiple scripts — useful for multi-step challenges (e.g., “activate all 3 switches to unlock the exit”).

---

### 🕹️ Game Logic
**`GameManager.cs`**  
Core singleton managing game state (Paused, Running, GameOver). Handles level transitions, restarts, and player stats.  

**`UIManager.cs`**  
Updates HUD elements like timers, hints, and puzzle indicators. Works closely with `GameManager`.  

**`LevelTransition.cs`**  
Fades scenes in/out and loads new levels when objectives are met.

---

### 🧰 Utility Scripts
**`AudioManager.cs`**  
Manages sound effects and background music. Supports volume settings, fade transitions, and audio pooling.  

**`CheckpointSystem.cs`**  
Handles checkpoint registration and data persistence between levels.

---

## ⚙️ Technical Notes
- **Engine:** Unity (version 2022 or newer recommended)  
- **Language:** C#  
- **Physics:** Unity’s built-in 3D physics engine  
- **Input System:** Unity’s old Input Manager (migratable to the new Input System)  
- **Architecture:** Component-based, following SOLID principles where possible  

---

## 🚀 How to Use
1. Attach `PlayerMovement` and `PlayerController` to the Player GameObject.  
2. Attach `CameraFollow` to the Main Camera, and assign the Player as target.  
3. For each puzzle element:
   - Add `PressurePlate` or `DoorTrigger` as needed.  
   - Link actions in the Unity Inspector.  
4. Assign the `GameManager` prefab to your scene (singleton pattern).  
5. Test in Play Mode and adjust serialized values to fine-tune gameplay.

---

## 🧩 Extending the System
You can easily extend the game by:
- Adding new puzzle types (e.g., rotating mirrors, light triggers).  
- Expanding the `PuzzleManager` logic to handle chained puzzles.  
- Integrating collectibles and a scoring system.  
- Replacing movement physics with Rigidbody-based motion for realism.

---

## 👨‍💻 Author
**Trevor Nweze**  
Fullstack & Creative Developer  
📧 `trevorcnweze@gmail.com`  
🌐 [LinkedIn](https://linkedin.com/in/trevornweze)  

---

💬 *“Games are puzzles in motion — I just love bringing them to life.”*
