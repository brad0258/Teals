using System;

namespace TicTacToe
{
    class Program
    {

        static char[,] board = new char[3, 3];
        static int gameEnd = 0;
        static int Turn = 0;
        static char Player = 'X';

        static void Main(string[] args)
        {

            
            howToPlay();
            initBoard(board);

            while (gameEnd == 0)
            {

                Turn++;
                DrawBoard(board);

                if ((Turn % 2) == 0)
                    Player = 'O';
                else
                    Player = 'X';

                ProcessTurn(Player);

                gameEnd = VerifyBoard(board);


            }

            DrawBoard(board);
            if (gameEnd == 1)
                Console.WriteLine("player {0} is winner", Player);
            else
                Console.WriteLine("Game was a tie");

            Console.ReadLine();



            void howToPlay()
            {
                Console.WriteLine("How to play Tic-Tac-Toe ");

            }

            void DrawBoard(char[,] x)
            {
                Console.Write(" ");
                for (int i = 0; i < x.GetLength(0); i++)
                {
                    Console.Write("   " + (i + 1));
                }

                Console.Write(" Y ");
                Console.WriteLine();

                for (int i = 0; i < x.GetLength(0); i++)
                {
                    Console.Write((i + 1) + " | ");
                    for (int j = 0; j < x.GetLength(1); j++)

                    {
                        // Console.WriteLine(x.GetLength(1) - 1);
                        // Console.WriteLine(j);
                        Console.Write(x[i, j] + " | ");
                    }
             
                    Console.WriteLine();
                }
                Console.WriteLine("X");
            }

            void ProcessTurn(char player)
            {
                int XCord = 0;
                int YCord = 0;
                bool XValid = false;
                bool YValid = false;

                while (XValid == false || YValid == false)
                {

                    Console.WriteLine("Player {0} turn", player);

                    while (XCord == 0)
                    {
                        Console.WriteLine("Enter X coordinate");
                        XCord = int.Parse(Console.ReadLine());
                        if (XCord < 1 )
                        {
                            Console.WriteLine("X coordinate is to small");
                            XCord = 0;
                        } else if (XCord > board.GetLength(0))
                        {
                            Console.WriteLine("X coordinate is to large");
                            XCord = 0;

                        }
                        else
                        {
                            XValid = true;
                        }
                    }


                    while (YCord == 0)
                    {
                        Console.WriteLine("Enter Y coordinate");
                        YCord = int.Parse(Console.ReadLine());
                        if (YCord < 1 )
                        {
                            Console.WriteLine("Y coordinate to small");
                            YCord = 0;
                        } else if (YCord > board.GetLength(1))
                        {
                            Console.WriteLine("Y coordinate is to large");
                            YCord = 0;
                        }
                        else
                        {
                            YValid = true;
                        }

                    }

                    // make cordinates relative to 0
                    XCord--;
                    YCord--;


                    if (board[XCord, YCord] == ' ')
                    {
                         board[XCord, YCord] = player;

                    }
                    else 
                    {
                        Console.WriteLine("Position is already taken");
                        XCord = 0;
                        YCord = 0;
                        XValid = false;
                        YValid = false;
                    }

                }


            }


            int VerifyBoard(char[,] arry)
            {

                // Verify Horizontal 

                for (int i = 0; i < arry.GetLength(0); i++)
                {

                    int j = 0;
                    do
                    {
                        if ((arry[i, j] == Player) && (arry[i, j + 1] == Player) && (arry[i, j + 2] == Player))
                        {
                            gameEnd = 1;
                            break;
                        } 
                        else
                        {
                            j++;
                        }
                    } while (j <= arry.GetLength(1) - 3);

                    if (gameEnd == 1)
                    {
                        break;
                    }

                }


                // Verify Vertical
                if (gameEnd == 0)
                {
                    for (int j = 0; j < arry.GetLength(1); j++)
                    {

                        int i = 0;
                        do
                        {
                            if ((arry[i, j] == Player) && (arry[i + 1, j] == Player) && (arry[i + 2, j] == Player))
                            {
                                gameEnd = 1;
                                break;
                            }
                            else
                            {
                                i++;
                            }
                        } while (i <= arry.GetLength(1) - 3);

                        if (gameEnd == 1)
                        {
                            break;
                        }
                    }
                }


                // Verify Left Diagonal
                if (gameEnd == 0)
                {
                    int i = 0;
                    do
                    {
                        int j = 0;
                        do
                        {
                            if ((arry[i, j] == Player) && (arry[i + 1, j + 1] == Player) && (arry[i + 2, j + 2] == Player))
                            {
                                gameEnd = 1;
                                break;
                            }
                            else
                            {
                                j++;
                            }
                        } while (j <= arry.GetLength(1) - 3);

                        if (gameEnd == 1)
                        {
                            break;
                        }
                        else
                        {
                            i++;
                        }

                } while (i <= arry.GetLength(0) - 3);

                }

                // Verify Right Diagonal
                if (gameEnd == 0)
                {
                    int i = 0;
                    do
                    {
                        int j = 0;
                        do
                        {
                            if ((arry[i, j + 2] == Player) && (arry[i + 1, j + 1] == Player) && (arry[i + 2, j] == Player))
                            {
                                gameEnd = 1;
                                break;
                            }
                            else
                            {
                                j++;
                            }
                        } while (j <= arry.GetLength(1) - 3);
                        if (gameEnd == 1)
                        {
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    } while (i <= arry.GetLength(0) - 3);

                }

                // Verify Tie
                if (gameEnd == 0)
                {
                    gameEnd = 2;
                    for (int i = 0; i < arry.GetLength(0); i++)
                    {
                        for (int j = 0; j < arry.GetLength(1); j++)

                        {
                            if (arry[i,j] == ' ')
                            {
                                gameEnd = 0;
                                break;

                            }
                        }
                       
                    }
                }



                return gameEnd;
            }

            void initBoard(char[,] arry)
            {
                for (int i = 0; i < arry.GetLength(0); i++)
                {
                    for (int j = 0; j < arry.GetLength(1); j++)

                    {
                        arry[i, j] = ' ';
 
                    }

                }
            }
        }
    }
}
