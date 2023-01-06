namespace Microsoft.Azure.Commands.Network.Models.Bastion
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using MNM = Management.Network.Models;

    public class PSBastionSku
    {
        [Ps1Xml(Target = ViewControl.List)]
        public string Name { get; set; }

        public PSBastionSku(string skuName = null)
        {
            if (string.IsNullOrEmpty(skuName) || string.IsNullOrWhiteSpace(skuName))
            {
                this.Name = MNM.BastionHostSkuName.Basic;
            }

            this.Name = skuName;
        }
    }
}
