# Siyoung Lee

1. A copycat project : OverCooked
           
2. Code Description
(1) Player.cs : 
Code for players seen in screenshots. 
It includes actions such as basic movements, plate picking, food making, etc.

(2) Plate.cs & Food.cs : 
Codes of dishes and food shown in screenshots, 
including basic movement actions, interactions with players, etc.

(3) Recipe.cs : 
Code for recipes shown at the top left of the screenshot. 
It includes basic movement actions (add every period of time), 
interactions with players (add coins if you make the right food, reduce coins if you don't make it in time).

(4) TimeOut.cs : 
Codes for timers shown in the lower right of the screenshot, 
including basic movement actions (reduced time, moved to the next stage after a certain period of time).


- applied collisions and physics between basic objects using BoxCollider (trigger), rigidbody, and physics.
- Scripts were written using Serialized fields, and class inheritance.
- implemented the necessary functions for objects using corutin (creating/deleting recipes after a certain period of time, etc.)






