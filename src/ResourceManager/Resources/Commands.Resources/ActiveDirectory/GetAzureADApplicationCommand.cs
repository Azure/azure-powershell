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

using Microsoft.Azure.Commands.ActiveDirectory.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using System.Collections.Generic;
using System.Management.Automation;
using System;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Graph.RBAC.Models;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Gets the AD application.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADApplication", DefaultParameterSetName = ParameterSet.Empty), OutputType(typeof(List<PSADApplication>))]
    public class GetAzureADApplicationCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectId, HelpMessage = "The application object id.")]
        [ValidateGuidNotEmpty]
        public Guid ApplicationObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationId, HelpMessage = "The application id.")]
        [ValidateGuidNotEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationDisplayName, HelpMessage = "The display name.")]
        [ValidateNotNullOrEmpty]
        public string DisplayNameStartWith { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdentifierUri, HelpMessage = "The identifierUri of the application.")]
        [ValidateNotNullOrEmpty]
        public string IdentifierUri { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ApplicationObjectId != Guid.Empty)
            {
                WriteObject(ActiveDirectoryClient.GetApplication(ApplicationObjectId.ToString()));
            }
            else
            {
                ApplicationFilterParameters parameters = new ApplicationFilterParameters();
                if (ApplicationId != Guid.Empty)
                {
                    parameters.AppId = ApplicationId;
                }
                else if (!string.IsNullOrEmpty(DisplayNameStartWith))
                {
                    parameters.DisplayNameStartsWith = DisplayNameStartWith;
                }
                else if (!string.IsNullOrEmpty(IdentifierUri))
                {
                    parameters.IdentifierUri = IdentifierUri;
                }

                WriteObject(ActiveDirectoryClient.GetApplicationWithFilters(parameters), enumerateCollection: true);
            }
        }
    }
}
