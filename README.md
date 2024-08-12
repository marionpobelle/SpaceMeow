# Space Meow
## Summary

<p align="center"><img src="https://github.com/marionpobelle/SpaceMeow/blob/master/Assets/Images/SM_MainMenuNew.png?raw=true)" width="800" height="400"/></p>

Space Meow is a Top/Down shooter game.
The player takes the role of a cat in a spaceship that is trapped in an asteroid field. It includes two modes :  
* ENDLESS : The player will have to shoot and dodge the asteroids to keep themselves out of trouble for as long as possible.
* STORY : The player has to reach a certain amount of points in order to trigger a bossfight.

Destroying asteroids grants the player points that increase their overall score. Different bonuses will randomly spawn in order to help them survive longer and get a higher score.

### Heart

### Star

## Bubble

## Development

This game was made with [Unity](https://unity.com/fr).\
The music used in this project is [Newer Wave by Kevin MacLeod](https://www.youtube.com/watch?v=T-4jRyT8lDc&ab_channel=KevinMacLeod). It is an easy song to work with as the beats are easy to notice. 

Additionnal plug-ins :
[XR Interaction Toolkit](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.5/manual/index.html).

## Demo

![Gif_TempoSword](https://github.com/marionpobelle/Tempo-Sword/assets/112869026/3ebc9078-e9a1-4a50-92b9-0cda5c8035cf)

https://github.com/marionpobelle/Tempo-Sword/assets/112869026/345a8f58-9220-406b-8c04-33a1a126a608

## TDL

- [x] GAMEPLAY
- - [x] Environment (platform, track lines, track beat lines)
- - [x] Blocks (model, behavior, SFX, hit)
- - [x] Miss Hit Detector
- - [x] Track (beats)
  
- [x] SYSTEM
- - [x] Game Handler (score, life, end game logic, velocity threshold)
- - [x] Automated block map generation on track
- - [x] Velocity Tracker (on controllers)
- - [x] Audio Handler (SFX, music)
- - [x] Song Data
  
- [x] UI
- - [x] HUD

- [x] VR
- - [x] Set up XR Origin
- - [x] Set up controllers
- - [x] Models for controllers

## Summary



![boss1](https://github.com/marionpobelle/SpaceMeow/assets/112869026/cd1df237-7ff1-4ab0-9ce3-1c3de9f273ab)
![boss2](https://github.com/marionpobelle/SpaceMeow/assets/112869026/6cad1da9-8b00-4ffc-b00f-fa1334923cf1)
![smbonus](https://github.com/marionpobelle/SpaceMeow/assets/112869026/c17a94d3-2ab1-4a64-8ffc-d025364e8307) 

# Development

This game is made with [Unity](https://unity.com/fr) and the assets are made with [Pixel Art Studio](https://store.steampowered.com/app/1204050/Pixel_Studio__pixel_art_editor/?l=french).

During the development phase, a build of the game was made available on a discord server for people to compete and report bugs. The current leaderboard in ENDLESS mode is :

<p align="center"><img src="https://github.com/marionpobelle/SpaceMeow/blob/master/Assets/Images/sm_leaderboard.png?raw=true)" width="800" height="400"/></p>


# Demo

### Main Menu

https://github.com/marionpobelle/SpaceMeow/assets/112869026/53e62f05-c107-42c3-80d9-93b0a85079c6

### Gameplay

https://github.com/marionpobelle/SpaceMeow/assets/112869026/ef1e68dc-040a-45b2-957f-d4ec6f45b6be


### Bossfight

https://github.com/marionpobelle/SpaceMeow/assets/112869026/936d82f0-1338-4c4f-bbf8-f302e1a31048

# TDL

- [x] MAIN MENU
- - [x] Background sprite
- - [x] Start button + sprite
- - [x] Quit button + sprite
- - [x] Controls button + sprite
- - [x] Controls menu + sprite
- - [x] Music
- - [x] Windowed/Fullscreen dropdown + sprite

- [x] GAME
- - [x] Background sprite
- - [x] Music
- - [x] UI for HP and Lifes + sprites
- - [x] First wave contains no small asteroid
- - [x] Asteroids spawn out of sight
- - [x] Score increasing upon destroying or hitting asteroids
- - [x] Screen bounds preventing the player from leaving the screen view
- - [x] Endless and Story modes
- - [x] Difficulty scaling
- - [x] Timer
- - [x] Point pop ups

- [x] PLAYER
- - [x] HP and Lifes system
- - [x] Death + animation + sound feedback + respawn
- - [x] Damage + animation + sound feedback + invulnerability
- - [x] Movement with space inertia

- [x] ARROW
- - [x] Firepoint follows the mouse
- - [x] Left click : on click shots
- - [x] Right click : uninterrupted shots
- - [x] Shooting sound feedback
- - [x] Anti-macro system
- - [x] Animation upon shot hitting an asteroid

- [x] METEORS
- - [x] Sound feedback upon damage
- - [x] Sound feedback upon destruction
- - [x] Animation upon destruction
- - [x] Deterioration upon taking damage
- - [x] Destruction upon collision with the player
- - [x] HP/Point system
- - [x] Balance meteor speed

- [x] BONUSES
- - [x] Sound cue upon appearance
- - [x] Disappearance after a few seconds
- - [x] Heart : sound feedback + effect
- - [x] Bubble : sound feedback + effect + animation
- - [x] Star : sound feedback + effect + animation

- [x] PAUSE MENU
- - [x] Background sprite
- - [x] Resume button + sprite
- - [x] Main menu button + sprite
- - [x] Sliders for sound + sprites
- - [x] Display current score and highscore

- [x] ENDING SCREEN
- - [x] Background sprite 
- - [x] Display highscore
- - [x] Sound cue upon new highscore
- - [x] Try again button + sprite
- - [x] Main menu button
- - [x] Quit button
- - [x] Reset highscore button for tests
- - [x] Save highscore between sessions
- - [x] Music

- [x] BOSS
- - [x] Code Implementation
- - - [x] Movement
- - - [x] Attack
- - - [x] Spawn
- - - [x] Damage Taken
- - - [x] Death
- - [x] Sprites : Self, Idle animation, Attack, Death, Damage taken, HP bar
- - [x] Sounds : Spawn, Death, Music, Attack, Damage taken
