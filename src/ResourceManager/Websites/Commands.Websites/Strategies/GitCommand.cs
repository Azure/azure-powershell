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

using System.Management.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Azure.Commands.WebApps.Properties;

namespace Microsoft.Azure.Commands.WebApps.Strategies
{
    public class GitCommand : ExternalCommand
    {
        public GitCommand(PathIntrinsics currentPath, string workingDirectory = null) : base(currentPath, "git.exe", workingDirectory)
        {
        }

        public override string InstallationInstructions
        {
            get
            {
                return Microsoft.Azure.Commands.WebApps.Properties.Resources.GitInstallMessage;
            }
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public Task<string> VerifyGitRepository(string path = null)
        {
            var basePath = WorkingDirectory;
            var searchPath = path == null ? basePath : PathInfo.GetUnresolvedProviderPathFromPSPath(path);
            var dirPath = PathInfo.Combine(searchPath, ".git");
            return Task.FromResult(Directory.Exists(dirPath) ? dirPath : null);
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public async Task<string> GetConfigurationValue(string name)
        {
            var output = await Execute($"config --get {name}");
            return output.Split('\n').FirstOrDefault();
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public Task SetConfigurationValue(string name, string value)
        {
             return Execute($"config {name} {value}");
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public Task ClearConfigurationValue(string name)
        {
            return Execute($"config --unset {name}");
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public async Task<IList<string>> GetRemoteRepositories()
        {
            var remotes = await Execute("remote");
            return remotes.Split('\n');
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public Task AddRemoteRepository(string name, string url)
        {
            return Execute($"remote add {name} {url}");
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public Task RemoveRemoteRepository(string name)
        {
            return Execute($"remote rm {name}");
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public Task InitRepository()
        {
            return Execute("init");
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public async Task<IList<string>> GetWorkingTree()
        {
            var tree = await Execute("rev-parse --git-dir");
            return tree.Split('\n');
        }

        public override Task<bool> CheckExistence(string command = null)
        {
            return base.CheckExistence("--version");
        }

    }
}
