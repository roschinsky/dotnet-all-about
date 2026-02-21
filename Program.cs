
namespace TRoschinsky.DotnetAllAbout.App;

internal class Program
{
    /// <summary>
    /// A simple console application that you can use in your CLI, 
    /// in a container, or elsewhere to get all the information you 
    /// want about your Dotnet assembly and environment.
    /// </summary>
    /// <param name="args">Command line parameters</param>
    private static void Main(string[] args)
    {
        Console.WriteLine("# Dotnet All About");
        Console.WriteLine("More information at https://github.com/roschinsky/dotnet-all-about.  ");
        Console.WriteLine("-------------------------------------------------------------------");

        try
        {
            ShowRuntimeInfo();
            ShowAppInfo(args);
            ShowFileSystemInfo();
            ShowNetworkInfo();
            ShowEnvironmentVars();
            ShowConsoleInfo();
            ShowConsoleIO();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nWhoops... that wasn't expected at all. Please be so kind and reports the issue providing the following error message: {ex.Message}");
        }
    }

    private static void ShowConsoleIO()
    {
        throw new NotImplementedException();
    }

    private static void ShowConsoleInfo()
    {
        throw new NotImplementedException();
    }

    private static void ShowEnvironmentVars()
    {
        throw new NotImplementedException();
    }

    private static void ShowNetworkInfo()
    {
        throw new NotImplementedException();
    }

    private static void ShowFileSystemInfo()
    {
        throw new NotImplementedException();
    }

    private static void ShowAppInfo(string[] args)
    {
        throw new NotImplementedException();
    }

    private static void ShowRuntimeInfo()
    {
        throw new NotImplementedException();
    }
}