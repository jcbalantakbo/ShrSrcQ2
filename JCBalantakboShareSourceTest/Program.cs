// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using JCBalantakboShareSourceTest.Enums;


// Question 2.1 Checking if a feature is enabled
string settingInput = "01100000";
UserSettings userSetting = UserSettings.Biometrics;

bool? x = IsEnabled(userSetting, settingInput);
if (x == null)
{
    Console.WriteLine("Invalid setting input");
}
else
{
    Console.WriteLine(userSetting.ToString()+" is "+x.ToString());
}

bool? IsEnabled(UserSettings settingPosition, string settingInput)
{
    //Create regex patter of 0s and 1s where string length equals enum size
    string pattern = $"^[01]{{{Enum.GetNames(typeof(UserSettings)).Length}}}$";
    // Check if valid 8 character boolean
    if (!Regex.IsMatch(settingInput, pattern))
    {
        return null;
    }
    return settingInput[Convert.ToInt32(settingPosition) - 1] == '1';
}


// Question 2.2 Storing user settings
// Write some functions which can read and write the settings to a file in the least
// amount of space.

string inputFileName = "input.txt";
string outputFileName = "output.txt";

string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

string inputFilePath = Path.Combine(documentsPath, inputFileName);
string outputFilePath = Path.Combine(documentsPath, outputFileName);


string[] lines = new string[] {settingInput};

WriteFile(outputFilePath, lines);

string[] readFileLines = ReadFile(inputFilePath);

Console.WriteLine("File read and write operations completed.");
Console.WriteLine($"Output file path: {outputFilePath}");

Console.WriteLine("Input file values:");
foreach (string readFileLine in readFileLines)
{
    Console.WriteLine(readFileLine);
}

string[] ReadFile(string filePath)
{
    try
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            // Read all lines from the file
            string[] lines = sr.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while reading from {filePath}: {ex.Message}");
        return new string[0]; 
    }
}

void WriteFile(string filePath, string[] lines)
{
    try
    {
        // Write to output file
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string line in lines)
            {
                sw.WriteLine(line); // Write each line to the output file
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while writing to {filePath}: {ex.Message}");
    }
}




