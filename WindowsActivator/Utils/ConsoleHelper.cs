using System.Diagnostics;
using System.IO;

public static class ConsoleHelper
{
    /// <summary>
    /// Runs a command and returns its output or error text.
    /// If runAsAdmin is true, the process will elevate but output cannot be captured.
    /// </summary>
    public static async Task<string> RunCommandAsync(string command, bool runAsAdmin = false)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            CreateNoWindow = true
        };

        if (!runAsAdmin)
        {
            // Capture output
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
        }
        else
        {
            // Elevation requires UseShellExecute = true; cannot redirect output
            psi.UseShellExecute = true;
            psi.Verb = "runas";
        }

        using (var process = new Process { StartInfo = psi })
        {
            process.Start();

            if (!runAsAdmin)
            {
                // Read output asynchronously
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                await process.WaitForExitAsync();

                if (!string.IsNullOrWhiteSpace(error))
                    return $"Error:\n{error.Trim()}";

                return string.IsNullOrWhiteSpace(output) ? "No output (may require admin privileges)." : output.Trim();
            }
            else
            {
                // Wait for elevated process to finish
                await process.WaitForExitAsync();
                return $"Command executed with exit code {process.ExitCode}.";
            }
        }
    }


    /// <summary>
    /// Runs a .cmd file asynchronously and captures its output.
    /// </summary>
    /// <param name="cmdFilePath">Full path to the .cmd file</param>
    /// <param name="runAsAdmin">Whether to run the process elevated (UAC prompt)</param>
    /// <returns>Output or error text from the command</returns>
    public static async Task<string> RunCmdFileAsync(string cmdFilePath, bool runAsAdmin = false)
    {
        if (string.IsNullOrWhiteSpace(cmdFilePath))
            throw new ArgumentException("Path to .cmd file is required.", nameof(cmdFilePath));

        if (!File.Exists(cmdFilePath))
            throw new FileNotFoundException("The specified .cmd file does not exist.", cmdFilePath);

        var psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c \"{cmdFilePath}\"",
            CreateNoWindow = true
        };

        if (!runAsAdmin)
        {
            // capture output
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
        }
        else
        {
            // elevation requires UseShellExecute = true; cannot capture output
            psi.UseShellExecute = true;
            psi.Verb = "runas";
        }

        using (var process = new Process { StartInfo = psi })
        {
            process.Start();

            if (!runAsAdmin)
            {
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                await process.WaitForExitAsync();

                if (!string.IsNullOrWhiteSpace(error))
                    return $"Error:\n{error.Trim()}";

                return string.IsNullOrWhiteSpace(output)
                    ? "No output from command."
                    : output.Trim();
            }
            else
            {
                await process.WaitForExitAsync();
                return $"Command executed with exit code {process.ExitCode}.";
            }
        }
    }
}
