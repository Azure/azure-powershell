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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;

namespace Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools
{
    public class CsRun 
    {
        private string _csrunPath;

        private string _standardOutput;

        public string RoleInformation { get; private set; }
        public int DeploymentId { get; private set; }

        public CsRun(string emulatorDirectory)
        {
            _csrunPath = Path.Combine(emulatorDirectory, Resources.CsRunExe);
        }

        // a test seam used for unit testing this class 
        internal ProcessHelper CommandRunner { get; set; }
        /// <summary>
        /// Deploys package on local machine. This method does following:
        /// 1. Starts compute emulator.
        /// 2. Remove all previous deployments in the emulator.
        /// 3. Deploys the package on local machine.
        /// </summary>
        /// <param name="packagePath">Path to package which will be deployed</param>
        /// <param name="configPath">Local configuration path to used with the package</param>
        /// <param name="launch">Switch which opens browser for web roles after deployment</param>
        /// <param name="mode">Emulator mode: Full or Express</param>
        /// <param name="roleInformation">Standard output of deployment</param>
        /// <param name="standardError">Standard error of deployment</param>
        /// <returns>Deployment id associated with the deployment</returns>
        public int StartEmulator(string packagePath, 
                string configPath, 
                bool launch, 
                ComputeEmulatorMode mode)
        {
            RoleInformation = string.Empty;

            // Starts compute emulator.
            StartComputeEmulator(mode);

            // Remove all previous deployments in the emulator.
            RemoveAllDeployments();

            // Deploys the package on local machine.
            string arguments = string.Format(Resources.RunInEmulatorArguments, packagePath, configPath, (launch) ? Resources.CsRunLanuchBrowserArg : string.Empty);
            StartCsRunProcess(mode, arguments);

            DeploymentId = GetDeploymentCount(_standardOutput);
            RoleInformation = GetRoleInfoMessage(_standardOutput);

            return DeploymentId;
        }

        public void StopComputeEmulator()
        {
            StartCsRunProcess(Resources.CsRunStopEmulatorArg);
        }   

        public void RemoveAllDeployments()
        {
            StartCsRunProcess(Resources.CsRunRemoveAllDeploymentsArg);
        }

        private void StartComputeEmulator(ComputeEmulatorMode mode)
        {
            StartCsRunProcess(mode, Resources.CsRunStartComputeEmulatorArg);
        }
      
        private void StartCsRunProcess(string arguments)
        {
            ProcessHelper runner = GetCommandRunner();
            runner.StartAndWaitForProcess(_csrunPath, arguments);
            _standardOutput = runner.StandardOutput;
            string standardError = runner.StandardError;
            // If there's an error from the CsRun tool, we want to display that
            // error message.
            if (!string.IsNullOrEmpty(standardError))
            {
                throw new InvalidOperationException(string.Format(Resources.CsRun_StartCsRunProcess_UnexpectedFailure, standardError));
            }
        }

        private void StartCsRunProcess(ComputeEmulatorMode mode, string arguments)
        {
            if (mode == ComputeEmulatorMode.Full)
            {
                arguments += " " + Resources.CsRunFullEmulatorArg;
            }
            StartCsRunProcess(arguments);
        }

        private ProcessHelper GetCommandRunner()
        {
            if (CommandRunner == null)
            {
                CommandRunner = new ProcessHelper();
            }
            return CommandRunner;
        }

        private int GetDeploymentCount(string text)
        {
            //Parse output, like 'Created: deployment23(55)', and extract the deployment ID of '55'
            Regex deploymentRegex = new Regex(@"deployment\d+\((?<Number>\d+)\)", RegexOptions.Multiline);
            int value = -1;

            Match match = deploymentRegex.Match(text);

            if (match.Success)
            {
                string digits = match.Groups["Number"].Value;
                int.TryParse(digits, out value);
            }

            return value;
        }

        public static string GetRoleInfoMessage(string emulatorOutput)
        {
            var regex = new Regex(@"(?<RoleUrl>(http|tcp)://[\d.]+:\d+/?)");
            var match = regex.Match(emulatorOutput);
            var builder = new StringBuilder();
            while (match.Success)
            {
                builder.AppendLine(string.Format(Resources.EmulatorRoleRunningMessage, match.Groups["RoleUrl"].Value));
                match = match.NextMatch();
            }
            var roleInfo = builder.ToString();
            return roleInfo;
        }
    }
}