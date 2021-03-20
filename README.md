<img src="https://jacpro.github.io/images/splashmenu.png" title="Splash Main Menu"></img>

## Introduction
This top-down 2.5D shooter started as a project for the [*Game Jobs Live 2021 Game Jam*](https://itch.io/jam/gjl-game-parade). When the submission deadline arrived, I had already programmed the core functionality of the game, but wasn't happy with the final result; there was a lot more I wanted to add to it. As such, I decided to turn it into a longer term project to span a couple of months.


<img src="https://jacpro.github.io/images/splash1.png" title="Splash (Work in Progress)" width="33%"></img>
<img src="https://jacpro.github.io/images/splash2.png" title="Change colour to match enemies" width="33%"></img>
<img src="https://jacpro.github.io/images/splash3.png" title="Enemy death colour splash" width="33%"></img>

___
#### To play the game in your browser, [*click here*]()
___

## Story
The village is under attack by dark forces; everyone else has already evacuated, but you've overslept! The only escape now is to fight off the hordes of enemies coming your way.

Luckily, you're not alone. The village is inhabited by three wizards, each with a different speciality. They aren't fighters - they're scholars, after all - but they want to get rid of these pesky beasts as much as you do. 
You must visit each Wizard in turn to be gifted with a different power. Only once you wield the combined powers of all three wizards will you be able to defeat the incoming forces of darkness and restore the village to its former glory.

## Features
#### Core Mechanics
* Cursor aiming
  * TODO - Will add analog stick aiming 
* Cross-Platform Movement
* Colour-coordinated Attacks and Enemy Health
* Enemy colour change according to amount of each health type remaining
* TODO - Enemy AI - follow, attack and line of sight
* TODO - Boss battles

#### Visuals and Cinematics
* TODO - Add cutscenes
* TODO - Add dialogue (show in game world, rather than UI)
* TODO - Add UI
* TODO - Add colour blindness options

#### Menus
* Main Menu
* TODO - Add Pause Menu
* TODO - Add Settings Menu

#### Sound
* SFX (footsteps, firing bullets, (TODO - player damaged, player death, enemy damaged, enemy death, boss damaged, boss death))
* Added Music (using singleton pattern to persist between scenes)
* TODO - Separate volume control (SFX, music, master)

#### Polish/Effects
* Particle Effects (enemy death, bullet collision (TODO - player damaged, player death))
* Post-processing (bloom , vignette, mild colour enhancements etc.)
* TODO - Customisable VFX settings (for tailoring visuals vs performance)
