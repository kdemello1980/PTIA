# PTIA

Unity programming theory project.

https://learn.unity.com/tutorial/submission-programming-theory-in-action

# New Text (a game that has nothing to do with new text)

A working title.

You are an amorphous blob. With a gun, somehow. Anywho, things keep popping up everywhere and you have to eat what won't kill you, and not touch what will. Like _Time Bandits_, touching evil is inadvisible.

# Serious Technical Details

You are an amorphous blob....

You interact with _Actors_, which have the following attributes:
* They are mobile, or stationary.
* They are safe to absorb or toxic.
* If you touch a safe actor, you will absorb its _volume_ and add it to your own (i.e. diminishing returns as you get larger).
* If you touch a toxic actor, you will subtract its volume from your own. If you drop to 0 or below, game over.
* A winning condition is to reach a certain goal in a specified time.
