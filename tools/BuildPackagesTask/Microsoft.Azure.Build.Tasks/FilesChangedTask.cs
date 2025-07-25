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
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using Octokit;
    using System.Linq;

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
        /// Gets or set the trigger type, either PullRequest, Commit, or TargetModule.
        /// </summary>
        [Required]
        public string TriggerType { get; set; }

        /// <summary>
        /// Gets or set the file changed trigger, could be commit ID when CI triggered or pull request number when PR triggered, target modules when manual triggered or scheduled.
        /// </summary>
        public string Trigger { get; set; }

        /// <summary>
        /// Gets or set the OutputFile, store FilesChanged.txt in 'artifacts' folder
        /// </summary>
        /// 
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
                if (string.Equals("PullRequest", TriggerType))
                {
                    Console.WriteLine("Pull Request Number:" + Trigger);
                }
                else if (string.Equals("Commit", TriggerType))
                {
                    Console.WriteLine("Commit Id:" + Trigger);
                }
                else if (string.Equals("TargetModule", TriggerType))
                {
                    Console.WriteLine("Target Module:" + Trigger);
                }
                else
                {
                    Console.WriteLine("DEBUG: ---Invalid TriggerType");
                }
            }

            try 
            {
                var client = new GitHubClient(new ProductHeaderValue("Azure"))
                {
                    Credentials = new Credentials(Environment.GetEnvironmentVariable("OCTOKITPAT"))
                };
                // The next statement will convert the string representation of a number to its integer equivalent.
                // If it succeeds it will return 'true'.
                switch (TriggerType) 
                {
                    case "PullRequest":
                        try
                        {
                            FilesChanged = client.PullRequest.Files(RepositoryOwner, RepositoryName, Int32.Parse(Trigger))
                                            .ConfigureAwait(false).GetAwaiter().GetResult().Select(x => x.FileName).ToArray<string>();
                        }
                        catch (AuthorizationException e)
                        {
                            Console.WriteLine(e.Message);
                            client = new GitHubClient(new ProductHeaderValue("Azure"));
                            FilesChanged = client.PullRequest.Files(RepositoryOwner, RepositoryName, Int32.Parse(Trigger))
                                            .ConfigureAwait(false).GetAwaiter().GetResult().Select(x => x.FileName).ToArray<string>();
                        }
                        break;
                    case "Commit":
                        try
                        {
                            FilesChanged = client.Repository.Commit.Get(RepositoryOwner, RepositoryName, Trigger)
                                            .ConfigureAwait(false).GetAwaiter().GetResult().Files.Select(x => x.Filename).ToArray<string>();
                        }
                        catch (AuthorizationException e)
                        {
                            Console.WriteLine(e.Message);
                            client = new GitHubClient(new ProductHeaderValue("Azure"));
                            FilesChanged = client.Repository.Commit.Get(RepositoryOwner, RepositoryName, Trigger)
                                            .ConfigureAwait(false).GetAwaiter().GetResult().Files.Select(x => x.Filename).ToArray<string>();
                        }
                        break;
                    case "TargetModule":
                        FilesChanged = Trigger.Split(',');
                        break;
                    default:
                        FilesChanged = new string[] { };
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("---Exception Caught when trying to detect file changes with PS script: " + e.ToString());
                FilesChanged = new string[] { };
                return true;
            }
            
            if (null != FilesChanged && FilesChanged.Length != 0 && debug) {
                Console.WriteLine("DEBUG: ---Using these files: ");
                foreach (string fileName in FilesChanged) 
                {
                    Console.WriteLine("DEBUG: " + fileName);
                }
                Console.WriteLine("Total: " + FilesChanged.Length);
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