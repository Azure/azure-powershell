//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
namespace Microsoft.WindowsAzure.Build.Tasks
{
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System.Management.Automation;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Reflection;
    /// <summary>
    /// Build task to get all of the files changed in a given PR.
    /// </summary>
    public class FilesChangedTask : Task
    {
        /// <summary>
        /// Gets or sets the Repository owner of a GitHub repository.
        /// </summary>
        [Required]
        public string RepositoryOwner { get; set; }

        /// <summary>
        /// Gets or sets the Repository name of a GitHub repository.
        /// </summary>
        [Required]
        public string RepositoryName { get; set; }

        /// <summary>
        /// Gets or set the PullRequestNumber of a GitHub Pull Request.
        /// </summary>
        public string PullRequestNumber { get; set; }

        /// <summary>
        /// Gets or sets the files changed produced by the task.
        /// </summary>
        [Output]
        public string[] FilesChanged { get; set; }

        /// <summary>
        /// File path of PS script to get list of filechanges from a PR.
        /// </summary>
        public static string ScriptFilePath
        {
            get
            {
                string scriptFileName = "GetPullRequestFileChanges.ps1";
                var assemblyLocation = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                var buildTaskDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(assemblyLocation)));
                return Path.Combine(buildTaskDirectory, scriptFileName);
            }
        }

        /// <summary>
        /// Executes the task to generate a list of files changed in a given pull request.
        /// </summary>
        /// <returns> Returns a value indicating wheter the success status of the task. </returns>
        public override bool Execute()
        {
            // validate parameters
            if (RepositoryOwner == null)
            {
                throw new ArgumentNullException("The RepositoryOwner cannot be null.");
            }

            if (RepositoryName == null)
            {
                throw new ArgumentNullException("The RepositoryName cannot be null.");
            }

            var debugEnvironmentVariable = Environment.GetEnvironmentVariable("DebugLocalBuildTasks");
            bool debug;
            if (!Boolean.TryParse(debugEnvironmentVariable, out debug))
            {
                debug = false;
            }

            int ParsedPullRequestNumber;

            // The next statement will convert the string representation of a number to its integer equivalent.
            // If it succeeds it will return 'true'.
            if (int.TryParse(PullRequestNumber, out ParsedPullRequestNumber))
            {
                List<string> filesChanged = new List<string>();
                Collection<PSObject> psOutput = new Collection<PSObject>();
                var GetFilesScript = File.ReadAllText(ScriptFilePath);
                PowerShell powerShell = PowerShell.Create();
                powerShell.AddScript(GetFilesScript);
                if (debug)
                {
                    powerShell.AddScript("$DebugPreference=\"Continue\"");
                }

                powerShell.AddScript($"Get-PullRequestFileChanges " +
                                        $"-RepositoryOwner {RepositoryOwner} " +
                                        $"-RepositoryName {RepositoryName} " +
                                        $"-PullRequestNumber {ParsedPullRequestNumber}");
                powerShell.Streams.Debug.Clear();
                try
                {
                    if (debug)
                    {
                        Console.WriteLine("DEBUG: ---Starting PS script to detect file changes...");
                    }

                    psOutput = powerShell.Invoke();
                    if (debug)
                    {
                        foreach (var debugRecord in powerShell.Streams.Debug)
                        {
                            Console.WriteLine("[PS]DEBUG: " + debugRecord.ToString());
                        }
                    }

                    if (psOutput == null)
                    {
                        return false;
                    }

                    if (debug)
                    {
                        Console.WriteLine("DEBUG: ---Using these files: ");
                    }

                    foreach (var element in psOutput)
                    {
                        var filename = element.ToString();
                        if (debug)
                        {
                            Console.WriteLine("DEBUG: " + filename);
                        }

                        filesChanged.Add(filename);
                    }

                    if (debug)
                    {
                        Console.WriteLine("Total: " + filesChanged.Count);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("---Exception Caught when trying to detect file changes with PS script: " + e.ToString());
                    FilesChanged = new string[] { };
                    return true;
                }

                FilesChanged = filesChanged.ToArray();
            }
            else
            {
                FilesChanged = new string[] { };
            }

            return true;
        }
    }
}
