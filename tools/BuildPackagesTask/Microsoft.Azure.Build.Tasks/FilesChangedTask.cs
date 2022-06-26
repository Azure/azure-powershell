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
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Octokit;

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
        /// Gets or set the TargetModule, e.g. Storage
        /// </summary>
        public string TargetModule { get; set; }

        /// <summary>
        /// Gets or set the OutputFile, store FilesChanged.txt in 'artifacts' folder
        /// </summary>
        public string OutputFile { get; set; }

        /// <summary>
        /// Gets or sets the files changed produced by the task.
        /// </summary>
        [Output]
        public string[] FilesChanged { get; set; }

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
            Console.WriteLine("DebugLocalBuildTasks:" + debugEnvironmentVariable);
            bool debug;
            if (!Boolean.TryParse(debugEnvironmentVariable, out debug))
            {
                debug = false;
            }

            if (debug)
            {
                Console.WriteLine("PullRequestNumber:" + PullRequestNumber);
            }

            int ParsedPullRequestNumber;

            // The next statement will convert the string representation of a number to its integer equivalent.
            // If it succeeds it will return 'true'.
            if (int.TryParse(PullRequestNumber, out ParsedPullRequestNumber))
            {
                List<string> filesChanged = new List<string>();
                try
                {
                    //The variable is set in pipeline: "azure-powershell - powershell-core"
                    var token = Environment.GetEnvironmentVariable("NOSCOPEPAT_ADXSDKPS");
                    var client = new GitHubClient(new ProductHeaderValue("Azure"));
                    if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX) && !string.IsNullOrEmpty(token))
                    {
                        client.Credentials = new Credentials(token);
                    }
                    var files = client.PullRequest.Files(RepositoryOwner, RepositoryName, int.Parse(PullRequestNumber))
                                    .ConfigureAwait(false).GetAwaiter().GetResult();
                    if (files == null)
                    {
                        return false;
                    }

                    if (debug)
                    {
                        Console.WriteLine("DEBUG: ---Using these files: ");
                    }

                    foreach (var file in files)
                    {
                        var fileName = file.FileName;
                        if (debug)
                        {
                            Console.WriteLine("DEBUG: " + fileName);
                        }

                        filesChanged.Add(fileName);
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

            SerializeChangedFilesToFile(FilesChanged);

            return true;
        }

        // This method will record the changed files into a text file at `OutputFile` for other task to consum.
        private void SerializeChangedFilesToFile(string[] FilesChanged)
        {
            File.WriteAllLines(OutputFile, FilesChanged);
        }
    }
}
