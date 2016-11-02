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

using System;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Analysis.Models;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Set, "AzureRmAnalysisServicesServer", SupportsShouldProcess = true), OutputType(typeof(AzureAnalysisServicesServer))]
    [Alias("Set-AzureAs")]
    public class SetAzureAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the server.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the server.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage =
                "Name of the Sku used to create the server"
            )]
        [ValidateNotNullOrEmpty]
        [ValidateSet("S1", "S2", "S4")]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this server")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A comma separated server names to set as administrators on the server")]
        [ValidateNotNull]
        public string Administrator { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteExceptionError(new PSArgumentNullException("Name", "Name of server not specified"));
            }

            if (ShouldProcess(Name, Resources.UpdatingAnalysisServicesServer))
            {
                AnalysisServicesServer currentServer = null;
                if (!AnalysisServicesClient.TestServer(ResourceGroupName, Name, out currentServer))
                {
                    throw new InvalidOperationException(string.Format(Properties.Resources.ServerDoesNotExist, Name));
                }

                var location = currentServer.Location;
                if (Tag == null && currentServer.Tags != null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentServer.Tags);
                }

                AnalysisServicesServer updatedServer = AnalysisServicesClient.CreateOrUpdateServer(ResourceGroupName, Name, location, Sku, Tag, Administrator, currentServer);

                if(PassThru.IsPresent)
                {
                    WriteObject(AzureAnalysisServicesServer.FromAnalysisServicesServer(updatedServer));
                }
            }
        }
    }
}