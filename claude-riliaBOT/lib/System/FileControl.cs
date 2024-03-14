namespace claude_riliaBOT.lib.System;

public class FileControl
{
    public static void CreateConfig()
    {
        if (!File.Exists("./data/setting.cfg"))
        {
            File.Create("./data/setting.cfg");
        }
    }
}