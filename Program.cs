using System;
using System.Collections.Generic;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int offRow = 0;
            int offCol = 0;
            int bladesCount = 0;
            List<int> m1 = new List<int>();
            List<int> m2 = new List<int>();
            

            for (int r = 0; r < n; r++)
            {

                var input = Console.ReadLine().ToCharArray();
                for (int c = 0; c < input.Length; c++)
                {
                    matrix[r, c] = input[c];

                    if (matrix[r, c] == 'A')
                    {
                        offRow = r;
                        offCol = c;
                    }
                    if (matrix[r, c] == 'M')
                    {
                        if (m1.Count == 0)
                        {
                            m1.Add(r);
                            m1.Add(c);
                        }
                        else
                        {
                            m2.Add(r);
                            m2.Add(c);
                        }
                    }
                }

            }

            while (bladesCount < 65)
            {
                string command = Console.ReadLine();


                if (command == "up" && offRow - 1 >= 0)
                {
                    if (char.IsDigit(matrix[offRow - 1, offCol]))
                    {
                        
                        bladesCount += matrix[offRow - 1, offCol] - 48;
                        matrix[offRow, offCol] = '-';
                        matrix[offRow -= 1 , offCol] = 'A';
                    }
                    else if (matrix[offRow - 1, offCol] == 'M')
                    {
                        if (offRow - 1 == m1[0] && offCol == m1[1])
                        {
                            matrix[offRow, offCol] = '-';
                            matrix[m1[0], m1[1]] = '-';
                            matrix[offRow = m2[0], offCol = m2[1]] = 'A';
                        }
                        else
                        {
                            matrix[offRow, offCol] = '-';
                            matrix[m2[0], m2[1]] = '-';
                            matrix[offRow = m1[0], offCol = m1[1]] = 'A';
                            
                        }
                    }
                    else if (matrix[offRow - 1, offCol] == '-')
                    {
                        matrix[offRow, offCol] = '-';
                        matrix[offRow -= 1, offCol] = 'A';

                    }
                }
                else if (command == "down" && offRow + 1< n)
                {
                    if (char.IsDigit(matrix[offRow + 1, offCol]))
                    {
                        bladesCount += matrix[offRow + 1, offCol] - 48;
                        matrix[offRow, offCol] = '-';
                        matrix[offRow += 1, offCol] = 'A';
                    }
                    else if (matrix[offRow + 1, offCol] == 'M')
                    {
                        if (offRow + 1 == m1[0] && offCol == m1[1])
                        {
                            matrix[offRow, offCol] = '-';
                            matrix[m1[0], m1[1]] = '-';
                            matrix[offRow = m2[0], offCol = m2[1]] = 'A';
                        }
                        else
                        {
                            matrix[offRow, offCol] = '-';
                            matrix[m2[0], m2[1]] = '-';
                            matrix[offRow = m1[0], offCol = m1[1]] = 'A';

                        }
                    }
                    else if (matrix[offRow + 1, offCol] == '-')
                    {

                        matrix[offRow, offCol] = '-';
                        matrix[offRow += 1, offCol] = 'A';

                    }
                }
                else if (command == "left" && offCol - 1 >= 0)
                {
                    if (char.IsDigit(matrix[offRow, offCol - 1]))
                    {
                        bladesCount += matrix[offRow, offCol - 1] - 48;
                        matrix[offRow, offCol] = '-';
                        matrix[offRow, offCol -= 1] = 'A';
                    }
                    else if (matrix[offRow, offCol - 1] == 'M')
                    {
                        if (offRow == m1[0] && offCol - 1 == m1[1])
                        {
                            matrix[offRow , offCol] = '-';
                            matrix[m1[0], m1[1]] = '-';
                            matrix[offRow = m2[0], offCol = m2[1]] = 'A';
                        }
                        else
                        {
                            matrix[offRow, offCol] = '-';
                            matrix[m2[0], m2[1]] = '-';
                            matrix[offRow = m1[0], offCol = m1[1]] = 'A';

                        }
                    }
                    else if (matrix[offRow , offCol - 1] == '-')
                    {
                        matrix[offRow, offCol] = '-';
                        matrix[offRow , offCol -= 1] = 'A';
                    }
                }
                else if (command == "right" &&  offCol + 1 < matrix.GetLength(1))
                {
                    if (char.IsDigit(matrix[offRow, offCol + 1]))
                    {
                        bladesCount += matrix[offRow, offCol + 1] - 48;
                        matrix[offRow, offCol] = '-';
                        matrix[offRow, offCol += 1] = 'A';
                    }
                    else if (matrix[offRow , offCol + 1] == 'M')
                    {
                        if (offRow == m1[0] && offCol + 1 == m1[1])
                        {
                            matrix[offRow , offCol] = '-';
                            matrix[m1[0], m1[1]] = '-';
                            matrix[offRow = m2[0], offCol = m2[1]] = 'A';
                        }
                        else
                        {
                            matrix[offRow , offCol] = '-';
                            matrix[m2[0], m2[1]] = '-';
                            matrix[offRow = m1[0], offCol = m1[1]] = 'A';

                        }
                    }
                    else if (matrix[offRow, offCol + 1] == '-')
                    {
                        matrix[offRow, offCol] = '-';
                        matrix[offRow, offCol += 1] = 'A';
                    }


                }
                else
                {
                    matrix[offRow, offCol] = '-';
                   
                   
                    break;
                }



            }

            if (matrix[offRow, offCol] == '-')
            {
                Console.WriteLine($"I do not need more swords!");
                Console.WriteLine($"The king paid {bladesCount} gold coins.");
            }

           else  if (bladesCount >= 65)
            {
                Console.WriteLine($"Very nice swords, I will come back for more!");
                Console.WriteLine($"The king paid {bladesCount} gold coins.");

            }
           
           
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(matrix[r,c]);
                }
                Console.WriteLine();
            }

        }
    }
}
