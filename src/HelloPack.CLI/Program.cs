﻿using McMaster.Extensions.CommandLineUtils;

class Program
{
    public const int EXCEPTION = 1;
    public const int OK = 0;

    public static async Task<int> Main(string[] args)
    {
        try
        {
            return await CommandLineApplication.ExecuteAsync<Commands>(args);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(ex.ToString());
            Console.ResetColor();
            return EXCEPTION;
        }
    }

    [Command(Name = "hellopack", Description = "Aplicação CLI hellopack", ExtendedHelpText = "Executa rotinas através de linha de comando")]
    [HelpOption]
    public class Commands
    {

        [Option("-t | --time", CommandOptionType.NoValue, Description = "Show Local Time", ShowInHelpText = true)]
        public bool ShowTime { get; set; }

        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            if (ShowTime)
            {
                console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            }

            return OK;
        }

    }
}