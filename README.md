# dotnet-all-about

A very simple console application that you'll use in your CLI, in a container, or elsewhere to gather all the information you'd like to know about your Dotnet assembly and the environment in which it is being executed.  

## Features

If command line parameters are specified, they are evaluated to select individual feature blocks for output.  

| Arguments | Description |
| :---      | :---        |
|   `-n`; `--show-network` | available network adapters, type and IPs |
|   `-f`; `--show-filesystem` | available drives/mounts, format and space |
|   `-a`; `--show-app` | info about working folder, process, etc. |
|   `-r`; `--show-runtime` | running on which platform, CPU, arch and OS |
|   `-c`; `--show-console` | info about terminal properties |
|   `-i`; `--show-console-io` | info about terminal input and output |
|   `-e`; `--show-env` | prints all environment variables |
|   `-?`; `-h`; `--help` | guess what ¯\\_(ツ)_/¯ |

 If no command line parameters are specified, all feature blocks are considered for evaluation.  

## Prerequisites

- [Download](https://git-scm.com/downloads) and install a current version of Git
- [Download](https://dotnet.microsoft.com/en-us/download) and Install .NET SDK (at least Version 9.0)
- Clone the project [repository "dotnet-all-about"](https://github.com/roschinsky/dotnet-all-about.git)

If you are working under Windows, you can perform all of the above steps with the following [PowerShell](https://learn.microsoft.com/de-de/powershell/scripting/what-is-a-command-shell?view=powershell-7.5) commands to get started:  

```powershell
winget install Git.Git -e
winget install Microsoft.DotNet.SDK.9 -e
cd ~
git clone https://github.com/roschinsky/dotnet-all-about.git
cd dotnet-all-about
ls
```

## Usage

- Simple run on dotnet CLI: `dotnet run`
- Run on dotnet CLI with parameter: `dotnet run -- -?`
- Execute assembly: `.\dotnet-all-about.exe`
- Execute assembly with parameter: `.\dotnet-all-about.exe -?`
- Run in Docker container: `docker run --rm -ti roschinsky/dotnet-all-about`
