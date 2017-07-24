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
    using Microsoft.Azure.Build.Tasks.Properties;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// A simple Microsoft Build task used to generate a list of test assemblies to be
    /// used for testing Azure PowerShell.
    /// </summary>
    public class SmartTestingTask : Task
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
        ///  Gets or sets the path to the files-to-test-assemblies map.
        /// </summary>
        [Required]
        public string MapFilePath { get; set; }
        /// <summary>
        /// Gets or sets the test assemblies output produced by the task.
        /// </summary>
        [Output]
        public string[] TestAssemblies { get; set; }
        /// <summary>
        /// Executes the task to generate a list of test assemblies 
        /// based on file changes from a specified Pull Request.
        /// The output it produces is said list.
        /// </summary>
        /// <returns> Returns a value indicating wheter the success status of the task. </returns>
        public override bool Execute()
        {
           int ParsedPullRequestNumber;
           // validate parameters
           if (RepositoryOwner == null)
            {
                throw new ArgumentNullException("The RepositoryOwner cannot be null.");
            }

           if (RepositoryName == null)
            {
                throw new ArgumentNullException("The RepositoryName cannot be null.");
            }
           
           if (MapFilePath == null)
            {
                throw new ArgumentNullException("The MapFilePath cannot be null.");
            }

           // The next statement will convert the string representation of a number to its integer equivalent.
           // If it succeeds it will return 'true'. 
           if (int.TryParse(PullRequestNumber, out ParsedPullRequestNumber))
            {
                // Call the PowerShell.Create() method to create an 
                // empty pipeline.
                PowerShell powerShell = PowerShell.Create();
                powerShell.AddScript(Resources.GetFilesScript);
                powerShell.AddScript($"Get-PullRequestFileChanges -RepositoryOwner {RepositoryOwner} " +
                                             $"-RepositoryName {RepositoryName} -PullRequestNumber {ParsedPullRequestNumber}");
                // invoke execution on the pipeline (collecting output)
                Collection<PSObject> psOutput = powerShell.Invoke();
                List<string> filesChanged = new List<string>();

                if (psOutput == null)
                {
                    return false;
                }

                foreach (var element in psOutput)
                {
                    filesChanged.Add(element.ToString());
                }

                TestAssemblies = new List<string>(TestSetGenerator.GetTests(filesChanged, MapFilePath)).ToArray();
            }
            else
            {                
                TestAssemblies = new List<string>(TestSetGenerator.GetTests(MapFilePath)).ToArray();
            }         

            return true;
        }
    }
}
