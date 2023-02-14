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
                        if (this.InputObject.Sku.Name.Equals(MNM.BastionHostSkuName.Standard) && this.Sku.Equals(MNM.BastionHostSkuName.Basic))
                        {
                            
                            throw new ArgumentException("Downgrading Sku is not allowed");
                        }

                        this.InputObject.Sku = new PSBastionSku(this.Sku);
                    }
                    // If Sku parameter is not present
                    else
                    {
                        // Check if getBastionHost Sku is being downgraded from InputObject by setting InputObject.Sku.Name = "Basic"
                        if (getBastionHost.Sku.Name.Equals(MNM.BastionHostSkuName.Standard) && this.InputObject.Sku.Name.Equals(MNM.BastionHostSkuName.Basic))
                        {
                            throw new ArgumentException("Downgrading Sku is not allowed");
                        }

                        this.InputObject.Sku = new PSBastionSku(getBastionHost.Sku.Name);
                    }

                    if (this.ScaleUnit.HasValue)
                    {
                        if(this.InputObject.Sku.Name.Equals(MNM.BastionHostSkuName.Standard))
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
                        else if (this.InputObject.Sku.Name.Equals(MNM.BastionHostSkuName.Basic))
                        {
                            throw new ArgumentException("Scale Units cannot be updated with Basic Sku");
                        }
                    }
                    else
                    {
                        if (this.InputObject.ScaleUnit < 2 || this.InputObject.ScaleUnit > 50)
                        {
                            throw new ArgumentException("Please select scale units value between 2 and 50");
                        }
                    }

                    MNM.BastionHost bastionHostModel = NetworkResourceManagerProfile.Mapper.Map<MNM.BastionHost>(this.InputObject);
                    bastionHostModel.ScaleUnits = this.InputObject.ScaleUnit;
                    bastionHostModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

                    this.BastionClient.CreateOrUpdate(this.InputObject.ResourceGroupName, this.InputObject.Name, bastionHostModel);

                    getBastionHost = this.GetBastion(this.InputObject.ResourceGroupName, this.InputObject.Name);
                    
                    WriteObject(getBastionHost);
                 });

        }
    }
}
