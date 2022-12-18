# Presentation

<p align="center"><img src="https://github.com/marionpobelle/SpaceMeow/blob/master/Assets/Images/sm_main_menu.png?raw=true)" width="800" height="400"/></p>

Space Meow is a Top/Down shooter game.
In this game the player takes the role of a cat in a spaceship that is trapped in an asteroid field. The player will have to shoot and dodge the asteroids to keep themselves out 
of trouble as long as possible !

Destroying asteroids grants the player points that increase their overall score. Different bonuses will randomly spawn in order to help them survive longer and get 
a higher score.

## Bonuses available

### Star

<p align="center"><img src="https://github.com/marionpobelle/SpaceMeow/blob/master/Assets/Images/bonus_star.png?raw=true)" width="100" height="100"/></p>

Grants the player invulnerability for a few seconds. A sound cue will play when this bonus is collected by 
the player and when its effect dissipates. A visual cue will also show the player that the effect is active.

### Heart

<p align="center"><img src="https://github.com/marionpobelle/SpaceMeow/blob/master/Assets/Images/heart.png?raw=true)" width="100" height="100"/></p>

Grants the player one more HP when collected.

### Bubble

<p align="center"><img src="https://github.com/marionpobelle/SpaceMeow/blob/master/Assets/Images/bubble_bonus.png?raw=true)" width="100" height="100"/></p>

Destroys all asteroids visible on screen. Doesn't grant the player points for the destroyed elements. 


# Development

This game is made with [Unity](https://unity.com/fr) and the assets are made with [Pixel Art Studio](https://store.steampowered.com/app/1204050/Pixel_Studio__pixel_art_editor/?l=french).

During the development phase, a build of the game was made available on a discord server for people to compete and report bugs. The current leaderboard is :

<p align="center"><img src="https://github.com/marionpobelle/SpaceMeow/blob/master/Assets/Images/sm_leaderboard.png?raw=true)" width="800" height="400"/></p>


# Demo

### Main Menu

https://user-images.githubusercontent.com/112869026/208313370-a13b1179-143c-487d-ba1b-b8682809e187.mp4

### Gameplay

https://user-images.githubusercontent.com/112869026/208313543-9bc13360-157b-4e5c-a463-487d381856cb.mp4

# TDL

- [ ] incomplete task
- - [x] completed task

- [ ] MAIN MENU
- - [x] Background sprite
- - [x] Start button + sprite
- - [x] Quit button + sprite
- - [x] Controls button + sprite
- - [x] Controls menu + sprite
- - [x] Music
- - [ ] Windowed/Fullscreen dropdown + sprite

- [ ] GAME
- - [x] Background sprite
- - [x] Music
- - [x] UI for HP and Lifes + sprites
- - [x] First wave contains no small asteroid
- - [x] Asteroids spawn out of sight
- - [x] Score increasing upon destroying asteroids
- - [x] Screen bounds preventing the player to leave the screen view
- - [ ] Difficulty scaling

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

- [x] ASTEROIDS
- - [x] Sound feedback upon damage
- - [x] Sound feedback upon destruction
- - [x] Animation upon destruction
- - [x] Deterioration upon taking damage
- - [x] Destruction upon collision with the player
- - [x] HP/Point system

- [x] BONUSES
- - [x] Sound cue upon appearance
- - [x] Disappearance after a few seconds
- - [x] Heart : sound feedback + effect
- - [x] Bubble : sound feedback + effect + animation
- - [x] Star : sound feedback + effect + animation

- [ ] PAUSE MENU
- - [x] Background sprite
- - [x] Resume button + sprite
- - [x] Main menu button + sprite
- - [ ] Slides for sound + sprites
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

- [ ] BOSS
- - [ ] Find music
- - [ ] Brainstorm boss implementation
