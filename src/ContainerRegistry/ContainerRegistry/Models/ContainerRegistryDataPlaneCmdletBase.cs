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

using System.Text.RegularExpressions;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class ContainerRegistryDataPlaneCmdletBase : ContainerRegistryCmdletBase
    {
        protected const string ListParameterSet = "ListParameterSet";
        protected const string GetParameterSet = "GetParameterSet";
        protected const string ByManifestParameterSet = "ByManifestParameterSet";
        protected const string ByTagParameterSet = "ByTagParameterSet";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Azure Container Registry Name."),]
        [ValidateNotNullOrEmpty]
        public string RegistryName { get; set; }

        protected override void InitDebuggingFilter()
        {
            AddDebuggingFilter(new Regex("(\\s*access_token\\s*=\\s*)[^\"]+"));
            AddDebuggingFilter(new Regex("(\\s*refresh_token\\s*=\\s*)[^\"]+"));
            AddDebuggingFilter(new Regex("(\\s*\"refresh_token\"\\s*:\\s*)\"[^\"]+\""));
            base.InitDebuggingFilter();
        }

        public override void ExecuteCmdlet()
        {
            this.RegistryDataPlaneClient.SetEndPoint(this.RegistryName);
            ExecuteChildCmdlet();
        }

        public virtual void ExecuteChildCmdlet()
        {
            throw new NotImplementedException();
        }
    }
}
