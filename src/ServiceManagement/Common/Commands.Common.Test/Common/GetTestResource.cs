﻿﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "TestResource", DefaultParameterSetName = ParameterSet1)]
    public class GetTestResource : AzureSMCmdlet
    {
        public ManagementClient client { get; set; }

        /// <summary>
        /// Default parameter set name
        /// </summary>
        private const string ParameterSet1 = "ParameterSet1";

        /// <summary>
        /// Another parameter set name
        /// </summary>
        private const string ParameterSet2 = "ParameterSet2";

        [Alias("N", "Container")]
        [Parameter(Position = 0, HelpMessage = "Container Name",
            ParameterSetName = ParameterSet1)]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Container Prefix",
            ParameterSetName = ParameterSet2, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            client = AzureSession.ClientFactory.CreateClient<ManagementClient>(base.DefaultContext, AzureEnvironment.Endpoint.ServiceManagement);
            WriteObject(client);
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}