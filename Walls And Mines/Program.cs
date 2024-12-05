using System.Numerics;
using System;

namespace wallss

{
    internal class Program
    {

        static void Main(string[] args)

        {
            Console.CursorVisible = false;


            //****************************************************************************************************************************************************************************************************************************


            int energy = 200;       //Here we define our energy value as 200.

            int score = 0;

            int mine = 10;

            //****************************************************************************************************************************************************************************************************************************



            char[,] randomWall()    //We wrote a function to create the walls.          
            {
                char[,] wall = new char[23, 53];                    //We open an array suitable for the dimensions.


                for (int i = 0; i < wall.GetLength(0); i++)         //With this for loop, we create its outer walls.
                {
                    for (int j = 0; j < wall.GetLength(1); j++)
                    {
                        if (i == 0 || j == 0 || i == 22 || j == 52) //We write the conditions for the exterior walls and print "#" if it fits.
                        {
                            wall[i, j] = '#';
                        }
                        else
                        {
                            wall[i, j] = ' ';
                        }
                    }
                }


                for (int i = 2; i <= 47; i = i + 5)                 //We call the function for the other parts.
                {
                    for (int j = 2; j <= 17; j = j + 5)             //The reason we increase it five by five is if one wall will be formed on the 2nd column,
                                                                    //the other will be formed on the 7th wall, the same goes for the rows.
                    {
                        generateRandomWalls(j, i);
                    }
                }



                void generateRandomWalls(int i, int j)              //here we create our wall creation function and it consists of 3 cases. Case 1 is a single wall block. Case 2 is 2 wall blocks. Case 3 is 3 wall blocks.
                {
                    Random random = new Random();
                    int right_down_or_left_up = random.Next(1, 3);  //This random number assignment chooses whether the wall is on the right or on the left.
                    int wallNumber = random.Next(1, 4);             //This random number assignment chooses how many wall blocks will form.

                    switch (wallNumber)
                    {
                        case 1:

                            int one_wall = random.Next(1, 3);       //This random number assignment chooses one of the options left or right.

                            if (right_down_or_left_up == 1)
                            {
                                if (one_wall == 1)                  //It forms the right wall block.
                                {
                                    for (int a = 0; a < 4; a++)
                                    {
                                        wall[i + a, j] = '#';
                                    }
                                }
                                else
                                {
                                    for (int a = 0; a < 4; a++)     //It forms the left wall block.
                                    {
                                        wall[i, j + a] = '#';
                                    }
                                }
                            }

                            else                                    //If right_down_or_left_up = 2, a wall block will be formed either up or down.
                            {
                                if (one_wall == 1)                  //One of these for is the up wall block and the other is the down wall block.
                                {
                                    for (int a = 0; a < 4; a++)
                                    {
                                        wall[i + 3 - a, j + 3] = '#';
                                    }
                                }
                                else
                                {
                                    for (int a = 0; a < 4; a++)
                                    {
                                        wall[i + 3, j - a + 3] = '#';
                                    }
                                }
                            }
                            break;


                        case 2:

                            int two_wall = random.Next(1, 3);           //There are two possibilities for the formation of 2-wall blocks. One possibility is that it occurs opposite,
                                                                        //the other is that it occurs adjacently for example "L".

                            right_down_or_left_up = random.Next(1, 3);  //It shows where the 2-wall blocks begin to form.

                            switch (two_wall)
                            {
                                case 1:                                 //As I mentioned above, since there are 2 forms of double wall blocks, they are divided into 2 cases in themselves.

                                    //In this case, we print wall blocks that are L-shaped.
                                    if (right_down_or_left_up == 1)
                                    {
                                        for (int a = 0; a < 4; a++)
                                        {
                                            wall[i + a, j] = '#';
                                            wall[i, j + a] = '#';
                                        }
                                    }
                                    else
                                    {
                                        for (int a = 0; a < 4; a++)
                                        {
                                            wall[i - a + 3, j + 3] = '#';
                                            wall[i + 3, j - a + 3] = '#';
                                        }
                                    }
                                    break;


                                case 2:                                 //In this case, we print the opposing wall blocks.
                                    if (right_down_or_left_up == 1)
                                    {
                                        for (int a = 0; a < 4; a++)
                                        {
                                            wall[i + a, j] = '#';
                                            wall[i + a, j + 3] = '#';
                                        }
                                    }
                                    else
                                    {
                                        for (int a = 0; a < 4; a++)
                                        {
                                            wall[i, j + a] = '#';
                                            wall[i + 3, j + a] = '#';
                                        }
                                    }
                                    break;
                            }
                            break;


                        case 3:

                            int three_wall = random.Next(1, 5);         //When there are 3 wall blocks, there are 4 possibilities. The odds are calculated that there is no wall block on one side only.

                            switch (three_wall)
                            {
                                case 1:                               //There's no wall block here, just on the left.    
                                    for (int a = 0; a < 4; a++)
                                    {
                                        wall[i + a, j] = '#';
                                        wall[i + 3, j + a] = '#';
                                        wall[i + 3 - a, j + 3] = '#';

                                    }
                                    break;

                                case 2:                               //There's no wall block here, just on the right.    
                                    for (int a = 0; a < 4; a++)
                                    {
                                        wall[i + a, j] = '#';
                                        wall[i, j + a] = '#';
                                        wall[i + 3 - a, j + 3] = '#';
                                    }
                                    break;

                                case 3:                              //There's no wall block here, just on the up.    
                                    for (int a = 0; a < 4; a++)
                                    {
                                        wall[i, j + a] = '#';
                                        wall[i + 3, j + a] = '#';
                                        wall[i + 3 - a, j + 3] = '#';

                                    }
                                    break;

                                case 4:                              //There's no wall block here, just on the down.                               
                                    for (int a = 0; a < 4; a++)
                                    {
                                        wall[i + a, j] = '#';
                                        wall[i + 3, j + a] = '#';
                                        wall[i, j + a] = '#';
                                    }
                                    break;
                            }
                            break;
                    }
                }
                return wall;                                        //Since this is a function, we call the last return command.
            }
            char[,] wall = randomWall();



            //****************************************************************************************************************************************************************************************************************************


            void printScreen(int time, bool flag, int time_helper)                              //Here we wrote a function to print to the screen.
            {
                if (flag)
                {
                    for (int i = 0; i < wall.GetLength(0); i++)
                    {
                        for (int j = 0; j < wall.GetLength(1); j++)
                        {
                            if (wall[i, j] == '+')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('+');
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (wall[i, j] == '1')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write('1');
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (wall[i, j] == '2')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write('2');
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (wall[i, j] == '3')
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write('3');
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (wall[i, j] == 'P')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write('P');
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (wall[i, j] == 'X')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write('X');
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else if (wall[i, j] == 'Y')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write('Y');
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            else
                                Console.Write(wall[i, j]);
                        }
                        Console.WriteLine();
                    }


                    Console.SetCursorPosition(55, 0);
                    Console.WriteLine($"TIME: {time}" + " ");           //We print the time.            
                    Console.SetCursorPosition(55, 5);
                    Console.WriteLine("energy: " + energy + " ");       //We print the energy.
                    Console.SetCursorPosition(55, 10);
                    Console.WriteLine("score: " + score + " ");         //We print the score.
                    Console.SetCursorPosition(55, 15);
                    Console.WriteLine("mine: " + mine + " ");         //We print the mine.
                    time_helper = time;
                }

                else
                {
                    printFinalScreen(time);
                }



            }

            //****************************************************************************************************************************************************************************************************************************


            Random rnd = new Random();
            void assign_random_123(char number, int how_many)           //In this part of the code, we randomly place 1,2,3 values ​​on the map if there is no wall.
            {
                int number_x_coor = 0, number_y_coor = 0;
                int counter = 1;
                while (counter <= how_many)
                {
                    number_x_coor = rnd.Next(1, 52);
                    number_y_coor = rnd.Next(1, 22);

                    if (wall[number_y_coor, number_x_coor] != '#')      //We check that there are no wall grooves.
                    {
                        wall[number_y_coor, number_x_coor] = number;
                        counter++;
                    }
                }
            }

            //We print 1,2 or 3 as many times as we want it to be. Since there should be 20 at first, we do it accordingly.



            assign_random_123('1', 12);
            assign_random_123('2', 6);
            assign_random_123('3', 2);


            //****************************************************************************************************************************************************************************************************************************


            int xdir = 1;
            int ydir = 1;


            int cursorx = 0, cursory = 0;           // position of cursor

            while (true)                            //We control the walls in P's movement, and this is how we prevent it if there is a wall in its destination.
            {
                cursorx = rnd.Next(1, 52);
                cursory = rnd.Next(1, 22);
                if (wall[cursory, cursorx] != '#')
                    break;
            }
            wall[cursory, cursorx] = 'P';

            ConsoleKeyInfo cki;                     // required for readkey


            //****************************************************************************************************************************************************************************************************************************


            int[,] coor = new int[100, 2];              //In this part, we assign the values ​​that we will use when creating the X enemy.

            for (int i = 0; i < coor.GetLength(0); i++)
            {
                coor[i, 0] = -2;
                coor[i, 1] = -1;
            }
            void assign_random_x()
            {
                int x_cor = 0, y_cor = 0;               //We assign two variables for the enemy's coordinates.
                int counter = 0;

                for (int i = 0; i < coor.Length; i++)
                {
                    if (coor[i, 0] == -2)
                        break;
                    else
                        counter++;
                }

                while (true)
                {
                    x_cor = rnd.Next(1, 52);
                    y_cor = rnd.Next(1, 22);


                    if (wall[y_cor, x_cor] == ' ')      //If the place where it will occur is ' ', we place our enemy in those coordinates.
                    {
                        coor[counter, 0] = y_cor;       //We assign these variables according to the value.
                        coor[counter, 1] = x_cor;
                        break;
                    }
                }

            }

            int counter_time = 0;
            int counter_energy = 0;
            //We create a 2 value for X 

            assign_random_x();
            assign_random_x();


            //****************************************************************************************************************************************************************************************************************************



            int[,] coordinates = new int[100, 2];             //What I did in the codes above, I am now implementing for the Y enemy.
            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                for (int j = 0; j < coordinates.GetLength(1); j++)
                {
                    coordinates[i, j] = -2;
                }
            }

