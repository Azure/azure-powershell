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

namespace Microsoft.Azure.Commands.Network.Bastion
{
    using System;
    using System.Collections;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.Network.Models.Bastion;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using MNM = Management.Network.Models;

    [Cmdlet(VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + Constants.BastionResourceName,
        DefaultParameterSetName = BastionParameterSetNames.ByBastionObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSBastion))]
    public class SetAzBastionCommand : BastionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Bastion Object")]
        [ValidateNotNullOrEmpty]
        public PSBastion InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Bastion Sku")]
        [PSArgumentCompleter(PSBastionSku.Basic, PSBastionSku.Standard, PSBastionSku.Premium)]
        [ValidateSet(
            MNM.BastionHostSkuName.Basic,
            MNM.BastionHostSkuName.Standard,
            MNM.BastionHostSkuName.Premium,
            IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Bastion Scale Units")]
        public int? ScaleUnit { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Kerberos")]
        public bool? EnableKerberos { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Copy and Paste")]
        public bool? DisableCopyPaste { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Native Client")]
        public bool? EnableTunneling { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "IP Connect")]
        public bool? EnableIpConnect { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Shareable Link")]
        public bool? EnableShareableLink { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipeline = true,
           HelpMessage = "Session Recording")]
        public bool? EnableSessionRecording { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            ConfirmAction(Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, InputObject.Name),
                Properties.Resources.SettingResourceMessage,
                InputObject.Name, () => 
                {
                    if (this.TryGetBastion(this.InputObject.ResourceGroupName, this.InputObject.Name, out PSBastion getBastionHost))
                    {
                        #region SKU Validations
                        // If Sku parameter is present
                        if (!string.IsNullOrWhiteSpace(this.Sku))
                        {
                            // Check if InputObject Sku is being downgraded
                            if (IsSkuDowngrade(this.InputObject, this.Sku))
                            {
                                throw new ArgumentException(Properties.Resources.BastionSkuDowngradeNotAllowed);
                            }

                            this.InputObject.Sku = new PSBastionSku(this.Sku);
                        }
                        // If Sku parameter is not present
                        else
                        {
                            // Check if getBastionHost Sku is being downgraded from InputObject by setting InputObject.Sku.Name
                            if (IsSkuDowngrade(getBastionHost, this.InputObject.Sku.Name))
                            {
                                throw new ArgumentException(Properties.Resources.BastionSkuDowngradeNotAllowed);
                            }

                            this.InputObject.Sku = new PSBastionSku(getBastionHost.Sku.Name);
                        }
                        #endregion

                        #region Feature validations and updates
                        ValidateFeatures(this.InputObject, this.DisableCopyPaste, this.EnableTunneling, this.EnableIpConnect, this.EnableShareableLink, this.EnableSessionRecording);
                        if (this.EnableKerberos.HasValue)
                        {
                            this.InputObject.EnableKerberos = this.EnableKerberos.Value;
                        }
                        if (this.DisableCopyPaste.HasValue)
                        {
                            this.InputObject.DisableCopyPaste = this.DisableCopyPaste.Value;
                        }
                        if (this.EnableTunneling.HasValue)
                        {
                            this.InputObject.EnableTunneling = this.EnableTunneling.Value;
                        }
                        if (this.EnableIpConnect.HasValue)
                        {
                            this.InputObject.EnableIpConnect = this.EnableIpConnect.Value;
                        }
                        if (this.EnableShareableLink.HasValue)
                        {
                            this.InputObject.EnableShareableLink = this.EnableShareableLink.Value;
                        }
                        if (this.EnableSessionRecording.HasValue)
                        {
                            this.InputObject.EnableSessionRecording = this.EnableSessionRecording.Value;
                        }
                        #endregion

                        #region Scale unit validations and update
                        ValidateScaleUnits(this.InputObject, this.ScaleUnit);
                        if (this.ScaleUnit.HasValue)
                        {
                            this.InputObject.ScaleUnit = this.ScaleUnit.Value;
                        }
                        #endregion

                        //// Map to the sdk object
                        MNM.BastionHost bastionHostModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BastionHost>(this.InputObject);
                        //// PS does not allow plurals which is why there is a mismatch in property name and hence the below line
                        bastionHostModel.ScaleUnits = this.InputObject.ScaleUnit;
                        bastionHostModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

                        this.BastionClient.CreateOrUpdate(this.InputObject.ResourceGroupName, this.InputObject.Name, bastionHostModel);

                        getBastionHost = this.GetBastion(this.InputObject.ResourceGroupName, this.InputObject.Name);
                        WriteObject(getBastionHost);
                    }
                    else
                    {
                        throw new ArgumentException(Properties.Resources.ResourceNotFound);
                    }
                }
            );
        }
    }
}
