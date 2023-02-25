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

        [Option("-n|--now", CommandOptionType.NoValue, Description = "Show Local Time", ShowInHelpText = true)]
        public bool Now { get; set; }

        [Option("-t|--timeonly", CommandOptionType.NoValue, Description = "Show Time", ShowInHelpText = true)]
        public bool TimeOnly { get; set; }

        [Option("-d|--dateonly", CommandOptionType.NoValue, Description = "Show Date", ShowInHelpText = true)]
        public bool DateOnly { get; set; }

        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            if (Now)
            {
                console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            }

            if (TimeOnly)
            {
                console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            }

            if (DateOnly)
            {
                console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
            }

            return OK;
        }

    }
}