            void assign_random_y()
            {
                int x_cor = 0, y_cor = 0;               //We assign two variables for the enemy's coordinates.
                int counter = 0;

                for (int i = 0; i < coordinates.Length; i++)
                {
                    if (coordinates[i, 0] == -2)
                        break;
                    else
                        counter++;
                }
                while (true)
                {
                    x_cor = rnd.Next(1, 52);
                    y_cor = rnd.Next(1, 22);


                    if (wall[y_cor, x_cor] == ' ')      //If the place where it will occur is ' ', we place our enemy in those coordinates.
                    {
                        coordinates[counter, 0] = y_cor;      //We assign these variables according to the value.
                        coordinates[counter, 1] = x_cor;
                        break;
                    }
                }

            }

            //We create a 2 value for Y 
            assign_random_y();
            assign_random_y();

            //****************************************************************************************************************************************************************************************************************************

            int time_helper = 0;

            coor = generate_x(coor);
            coordinates = generate_y();


            int elapsedTime = 0;


            //This is where our code provides the actual movement. We achieved this with a while loop.

            int timer = 0;
            int timer2 = 0;
            int timer3 = -1;

            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;

            bool flag5 = true;

            int energy_speed = 1;


            // game
            while (flag5)
            {
                elapsedTime++;

                if (elapsedTime % 10 == 0 && elapsedTime != 0 && timer != elapsedTime)
                {
                    timer = elapsedTime;

                    int random = rnd.Next(1, 101);

                    if (random <= 60)
                    {
                        assign_random_123('1', 1);
                    }

                    if (random > 60 && random <= 90)
                    {
                        assign_random_123('2', 1);
                    }

                    if (random <= 100 && random > 90)
                    {
                        assign_random_123('3', 1);
                    }
                }


                if (elapsedTime % 150 == 0 && elapsedTime != 0 && timer2 != elapsedTime)
                {
                    timer2 = elapsedTime;

                    int random2 = rnd.Next(1, 3);

                    if (random2 == 1)
                    {
                        assign_random_x();
                    }

                    else if (random2 == 2)
                    {
                        assign_random_y();
                    }
                }

                Console.SetCursorPosition(0, 0);
                if (!flag5 && counter_time == 0)
                {
                    counter_time++;
                    time_helper = elapsedTime;
                }
                printScreen(elapsedTime, flag5, time_helper);                                   //We print the time.


                if (Console.KeyAvailable)                                   //In this part, we make the code shared in sakaide suitable by making the necessary arrangements.
                {

                    cki = Console.ReadKey(true);
                    if (energy_speed == 1)
                    {
                        if (cki.Key == ConsoleKey.RightArrow && wall[cursory, cursorx + 1] != '#')      //Inside the if parts, we ensure that P's movement is in line with the walls.
                        {
                            flag1 = true;
                            flag4 = false;
                            flag2 = false;
                            flag3 = false;

                            if (wall[cursory, cursorx] != '+')                                          //We make sure that P player doesn't care if there is a bomb in it destination.
                                wall[cursory, cursorx] = ' ';


                            if (wall[cursory, cursorx + 1] == '1')
                            {
                                score = score + 10;
                            }

                            else if (wall[cursory, cursorx + 1] == '2')
                            {
                                score = score + 30;
                                energy = energy + 50;
                            }

                            else if (wall[cursory, cursorx + 1] == '3')
                            {
                                score = score + 90;
                                energy = energy + 200;
                                mine = mine + 1;
                            }

                            cursorx++;                                                                  //We increase or decrease our variable according to where it will go.
                            if (wall[cursory, cursorx] == '+')
                            {
                                flag5 = false;

                                break;
                            }

                            wall[cursory, cursorx] = 'P';


                            if (energy > 0)                                                             //If our energy is greater than 0, we reduce it by one in each movement.
                            {
                                energy--;

                            }
                        }



                        //******We proceeded using the same logic in the other movement parts, so I will not add comments to those parts.******

                        else if (cki.Key == ConsoleKey.LeftArrow && wall[cursory, cursorx - 1] != '#')
                        {
                            flag2 = true;
                            flag1 = false;
                            flag4 = false;
                            flag3 = false;

                            if (wall[cursory, cursorx] != '+')
                                wall[cursory, cursorx] = ' ';

                            if (wall[cursory, cursorx - 1] == '1')
                            {
                                score = score + 10;
                            }

                            else if (wall[cursory, cursorx - 1] == '2')
                            {
                                score = score + 30;
                                energy = energy + 50;
                            }

                            else if (wall[cursory, cursorx - 1] == '3')
                            {
                                score = score + 90;
                                energy = energy + 200;
                                mine = mine + 1;
                            }

                            cursorx--;
                            if (wall[cursory, cursorx] == '+')
                            {
                                flag5 = false;

                                break;
                            }
                            wall[cursory, cursorx] = 'P';


                            if (energy > 0)
                            {
                                energy--;

                            }
                        }


                        else if (cki.Key == ConsoleKey.UpArrow && wall[cursory - 1, cursorx] != '#')
                        {
                            flag3 = true;
                            flag1 = false;
                            flag2 = false;
                            flag4 = false;

                            if (wall[cursory, cursorx] != '+')
                                wall[cursory, cursorx] = ' ';


                            if (wall[cursory - 1, cursorx] == '1')
                            {
                                score = score + 10;
                            }

                            else if (wall[cursory - 1, cursorx] == '2')
                            {
                                score = score + 30;
                                energy = energy + 50;
                            }

                            else if (wall[cursory - 1, cursorx] == '3')
                            {
                                score = score + 90;
                                energy = energy + 200;
                                mine = mine + 1;
                            }

                            cursory--;
                            if (wall[cursory, cursorx] == '+')
                            {
                                flag5 = false;

                                break;
                            }
                            wall[cursory, cursorx] = 'P';


                            if (energy > 0)
                            {
                                energy--;

                            }
                        }


                        else if (cki.Key == ConsoleKey.DownArrow && wall[cursory + 1, cursorx] != '#')
                        {
                            flag4 = true;
                            flag1 = false;
                            flag2 = false;
                            flag3 = false;

                            if (wall[cursory, cursorx] != '+')
                                wall[cursory, cursorx] = ' ';

                            if (wall[cursory + 1, cursorx] == '1')
                            {
                                score = score + 10;
                            }

                            else if (wall[cursory + 1, cursorx] == '2')
                            {
                                score = score + 30;
                                energy = energy + 50;
                            }

                            else if (wall[cursory + 1, cursorx] == '3')
                            {
                                score = score + 90;
                                energy = energy + 200;
                                mine = mine + 1;
                            }

                            cursory++;
                            if (wall[cursory, cursorx] == '+')
                            {
                                flag5 = false;

                                break;
                            }
                            wall[cursory, cursorx] = 'P';


                            if (energy > 0)
                            {
                                energy--;

                            }
                        }


                        else if (cki.Key == ConsoleKey.Escape)
                            break;


                        else if (cki.Key == ConsoleKey.Spacebar && mine > 0)    //If the player presses the spacebar, we place bombs on those coordinates.
                        {
                            if (flag1 == true && wall[cursory, cursorx - 1] != '#')
                            {
                                mine--;
                                wall[cursory, cursorx - 1] = '+';
                            }

                            else if (flag2 == true && wall[cursory, cursorx + 1] != '#')
                            {
                                mine--;
                                wall[cursory, cursorx + 1] = '+';
                            }

                            else if (flag3 == true && wall[cursory + 1, cursorx] != '#')
                            {
                                mine--;
                                wall[cursory + 1, cursorx] = '+';
                            }

                            else if (flag4 == true && wall[cursory - 1, cursorx] != '#')
                            {
                                mine--;
                                wall[cursory - 1, cursorx] = '+';
                            }
                        }
                    }
                }

                if (energy == 0 && counter_energy % 2 == 0)
                {
                    counter_energy++;
                    energy_speed = 2;

                }
                else
                {
                    energy_speed = 1;
                }



                if (elapsedTime % 1 == 0 && timer != elapsedTime)
                {
                    timer3 = elapsedTime;
                    coor = generate_x(coor);
                    coordinates = generate_y();

                    int a = rnd.Next(1, 3);
                    if (a == 1)
                        deleteWalls();
                    else
                        addWalls();
                }


                if (energy == 100)          //We used a method like this to print energy properly.
                {
                    Console.WriteLine();
                }

                Thread.Sleep(200);
            }

