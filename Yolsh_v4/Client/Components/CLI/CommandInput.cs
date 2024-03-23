namespace Yolsh_v4.Client.Components.CLI
{
    public class Input
    {
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; } = DateTime.Now;
    }

    public abstract class BaseCommand
    {
        public struct argument
        {
            public string arg;
            public int group;
        }

        public string command { get; set; }

        public BaseCommand(string inCommand)
        {
            command = inCommand;
        }

        public abstract string Execute(string[] args);

        public abstract string getDescription();
    }
}

