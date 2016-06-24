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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Management.PowerBIEmbedded.Models;
using Microsoft.Azure.Commands.Management.PowerBIEmbedded.Properties;
using Microsoft.Azure.Management.PowerBIEmbedded;
using Microsoft.Azure.Management.PowerBIEmbedded.Models;

namespace Microsoft.Azure.Commands.Management.PowerBIEmbedded.WorkspaceCollection
{
    [Cmdlet(VerbsCommon.Reset, Nouns.WorkspaceCollectionAccessKeys, SupportsShouldProcess = true), OutputType(typeof(PSWorkspaceCollectionAccessKey))]
    public class ResetWorkspaceCollectionAccessKeys : WorkspaceCollectionBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Workspace Collection Name.")]
        [Alias("Name", "ResourceName")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceCollectionName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Reset Access Key1.")]
        public SwitchParameter Key1 { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Reset Access Key2.")]
        public SwitchParameter Key2 { get; set; }

        public override void ExecuteCmdlet()
        {
            var keys = new List<string>();
            if (Key1)
            {
                keys.Add("Key1");
            }

            if (Key2)
            {
                keys.Add("Key2");
            }

            if (keys.Count == 0)
            {
                throw new ArgumentException("At least one of Key1 or Key2 switch required");
            }

            var description = string.Format(Resources.ResetWorkspaceCollectionAccessKeyDescription, keys[0], this.WorkspaceCollectionName);
            var warning = string.Format(Resources.ResetWorkspaceCollectionAccessKeyWarning, keys[0], this.WorkspaceCollectionName);

            if (!ShouldProcess(description, warning, Resources.ShouldProcessCaption))
            {
                return;
            }

            foreach (var key in keys)
            {
                var accessKeyRequest = new WorkspaceCollectionAccessKey((AccessKeyName)Enum.Parse(typeof(AccessKeyName), key));

                var accessKeys = this.PowerBIClient.WorkspaceCollections.RegenerateKey(
                    this.ResourceGroupName,
                    this.WorkspaceCollectionName,
                    accessKeyRequest);

                this.WriteWorkspaceCollectionAccessKeys(accessKeys);
            }
        }
    }
}
