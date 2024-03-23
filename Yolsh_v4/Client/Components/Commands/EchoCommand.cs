using System.Runtime.ConstrainedExecution;
using Yolsh_v4.Client.Components.CLI;

namespace Yolsh_v4.Client.Components.Commands
{
    public class EchoCommand : BaseCommand
    {
        public EchoCommand(string inCommand) : base(inCommand) { }

        public override string Execute(string[] args)
        {
            string FinalString = "";
            for (int i = 1; i < args.Length; i++)
            {
                FinalString += args[i];
            }

            return FinalString;
        }

        public override string getDescription()
        {
            return "Prints out whatever value it was given back to the user";
        }
    }
}
