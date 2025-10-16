using System;
using System.Collections.Generic;

namespace BackToBasics
{
    class BasicsExamples
    {
        static void Main(string[] args)
        {
            // ----------------------------------------
            // 1. Variables and Data Types
            // ----------------------------------------
            Console.WriteLine("\n=== 1. Variables and Data Types ===");
            Console.WriteLine("-----------------------------------");

            int myInt;              // Declare an integer variable
            myInt = 10;             // Initialize the variable
            float myFloat = 3.14f;  // Declare and initialize a float variable

            Console.WriteLine($"int myInt = {myInt}");
            Console.WriteLine($"float myFloat = {myFloat}");

            int wholeNumber = 42;
            float decimalNumber = 2.718f;
            string message = "Hello, World!";
            bool isActive = true;
            char letter = 'A';
            double preciseNumber = 3.14159265359;

            Console.WriteLine($"wholeNumber: {wholeNumber}, decimalNumber: {decimalNumber}, message: {message}, isActive: {isActive}, letter: {letter}, preciseNumber: {preciseNumber}");

            // ----------------------------------------
            // 2. String Manipulation
            // ----------------------------------------
            Console.WriteLine("\n=== 2. String Manipulation ===");
            Console.WriteLine("-----------------------------------");

            string fullName = "Leo" + " " + "Nabel"; // Concatenation
            int nameLength = fullName.Length;        // Length
            string upperName = fullName.ToUpper( );   // ToUpper
            string[] nameParts = fullName.Split(' ');// Split
            string trimmedName = "  Leo Nabel  ".Trim( ); // Trim

            Console.WriteLine($"Concatenation: {fullName}");
            Console.WriteLine($"Length: {nameLength}");
            Console.WriteLine($"ToUpper: {upperName}");
            Console.WriteLine($"Split: {string.Join(", ", nameParts)}");
            Console.WriteLine($"Trim: {trimmedName}");

            string escapeExample = "Line1\nLine2\tTabbed\\Backslash\"Quote\'SingleQuote";
            Console.WriteLine("Escape Sequences Example:");
            Console.WriteLine(escapeExample);

            int age = 20;
            string greeting = $"Hello, {fullName}!";
            string info = $"Name: {fullName}, Age: {age}";
            Console.WriteLine($"String Interpolation: {greeting}");
            Console.WriteLine($"String Interpolation: {info}");

            // ----------------------------------------
            // 3. Type Conversion and Casting
            // ----------------------------------------
            Console.WriteLine("\n=== 3. Type Conversion and Casting ===");
            Console.WriteLine("-----------------------------------");

            int smallInt = 10;
            float bigFloat = smallInt; // Implicit conversion
            Console.WriteLine($"Implicit conversion: int {smallInt} -> float {bigFloat}");

            float someFloat = 3.14f;
            int someInt = (int)someFloat; // Explicit conversion
            Console.WriteLine($"Explicit conversion: float {someFloat} -> int {someInt}");

            int intVal = 5;
            float floatVal = 2.5f;
            int intResult = (int)( intVal * floatVal );    // Result: 12
            float floatResult = intVal * floatVal;        // Result: 12.5
            Console.WriteLine($"Type conversion during computation: intResult = {intResult}, floatResult = {floatResult}");

            // ----------------------------------------
            // 4. Control Structures
            // ----------------------------------------
            Console.WriteLine("\n=== 4. Control Structures ===");
            Console.WriteLine("-----------------------------------");

            int score = 85;
            Console.WriteLine("If-Else Example:");
            if (score >= 90)
            {
                Console.WriteLine("Grade: A");
            } else if (score >= 80)
            {
                Console.WriteLine("Grade: B");
            } else
            {
                Console.WriteLine("Grade: F");
            }

            char grade = 'B';
            Console.WriteLine("Switch Example:");
            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent!");
                    break;
                case 'B':
                    Console.WriteLine("Well done!");
                    break;
                default:
                    Console.WriteLine("Invalid grade");
                    break;
            }

            // ----------------------------------------
            // 5. Loops
            // ----------------------------------------
            Console.WriteLine("\n=== 5. Loops ===");
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("For Loop:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration: {i}");
            }

            Console.WriteLine("While Loop:");
            int count = 0;
            while (count < 5)
            {
                Console.WriteLine($"Count: {count}");
                count++;
            }

            Console.WriteLine("Do-While Loop:");
            count = 0;
            do
            {
                Console.WriteLine($"Count: {count}");
                count++;
            } while (count < 5);

