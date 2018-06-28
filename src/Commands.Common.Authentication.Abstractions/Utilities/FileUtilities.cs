// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// File utilities using the data store
    /// </summary>
    public static class FileUtilities
    {
        static FileUtilities()
        {
            DataStore = new DiskDataStore();
        }

        /// <summary>
        /// The data store to use in these utilities
        /// </summary>
        public static IDataStore DataStore { get; set; }

        /// <summary>
        /// Get the directory for the executing assembly
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyDirectory()
        {
            var assemblyPath = Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            return Path.GetDirectoryName(assemblyPath);
        }

        /// <summary>
        /// Search for the path of a file starting in the assembly directory
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The path of the given file in the assembly directory</returns>
        public static string GetContentFilePath(string fileName)
        {
            return GetContentFilePath(GetAssemblyDirectory(), fileName);
        }

        /// <summary>
        /// Search for the path of the given file starting in the given directory
        /// </summary>
        /// <param name="startDirectory">The directory to search in</param>
        /// <param name="fileName">The file name</param>
        /// <returns>The path to the file</returns>
        public static string GetContentFilePath(string startDirectory, string fileName)
        {
            string path = Path.Combine(startDirectory, fileName);

            // Try search in the subdirectories in case that the file path does not exist in root path
            if (!DataStore.FileExists(path) && !DataStore.DirectoryExists(path))
            {
                try
                {
                    path = DataStore.GetDirectories(startDirectory, fileName, SearchOption.AllDirectories).FirstOrDefault();

                    if (string.IsNullOrEmpty(path))
                    {
                        path = DataStore.GetFiles(startDirectory, fileName, SearchOption.AllDirectories).First();
                    }
                }
                catch
                {
                    throw new FileNotFoundException(Path.Combine(startDirectory, fileName));
                }
            }

            return path;
        }

        /// <summary>
        /// Get the directory path to the given directory in the paltform-appropriate program files path
        /// </summary>
        /// <param name="directoryName">The name fo the directory</param>
        /// <param name="throwIfNotFound">Whether to throw if the directory is not found</param>
        /// <returns>The full directory path</returns>
        public static string GetWithProgramFilesPath(string directoryName, bool throwIfNotFound)
        {
            string programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (DataStore.DirectoryExists(Path.Combine(programFilesPath, directoryName)))
            {
                return Path.Combine(programFilesPath, directoryName);
            }
            else
            {
                if (programFilesPath.IndexOf(Resources.x86InProgramFiles, StringComparison.InvariantCultureIgnoreCase) == -1)
                {
                    programFilesPath += Resources.x86InProgramFiles;
                    if (throwIfNotFound)
                    {
                        ValidateDirectoryExists(Path.Combine(programFilesPath, directoryName));
                    }
                    return Path.Combine(programFilesPath, directoryName);
                }
                else
                {
                    programFilesPath = programFilesPath.Replace(Resources.x86InProgramFiles, String.Empty);
                    if (throwIfNotFound)
                    {
                        ValidateDirectoryExists(Path.Combine(programFilesPath, directoryName));
                    }
                    return Path.Combine(programFilesPath, directoryName);
                }
            }
        }

        /// <summary>
        /// Copies a directory.
        /// </summary>
        /// <param name="sourceDirName">The source directory name</param>
        /// <param name="destDirName">The destination directory name</param>
        /// <param name="copySubDirs">Should the copy be recursive</param>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dirs = DataStore.GetDirectories(sourceDirName);

            if (!DataStore.DirectoryExists(sourceDirName))
            {
                throw new DirectoryNotFoundException(String.Format(Resources.PathDoesNotExist, sourceDirName));
            }

            DataStore.CreateDirectory(destDirName);

            var files = DataStore.GetFiles(sourceDirName);
            foreach (var file in files)
            {
                string tempPath = Path.Combine(destDirName, Path.GetFileName(file));
                DataStore.CopyFile(file, tempPath);
            }

            if (copySubDirs)
            {
                foreach (var subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, Path.GetDirectoryName(subdir));
                    DirectoryCopy(subdir, temppath, copySubDirs);
                }
            }
        }

        /// <summary>
        /// Ensures that a directory exists beofre attempting to write a file
        /// </summary>
        /// <param name="pathName">The path to the file that will be created</param>
        public static void EnsureDirectoryExists(string pathName)
        {
            ValidateStringIsNullOrEmpty(pathName, "Settings directory");
            string directoryPath = Path.GetDirectoryName(pathName);
            if (!DataStore.DirectoryExists(directoryPath))
            {
                DataStore.CreateDirectory(directoryPath);
            }
        }

        /// <summary>
        /// Create a unique temp directory.
        /// </summary>
        /// <returns>Path to the temp directory.</returns>
        public static string CreateTempDirectory()
        {
            string tempPath;
            do
            {
                tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            }
            while (DataStore.DirectoryExists(tempPath) || DataStore.FileExists(tempPath));

            DataStore.CreateDirectory(tempPath);
            return tempPath;
        }

        /// <summary>
        /// Copy a directory from one path to another.
        /// </summary>
        /// <param name="sourceDirectory">Source directory.</param>
        /// <param name="destinationDirectory">Destination directory.</param>
        public static void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            Debug.Assert(!String.IsNullOrEmpty(sourceDirectory), "sourceDictory cannot be null or empty!");
            Debug.Assert(Directory.Exists(sourceDirectory), "sourceDirectory must exist!");
            Debug.Assert(!String.IsNullOrEmpty(destinationDirectory), "destinationDirectory cannot be null or empty!");
            Debug.Assert(!Directory.Exists(destinationDirectory), "destinationDirectory must not exist!");

            foreach (string file in DataStore.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                string relativePath = file.Substring(
                    sourceDirectory.Length + 1,
                    file.Length - sourceDirectory.Length - 1);
                string destinationPath = Path.Combine(destinationDirectory, relativePath);

                string destinationDir = Path.GetDirectoryName(destinationPath);
                if (!DataStore.DirectoryExists(destinationDir))
                {
                    DataStore.CreateDirectory(destinationDir);
                }

                DataStore.CopyFile(file, destinationPath);
            }
        }

        /// <summary>
        /// Get the encoding of the given file
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns>The encoding of the file, or the defautl encoding if the file does not exist</returns>
        public static Encoding GetFileEncoding(string path)
        {
            Encoding encoding;
            if (DataStore.FileExists(path))
            {
                using (StreamReader r = new StreamReader(DataStore.ReadFileAsStream(path)))
                {
                    encoding = r.CurrentEncoding;
                }
            }
            else
            {
                encoding = Encoding.Default;
            }

            return encoding;
        }

        /// <summary>
        /// Combine the given array of paths
        /// </summary>
        /// <param name="paths">The paths to combine</param>
        /// <returns>The combined paths</returns>
        public static string CombinePath(params string[] paths)
        {
            return Path.Combine(paths);
        }

        /// <summary>
        /// Returns true if path is a valid directory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsValidDirectoryPath(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return false;
            }

            try
            {
                FileAttributes attributes = DataStore.GetFileAttributes(path);

                if ((attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Remove the given directory if it exists, then create the directory
        /// </summary>
        /// <param name="dir">The directory to recreate</param>
        public static void RecreateDirectory(string dir)
        {
            if (DataStore.DirectoryExists(dir))
            {
                DataStore.DeleteDirectory(dir);
            }

            DataStore.CreateDirectory(dir);
        }

        /// <summary>
        /// Gets the root installation path for the given Azure module.
        /// </summary>
        /// <param name="module" >The module name</param>
        /// <returns>The module full path</returns>
        public static string GetPSModulePathForModule(AzureModule module)
        {
            return GetContentFilePath(GetInstallPath(), GetModuleFolderName(module));
        }

        /// <summary>
        /// Gets the root directory for all modules installation.
        /// </summary>
        /// <returns>The install path</returns>
        public static string GetInstallPath()
        {
            string currentPath = GetAssemblyDirectory();
            while (!currentPath.EndsWith(GetModuleFolderName(AzureModule.AzureProfile)) &&
                   !currentPath.EndsWith(GetModuleFolderName(AzureModule.AzureResourceManager)) &&
                   !currentPath.EndsWith(GetModuleFolderName(AzureModule.AzureServiceManagement)))
            {
                currentPath = Directory.GetParent(currentPath).FullName;
            }

            // The assemption is that the install directory looks like that:
            // ServiceManagement
            //  AzureServiceManagement
            //      <Service Commands Folders>
            // ResourceManager
            //  AzureResourceManager
            //      <Service Commands Folders>
            // Profile
            //  AzureSMProfile
            //      <Service Commands Folders>
            return Directory.GetParent(currentPath).FullName;
        }

        /// <summary>
        /// Get the module name for the given modules
        /// </summary>
        /// <param name="module">The module type</param>
        /// <returns>The mdoule name for th emoduel type</returns>
        public static string GetModuleName(AzureModule module)
        {
            switch (module)
            {
                case AzureModule.AzureServiceManagement:
                    return "Azure";

                case AzureModule.AzureResourceManager:
                    return "AzureResourceManager";

                case AzureModule.AzureProfile:
                    return "AzureProfile";

                default:
                    throw new ArgumentOutOfRangeException(module.ToString());
            }
        }

        /// <summary>
        /// Get the name of the folder containign the given module type
        /// </summary>
        /// <param name="module">The module type</param>
        /// <returns>The name fo the contianing folder</returns>
        public static string GetModuleFolderName(AzureModule module)
        {
            return module.ToString().Replace("Azure", "");
        }

        private static void ValidateDirectoryExists(string directory, string exceptionMessage = null)
        {
            string msg = string.Format(Resources.PathDoesNotExist, directory);
            if (!DataStore.DirectoryExists(directory))
            {
                if (!string.IsNullOrEmpty(exceptionMessage))
                {
                    msg = exceptionMessage;
                }

                throw new FileNotFoundException(msg);
            }
        }

        private static void ValidateStringIsNullOrEmpty(string data, string messageData, bool useDefaultMessage = true)
        {
            if (string.IsNullOrEmpty(data))
            {
                if (useDefaultMessage)
                {
                    throw new ArgumentException(string.Format(Resources.InvalidOrEmptyArgumentMessage, messageData));
                }
                else
                {
                    throw new ArgumentException(messageData);
                }
            }
        }
    }
}
