using System.Runtime.InteropServices;
using claude_riliaBOT.lib;
using claude_riliaBOT.lib.System;

namespace claude_riliaBOT;

internal static unsafe partial class Program
{
    //System.AccessViolationException: Attempted to read or write protected memoryで起動しない
    /*const string TomlCreateDLL = "TomlCreate";
    private static readonly string FilePath = "./data/setting.cfg";
    [DllImport(TomlCreateDLL, EntryPoint = "toml_control", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void toml_control();*/
    
    private static void Main()
    {
        try
        {
            DirControl.CreateData();
            /*try
            {
                Program.toml_control();
            }
            catch (System.AccessViolationException ex)
            {
                // Log the error, or perform some other action.
                Console.WriteLine("AccessViolationException caught and ignored. " + ex.Message);
            }*/
          
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        AiCore aiCore = new AiCore();
        Console.WriteLine("Hello, I am Claude. I am a bot. I am here to help you. What do you want to say?");
        while (true)
        {
           var input = Console.ReadLine();
           if (input != null) aiCore?.LoadAi(input);
            else
            {
                Console.WriteLine("You said nothing!");
                continue;
            }

            if (input == "exit")
            {
                break;
            }
            continue;
        }
    }
}