using System;

public class Class1
{
    static void Main()
    {
        string root = @"C:\Users\iray\Documents\28897 - 28904 - Gandalf RC#0.5-20230725T080653Z-001\28897 - 28904 - Gandalf RC#0.5";
        string[] direc = Directory.GetDirectories(root);
        foreach (string dir in direc)
        {
            Console.WriteLine(dir);
        }
    }
}
