INCLUDE globals.ink
{ gun == "fire_gun": -> already_chose | -> main }

===main===
Hi there traveler you look like you need a hand (or a spell)
    ~ gun = "fire_gun"
    ~ giveGun("fire_gun")
->END

===already_chose===
I already gave you everything I have.
->END