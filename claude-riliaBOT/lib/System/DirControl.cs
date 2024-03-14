namespace claude_riliaBOT.lib.System;

public class DirControl
{
    public static void CreateData()
    {
        if (!Directory.Exists("data"))
        {
            Directory.CreateDirectory("data");
        }
    }
}