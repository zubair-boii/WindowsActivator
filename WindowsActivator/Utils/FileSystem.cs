using System.IO;
using System.Windows;
using Inkore = iNKORE.UI.WPF.Modern.Controls;

namespace WindowsActivator.Utils
{
    public static class FileSystem
    {
        /// <summary>
        /// Copy a file into a destination directory. The destination filename will be the same as the source filename.
        /// </summary>
        /// <param name="sourceFilePath">Full path to the source file.</param>
        /// <param name="destinationDirectory">Directory to copy the file into (will be created if missing).</param>
        /// <param name="overwrite">Whether to overwrite if the file already exists in destination.</param>
        /// <param name="showMessageBox">Whether to show success/error messages using Inkore.MessageBox.</param>
        /// <returns>True if copy succeeded; false otherwise.</returns>
        public static bool CopyFileToDirectory(string sourceFilePath, string destinationDirectory, bool overwrite = true, bool showMessageBox = true)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceFilePath))
                    throw new ArgumentException("Source file path is null or empty.", nameof(sourceFilePath));

                if (string.IsNullOrWhiteSpace(destinationDirectory))
                    throw new ArgumentException("Destination directory is null or empty.", nameof(destinationDirectory));

                if (!File.Exists(sourceFilePath))
                    throw new FileNotFoundException("Source file not found.", sourceFilePath);

                // Ensure destination directory exists
                if (!Directory.Exists(destinationDirectory))
                    Directory.CreateDirectory(destinationDirectory);

                // Destination file path (use source file name)
                string fileName = Path.GetFileName(sourceFilePath);
                string destinationFilePath = Path.Combine(destinationDirectory, fileName);

                // Copy file
                File.Copy(sourceFilePath, destinationFilePath, overwrite);

                if (showMessageBox)
                    Inkore.MessageBox.Show($"File copied successfully to:\n{destinationFilePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
            catch (Exception ex)
            {
                if (showMessageBox)
                    Inkore.MessageBox.Show($"Error copying file:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Copy a file to an exact destination file path.
        /// </summary>
        public static bool CopyFile(string sourceFilePath, string destinationFilePath, bool overwrite = true, bool showMessageBox = true)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceFilePath))
                    throw new ArgumentException("Source file path is null or empty.", nameof(sourceFilePath));

                if (string.IsNullOrWhiteSpace(destinationFilePath))
                    throw new ArgumentException("Destination file path is null or empty.", nameof(destinationFilePath));

                if (!File.Exists(sourceFilePath))
                    throw new FileNotFoundException("Source file not found.", sourceFilePath);

                string? destDir = Path.GetDirectoryName(destinationFilePath);
                if (string.IsNullOrEmpty(destDir))
                    throw new DirectoryNotFoundException("Invalid destination path.");

                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);

                File.Copy(sourceFilePath, destinationFilePath, overwrite);

                if (showMessageBox)
                    Inkore.MessageBox.Show($"File copied successfully to:\n{destinationFilePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                return true;
            }
            catch (Exception ex)
            {
                if (showMessageBox)
                    Inkore.MessageBox.Show($"Error copying file:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Returns the path to the GenuineTicket folder (ProgramData\Microsoft\Windows\ClipSVC\GenuineTicket).
        /// </summary>
        public static string GetGenuineTicketFolder()
        {
            string commonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            return Path.Combine(commonAppData, "Microsoft", "Windows", "ClipSVC", "GenuineTicket");
        }

        /// <summary>
        /// Returns the full path inside GenuineTicket for a filename (e.g. "Education.xml").
        /// </summary>
        public static string GetGenuineTicketPath(string fileName)
        {
            return Path.Combine(GetGenuineTicketFolder(), fileName);
        }
    }
}
