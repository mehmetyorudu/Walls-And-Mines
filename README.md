
General Information

The game is played in a 23*53 game field including outer walls. Game characters are P, X and Y. Human player is represented by P. Computer controls X and Y. The aim of the game is reaching the highest score.


Game Characters

P: Human player   
•	Cursor keys: To move the human player (4 directions)   
•	Space: To drop a mine (+) behind the human player

X and Y: Computer controlled enemies   
•	They try to reach the location of the P (4 directions). They are stuck on obstacles.    
•	X: In chasing, priority is x-axis
•	Y: In chasing, priority is y-axis

Numbers: 1, 2, 3
•	These can be collected by the human player. They have some functions for the human player.
o	1: 10 points.
o	2: 30 points and 50 energy.
o	3: 90 points, 200 energy and 1 mine.    

Mine: +
•	Fatal for any game character (P, X, Y) in the same square with the mine.
Game Initialization

•	The walls in the game area are generated randomly. 

•	Game area consists of 4*10 cores of walls.  

#### <-- Cores are blueprints of 4 walls which are square shaped. 
#  #     In the game, a core must have min. 1 wall, max. 3 walls. 
#  #     Each wall is randomly generated with 50% probability.
####

•	Human player P is located randomly. Energy of P is 200 at the beginning.

•	2 X and 2 Y enemies are located randomly. 

•	20 numbers (1, 2, or 3) are placed at random positions.
o	Generation probability of 1: 60%
o	Generation probability of 2: 30%
o	Generation probability of 3: 10%



Game Playing Information

•	Time unit of the game is 200 ms.

•	In 1 time unit, P can move one square. Moving 1 square requires 1 energy for the player.
If the human player has no energy, his/her movement speed is reduced by half.

•	In 1 time unit, each enemy (X or Y) can move one square. They don't need energy. If an enemy reaches the square of P, the game is over. If they encounter a number (1/2/3), the number disappears.

•	Enemies cannot see or sense the mines (or the numbers). If an enemy is in the same square with a mine, the mine and the enemy disappear, and the human player gains 300 score points. 

•	There can be only 1 game object (characters, items or walls) in a game square.


Changes with time:

•	1 number (1, 2, or 3 with the same generation probabilities) is added to the game area (random position) for every 10 time units. 

•	1 enemy (X or Y with equal probability) is added to the game area (random position) for every 150 time units. 

•	1 wall is added or deleted randomly for every time unit.
