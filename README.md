# Mecha Mania (Friend Birthday Present Series)

## Introduction
Welcome to [Mecha Mania](https://ankehao.itch.io/mecha-mania), the gamified interactive experience I made for my friend's birthday! In this experience, you play as a character in a 2D platformer who navigates the environment and fight against mechas representing the ~~grueling computer science courses and~~ challenges we faced together throughout our college experience. 

## How To Play

<img align="right" src="https://github.com/anke-hao/Friend-Mecha-BDayPresent/blob/main/Screenshots/In%20Game%20Screenshot%20Grades.png" style="height: 300px;">

### Basic Commands
- As the main player, navigate with WASD and press C to shoot.
- As Anke (your new buddy!), navigate with IJKL and press N to shoot.
  
### What to Expect
- The content of the game has been edited for privacy reasons, but the structure has remained the same! It is comprised of three levels where you navigate a 2D platform and shoot all the mechas on screen, whether that be Natural Deduction, the Algorithm Final, or a 5 AM wakeup time. 
- At the end of each level, a pair of doors will open into the Waiting for Final Grades to Come Out room, and you'll have to wait a bit before proceeding to the next level. 
- Once you enter Winter Quarter, Anke will join you in your crusade and accompany you through Spring Quarter. After finishing all of the school year, you'll receive a salute from Anke and it's off to the next year!

## Motivation
My friend's birthday was over the summer and we would be living in different locations at that time. I wanted to send a birthday gift that would both reach them on the day of their actual birthday (aka no giving them something way before or after the date!) and have quality that would be on par with a gift in person. 

### Level Design
- Separate from most of the other games in this series, this gift was more focused on game mechanics like shooting (and sometimes controlling two players at once). This is to reflect the ~~chaotic grinding my friend and I experienced and~~ the preferences of my friend.

<img align="right" src="https://github.com/anke-hao/Friend-Mecha-BDayPresent/blob/main/Screenshots/In%20Game%20Screenshot%20Winter%20Quarter.png" style="height: 300px;">

- The mecha monsters featured include:
  - Natural Deduction
  - Discrete Math Midterm
  - Discrete Math Final
  - Algorithm Midterm
  - Algorithm Final
  - 5 AM Wakeup Time (this is specific to my friend)
  - Computer Security Projects
  - Computer Security Writeups (separate from the coding projects themselves)
  - Waiting for Grades to Come Out (an undefeatable, noninteractable NPC that is nevertheless unfailingly present at the end of each level) 

## Tech Stack
<img align="right" src="https://github.com/anke-hao/Friend-Mecha-BDayPresent/blob/main/Screenshots/Fall%20Q%20Workspace.png" style="height: 330px; width:400px;">

The game was built in Unity2D, with the use of C# scripts for the following:
- managing the playable sprite’s movements and shooting (PlayerController, Projectile)
- handling dialogue, including detecting when the player is close to a Robo Memory and allowing for skipping ahead or moving to the next dialogue line
- handling the mechas' movements and HP (EnemyController, FollowPlayer)
- miscellaneous handling of object animations and switching between scenes (DontDestroy, NextScene, OpenDoor).
- handling the final ending scene (Ending)

## Visual and Audio Assets
- All the visual assets, including the playable character and all the environmental assets, were sourced from [Trevor Pupkin's](https://trevor-pupkin.itch.io/) [Tech Dungeon: Roguelite Pixel Art Assets Pack](https://trevor-pupkin.itch.io/tech-dungeon-roguelite), which is licensed for personal and commercial use.
- The background music was sourced from [TallBeard Studios's](https://tallbeard.itch.io/) [Music Loop Bundle](https://tallbeard.itch.io/music-loop-bundle).


## Future Additions/Bugfixes

<img align="left" src="https://github.com/anke-hao/Friend-Mecha-BDayPresent/blob/main/Screenshots/In%20Game%20Screenshot%20Ending.png" style="height: 250px; ">

### Additions/Revisions
- A proper start/ending screen with the option to begin or replay the experience.
- The physics system right now is such that the player and their bullets push the mecha back (i.e., the bullets have mass). It'd be good to finetune the physics system to account for the perceived size difference between player/bullet and mecha.
### Bugfixes
- If the screen is too big (i.e. a monitor), Anke's bullets may have no effect on the mechas even if you see her running around and shooting, as the mechas and their HP won't be activated unless the main player is within range and the screen size may be bigger than the range needed to activate them.

