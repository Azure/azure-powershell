﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;

    public abstract class DeploymentWhatIfCmdlet: ResourceWithParameterCmdletBase, IDynamicParameters
    {
        protected abstract PSDeploymentWhatIfCmdletParameters WhatIfParameters { get; }

        protected override void OnProcessRecord()
        {
            PSWhatIfOperationResult whatIfResult = this.ExecuteWhatIf();

            this.WriteObject(whatIfResult);
        }

        protected PSWhatIfOperationResult ExecuteWhatIf()
        {
            const string statusMessage = "Getting the latest status of all resources...";
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };

            try
            {
                // Write status message.
                this.WriteInformation(information, tags);

                PSWhatIfOperationResult whatIfResult = ResourceManagerSdkClient.ExecuteDeploymentWhatIf(this.WhatIfParameters);

                // Clear status before returning result.
                this.WriteInformation(clearInformation, tags);

                return whatIfResult;
            }
            catch (Exception)
            {
                // Clear status before on exception.
                this.WriteInformation(clearInformation, tags);
                throw;
            }
        }
    }
}
