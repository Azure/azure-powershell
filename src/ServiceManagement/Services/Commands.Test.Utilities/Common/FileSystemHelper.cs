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

using System;
using System.Diagnostics;
using System.IO;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.ServiceManagemenet.Common;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    /// <summary>
    /// Utility used to create files and directories and clean them up when
    /// complete.
    /// </summary>
    public class FileSystemHelper : IDisposable
    {
        /// <summary>
        /// Gets the path to the rootPath of the file system utilized by the test.
        /// </summary>
        public string RootPath { get; private set; }

        /// <summary>
        /// Gets or sets the path to a temporary Azure SDK which we use to
        /// store and cleanup after global files.
        /// </summary>
        public string AzureSdkPath { get; private set; }

        /// <summary>
        /// Gets a reference to the test class using the FileSystemHelper to
        /// provide access to its logging.
        /// </summary>
        public SMTestBase TestInstance { get; private set; }

        /// <summary>
        /// Monitors changes to the file system.
        /// </summary>
        private FileSystemWatcher _watcher = null;
        
        /// <summary>
        /// Gets or sets a value indicating whether to enable monitoring on
        /// the portion of the file system being managed by FileSystemHelper.
        /// </summary>
        public bool EnableMonitoring
        {
            get { return _watcher != null; }
            set
            {
                if (!value && _watcher != null)
                {
                    // Dispose of the watcher if we're turning it off
                    DisposeWatcher();
                }
                else if (value && _watcher == null)
                {
                    // Create a file system watcher
                    _watcher = new FileSystemWatcher();
                    _watcher.Path = RootPath;
                    _watcher.IncludeSubdirectories = true;
                    _watcher.Changed += (s, e) => Log("<Watcher>  Changed {0}", GetRelativePath(e.FullPath));
                    _watcher.Created += (s, e) => Log("<Watcher>  Created at {0}", GetRelativePath(e.FullPath));
                    _watcher.Deleted += (s, e) => Log("<Watcher>  Deleted at {0}", GetRelativePath(e.FullPath));
                    _watcher.Renamed += (s, e) => Log("<Watcher>  Renamed {0} to {1}", GetRelativePath(e.OldFullPath), GetRelativePath(e.FullPath));
                    _watcher.EnableRaisingEvents = true;
                }

            }
        }

        /// <summary>
        /// Initializes a new FileSystemHelper to a random temp directory.
        /// </summary>
        /// <param name="testInstance">
        /// Reference to the test class (to access its logging).
        /// </param>
        public FileSystemHelper(SMTestBase testInstance)
            : this(testInstance, GetTemporaryDirectoryName())
        {
        }

        /// <summary>
        /// Initialize a new FileSystemHelper to a specific directory.
        /// </summary>
        /// <param name="testInstance">
        /// Reference to the test class (to access its logging).
        /// </param>
        /// <param name="rootPath">The rootPath directory.</param>
        public FileSystemHelper(SMTestBase testInstance, string rootPath)
        {
            Debug.Assert(testInstance != null);
            Debug.Assert(!string.IsNullOrEmpty(rootPath));

            TestInstance = testInstance;

            // Set the directory and create it if necessary.
            RootPath = rootPath;
            if (!FileUtilities.DataStore.DirectoryExists(rootPath))
            {
                Log("Creating directory {0}", rootPath);
                FileUtilities.DataStore.CreateDirectory(rootPath);
            }
        }

        /// <summary>
        /// Destroy the files and directories created during the test.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (RootPath != null)
                {
                    // Cleanup any certificates added during the test
                    if (!string.IsNullOrEmpty(AzureSdkPath))
                    {
                        try { new RemoveAzurePublishSettingsCommand().RemovePublishSettingsProcess(AzureSdkPath); }
                        catch { /* Cleanup failed, ignore*/ }
                        
                        AzureSdkPath = null;
                    }
                    
                    Log("Deleting directory {0}", RootPath);
                    try
                    {
                        FileUtilities.DataStore.DeleteDirectory(RootPath);
                    }
                    catch { }

                    DisposeWatcher();

                    // Note: We can't clear the RootPath until we've disposed the
                    // watcher because its handlers will attempt to get relative
                    // paths which will fail if there is no RootPath
                    RootPath = null;
                }
            }
        }

        /// <summary>
        /// Dispose of the FileSystemWatcher we're using to monitor changes to
        /// the FileSystem.
        /// </summary>
        private void DisposeWatcher()
        {
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
                _watcher = null;
            }
        }

        /// <summary>
        /// Log a message from the FileSytemHelper.
        /// </summary>
        /// <param name="format">Message format.</param>
        /// <param name="args">Message argument.</param>
        private void Log(string format, params object[] args)
        {
            TestInstance.Log("[FileSystemHelper]  " + format, args);
        }

        /// <summary>
        /// Get the path of a file relative to the FileSystemHelper's rootPath.
        /// </summary>
        /// <param name="fullPath">The full path to the file.</param>
        /// <returns>The path relative to the FileSystemHelper's rootPath.</returns>
        public string GetRelativePath(string fullPath)
        {
            Debug.Assert(!string.IsNullOrEmpty(fullPath));
            Debug.Assert(fullPath.StartsWith(RootPath, StringComparison.OrdinalIgnoreCase));
            return fullPath.Substring(RootPath.Length, fullPath.Length - RootPath.Length);
        }

        /// <summary>
        /// Get the full path to a file given a path relative to the
        /// FileSystemHelper's rootPath.
        /// </summary>
        /// <param name="relativePath">Relative path.</param>
        /// <returns>Corresponding full path.</returns>
        public string GetFullPath(string relativePath)
        {
            Debug.Assert(!string.IsNullOrEmpty(relativePath));
            return Path.Combine(RootPath, relativePath);
        }

        /// <summary>
        /// Create a random directory name that doesn't yet exist on disk.
        /// </summary>
        /// <returns>A random, non-existent directory name.</returns>
        public static string GetTemporaryDirectoryName()
        {
            string path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            while (Directory.Exists(path))
            {
                path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            }

            return path;
        }

        /// <summary>
        /// Create a new directory relative to the rootPath.
        /// </summary>
        /// <param name="relativePath">Relative path to the directory.</param>
        /// <returns>The full path to the directory.</returns>
        public string CreateDirectory(string relativePath)
        {
            Debug.Assert(!string.IsNullOrEmpty(relativePath));

            string path = Path.Combine(RootPath, relativePath);
            if (!FileUtilities.DataStore.DirectoryExists(path))
            {
                Log("Creating directory {0}", path);
                FileUtilities.DataStore.CreateDirectory(path);
            }

            return path;
        }

        /// <summary>
        /// Create an empty file relative to the rootPath.
        /// </summary>
        /// <param name="relativePath">Relative path to the file.</param>
        /// <returns>The full path to the file.</returns>
        public string CreateEmptyFile(string relativePath)
        {
            Debug.Assert(!string.IsNullOrEmpty(relativePath));

            string path = Path.Combine(RootPath, relativePath);
            if (!FileUtilities.DataStore.FileExists(path))
            {
                Log("Creating empty file {0}", path);
                FileUtilities.DataStore.WriteFile(path, "");
            }

            return path;
        }

        /// <summary>
        /// Create a temporary Azure SDK directory to simulate global files.
        /// </summary>
        /// <returns>The path to the temporary Azure SDK directory.</returns>
        public string CreateAzureSdkDirectoryAndImportPublishSettings()
        {
            return CreateAzureSdkDirectoryAndImportPublishSettings(Data.ValidPublishSettings[0]);
        }

        /// <summary>
        /// Create a temporary Azure SDK directory to simulate global files.
        /// </summary>
        /// <param name="publishSettingsPath">
        /// Path to the publish settings.
        /// </param>
        /// <returns>The path to the temporary Azure SDK directory.</returns>
        public string CreateAzureSdkDirectoryAndImportPublishSettings(string publishSettingsPath)
        {
            Debug.Assert(!string.IsNullOrEmpty(publishSettingsPath));
            Debug.Assert(File.Exists(publishSettingsPath));
            Debug.Assert(string.IsNullOrEmpty(AzureSdkPath));

            AzureSdkPath = CreateDirectory("AzureSdk");
            ProfileClient client = new ProfileClient(new AzureSMProfile(Path.Combine(AzureSession.ProfileDirectory, AzureSession.ProfileFile)));
            AzureSession.DataStore.WriteFile(publishSettingsPath, File.ReadAllText(publishSettingsPath));
            client.ImportPublishSettings(publishSettingsPath, null);
            client.Profile.Save();

            return AzureSdkPath;
        }

        /// <summary>
        /// Create a new service with a given name and make that the current
        /// directory used by cmdlets.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>Directory created for the service.</returns>
        public string CreateNewService(string serviceName)
        {
            CloudServiceProject newService = new CloudServiceProject(RootPath, serviceName, FileUtilities.GetContentFilePath(@"..\..\..\..\..\Package\Debug\ServiceManagement\Azure\Services"));
            string path = Path.Combine(RootPath, serviceName);
            TestMockSupport.TestExecutionFolder = path;
            return path;
        }

        public void CreateDirectoryWithPrebuiltPackage(string packageName, out string package, out string configuration)
        {
            string serviceName = packageName;
            package = Path.Combine(RootPath, packageName + ".cspkg");
            FileUtilities.DataStore.WriteFile(package, "does not matter");
            configuration = Path.Combine(RootPath, "ServiceConfiguration.Cloud.cscfg");
            string template = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" 
                + Environment.NewLine
                + "<ServiceConfiguration serviceName=\"" + serviceName + "\" " 
                + "xmlns=\"http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration\" " 
                + "osFamily=\"2\" osVersion=\"*\" />";
            FileUtilities.DataStore.WriteFile(configuration, template);
            TestMockSupport.TestExecutionFolder = RootPath;
        }
    }
}
