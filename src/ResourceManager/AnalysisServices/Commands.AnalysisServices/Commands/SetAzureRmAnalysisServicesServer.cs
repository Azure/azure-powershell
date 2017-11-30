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
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.Set, "AzureRmAnalysisServicesServer", SupportsShouldProcess = true, DefaultParameterSetName = ParamSetDefault), OutputType(typeof(AzureAnalysisServicesServer))]
    [Alias("Set-AzureAs")]
    public class SetAzureAnalysisServicesServer : AnalysisServicesCmdletBase
    {
        private const string ParamSetDefault = "Default";
        private const string ParamSetDisableBackup = "DisableBackup";

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the server.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the server.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "Name of the Sku used to create the server")]
        [ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 3, Mandatory = false,
            HelpMessage = "A string,string dictionary of tags associated with this server")]
        [ValidateNotNull]
        public Hashtable Tag { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 4, Mandatory = false,
            HelpMessage = "A comma separated server names to set as administrators on the server")]
        [ValidateNotNull]
        public string Administrator { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = false,
            ParameterSetName = ParamSetDefault,
            HelpMessage = "The Uri of blob container for backing up the server")]
        [ValidateNotNullOrEmpty]
        public string BackupBlobContainerUri { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 5, Mandatory = true,
            ParameterSetName = ParamSetDisableBackup,
            HelpMessage = "The switch to turn off backup of the server.")]
        public SwitchParameter DisableBackup { get; set; }

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

                var availableSkus = AnalysisServicesClient.ListSkusForExisting(ResourceGroupName, Name);
                if (Sku != null && !availableSkus.Value.Any(v => v.Sku.Name == Sku))
                {
                    throw new InvalidOperationException(string.Format(Resources.InvalidSku, Sku, String.Join(",", availableSkus.Value.Select(v => v.Sku.Name))));
                }

                var location = currentServer.Location;
                if (Tag == null && currentServer.Tags != null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentServer.Tags);
                }

                if (DisableBackup.IsPresent)
                {
                    BackupBlobContainerUri = "-";
                }

                AnalysisServicesServer updatedServer = AnalysisServicesClient.CreateOrUpdateServer(ResourceGroupName, Name, location, Sku, Tag, Administrator, currentServer, BackupBlobContainerUri);

                if(PassThru.IsPresent)
                {
                    WriteObject(AzureAnalysisServicesServer.FromAnalysisServicesServer(updatedServer));
                }
            }
        }
    }
}