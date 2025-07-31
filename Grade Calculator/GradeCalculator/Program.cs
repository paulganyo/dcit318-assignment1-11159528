using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Grade Converter ===");
        Console.WriteLine("Enter a numerical grade between 0 and 100");
        
        bool validInput = false;
        double grade = 0;
        
        // Input validation loop
        while (!validInput)
        {
            Console.Write("Enter grade: ");
            string input = Console.ReadLine();
            
            if (double.TryParse(input, out grade))
            {
                if (grade >= 0 && grade <= 100)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Error: Grade must be between 0 and 100. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number. Please try again.");
            }
        }
        
        // Determine letter grade
        string letterGrade = GetLetterGrade(grade);
        
        // Display result
        Console.WriteLine($"\nNumerical Grade: {grade}");
        Console.WriteLine($"Letter Grade: {letterGrade}");
        
        // Log the conversion
        LogGradeConversion(grade, letterGrade);
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
    
    static string GetLetterGrade(double grade)
    {
        if (grade >= 90)
            return "A";
        else if (grade >= 80)
            return "B";
        else if (grade >= 70)
            return "C";
        else if (grade >= 60)
            return "D";
        else
            return "F";
    }
    
    static void LogGradeConversion(double numericalGrade, string letterGrade)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string logEntry = $"[{timestamp}] Grade Conversion: {numericalGrade} -> {letterGrade}";
        
        try
        {
            // Log to console
            Console.WriteLine($"\nLog: {logEntry}");
            
            // Optionally log to file
            System.IO.File.AppendAllText("grade_log.txt", logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: Could not write to log file: {ex.Message}");
        }
    }
}