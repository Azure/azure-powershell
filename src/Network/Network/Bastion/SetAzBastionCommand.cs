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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Bastion",
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
        [PSArgumentCompleter("Basic", "Standard")]
        [ValidateSet(
            MNM.BastionHostSkuName.Basic,
            MNM.BastionHostSkuName.Standard,
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
            HelpMessage = "Native Client Support")]
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
                        //PSBastion getBastionHost = this.GetBastion(this.InputObject.ResourceGroupName, this.InputObject.Name);

                        #region SKU Validations
                        // If Sku parameter is present
                        if (!string.IsNullOrWhiteSpace(this.Sku))
                        {
                            // Check if InputObject Sku is being downgraded
                            if (IsSkuDowngrade(this.InputObject, this.Sku))
                            {
                                throw new ArgumentException("Downgrading Sku is not allowed");
                            }

                            this.InputObject.Sku = new PSBastionSku(this.Sku);
                        }
                        // If Sku parameter is not present
                        else
                        {
                            // Check if getBastionHost Sku is being downgraded from InputObject by setting InputObject.Sku.Name = "Basic"
                            if (IsSkuDowngrade(getBastionHost, this.InputObject.Sku.Name))
                            {
                                throw new ArgumentException("Downgrading Sku is not allowed");
                            }

                            this.InputObject.Sku = new PSBastionSku(getBastionHost.Sku.Name);
                        }
                        #endregion

                        #region Feature Validations
                        ValidateFeatures(this.InputObject, this.DisableCopyPaste, this.EnableTunneling, this.EnableIpConnect, this.EnableShareableLink);
                        #endregion

                        #region Scale Unit Validations
                        ValidateScaleUnits(this.InputObject, this.ScaleUnit);
                        #endregion

                        MNM.BastionHost bastionHostModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BastionHost>(this.InputObject);
                        // PS does not allow plurals which is why there is a mismatch in property name and hence the below line
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
