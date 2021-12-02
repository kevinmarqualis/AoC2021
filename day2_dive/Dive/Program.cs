using System;
using System.Collections.Generic;
using System.IO;

namespace Dive
{
    class Program
    {
        static void Main()
        {
            List<string[]> list = GetPlannedCourse();
            int multipliedPositions = PuzzleOne(list);
            int finalMultipliedPositions = PuzzleTwo(list);
            Console.WriteLine($"Puzzle One: {multipliedPositions}");
            Console.WriteLine($"Puzzle Two: {finalMultipliedPositions}");
        }

        public static List<string[]> GetPlannedCourse()
        {
            List<string[]> plannedCourse = new List<string[]>();

            StreamReader reader = File.OpenText(@"C:\Dev\Csharp\AoC2021\day2_dive\Dive\planned_course.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] direction = line.Split(' ');
                plannedCourse.Add(direction);
            }

            return plannedCourse;
        }

        public static int PuzzleOne(List<string[]> plannedCourse)
        {
            int depth = 0;
            int horizontalPos = 0;
            
            foreach (string[] direction in plannedCourse)
            {
                switch (direction[0])
                {
                    case "forward": 
                        horizontalPos+= int.Parse(direction[1]); 
                        break;
                    case "down": 
                        depth+= int.Parse(direction[1]); 
                        break;
                    case "up": 
                        depth-= int.Parse(direction[1]); 
                        break;
                    default: Console.WriteLine("The direction is invalid"); 
                        break;
                }
            }

            return depth * horizontalPos;
        }

        public static int PuzzleTwo(List<string[]> plannedCourse)
        {
            int depth = 0;
            int horizontalPos = 0;
            int aim = 0;

            foreach (string[] direction in plannedCourse)
            {
                switch (direction[0])
                {
                    case "forward": 
                        horizontalPos += int.Parse(direction[1]);
                        depth += aim * int.Parse(direction[1]);
                        break;
                    case "down": 
                        aim += int.Parse(direction[1]); 
                        break;
                    case "up": 
                        aim -= int.Parse(direction[1]); 
                        break;
                    default: 
                        Console.WriteLine("The direction is invalid"); 
                        break;
                }
            }

            return depth * horizontalPos;
        }
    }
}
