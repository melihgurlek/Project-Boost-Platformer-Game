# Void Drifter
> A physics-based precision platformer built in Unity (C#).

[![Play in Browser](https://img.shields.io/badge/Play_in_Browser-itch.io-fa5c5c?style=for-the-badge&logo=itch.io)](https://aciros.itch.io/void-booster)
[![Unity](https://img.shields.io/badge/Made_with-Unity-000000?style=for-the-badge&logo=unity)](https://unity.com/)

## Overview
Void Drifter is a momentum-based flight game where players navigate a spaceship through hazardous procedural environments. The core gameplay relies on **Newtonian physics** rather than standard character controllers, requiring players to manage thrust, inertia, and rotational velocity.

## Technical Highlights

### 1. Physics-Based Flight Controller
The ship uses a custom implementation of Unity's **Rigidbody** physics engine. Instead of modifying transform positions directly, the controller applies relative force vectors, creating realistic drift and weight.
* **Thrust:** Applied via `rb.AddRelativeForce(Vector3.forward)` to simulate engine propulsion relative to the ship's nose.
* **Rotation:** Uses `transform.Rotate` with temporary `freezeRotation` constraints to prevent physics engine jitter during player input.
* **Code:** [`Scripts/Movement_Alt.cs`](./Assets/Scripts/Movement_Alt.cs)

### 2. Procedural Obstacle Oscillation
Obstacles utilize trigonometric functions (Sine Waves) to generate smooth, looping movement patterns without requiring complex Animator Controllers or keyframes.
* **Math:** $Position = Start + (Vector \times \sin(\frac{Time}{\text{Period}} \times \tau))$
* **Benefit:** Allows for infinite, jitter-free movement cycles with near-zero performance overhead.
* **Code:** [`Scripts/Oscilliator.cs`](./Assets/Scripts/Oscilliator.cs)

### 3. Persistent Session State
The game tracks player performance (Death Count, Time) across scene reloads using static state persistence, ensuring data integrity even when the Scene Manager unloads the current level.
* **Implementation:** `public static int deathCounter` retains values between `SceneManager.LoadScene()` calls.
* **Code:** [`Scripts/CollisionHandler.cs`](./Assets/Scripts/CollisionHandler.cs)

### 4. Event-Driven Feedback System
The game features a dedicated `CollisionHandler` that manages the game state loop. It uses boolean flags (`isTransitioning`) to lock inputs during win/loss sequences, preventing race conditions (e.g., dying after crossing the finish line).

## Project Structure
* `Assets/Scripts/Movement_Alt.cs`: Core player physics logic.
* `Assets/Scripts/CollisionHandler.cs`: Game loop, state management, and scene transitions.
* `Assets/Scripts/Oscilliator.cs`: Mathematical logic for moving platforms.

## Controls
* **Space:** Thrust (Main Engine)
* **A / D:** Rotate Left / Right
* **L:** Skip Level (Debug)
* **C:** Toggle Collision (Debug)

---
*Developed by [Melih Gürlek](https://linkedin.com/in/melihgurlek)*
