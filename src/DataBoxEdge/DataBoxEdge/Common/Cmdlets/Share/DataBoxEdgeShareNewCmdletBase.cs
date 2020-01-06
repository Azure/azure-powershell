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
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using PSResourceModel = Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.PSDataBoxEdgeShare;
using ResourceModel = Microsoft.Azure.Management.DataBoxEdge.Models.Share;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Share
{
    [Cmdlet(VerbsCommon.New, Constants.Share,
         DefaultParameterSetName = SmbParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSResourceModel))]
    public class DataBoxEdgeShareNewCmdletBase : AzureDataBoxEdgeCmdletBase
    {
        private const string NfsParameterSet = "NfsParameterSet";
        private const string SmbParameterSet = "SmbParameterSet";
        private const string CloudShareNfsParameterSet = "CloudShareNfsParameterSet";
        private const string CloudShareSmbParameterSet = "CloudShareSmbParameterSet";

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = CloudShareNfsParameterSet,
            Position = 3,
            HelpMessage = HelpMessageShare.StorageAccountCredentialHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = CloudShareSmbParameterSet,
            Position = 3,
            HelpMessage = HelpMessageShare.StorageAccountCredentialHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountCredentialName { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareNfsParameterSet,
            HelpMessage = HelpMessageShare.StorageAccountCredentialHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareSmbParameterSet,
            HelpMessage = HelpMessageShare.StorageAccountCredentialHelpMessage)]
        public SwitchParameter CloudShare { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = CloudShareNfsParameterSet,
            HelpMessage = HelpMessageShare.DataFormatHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = CloudShareSmbParameterSet,
            HelpMessage = HelpMessageShare.DataFormatHelpMessage)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("BlockBlob", "PageBlob", "AzureFile")]
        public string DataFormat { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareSmbParameterSet,
            HelpMessage = HelpMessageShare.ContainerName)]
        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareNfsParameterSet,
            HelpMessage = HelpMessageShare.ContainerName)]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = SmbParameterSet,
            HelpMessage = HelpMessageShare.AccessProtocolHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareSmbParameterSet,
            HelpMessage = HelpMessageShare.AccessProtocolHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter SMB { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = SmbParameterSet,
            HelpMessage = HelpMessageShare.SetUserAccessRightsHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareSmbParameterSet,
            HelpMessage = HelpMessageShare.SetUserAccessRightsHelpMessage)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] UserAccessRight { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = NfsParameterSet,
            HelpMessage = HelpMessageShare.AccessProtocolHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareNfsParameterSet,
            HelpMessage = HelpMessageShare.AccessProtocolHelpMessage)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NFS { get; set; }

        [Parameter(Mandatory = false,
            ParameterSetName = NfsParameterSet,
            HelpMessage = HelpMessageShare.SetClientAccessRightsHelpMessage)]
        [Parameter(Mandatory = false,
            ParameterSetName = CloudShareNfsParameterSet,
            HelpMessage = HelpMessageShare.SetClientAccessRightsHelpMessage)]
        [ValidateNotNullOrEmpty]
        public Hashtable[] ClientAccessRight { get; set; }


        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private ResourceModel _share;

        private ResourceModel GetResourceModel()
        {
            return SharesOperationsExtensions.Get(
                this.DataBoxEdgeManagementClient.Shares,
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private string GetResourceAlreadyExistMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageShare.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                var resource = GetResourceModel();
                if (resource == null) return false;
                throw new Exception(GetResourceAlreadyExistMessage());
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private PSResourceModel CreateResourceModel()
        {
            return new PSResourceModel(SharesOperationsExtensions.CreateOrUpdate(
                DataBoxEdgeManagementClient.Shares,
                this.DeviceName,
                this.Name,
                _share,
                this.ResourceGroupName));
        }

        private ResourceModel AddAzureContainer(ResourceModel resourceModel)
        {
            var storageAccountCredential = this.DataBoxEdgeManagementClient.StorageAccountCredentials.Get(
                this.DeviceName,
                this.StorageAccountCredentialName,
                this.ResourceGroupName);
            resourceModel.AzureContainerInfo = this.IsParameterBound(c => c.ContainerName)
                ? new AzureContainerInfo(storageAccountCredential.Id, ContainerName, DataFormat)
                : new AzureContainerInfo(storageAccountCredential.Id, Name, this.DataFormat);
            return resourceModel;
        }

        private ResourceModel InitShareObject()
        {
            var dataPolicy = "Local";
            if (this.IsParameterBound(c => c.StorageAccountCredentialName))
            {
                dataPolicy = "Cloud";
            }

            var accessProtocol = this.NFS.IsPresent ? "NFS" : "SMB";
            var share = new ResourceModel("Online",
                "Enabled",
                accessProtocol,
                null, dataPolicy: dataPolicy);
            share = dataPolicy == "Cloud" ? AddAzureContainer(share) : share;
            return share;
        }

        private string GetUserId(string username)
        {
            var user = UsersOperationsExtensions.Get(
                this.DataBoxEdgeManagementClient.Users,
                this.DeviceName,
                username,
                this.ResourceGroupName
            );
            return user.Id;
        }

        public override void ExecuteCmdlet()
        {
            _share = InitShareObject();

            if (this.IsParameterBound(c => c.ClientAccessRight))
            {
                _share.ClientAccessRights = new List<ClientAccessRight>();
                foreach (var clientAccessRight in this.ClientAccessRight)
                {
                    var accessRightPolicy = HashtableToDictionary<string, string>(clientAccessRight);
                    _share.ClientAccessRights.Add(
                        new ClientAccessRight(
                            accessRightPolicy.GetOrNull("ClientId"),
                            accessRightPolicy.GetOrNull("AccessRight")
                        )
                    );
                }
            }

            if (this.IsParameterBound(c => c.UserAccessRight))
            {
                _share.UserAccessRights = new List<UserAccessRight>();
                foreach (var userAccessRight in this.UserAccessRight)
                {
                    var accessRightPolicy = HashtableToDictionary<string, string>(userAccessRight);

                    _share.UserAccessRights.Add(
                        new UserAccessRight(
                            GetUserId(accessRightPolicy.GetOrNull("Username")),
                            accessRightPolicy.GetOrNull("AccessRight")
                        ));
                }
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Creating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageShare.ObjectName, this.DeviceName, this.Name)))
            {
                DoesResourceExists();
                var results = new List<PSResourceModel>()
                {
                    CreateResourceModel()
                };

                WriteObject(results, true);
            }
        }
    }
}