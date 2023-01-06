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
            HelpMessage = "The Bastion Object")]
        [ValidateNotNullOrEmpty]
        public PSBastion InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The Bastion Sku Tier")]
        [PSArgumentCompleter("Basic", "Standard")]
        [ValidateSet(
            MNM.BastionHostSkuName.Basic,
            MNM.BastionHostSkuName.Standard,
            IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "The Bastion Scale Units")]
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
                    if (!this.IsResourcePresent(this.InputObject.ResourceGroupName, this.InputObject.Name))
                    {
                        throw new ArgumentException(Properties.Resources.ResourceNotFound);
                    }

                    PSBastion getBastionHost = this.GetBastion(this.InputObject.ResourceGroupName, this.InputObject.Name);

                    // If Sku parameter is present
                    if (!String.IsNullOrEmpty(this.Sku) || !String.IsNullOrWhiteSpace(this.Sku))
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
                        if (IsSkuDowngrade(getBastionHost, this.InputObject))
                        {
                            throw new ArgumentException("Downgrading Sku is not allowed");
                        }

                        this.InputObject.Sku = new PSBastionSku(getBastionHost.Sku.Name);
                    }

                    ValidateBastionFeatures(this.InputObject, this.ScaleUnit, this.EnableKerberos, this.DisableCopyPaste, this.EnableTunneling, this.EnableIpConnect, this.EnableShareableLink);
                    /* Changed to a new location
                    if (this.InputObject.IsBasic())
                    {
                        // Features allowed for Basic SKU
                        // Add after updating schema
                        //if (this.EnableKerberos.HasValue)
                        //{
                        //    bastion.EnableKerberos = this.EnableKerberos;
                        //}

                        // Features NOT allowed for Basic SKU
                        if (this.ScaleUnit.HasValue)
                        {
                            throw new ArgumentException("Scale Units cannot be updated with Basic Sku");
                        }

                        if (this.DisableCopyPaste.HasValue)
                        {
                            throw new ArgumentException("Copy/Paste cannot be updated with Basic SKU");
                        }

                        if (this.EnableTunneling.HasValue)
                        {
                            throw new ArgumentException("Native client cannot be updated with Basic SKU");
                        }

                        if (this.EnableIpConnect.HasValue)
                        {
                            throw new ArgumentException("IP connect cannot be updated with Basic SKU");
                        }

                        if (this.EnableShareableLink.HasValue)
                        {
                            throw new ArgumentException("Shareable link cannot be updated with Basic SKU");
                        }
                    }
                    else if (this.InputObject.IsStandard())
                    {
                        if (this.ScaleUnit.HasValue)
                        {
                            if (this.ScaleUnit >= 2 && this.ScaleUnit <= 50)
                            {
                                this.InputObject.ScaleUnit = this.ScaleUnit;
                            }
                            else
                            {
                                throw new ArgumentException("Please select scale units value between 2 and 50");
                            }
                        }

                        // Add after updating schema
                        //if (this.EnableKerberos.HasValue)
                        //{
                        //    bastion.EnableKerberos = this.EnableKerberos;
                        //}

                        if (this.DisableCopyPaste.HasValue)
                        {
                            this.InputObject.DisableCopyPaste = this.DisableCopyPaste;
                        }

                        if (this.EnableTunneling.HasValue)
                        {
                            this.InputObject.EnableTunneling = this.EnableTunneling;
                        }

                        if (this.EnableIpConnect.HasValue)
                        {
                            this.InputObject.EnableIpConnect = this.EnableIpConnect;
                        }

                        if (this.EnableShareableLink.HasValue)
                        {
                            this.InputObject.EnableShareableLink = this.EnableShareableLink;
                        }
                    }
                    */

                    MNM.BastionHost bastionHostModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BastionHost>(this.InputObject);
                    //bastionHostModel.ScaleUnits = this.InputObject.ScaleUnit;
                    bastionHostModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);
                    WriteObject("After mapping");
                    WriteObject(bastionHostModel);

                    this.BastionClient.CreateOrUpdate(this.InputObject.ResourceGroupName, this.InputObject.Name, bastionHostModel);

                    getBastionHost = this.GetBastion(this.InputObject.ResourceGroupName, this.InputObject.Name);
                    WriteObject("After get");
                    WriteObject(getBastionHost);
                 });

        }
    }
}
