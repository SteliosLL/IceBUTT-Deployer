using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

public static class waitWindowToClose
{
    /// <summary>
    /// Waits until the given Process exits.
    /// </summary>
    public static void WaitForProcessToExit(Process process, int timeoutSeconds = 1000)
    {
        int waited = 0;
        while (waited < timeoutSeconds * 10)
        {
            try
            {
                if (process.HasExited)
                    break;
            }
            catch
            {
                break; // Inaccessible process
            }

            Thread.Sleep(100);
            waited++;
        }
    }

    /// <summary>
    /// Waits until all processes with the given name exit.
    /// </summary>
    public static void WaitForProcessNameToExit(string processName, int timeoutSeconds = 1000)
    {
        int waited = 0;
        while (waited < timeoutSeconds * 10)
        {
            var stillRunning = Process.GetProcessesByName(processName).Any();
            if (!stillRunning)
                break;

            Thread.Sleep(100);
            waited++;
        }
    }

    /// <summary>
    /// Waits until all windows containing the title keyword are closed.
    /// </summary>
    public static void WaitForWindowTitleToClose(string windowTitleKeyword, int timeoutSeconds = 1000)
    {
        int waited = 0;
        while (waited < timeoutSeconds * 10)
        {
            var stillOpen = Process.GetProcesses().Any(p =>
            {
                try
                {
                    return p.MainWindowTitle.IndexOf(windowTitleKeyword, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                catch
                {
                    return false;
                }
            });

            if (!stillOpen)
                break;

            Thread.Sleep(100);
            waited++;
        }
    }
}
