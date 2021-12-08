using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Labyrinth_Game
{
    class Labyrinth
    {
        public int[,] matrix;
        public string[] schema;
        public Position start;
        public Position end;
        public bool JumpWall;
        

        public Labyrinth(string[] _schema)
        {
            this.schema = _schema;
            for (int i = 0; i < schema.Length; i++)
            {
                for (int j = 0; j < schema[i].Length; j++)
                {
                    if (schema[i][j] == 's')
                    {
                        start = new Position(i, j);
                    }
                    if (schema[i][j] == 'e')
                    {
                        end = new Position(i, j);
                    }
                }
            }

            matrix = new int[schema.Length, schema[0].Length];
            for (int i = 0; i < schema.Length; i++)
            {
                for (int j = 0; j < schema[i].Length; j++)
                {
                    switch (schema[i][j])
                    {
                        case ' ':
                            matrix[i, j] = 0;
                            break;
                        case '█':
                            matrix[i, j] = 1;
                            break;
                        case 's':
                            matrix[i, j] = 2;
                            break;
                        case 'e':
                            matrix[i, j] = 3;
                            break;
                        case '.':
                            matrix[i, j] = 4;
                            break;
                        case '*':
                            matrix[i, j] = 5;
                            break;
                        case '☻':
                            matrix[i, j] = 6;
                            break;

                    }
                }
            }
        }
        public bool IsAWall(Position pos)
        {
            if (matrix[pos.line , pos.column ] == 1) return true;
            else return false;
        }
        public bool IsASpike(Position pos)
        {
            if (matrix[pos.line, pos.column] == 5)
            {
                Console.WriteLine("You lost because you walk on a spike");
                return true;               
            }
            else return false;
        }
        public bool IsOccupied(Position pos)
        {
            if (matrix[pos.line , pos.column ] == 4) return true;
            else return false;
        }
        public bool Blocked(Position pos)
        {
            bool res = false;
            if (matrix[pos.line+1, pos.column] == 1 || matrix[pos.line + 1, pos.column] ==  4 || matrix[pos.line + 1, pos.column] == 5)
            {
                if (matrix[pos.line-1, pos.column] == 1 || matrix[pos.line-1, pos.column] == 4 || matrix[pos.line-1, pos.column] == 5)
                {
                    if (matrix[pos.line, pos.column+1] == 1 || matrix[pos.line, pos.column+1] == 4 || matrix[pos.line, pos.column+1] == 5)
                    {
                        if (matrix[pos.line, pos.column - 1] == 1 || matrix[pos.line, pos.column - 1] == 4 || matrix[pos.line, pos.column - 1] == 5)
                        {
                            if (JumpWall == false)
                            {
                                res = true;
                                Console.WriteLine("You lost because you are blocked");
                            }
                        }
                    }
                }

            }
            return res;
        }
        public bool IsAJumpBoost(Position pos)
        {
            if (matrix[pos.line, pos.column] == 6)
            {
                JumpWall = true;
                return true;
            }
            else return false;

        }
        public bool MarkPassage(Position pos, Position ActualPos, bool gameOverSpike, bool jumpBoostCase)
        {
            bool result = false;
            if (!IsAWall(pos))
            {
                if (!IsOccupied(pos))
                {
                    result = true;
                    if (gameOverSpike == false)
                    {
                        if(jumpBoostCase == true)
                        {
                            matrix[pos.line, pos.column] = 6;
                        }
                        matrix[pos.line, pos.column] = 4;
                    }
                    else matrix[pos.line, pos.column] = 5;
                }
                else
                {
                    Console.WriteLine("A character cannot move back to a square already occupied");
                    Thread.Sleep(3000);
                    result = false;
                }
            }
            else if (JumpWall == true)
            {
                int lineDirection = ActualPos.line - pos.line;
                int columnDirection = ActualPos.column - pos.column;
                while (IsAWall(pos)==true)
                {
                    pos = new Position(pos.line - lineDirection, pos.column - columnDirection);
                }
                result = true;
                if (gameOverSpike == false) matrix[pos.line, pos.column] = 4;
                else matrix[pos.line, pos.column] = 5;
                JumpWall = false; //only one use :)
            }
            else 
            {
                Console.WriteLine("A character cannot go over a wall without the jump wall ability");
                Thread.Sleep(3000);
                result = false;
            }
            return result;
        }
        public override string ToString()
        {
            string a = null;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                a = a + "\n";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    switch (matrix[i, j])
                    {
                        case 0:
                            a = a + ' ';
                            break;
                        case 1:
                            a = a + '█';
                            break;
                        case 2:
                            a = a + 's';
                            break;
                        case 3:
                            a = a + 'e';
                            break;
                        case 4:
                            a = a + '.';
                            break;
                        case 5:
                            a = a + '*';
                            break;
                        case 6:
                            a = a + '☻';
                            break;

                    }
                }
            }
            return a;


        }

    }
}
