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

## Virtual Methods
### Eat()
  Define how an Actor consumes another
### ComputeRadius(float volume)
  Given a float representing the volume of an actor, compute the radius of a bounding sphere.