            printScreen(elapsedTime, flag5, time_helper);                                   //We print the time.


            //****************************************************************************************************************************************************************************************************************************

            int[,] generate_x(int[,] coor)                          //Here we tried to make the movement of X and Y, but we did not use it.
            {
                int[,] coordinates = coor;

                //We assign variables to use when creating.
                int one_x = 0, one_y = 0;
                int coor_x, coor_y;

                for (int i = 0; i < coordinates.GetLength(0); i++)
                {

                    if (coordinates[i, 0] != -1 && coordinates[i, 0] != -2)
                    {
                        coor_x = coordinates[i, 1];
                        coor_y = coordinates[i, 0];


                        if (cursorx > coor_x)
                        {
                            if (wall[coor_y, coor_x + 1] != '#' && wall[coor_y, coor_x + 1] != 'X' && wall[coor_y, coor_x + 1] != 'Y')
                                one_x = +1;
                        }
                        else if (cursorx < coor_x)
                        {
                            if (wall[coor_y, coor_x - 1] != '#' && wall[coor_y, coor_x - 1] != 'X' && wall[coor_y, coor_x - 1] != 'Y')
                                one_x = -1;
                        }
                        else
                        {
                            one_x = 0;
                        }
                        if (one_x == 0)
                        {



                            if (coor_y > cursory)
                            {
                                if (wall[coor_y - 1, coor_x] != '#' && wall[coor_y - 1, coor_x] != 'X' && wall[coor_y - 1, coor_x] != 'Y')
                                {
                                    one_y = -1;
                                }
                            }
                            else if (coor_y < cursory)
                            {
                                if (wall[coor_y + 1, coor_x] != '#' && wall[coor_y + 1, coor_x] != 'X' && wall[coor_y + 1, coor_x] != 'Y')
                                {
                                    one_y = 1;
                                }
                            }
                            else
                            {
                                one_y = 0;
                            }
                        }
                        wall[coor_y, coor_x] = ' ';
                        coor_x += one_x;
                        coor_y += one_y;

                        if (wall[coor_y, coor_x] == '+')
                        {
                            coordinates[i, 0] = -1;
                            coordinates[i, 1] = -1;
                            wall[coor_y, coor_x] = ' ';
                            score += 300;

                        }
                        else if (wall[coor_y, coor_x] == 'P')
                        {

                            flag5 = false;

                            break;
                        }
                        else
                        {
                            coordinates[i, 1] = coor_x;
                            coordinates[i, 0] = coor_y;
                            wall[coor_y, coor_x] = 'X';

                        }
                        one_x = 0;
                        one_y = 0;
                    }
                    else
                        if (coordinates[i, 0] == -2)
                        break;
                }
                return coordinates;                         //Since this is a function, we return it at the end.
            }



