using Yolsh_v4.Client.Components.CLI;

namespace Yolsh_v4.Client.Components.Commands
{
    public class HelpCommand : BaseCommand
    {
        private List<BaseCommand> Commands = new List<BaseCommand>();

        public HelpCommand(string inCommand) : base(inCommand) { }

        public override string Execute(string[] args)
        {
            string FinalOut = "";

            foreach (BaseCommand Com in Commands)
            {
                FinalOut += Com.command + Com.getDescription();
            }
            return FinalOut;
        }

        public override string getDescription()
        {
            return "this command allows the user to see all the commands available to them on the console";
        }

        public void addComToHelpList(BaseCommand NewComm)
        {
            Commands.Add(NewComm);
        }
    }
}
