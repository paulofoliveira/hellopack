using McMaster.Extensions.CommandLineUtils;

class Program
{
    public const int EXCEPTION = 1;
    public const int OK = 0;

    public static async Task<int> Main(string[] args)
    {
        try
        {
            return await CommandLineApplication.ExecuteAsync<HelloPackCommands>(args);
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
    public class HelloPackCommands
    {

        [Option("-t | --time", CommandOptionType.NoValue, Description = "Show Local Time", ShowInHelpText = true)]
        public bool ShowTime { get; set; }

        [Option("-do | --dateonly", CommandOptionType.NoValue, Description = "Show Date Only", ShowInHelpText = true)]
        public bool DateOnly { get; set; }
        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            if (ShowTime)
            {
                console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }

            return OK;
        }

    }
}