            Console.WriteLine("Foreach Loop:");
            string[] fruits = { "Apple", "Banana", "Cherry" };
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"Fruit: {fruit}");
            }

            Console.WriteLine("Break Statement Example:");
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    break;
                }
                Console.WriteLine($"Iteration: {i}");
            }

            Console.WriteLine("Continue Statement Example:");
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                Console.WriteLine($"Odd Number: {i}");
            }

            // ----------------------------------------
            // 6. Arrays
            // ----------------------------------------
            Console.WriteLine("\n=== 6. Arrays ===");
            Console.WriteLine("-----------------------------------");

            int[] numbers = new int[5];
            numbers[0] = 10;
            Console.WriteLine($"numbers[0]: {numbers[0]}");

            string[] moreFruits = { "Apple", "Banana", "Cherry" };
            Console.WriteLine($"moreFruits[1]: {moreFruits[1]}");

            Console.WriteLine("For Loop over moreFruits:");
            for (int i = 0; i < moreFruits.Length; i++)
            {
                Console.WriteLine(moreFruits[i]);
            }
            Console.WriteLine("Foreach Loop over moreFruits:");
            foreach (string fruit in moreFruits)
            {
                Console.WriteLine(fruit);
            }

            int[] scores = new int[3];
            scores[0] = 90;
            scores[1] = 85;
            scores[2] = 88;
            Console.WriteLine($"scores[1]: {scores[1]}");
            Console.WriteLine("Foreach Loop over scores:");
            foreach (int scoreVal in scores)
            {
                Console.WriteLine(scoreVal);
            }

            int[,] matrix = new int[2, 3];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            Console.WriteLine($"matrix[1,2]: {matrix[1, 2]}");

            Console.WriteLine("For Loop over matrix:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(matrix[i, j]);
                }
            }
            Console.WriteLine("Foreach Loop over matrix:");
            foreach (int value in matrix)
            {
                Console.WriteLine(value);
            }

            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[3];
            jaggedArray[1] = new int[2];
            jaggedArray[0][0] = 1;
            jaggedArray[0][1] = 2;
            jaggedArray[0][2] = 3;
            jaggedArray[1][0] = 4;
            jaggedArray[1][1] = 5;
            Console.WriteLine($"jaggedArray[1][1]: {jaggedArray[1][1]}");

            Console.WriteLine("For Loop over jaggedArray:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine(jaggedArray[i][j]);
                }
            }
            Console.WriteLine("Foreach Loop over jaggedArray:");
            foreach (int[] row in jaggedArray)
            {
                foreach (int value in row)
                {
                    Console.WriteLine(value);
                }
            }

            // ----------------------------------------
            // 7. Lists and Dictionaries
            // ----------------------------------------
            Console.WriteLine("\n=== 7. Lists and Dictionaries ===");
            Console.WriteLine("-----------------------------------");

            List<string> colors = new List<string>( );
            colors.Add("Red");
            colors.Add("Green");
            colors.Add("Blue");
            Console.WriteLine($"colors[1]: {colors[1]}");

            Console.WriteLine("Foreach Loop over colors:");
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }

            colors.Remove("Green");
            colors.Insert(1, "Yellow");
            int colorCount = colors.Count;
            colors.Clear( );
            colors.Add("Red");
            bool containsRed = colors.Contains("Red");
            colors.Add("Green");
            colors.Add("Blue");
            colors.Sort( );
            colors.Reverse( );
            string[] colorArray = colors.ToArray( );
            int blueIndex = colors.IndexOf("Blue");
            colors.RemoveAt(0);
            colors.AddRange(new string[] { "Purple", "Orange" });
            colors.InsertRange(2, new string[] { "Cyan", "Magenta" });

            Dictionary<string, int> ageDictionary = new Dictionary<string, int>( );
            ageDictionary.Add("Leo", 30);
            ageDictionary.Add("Leor", 25);
            Console.WriteLine($"ageDictionary[\"Leo\"]: {ageDictionary["Leo"]}");

            Console.WriteLine("Foreach Loop over ageDictionary:");
            foreach (KeyValuePair<string, int> entry in ageDictionary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            ageDictionary.Remove("Leor");
            bool hasLeo = ageDictionary.ContainsKey("Leo");
            int dictCount = ageDictionary.Count;
            ageDictionary.Clear( );
            ageDictionary.Add("Leo", 30);
            ageDictionary.Add("Leor", 25);
            var keys = ageDictionary.Keys;
            var values = ageDictionary.Values;

            // ----------------------------------------
            // 8. Functions / Methods
            // ----------------------------------------
            Console.WriteLine("\n=== 8. Functions / Methods ===");
            Console.WriteLine("-----------------------------------");

            Greet( );
            Console.WriteLine($"Add(5, 3): {Add(5, 3)}");
        }

        // Method with no parameters and no return value
        static void Greet( )
        {
            Console.WriteLine("Hello, World!");
        }

        // Method with parameters and a return value
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}

