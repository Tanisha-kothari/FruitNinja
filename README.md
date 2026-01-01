````markdown
# Fruit Ninja – Unity Arcade Slicing Game

A fast-paced arcade slicing game inspired by the classic *Fruit Ninja* gameplay loop, developed in Unity with a strong focus on **game feel**, **reusable component-based architecture**, and **layered player feedback**.

This project was built as a **game developer portfolio piece**, showcasing clean gameplay systems, modular design, and real-time visual/audio/haptic feedback.

---

## Project Goals

The main goals of this project were:
- To implement responsive swipe-based slicing
- To focus on *game feel* through feedback (visual, sound, vibration, camera)
- To design reusable systems using Unity components
- To avoid hard-coded logic and duplicate systems

---

## Game Overview

The player slices flying fruits using swipe input to score points while avoiding bombs.  
Each successful slice triggers multiple feedback layers to make the action feel satisfying and impactful.

Bombs act as hazards and immediately interrupt gameplay by triggering a cutscene and resetting the game flow.

---

## Core Gameplay Loop

1. Fruits and bombs spawn periodically
2. Objects are launched upward using physics forces
3. Player swipes across the screen to slice fruits
4. On slice:
   - Fruit state changes
   - Score increases
   - Visual, sound, vibration, and camera feedback is triggered
5. Bomb collision triggers a cutscene and resets gameplay

---

##  Key Features

- Swipe-based slicing using trigger detection
- Physics-based fruit launching
- Combo-friendly scoring system
- Bomb hazard system
- Particle-based fruit splatter
- Camera screen shake
- Sound and vibration feedback
- Cutscene playback using VideoPlayer
- Modular and reusable component design

---

## Architecture & Code Design

This project uses **component-driven design** rather than monolithic scripts.

---

### Singleton Systems

#### Score System
```csharp
FruitCutScore.Instance.AddScore(1);
````

* `FruitCutScore` uses the Singleton pattern
* Maintains global score state
* Updates UI using TextMeshPro
* Centralized scoring avoids duplicated logic

---

### Component-Based Reusability (Major Highlight)

Instead of creating separate logic for fruits and bombs, reusable components were created and shared.

Reusable components include:

* Sound playback
* Vibration feedback
* Camera shake
* State handling

This allowed:

* Fruits and bombs to reuse feedback systems
* Minimal duplication of logic
* Faster iteration and easier maintenance

---

## Fruit System Breakdown

### Fruit Launching

* Fruits are launched using Rigidbody physics
* Randomized forward and upward force for variety
* Random angular velocity adds natural rotation

```csharp
rb.AddForce(launchDirection, ForceMode.Impulse);
rb.angularVelocity = Random.insideUnitSphere * spinForce;
```

---

### Fruit State Management

Each fruit uses a state enum:

```csharp
public enum FruitState
{
    Uncut,
    Cut,
    Destroyable
}
```

This ensures:

* Fruits cannot be sliced multiple times
* Clean transitions between gameplay states
* Safer object destruction logic

---

### Fruit Interaction Manager

`FruitManager` acts as the **orchestrator** when a fruit is sliced.

On player collision:

* Triggers vibration
* Triggers camera shake
* Plays slice sound
* Changes fruit state
* Plays splatter particles
* Increments score

This centralized handling keeps logic readable and expandable.

---

## 💥 Bomb System

Bombs intentionally reuse several fruit systems:

* Camera shake
* Vibration feedback
* Sound playback
* State tracking

### Bomb Collision Behavior

* Immediately triggers strong feedback
* Plays bomb sound
* Starts a cutscene
* Resets gameplay flow

This creates a clear and dramatic penalty for mistakes.

---

## Cutscene System

* Implemented using Unity’s `VideoPlayer`
* Uses a Singleton `CutsceneManager`
* Game is paused during cutscene playback
* Scene resets after video finishes

```csharp
PausePlayMenu.Pause();
videoPlayer.Play();
PausePlayMenu.Resume();
SceneManager.LoadScene("HomePage");
```

This system cleanly separates gameplay and cinematic logic.

---

## Visual Effects

### Particle System (Fruit Splatter)

* Each fruit contains a ParticleSystem
* Splatter is triggered exactly on slice
* Particle system is stopped on Awake and played on demand

---

### Trail Renderer (Swipe Feedback)

* Used to visually represent slicing motion
* Improves player control perception
* Adds smoothness and clarity to input

---

### Camera Shake

* Custom camera shake system using coroutines
* Randomized positional offsets
* Automatically resets camera position after shake

This adds weight and impact to successful interactions.

---

## Audio & Vibration

### Sound

* Separate audio sources for different interactions
* Sounds are triggered via reusable sound components
* Audio does not autoplay, ensuring precise timing

### Vibration

* Custom Android vibration implementation
* Falls back to `Handheld.Vibrate()` when needed
* Static access allows reuse across objects

---

## Controls

| Action | Input                    |
| ------ | ------------------------ |
| Slice  | Mouse Drag / Touch Swipe |
| Pause  | UI Button                |
| Exit   | UI Button                |

---

## Tech Stack

* Engine: Unity
* Language: C#
* Platform: PC / Android (Prototype)
* Systems Used:

  * Rigidbody Physics
  * Particle System
  * Trail Renderer
  * VideoPlayer
  * TextMeshPro

---

## Development Highlights

* Built a **reusable feedback system** shared by fruits and bombs
* Focused heavily on **game feel**, not just mechanics
* Avoided hard-coded behavior by using components and enums
* Designed systems to be expandable for future features

---

## Future Improvements

* Power-ups (slow motion, double score, freeze time)
* Difficulty scaling over time
* Improved shader-based juice effects
* Leaderboards and persistent score saving
* Object pooling for performance optimization

---

## How to Run

### Build

1. Download the build folder
2. Run `FruitNinja.exe`
3. Use mouse or touch input to play

### Unity Project

1. Open project in Unity
2. Load the main gameplay scene
3. Press Play

---

## Developer

**Tanisha**
Role: Solo Game Developer
Year: 2025

This project was developed independently to demonstrate gameplay programming, architecture design, and polish-focused development.

---

## Credits

* Sound effects:
  **Sound Effects**  
- "Sound Effect Name" by [Universfield](https://pixabay.com/users/universfield-28281460/) — Pixabay
* Fonts: Fonts by Windows
* All gameplay code and systems implemented by me

```
