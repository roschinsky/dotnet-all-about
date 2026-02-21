
using System.Collections;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

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
        Console.WriteLine("-------------------------------------------------------------------  ");

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

    private static void ShowNetworkInfo()
    {
        Console.WriteLine("\n## NETWORK INFO");
        try
        {
            NetworkInterface[] adapters  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                if (dnsServers.Count > 0)
                {
                    Console.WriteLine($"- {adapter.NetworkInterfaceType}: {adapter.Name} '{adapter.Description}'");
                    if(adapter.GetIPProperties().UnicastAddresses.Count > 0)
                    {
                        Console.WriteLine($"   - Address: {adapter.GetIPProperties().UnicastAddresses[0].Address}");
                    }
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"^^failed with {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ShowFileSystemInfo()
    {
        Console.WriteLine("\n## FILE SYSTEM INFO");
        try
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            if (drives == null || drives.Length == 0)
            {
                Console.WriteLine("none discovered; maybe no sufficent permissions to enumerate?");
            }
            else
            {
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"- {drive.DriveType} {drive.DriveFormat} {drive.Name} ({drive.VolumeLabel}) is {(drive.IsReady ? "ready" : "notready")}");
                    Console.WriteLine($"   - TotalSize: ........ {drive.TotalSize / 1024 / 1024:#,##0} MByte");
                    Console.WriteLine($"   - AvailableFreeSpace: {drive.AvailableFreeSpace / 1024 / 1024:#,##0} MByte");
                    Console.WriteLine($"   - TotalFreeSpace: ... {drive.TotalFreeSpace / 1024 / 1024:#,##0} MByte");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"^^failed with {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ShowConsoleIO()
    {
        Console.WriteLine("\n## CONSOLE I/O");
        try
        {
            Console.WriteLine($"- IsInputRedirected: {Console.IsInputRedirected}\n" +
                $"- IsOutputRedirected: {Console.IsOutputRedirected}\n" +
                $"- IsErrorRedirected: {Console.IsErrorRedirected}");
            Console.WriteLine($"- InputEncoding: {Console.InputEncoding.EncodingName}\n" +
                $"- OutputEncoding: {Console.OutputEncoding.EncodingName}");
            Console.WriteLine($"- CurrentCulture: {CultureInfo.CurrentCulture}\n" +
                $"- CurrentUICulture: {CultureInfo.CurrentUICulture}\n" +
                $"- InstalledUICulture: {CultureInfo.InstalledUICulture}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"^^failed with {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ShowConsoleInfo()
    {
        Console.WriteLine("\n## CONSOLE PROPERTIES");
        try
        {
            Console.WriteLine($"- BufferHeight: {Console.BufferHeight}\n" +
                $"- BufferWidth: {Console.BufferWidth}\n" +
                $"- CursorLeft: {Console.CursorLeft}\n" +
                $"- CursorSize: {Console.CursorSize}\n" +
                $"- CursorTop: {Console.CursorTop}\n" +
                $"- BackgroundColor: {Console.BackgroundColor}\n" +
                $"- ForegroundColor: {Console.ForegroundColor}\n" +
                $"- LargestWindowHeight: {Console.LargestWindowHeight}\n" +
                $"- LargestWindowWidth: {Console.LargestWindowWidth}\n" +
                $"- WindowHeight: {Console.WindowHeight}\n" +
                $"- WindowWidth: {Console.WindowWidth}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"^^failed with {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ShowEnvironmentVars()
    {
        Console.WriteLine("\n## ENVIRONMENT VARS");
        try
        {
            foreach (var env in Environment.GetEnvironmentVariables().Cast<DictionaryEntry>())
            {
                Console.WriteLine($"- {env.Key}: {env.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"^^failed with {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ShowAppInfo(string[] arguments)
    {
        Console.WriteLine("\n## APPLICATION INFORMATION");
        try
        {
            Console.WriteLine($"- App Domain: {AppDomain.CurrentDomain.BaseDirectory}\n" +
                $"- CurrentDirectory: {Environment.CurrentDirectory}\n" +
                $"- RelativeSearchPath: {AppDomain.CurrentDomain.RelativeSearchPath}\n" +
                $"- DynamicDirectory: {AppDomain.CurrentDomain.DynamicDirectory}\n" +
                $"- CommandLine: {Environment.CommandLine}");
            Console.Write($"- CommandLineArg: ");
            if (arguments == null || arguments.Length == 0)
            {
                Console.Write("none given");
            }
            else
            {
                foreach (var arg in arguments)
                {
                    Console.Write($"{arg}; ");
                }
            }
            Console.WriteLine($"- ProcessId: {Environment.ProcessId}\n" +
                $"- IsPrivilegedProcess: {Environment.IsPrivilegedProcess}\n" +
                $"- CurrentManagedThreadId: {Environment.CurrentManagedThreadId}\n" +
                $"- FriendlyName: {AppDomain.CurrentDomain.FriendlyName}\n" +
                $"- Id: {AppDomain.CurrentDomain.Id}\n" +
                $"- IsFullyTrusted: {AppDomain.CurrentDomain.IsFullyTrusted}\n" +
                $"- MonitoringSurvivedMemorySize: {AppDomain.CurrentDomain.MonitoringSurvivedMemorySize}\n" +
                $"- MonitoringTotalAllocatedMemorySize: {AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize}\n" +
                $"- MonitoringTotalProcessorTime: {AppDomain.CurrentDomain.MonitoringTotalProcessorTime}\n" +
                $"- TargetFrameworkName: {AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName}\n" +
                $"- WorkingSet: {Environment.WorkingSet}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"^^failed with {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static void ShowRuntimeInfo()
    {
        Console.WriteLine("\n## RUNTIME INFORMATION");
        try
        {
            Console.WriteLine($"- OSVersion: {Environment.OSVersion}\n" +
                $"- Runtime ID: {RuntimeInformation.RuntimeIdentifier}\n" +  
                $"- FrameworkDescription: {RuntimeInformation.FrameworkDescription}");
            Console.Write($"- IsOSPlatform: ");
            foreach (OSPlatform platform in new[] { OSPlatform.Windows, OSPlatform.Linux, OSPlatform.OSX, OSPlatform.FreeBSD })
            {
                Console.Write($"{platform}: {RuntimeInformation.IsOSPlatform(platform)}; ");
            }
            Console.WriteLine();
            Console.WriteLine($"- Architecture: {RuntimeInformation.ProcessArchitecture}\n" +
                $"- Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}\n" +
                $"- Is64BitProcess: {Environment.Is64BitProcess}\n" +
                $"- ProcessorCount: {Environment.ProcessorCount}\n" +
                $"- SystemPageSize: {Environment.SystemPageSize}\n" +
                $"- UserDomainName: {Environment.UserDomainName}\n" +
                $"- UserName: {Environment.UserName}\n" +
                $"- HasShutdownStarted: {Environment.HasShutdownStarted}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"^^failed with {ex.GetType().Name}: {ex.Message}");
        }
    }

}