            //****************************************************************************************************************************************************************************************************************************



            void deleteWalls()
            {

                int random_col = rnd.Next(1, 11) - 1;
                int x_of_square = (5 * random_col) + 2;
                int random_row = rnd.Next(1, 5) - 1;
                int y_of_square = 2 + (random_row * 5);

                int random_corner;
                int h_or_v; // 1 is horizontal, 2 is vertical



                int hashtag_counter = 0;
                for (int i = y_of_square; i < y_of_square + 4; i++)
                {
                    for (int j = x_of_square; j < x_of_square + 4; j++)
                    {
                        if (wall[i, j] == '#')
                        {

                            hashtag_counter++;

                        }
                    }
                }

                if (hashtag_counter == 8 || hashtag_counter == 7)
                {
                    random_corner = rnd.Next(1, 5);
                    h_or_v = rnd.Next(1, 3);//2 horizontal - 1 vertical
                    switch (random_corner)
                    {

                        case 1:
                            if ((wall[y_of_square, x_of_square + 1] == ' ' && wall[y_of_square + 1, x_of_square] == '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square + 1, x_of_square] = ' ';
                                wall[y_of_square + 2, x_of_square] = ' ';
                                wall[y_of_square + 3, x_of_square] = ' ';

                                break;
                            }
                            else if ((wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square + 1, x_of_square] != '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square, x_of_square + 1] = ' ';
                                wall[y_of_square, x_of_square + 2] = ' ';
                                wall[y_of_square, x_of_square + 3] = ' ';

                                break;
                            }
                            else
                            {
                                if (h_or_v == 1)
                                {
                                    if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] != '#')
                                    {

                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square] = ' ';

                                    }
                                    else if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] == '#')
                                    {

                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';
                                        wall[y_of_square + 3, x_of_square] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] != '#')
                                        {
                                            wall[y_of_square + 1, x_of_square + 3] = ' ';
                                            wall[y_of_square + 2, x_of_square + 3] = ' ';
                                            wall[y_of_square, x_of_square + 3] = ' ';
                                        }
                                        else if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] == '#')
                                        {
                                            wall[y_of_square + 1, x_of_square + 3] = ' ';
                                            wall[y_of_square + 2, x_of_square + 3] = ' ';
                                            wall[y_of_square + 3, x_of_square + 3] = ' ';
                                        }
                                    }
                                }
                                else if (h_or_v == 2)
                                {
                                    if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';
                                    }
                                    else if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';
                                        wall[y_of_square, x_of_square + 3] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] != '#')
                                        {
                                            wall[y_of_square + 3, x_of_square + 1] = ' ';
                                            wall[y_of_square + 3, x_of_square + 3] = ' ';
                                            wall[y_of_square + 3, x_of_square + 2] = ' ';
                                        }
                                        else if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] != '#')
                                        {
                                            wall[y_of_square + 3, x_of_square] = ' ';
                                            wall[y_of_square + 3, x_of_square + 1] = ' ';
                                            wall[y_of_square + 3, x_of_square + 2] = ' ';
                                        }
                                    }
                                }

                            }
                            break;
                        case 2:

                            if ((wall[y_of_square, x_of_square + 1] == ' ' && wall[y_of_square + 1, x_of_square] == '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square + 1, x_of_square] = ' ';
                                wall[y_of_square + 2, x_of_square] = ' ';
                                wall[y_of_square + 3, x_of_square] = ' ';

                                break;
                            }
                            else if ((wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square + 1, x_of_square] != '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square, x_of_square + 1] = ' ';
                                wall[y_of_square, x_of_square + 2] = ' ';
                                wall[y_of_square, x_of_square + 3] = ' ';

                                break;
                            }
                            else
                            {
                                x_of_square += 3;
                                if (h_or_v == 1)
                                {
                                    if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] != '#')
                                    {

                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square] = ' ';
                                    }
                                    else if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] == '#')
                                    {
                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';
                                        wall[y_of_square + 3, x_of_square] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] != '#')
                                        {
                                            x_of_square -= 3;
                                            wall[y_of_square + 1, x_of_square] = ' ';
                                            wall[y_of_square + 2, x_of_square] = ' ';
                                            wall[y_of_square, x_of_square] = ' ';
                                        }
                                        else if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] == '#')
                                        {
                                            x_of_square -= 3;
                                            wall[y_of_square + 1, x_of_square] = ' ';
                                            wall[y_of_square + 2, x_of_square] = ' ';
                                            wall[y_of_square + 3, x_of_square] = ' ';
                                        }
                                    }
                                }
                                else if (h_or_v == 2)
                                {
                                    if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';
                                    }
                                    else if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';
                                        wall[y_of_square, x_of_square - 3] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] != '#')
                                        {
                                            y_of_square += 3;
                                            wall[y_of_square, x_of_square - 1] = ' ';
                                            wall[y_of_square, x_of_square - 3] = ' ';
                                            wall[y_of_square, x_of_square - 2] = ' ';
                                        }
                                        else if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] != '#')
                                        {
                                            y_of_square += 3;
                                            wall[y_of_square, x_of_square] = ' ';
                                            wall[y_of_square, x_of_square - 1] = ' ';
                                            wall[y_of_square, x_of_square - 2] = ' ';
                                        }
                                    }
                                }

                            }
                            break;

                        case 3:

                            if ((wall[y_of_square, x_of_square + 1] == ' ' && wall[y_of_square + 1, x_of_square] == '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square + 1, x_of_square] = ' ';
                                wall[y_of_square + 2, x_of_square] = ' ';
                                wall[y_of_square + 3, x_of_square] = ' ';

                                break;
                            }
                            else if ((wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square + 1, x_of_square] != '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square, x_of_square + 1] = ' ';
                                wall[y_of_square, x_of_square + 2] = ' ';
                                wall[y_of_square, x_of_square + 3] = ' ';

                                break;
                            }
                            else
                            {
                                y_of_square += 3;

                                if (h_or_v == 1)
                                {
                                    if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] != '#')
                                    {

                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square] = ' ';
                                    }
                                    else if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] == '#')
                                    {
                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';
                                        wall[y_of_square - 3, x_of_square] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] != '#')
                                        {
                                            x_of_square += 3;
                                            wall[y_of_square - 1, x_of_square] = ' ';
                                            wall[y_of_square - 2, x_of_square] = ' ';
                                            wall[y_of_square, x_of_square] = ' ';
                                        }
                                        else if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] == '#')
                                        {
                                            x_of_square += 3;
                                            wall[y_of_square - 1, x_of_square] = ' ';
                                            wall[y_of_square - 2, x_of_square] = ' ';
                                            wall[y_of_square - 3, x_of_square] = ' ';
                                        }
                                    }
                                }
                                else if (h_or_v == 2)
                                {
                                    if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';
                                    }
                                    else if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';
                                        wall[y_of_square, x_of_square + 3] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] != '#')
                                        {
                                            y_of_square -= 3;
                                            wall[y_of_square, x_of_square + 1] = ' ';
                                            wall[y_of_square, x_of_square + 3] = ' ';
                                            wall[y_of_square, x_of_square + 2] = ' ';
                                        }
                                        else if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] != '#')
                                        {
                                            y_of_square -= 3;
                                            wall[y_of_square, x_of_square] = ' ';
                                            wall[y_of_square, x_of_square + 1] = ' ';
                                            wall[y_of_square, x_of_square + 2] = ' ';
                                        }
                                    }
                                }

                            }
                            break;

                        case 4:

                            if ((wall[y_of_square, x_of_square + 1] == ' ' && wall[y_of_square + 1, x_of_square] == '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square + 1, x_of_square] = ' ';
                                wall[y_of_square + 2, x_of_square] = ' ';
                                wall[y_of_square + 3, x_of_square] = ' ';

                                break;
                            }
                            else if ((wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square + 1, x_of_square] != '#'))
                            {
                                wall[y_of_square, x_of_square] = ' ';
                                wall[y_of_square, x_of_square + 1] = ' ';
                                wall[y_of_square, x_of_square + 2] = ' ';
                                wall[y_of_square, x_of_square + 3] = ' ';

                                break;
                            }
                            else
                            {
                                x_of_square += 3;
                                y_of_square += 3;
                                if (h_or_v == 1)
                                {
                                    if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] != '#')
                                    {

                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square] = ' ';
                                    }
                                    else if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] == '#')
                                    {
                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';
                                        wall[y_of_square - 3, x_of_square] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] != '#')
                                        {
                                            x_of_square -= 3;
                                            wall[y_of_square - 1, x_of_square] = ' ';
                                            wall[y_of_square - 2, x_of_square] = ' ';
                                            wall[y_of_square, x_of_square] = ' ';
                                        }
                                        else if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] == '#')
                                        {
                                            x_of_square -= 3;
                                            wall[y_of_square - 1, x_of_square] = ' ';
                                            wall[y_of_square - 2, x_of_square] = ' ';
                                            wall[y_of_square - 3, x_of_square] = ' ';
                                        }
                                    }
                                }
                                else if (h_or_v == 2)
                                {
                                    if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square] = ' ';
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';
                                    }
                                    else if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] == '#')
                                    {
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';
                                        wall[y_of_square, x_of_square - 3] = ' ';
                                    }
                                    else
                                    {
                                        if (wall[y_of_square - 1, x_of_square] == '#' && wall[y_of_square, x_of_square - 1] != '#')
                                        {
                                            y_of_square -= 3;
                                            wall[y_of_square, x_of_square - 1] = ' ';
                                            wall[y_of_square, x_of_square - 3] = ' ';
                                            wall[y_of_square, x_of_square - 2] = ' ';
                                        }
                                        else if (wall[y_of_square - 1, x_of_square] != '#' && wall[y_of_square, x_of_square - 1] != '#')
                                        {
                                            y_of_square -= 3;
                                            wall[y_of_square, x_of_square] = ' ';
                                            wall[y_of_square, x_of_square - 1] = ' ';
                                            wall[y_of_square, x_of_square - 2] = ' ';
                                        }
                                    }
                                }

                            }
                            break;

                    }


                }
                else if (hashtag_counter == 10)
                {
                    random_corner = rnd.Next(1, 5);
                    h_or_v = rnd.Next(1, 3);//1-vertical , 2-horizontal
                    switch (random_corner)
                    {
                        case 1:
                            if (h_or_v == 1)
                            {
                                if (wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square + 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square + 1, x_of_square + 3] != '#')
                                    {
                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';
                                        wall[y_of_square + 3, x_of_square] = ' ';
                                    }
                                }
                                else if (wall[y_of_square, x_of_square + 1] != '#')
                                {
                                    wall[y_of_square + 1, x_of_square] = ' ';
                                    wall[y_of_square + 2, x_of_square] = ' ';
                                    wall[y_of_square, x_of_square] = ' ';
                                }
                                else
                                {
                                    x_of_square += 3;
                                    wall[y_of_square + 1, x_of_square] = ' ';
                                    wall[y_of_square + 2, x_of_square] = ' ';
                                }
                            }
                            else
                            {
                                if (wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square + 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square + 1, x_of_square + 3] != '#')
                                    {
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';
                                        wall[y_of_square, x_of_square + 3] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';

                                    }
                                }
                                else if (wall[y_of_square, x_of_square + 1] != '#')
                                {
                                    y_of_square += 3;
                                    wall[y_of_square, x_of_square + 1] = ' ';
                                    wall[y_of_square, x_of_square + 2] = ' ';

                                }
                                else
                                {
                                    wall[y_of_square, x_of_square] = ' ';
                                    wall[y_of_square, x_of_square + 1] = ' ';
                                    wall[y_of_square, x_of_square + 2] = ' ';
                                }
                            }

                            break;

                        case 2:
                            x_of_square += 3;
                            if (h_or_v == 1)
                            {

                                if (wall[y_of_square, x_of_square - 1] == '#' && wall[y_of_square + 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square + 1, x_of_square - 3] != '#')
                                    {
                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square + 1, x_of_square] = ' ';
                                        wall[y_of_square + 2, x_of_square] = ' ';
                                        wall[y_of_square + 3, x_of_square] = ' ';
                                    }
                                }
                                else if (wall[y_of_square, x_of_square - 1] != '#' && wall[y_of_square + 1, x_of_square] == '#')
                                {
                                    wall[y_of_square + 1, x_of_square] = ' ';
                                    wall[y_of_square + 2, x_of_square] = ' ';
                                    wall[y_of_square, x_of_square] = ' ';
                                }
                                else
                                {
                                    x_of_square -= 3;
                                    wall[y_of_square + 1, x_of_square] = ' ';
                                    wall[y_of_square + 2, x_of_square] = ' ';
                                }
                            }
                            else
                            {
                                if (wall[y_of_square, x_of_square - 1] == '#' && wall[y_of_square + 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square + 1, x_of_square - 3] != '#')
                                    {
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';
                                        wall[y_of_square, x_of_square - 3] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';

                                    }
                                }
                                else if (wall[y_of_square, x_of_square - 1] != '#' && wall[y_of_square + 1, x_of_square] == '#')
                                {
                                    y_of_square += 3;
                                    wall[y_of_square, x_of_square - 1] = ' ';
                                    wall[y_of_square, x_of_square - 2] = ' ';

                                }
                                else
                                {
                                    wall[y_of_square, x_of_square - 1] = ' ';
                                    wall[y_of_square, x_of_square - 2] = ' ';
                                    wall[y_of_square, x_of_square] = ' ';

                                }
                            }

                            break;

                        case 3:
                            y_of_square += 3;
                            if (h_or_v == 1)
                            {
                                if (wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square - 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square - 1, x_of_square + 3] != '#')
                                    {
                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';
                                        wall[y_of_square - 3, x_of_square] = ' ';
                                    }
                                }
                                else if (wall[y_of_square, x_of_square + 1] != '#')
                                {
                                    wall[y_of_square - 1, x_of_square] = ' ';
                                    wall[y_of_square - 2, x_of_square] = ' ';
                                    wall[y_of_square, x_of_square] = ' ';
                                }
                                else
                                {
                                    x_of_square += 3;
                                    wall[y_of_square - 1, x_of_square] = ' ';
                                    wall[y_of_square - 2, x_of_square] = ' ';
                                }
                            }
                            else
                            {
                                if (wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square - 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square - 1, x_of_square + 3] != '#')
                                    {
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';
                                        wall[y_of_square, x_of_square + 3] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square, x_of_square + 1] = ' ';
                                        wall[y_of_square, x_of_square + 2] = ' ';

                                    }
                                }
                                else if (wall[y_of_square, x_of_square + 1] != '#')
                                {
                                    y_of_square -= 3;
                                    wall[y_of_square, x_of_square + 1] = ' ';
                                    wall[y_of_square, x_of_square + 2] = ' ';

                                }
                                else
                                {
                                    wall[y_of_square, x_of_square + 1] = ' ';
                                    wall[y_of_square, x_of_square + 2] = ' ';
                                    wall[y_of_square, x_of_square] = ' ';

                                }
                            }

                            break;

                        case 4:
                            y_of_square += 3;
                            x_of_square += 3;
                            if (h_or_v == 1)
                            {
                                if (wall[y_of_square, x_of_square - 1] == '#' && wall[y_of_square - 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square - 1, x_of_square - 3] != '#')
                                    {
                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square - 1, x_of_square] = ' ';
                                        wall[y_of_square - 2, x_of_square] = ' ';
                                        wall[y_of_square - 3, x_of_square] = ' ';
                                    }
                                }
                                else if (wall[y_of_square, x_of_square - 1] != '#')
                                {
                                    wall[y_of_square - 1, x_of_square] = ' ';
                                    wall[y_of_square - 2, x_of_square] = ' ';
                                    wall[y_of_square, x_of_square] = ' ';
                                }
                                else
                                {
                                    x_of_square -= 3;
                                    wall[y_of_square - 1, x_of_square] = ' ';
                                    wall[y_of_square - 2, x_of_square] = ' ';
                                }
                            }
                            else
                            {
                                if (wall[y_of_square, x_of_square - 1] == '#' && wall[y_of_square - 1, x_of_square] == '#')
                                {
                                    if (wall[y_of_square - 1, x_of_square - 3] != '#')
                                    {
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';
                                        wall[y_of_square, x_of_square - 3] = ' ';

                                    }
                                    else
                                    {
                                        wall[y_of_square, x_of_square - 1] = ' ';
                                        wall[y_of_square, x_of_square - 2] = ' ';

                                    }
                                }
                                else if (wall[y_of_square, x_of_square - 1] != '#')
                                {
                                    y_of_square -= 3;
                                    wall[y_of_square, x_of_square - 1] = ' ';
                                    wall[y_of_square, x_of_square - 2] = ' ';

                                }
                                else
                                {
                                    wall[y_of_square, x_of_square - 1] = ' ';
                                    wall[y_of_square, x_of_square - 2] = ' ';
                                    wall[y_of_square, x_of_square] = ' ';

                                }
                            }

                            break;



                    }
                }
                else
                    deleteWalls();
            }
            void addWalls()
            {
                int random_col = rnd.Next(1, 11) - 1;
                int x_of_square = (5 * random_col) + 2;
                int random_row = rnd.Next(1, 5) - 1;
                int y_of_square = 2 + (random_row * 5);


                int h_or_v = rnd.Next(1, 3); // 1 is horizontal, 2 is vertical



                int hashtag_counter = 0;
                for (int i = y_of_square; i < y_of_square + 4; i++)
                {
                    for (int j = x_of_square; j < x_of_square + 4; j++)
                    {
                        if (wall[i, j] != '#' && wall[i, j] != ' ')
                        {
                            hashtag_counter = 0;
                            break;
                        }
                        if (wall[i, j] == '#')
                        {

                            hashtag_counter++;

                        }
                    }
                }

                if (hashtag_counter == 4)
                {
                    int a = rnd.Next(1, 3);// 1->up 2->down
                    if (wall[y_of_square + 1, x_of_square] == '#')
                    {
                        if (h_or_v == 1)
                        {
                            wall[y_of_square, x_of_square + 3] = '#';
                            wall[y_of_square + 1, x_of_square + 3] = '#';
                            wall[y_of_square + 2, x_of_square + 3] = '#';
                            wall[y_of_square + 3, x_of_square + 3] = '#';

                        }
                        else
                        {

                            if (a == 1)
                            {
                                wall[y_of_square, x_of_square + 3] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square + 1] = '#';
                            }
                            else
                            {
                                y_of_square += 3;
                                wall[y_of_square, x_of_square + 3] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square + 1] = '#';
                            }
                        }
                    }
                    else if (wall[y_of_square, x_of_square + 1] == '#')
                    {
                        if (h_or_v == 1)//horizontal
                        {
                            y_of_square += 3;
                            wall[y_of_square, x_of_square + 1] = '#';
                            wall[y_of_square, x_of_square + 2] = '#';
                            wall[y_of_square, x_of_square] = '#';
                            wall[y_of_square, x_of_square + 3] = '#';
                        }
                        else
                        {

                            if (a == 1)
                            {

                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square + 3, x_of_square] = '#';
                            }
                            else
                            {
                                x_of_square += 3;
                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square + 3, x_of_square] = '#';
                            }
                        }
                    }

                    else if (wall[y_of_square + 3, x_of_square + 1] == '#')
                    {
                        if (h_or_v == 1)//horizontal
                        {

                            wall[y_of_square, x_of_square + 1] = '#';
                            wall[y_of_square, x_of_square + 2] = '#';
                            wall[y_of_square, x_of_square] = '#';
                            wall[y_of_square, x_of_square + 3] = '#';
                        }
                        else
                        {

                            if (a == 1)
                            {

                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square, x_of_square] = '#';
                            }
                            else
                            {
                                x_of_square += 3;
                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square, x_of_square] = '#';
                            }
                        }
                    }
                    else if (wall[y_of_square + 1, x_of_square + 3] == '#')
                    {
                        if (h_or_v == 1)
                        {

                            wall[y_of_square + 1, x_of_square] = '#';
                            wall[y_of_square + 2, x_of_square] = '#';
                            wall[y_of_square + 3, x_of_square] = '#';
                            wall[y_of_square, x_of_square] = '#';
                        }
                        else
                        {

                            if (a == 1)
                            {

                                wall[y_of_square, x_of_square + 1] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square] = '#';
                            }
                            else
                            {
                                y_of_square += 3;
                                wall[y_of_square, x_of_square + 1] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square] = '#';
                            }
                        }
                    }



                }
                else if (hashtag_counter == 8 || hashtag_counter == 7)
                {
                    int b = rnd.Next(1, 3); // left or right or up or down
                    if (wall[y_of_square, x_of_square + 1] == '#' && wall[y_of_square + 3, x_of_square + 1] == '#')
                    {
                        if (b == 1)
                        {
                            wall[y_of_square + 2, x_of_square] = '#';
                            wall[y_of_square + 1, x_of_square] = '#';

                        }
                        else
                        {
                            x_of_square += 3;
                            wall[y_of_square + 2, x_of_square] = '#';
                            wall[y_of_square + 1, x_of_square] = '#';
                        }

                    }
                    else if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square + 1, x_of_square + 3] == '#')
                    {
                        if (b == 1)
                        {
                            wall[y_of_square, x_of_square + 1] = '#';
                            wall[y_of_square, x_of_square + 2] = '#';

                        }
                        else
                        {
                            y_of_square += 3;
                            wall[y_of_square, x_of_square + 1] = '#';
                            wall[y_of_square, x_of_square + 2] = '#';
                        }
                    }
                    else
                    {
                        if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] == '#')
                        {
                            if (b == 1)
                            {
                                y_of_square += 3;
                                wall[y_of_square, x_of_square + 1] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square + 3] = '#';

                            }
                            else
                            {
                                x_of_square += 3;
                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square + 3, x_of_square] = '#';
                            }
                        }
                        else if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] == '#')
                        {
                            if (b == 1)
                            {
                                y_of_square += 3;
                                wall[y_of_square, x_of_square] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square + 1] = '#';

                            }
                            else
                            {

                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square + 3, x_of_square] = '#';
                            }
                        }
                        else if (wall[y_of_square + 1, x_of_square] == '#' && wall[y_of_square, x_of_square + 1] != '#')
                        {
                            if (b == 1)
                            {

                                wall[y_of_square, x_of_square + 3] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square + 1] = '#';

                            }
                            else
                            {
                                x_of_square += 3;
                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square, x_of_square] = '#';
                            }
                        }
                        else if (wall[y_of_square + 1, x_of_square] != '#' && wall[y_of_square, x_of_square + 1] != '#')
                        {
                            if (b == 1)
                            {

                                wall[y_of_square, x_of_square] = '#';
                                wall[y_of_square, x_of_square + 2] = '#';
                                wall[y_of_square, x_of_square + 1] = '#';

                            }
                            else
                            {

                                wall[y_of_square + 1, x_of_square] = '#';
                                wall[y_of_square + 2, x_of_square] = '#';
                                wall[y_of_square, x_of_square] = '#';
                            }
                        }

                    }
                }
                else
                {
                    addWalls();
                }
            }


            //****************************************************************************************************************************************************************************************************************************


            int[,] generate_y()
            {


                //We assign variables to use when creating.
                int one_x = 0, one_y = 0;
                int coor_x, coor_y;

                for (int i = 0; i < coordinates.GetLength(0); i++)
                {

                    if (coordinates[i, 0] != -1 && coordinates[i, 0] != -2)
                    {
                        coor_x = coordinates[i, 1];
                        coor_y = coordinates[i, 0];

                        if (cursory > coor_y)
                        {
                            if (wall[coor_y + 1, coor_x] != '#' && wall[coor_y + 1, coor_x] != 'X' && wall[coor_y + 1, coor_x] != 'Y')
                                one_y = +1;
                        }
                        else if (cursory < coor_y)
                        {
                            if (wall[coor_y - 1, coor_x] != '#' && wall[coor_y - 1, coor_x] != 'Y' && wall[coor_y - 1, coor_x] != 'X')
                                one_y = -1;
                        }
                        else
                        {
                            one_y = 0;
                        }
                        if (one_y == 0)
                        {



                            if (coor_x > cursorx)
                            {
                                if (wall[coor_y, coor_x - 1] != '#' && wall[coor_y, coor_x - 1] != 'X' && wall[coor_y, coor_x - 1] != 'Y')
                                {
                                    one_x = -1;
                                }
                            }
                            else if (coor_x < cursorx)
                            {
                                if (wall[coor_y, coor_x + 1] != '#' && wall[coor_y, coor_x + 1] != 'X' && wall[coor_y, coor_x + 1] != 'Y')
                                {
                                    one_x = 1;
                                }
                            }
                            else
                            {
                                one_x = 0;
                            }
                        }

                        wall[coor_y, coor_x] = ' ';
                        coor_x += one_x;
                        coor_y += one_y;

                        if (wall[coor_y, coor_x] == '+')
                        {
                            coordinates[i, 0] = -1;
                            coordinates[i, 1] = -1;
                            wall[coor_y, coor_x] = ' ';
                            score += 300;

                        }
                        else if (wall[coor_y, coor_x] == 'P')
                        {

                            flag5 = false;

                            break;
                        }
                        else
                        {
                            coordinates[i, 1] = coor_x;
                            coordinates[i, 0] = coor_y;
                            wall[coor_y, coor_x] = 'Y';

                        }
                        one_x = 0;
                        one_y = 0;
                    }
                    else
                        if (coordinates[i, 0] == -2)
                        break;

                }
                return coordinates;
            }

            void printFinalScreen(int time)
            {

                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < wall.GetLength(0); i++)
                    {
                        for (int j = 0; j < wall.GetLength(1); j++)
                        {
                            Console.Write(wall[i, j]);

                        }
                        Console.WriteLine();
                    }

                    Console.SetCursorPosition(55, 0);
                    Console.WriteLine($"TIME: {time}" + " ");           //We print the time.            
                    Console.SetCursorPosition(55, 5);
                    Console.WriteLine("energy: " + energy + " ");       //We print the energy.
                    Console.SetCursorPosition(55, 10);
                    Console.WriteLine("score: " + score + " ");         //We print the score.
                    Console.SetCursorPosition(55, 15);
                    Console.WriteLine("mine: " + mine + " ");         //We print the mine.

                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write(" ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ \r\n██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗\r\n██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝\r\n██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗\r\n╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║\r\n ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝");
                    Thread.Sleep(1000);
                }


            }

            //****************************************************************************************************************************************************************************************************************************


        }
    }
}

