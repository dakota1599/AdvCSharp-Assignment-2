/*
Dakota Shapiro
CIS 237 MW 3:30-5:45
9/26/19 (Date Last Modified)
 */

using System;

namespace cis237_assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {

        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(maze, xStart, yStart);
            
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: mazeTraversal(int currentX, int currentY)
        /// </summary>
        private void mazeTraversal(char[,] maze, int xStart, int yStart)
        {
            // Implement maze traversal recursive call
            try
            {

                PrintMaze(maze);

                maze[yStart, xStart] = 'X'; //SETS THE PREVIOUS POSITION TO X
                //MOVE UP
                if (maze[yStart - 1, xStart] == '.')
                {
                    
                    mazeTraversal(maze, xStart, yStart - 1); //CHANGES POSITION
                }
                //MOVE RIGHT
                else if (maze[yStart, xStart + 1] == '.')
                {
                    
                    mazeTraversal(maze, xStart + 1, yStart); //CHANGES POSITION
                }
                //MOVE DOWN
                else if (maze[yStart + 1, xStart] == '.')
                {
                    
                    mazeTraversal(maze, xStart, yStart + 1); //CHANGES POSITION
                }
                //MOVE LEFT
                else if (maze[yStart, xStart - 1] == '.')
                {
                    
                    mazeTraversal(maze, xStart - 1, yStart); //CHANGES POSITION
                }
                else
                {
                    BackTrack(maze, xStart, yStart);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("You win.");
                //RUN A METHOD HERE TO PRINT OUT THE MAZE.
                PrintMaze(maze);
            }
        }



        /// <summary>
        /// WHEN THERE ARE NO MORE PERIODS TO MOVE UPON, THIS METHOD IS CALLED TO BACKTRACK AND FOLLOW THE X'S UNTIL PERIODS
        /// ARE FOUND ONCE MORE.
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="xStart"></param>
        /// <param name="yStart"></param>
        private void BackTrack(char[,] maze, int xStart, int yStart) {
            //MOVE UP
            if (maze[yStart - 1, xStart] == 'X')
            {

                maze[yStart, xStart] = '0'; //SETS THE PREVIOUS POSITION TO O
                mazeTraversal(maze, xStart, yStart - 1); //CHANGES POSITION
            }
            //MOVE RIGHT
            else if (maze[yStart, xStart + 1] == 'X')
            {

                maze[yStart, xStart] = '0'; //SETS THE PREVIOUS POSITION TO O
                mazeTraversal(maze, xStart + 1, yStart); //CHANGES POSITION
            }
            //MOVE DOWN
            else if (maze[yStart + 1, xStart] == 'X')
            {

                maze[yStart, xStart] = '0'; //SETS THE PREVIOUS POSITION TO O
                mazeTraversal(maze, xStart, yStart + 1); //CHANGES POSITION
            }
            //MOVE LEFT
            else if (maze[yStart, xStart - 1] == 'X')
            {

                maze[yStart, xStart] = '0'; //SETS THE PREVIOUS POSITION TO O
                mazeTraversal(maze, xStart - 1, yStart); //CHANGES POSITION
            }
        }


        /// <summary>
        /// THIS PRINTS OUT THE FINISHED MAZE WITH ALL IT'S UPDATED MARKS.
        /// </summary>
        /// <param name="maze"></param>
        private void PrintMaze(char[,] maze) {
            for (int y = 0; y < maze.GetLength(0); y++) {
                for (int x = 0; x < maze.GetLength(1); x++) {
                    //GREEN FOR THE SUCCESSFUL PATH
                    if (maze[y, x] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(maze[y, x] + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    //RED FOR ALL FAILED PATHS
                    else if (maze[y, x] == '0') {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(maze[y, x] + " ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(maze[y, x] + " ");
                    }
                }
                Console.Write(Environment.NewLine);
            }

            //YELLOW BORDER FOR ORGANIZATION
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
