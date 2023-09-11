# PTIA

Unity programming theory project.

https://learn.unity.com/tutorial/submission-programming-theory-in-action

# CLADE

Clade is a descriptive title of what is going on behind the scenes of this simple game. It is called "Clade" because of how the enteties are implemented.

# Actors

* Everything is an Actor, including the player, although the player is tagged and treated differently.
* Actors are stationary or mobile
* Actors are toxic or non-toxic

When Actors collide, a few things can happen:
* If both are non-toxic, the larger one absorbs the smaller one and adds its volume
* If at least one is toxic, the larger absorbs the smaller and subtracts the volume
* If they are the same size and toxicity, they do nothing.

# Actor Class
## Virtual Methods
### Eat()
  Define how an Actor consumes another
### ComputeRadius(float volume)
  Given a float representing the volume of an actor, compute the radius of a bounding sphere.

# RigidbodyPlayerController
Child of Actor. 3rd-person mouse/keyboard controller.

# MobileController/ToxicMobileController
Child of actor. Toxic/Non-toxic mobile controllers
## Virtual Methods
### Move()
Uses FindPlayer() to determine the direction of the player and AddForce() in that direction to move in a straight line.
### FindPlayer()
Subtract our position from the player position to find the direction.

# Stationary Classes
Simply sit there being toxic/non-toxic.

# Roamers
Roamers are child classes of the MobileController that overrides the Move() method to hop randomly around, with a bias
in the player's overall direction.

# Initial gameplay
There is no real gameplay. 1000 random actors spawn on a 500x500 terrain grid, and continue spawing via Coroutine until the game
is quit.  Look with the mouse. Move with WASD.
