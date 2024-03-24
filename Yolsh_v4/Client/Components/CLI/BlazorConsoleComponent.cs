using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace Yolsh_v4.Client.Components.CLI
{
    public class BlazorConsoleComponent : ComponentBase
    {
        private List<BaseCommand> Commands { get; set; }
        protected string? Disabled { get; set; } = null;

        protected string Output = string.Empty;
        protected string Placeholder { get; set; } = "Enter a command, type 'help' for avaliable commands.";
        protected Input Command { get; set; } = new Input();
        [Parameter] public string Name { get; set; } = "**Must Set Name**";
        [Parameter] public string Description { get; set; } = "**Must Set Description**";
        [Parameter] public string Description2 { get; set; } = "";

        public bool ShowDate { get; set; } = true;

        public BlazorConsoleComponent()
        {
            Commands = new List<BaseCommand>();
        }

        public void AddCommand(BaseCommand command)
        {
            Commands.Add(command);
        }

        protected void Execute(EditContext context)
        {
            if (context.Model != null)
            {
                Input? input = context.Model as Input;
                if (input != null)
                {
                    if (input.Text.ToLower() == "clear" || input.Text.ToLower() == "clr")
                    {
                        Output = string.Empty;
                    }
                    else
                    {
                        //making the output look nice
                        string[] splitup = input.Text.Split(' ');
                        Disabled = "disabled";
                        Output += "<p>";
                        Output += "<span>$|</span><span class=\"user-red\">Yolsh~</span><span>> </span>" + "<span class=\"command\">" + input.Text + "</span>";

                        //add the response to the command to the final output
                        Output += " " + "<span>" + ExecuteCommand(splitup) + "</span>"; //need to check if the command is run if so call the server to execute (later build! | just prototyping)
                        Output += "</p>";
                        Disabled = null;
                        Placeholder = "Enter a command, type 'help' for avaliable commands.";
                        Command.Text = "";
                    }
                }
            }
        }

        private string ExecuteCommand(string[] splits)
        {
            if (splits[0] == "")
            {
                return "";
            }
            for (int i = 0; i < Commands.Count(); i++)
            {
                if (Commands[i].command.ToLower() == splits[0].ToLower())
                {
                    try
                    {
                        return Commands[i].Execute(splits);
                    }
                    catch (InvalidDataException e)
                    {
                        return e.Message;
                    }
                }
            }
            return "That is Not a Valid Command";
        }

        public string Version()
        {
            return Assembly.GetExecutingAssembly().GetName().Version!.ToString();
        }
    }
}

