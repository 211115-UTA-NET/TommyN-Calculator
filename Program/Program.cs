// See https://aka.ms/new-console-template for more information
public class Program
{
	public static void Main(string[] args)
	{
        // Initiating/resetting variables to keep the code running properly
        string resume = "Y";
        int length;
        string input;
        int total;
        
        do
        {
            Console.WriteLine("Type an expression for the calculator program to read");
            input = Console.ReadLine();
            Console.WriteLine("Length of input string: " + input.Length);

            length = input.Length; // this is to read the input backwards

            total = ReadUserInput(input, length);
            Console.WriteLine(input + " = " + total);
            Console.WriteLine("Do you want to do more calculations? Enter \"Y\" to continue.");
            resume = Console.ReadLine();

        }
        while ( resume == "Y" || resume == "y" );

	} // end of main method


    // This recursive function reads the strings and starts another one if an operator char is found
    static int ReadUserInput(string input, int prevCharPos)
    {
        int sum = 0;
        string num = "";
        bool valid = false;

        // This for-loop reads every char in string from reverse and breaks when an
        // operator is found only to start the same method for the next set of inputs
        // in recursion before calculating the value
        for (int i = prevCharPos-1; i < prevCharPos; i--)
        {
            string currentChar = input[i].ToString();
            Console.WriteLine("Char read: \"" + input[i] + "\"");
            switch (currentChar)
            {
                
                // ADDITION
                case "+":
                num = (input.Substring(i+1,prevCharPos-i-1)).Trim();

                // verifies if the string input can be converted to int
                valid = int.TryParse(num, out sum);
                if(valid)
                {
                    sum = ReadUserInput(input, i) + int.Parse(num);
                    Console.WriteLine("Add: " + num);
                }
                else
                {
                    Console.WriteLine("Something is wrong with this section of input: " + num + "\nReturning 0 to avoid exception.");
                    sum = ReadUserInput(input, i) + 0;
                    Console.WriteLine("Add: " + 0);
                }
                i = prevCharPos + 1; // This will interrupt and end the for-loop
                break;

                // SUBTRACTION
                case "-":
                num = (input.Substring(i+1,prevCharPos-i-1)).Trim();

                // verifies if the string input can be converted to int
                valid = int.TryParse(num, out sum);
                if(valid)
                {
                    sum = ReadUserInput(input, i) - int.Parse(num);
                    Console.WriteLine("Subtract: " + num);
                }
                else
                {
                    Console.WriteLine("Something is wrong with this section of input: " + num + "\nReturning 0 to avoid exception.");
                    sum = ReadUserInput(input, i) - 0;
                    Console.WriteLine("Subtract: " + 0);
                }
                i = prevCharPos + 1; // This will interrupt and end the for-loop
                break;

                // MULTIPLICATION
                case "*":
                num = (input.Substring(i+1,prevCharPos-i-1)).Trim();

                // verifies if the string input can be converted to int
                valid = int.TryParse(num, out sum);
                if(valid)
                {
                    sum = ReadUserInput(input, i) * int.Parse(num);
                    Console.WriteLine("Multiply: " + num);
                }
                else
                {
                    Console.WriteLine("Something is wrong with this section of input: " + num + "\nReturning 1 to avoid exception.");
                    sum = ReadUserInput(input, i) * 1;
                    Console.WriteLine("Multiply: " + 1);
                }
                i = prevCharPos + 1; // This will interrupt and end the for-loop
                break;

                // DIVISION
                case "/":
                num = (input.Substring(i+1,prevCharPos-i-1)).Trim();

                // verifies if the string input can be converted to int
                valid = int.TryParse(num, out sum);
                if(valid)
                {
                    try
                    {
                        sum = ReadUserInput(input, i) / int.Parse(num);
                        Console.WriteLine("Divide: " + num);
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("The divisor is 0. That Results in infinity!!! Avoiding exception by replacing with one. Please fix that.");
                        sum = ReadUserInput(input, i) / 1;
                        Console.WriteLine("Divide: " + 1);
                    }
                }
                else
                {
                    Console.WriteLine("Something is wrong with this section of input: " + num + "\nReturning 1 to avoid exception.");
                    sum = ReadUserInput(input, i) / 1;
                    Console.WriteLine("Divide: " + 1);

                }
                i = prevCharPos + 1; // This will interrupt and end the for-loop
                break;

            }

            // recursion stops here
            if (i == 0)
            {
                num = (input.Substring(i,prevCharPos)).Trim();
                Console.WriteLine("\nBeginning Calculation:");

                // verifies if the string input can be converted to int
                valid = int.TryParse(num, out sum);
                if(valid)
                {
                    sum = int.Parse(num);
                    Console.WriteLine("Initial: " + num);
                }
                else
                {
                    Console.WriteLine("Something is wrong with this section of input: " + num + "\nReturning 0 to avoid exception.");
                    sum = 0;
                }
                i = prevCharPos + 1; // This will interrupt and end the for-loop

            }
        }
        return sum;

    }// end of ReadUserInput function

    //static string CreateStringConstant(string input, int )

}


