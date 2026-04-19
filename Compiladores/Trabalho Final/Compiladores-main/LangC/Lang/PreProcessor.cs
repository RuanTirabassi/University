using System.Text.RegularExpressions;

public class PreProcessor
{
    private readonly Dictionary<string, string> _defines = new();

    public string Process(string code)
    {
        var lines = code.Split('\n');
        var processedCode = new List<string>();

        foreach (var line in lines)
        {
            if (line.StartsWith("#include"))
            {
                processedCode.Add(ProcessInclude(line));
            }
            else if (line.StartsWith("#define"))
            {
                ProcessDefine(line);
            }
            else
            {
                processedCode.Add(ExpandDefines(line));
            }
        }

        return string.Join("\n", processedCode);
    }

    private string ProcessInclude(string line)
    {
        var match = Regex.Match(line, @"#include\s+<(.+)>");
        if (match.Success)
        {
            var value = match.Groups[1].Value;
            if (value == "stdio.h")
            {
                return "#include <stdio.h>";
            }
            var librariesDir = Path.Combine(Directory.GetCurrentDirectory(), "libs");
            var libraryName = value + ".txt";

            var libraryPath = Path.Combine(librariesDir, libraryName);

            if (File.Exists(libraryPath))
            {
                return File.ReadAllText(libraryPath);
            }
        }

        throw new InvalidOperationException("Invalid #include directive.");
    }
 
    private void ProcessDefine(string line)
    {
        var match = Regex.Match(line, @"#define\s+(\w+)\s+(.+)");
        if (match.Success)
        {
            var name = match.Groups[1].Value;
            var value = match.Groups[2].Value;
            _defines[name] = value;
        }
        else
        {
            throw new InvalidOperationException("Invalid #define directive.");
        }
    }

    private string ExpandDefines(string line)
    {
        foreach (var define in _defines)
        {
            string delimiter = define.Key;
            string[] parts = line.Split([delimiter], 2, StringSplitOptions.None);

            if (parts.Length == 2)
            {
                string part1 = parts[0];
                string part2 = parts[1];
                var value = define.Value.Trim();
                return part1 + value + part2;
            }
        }
        return line;
    }
}
