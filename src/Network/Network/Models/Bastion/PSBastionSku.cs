namespace Microsoft.Azure.Commands.Network.Models.Bastion
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using MNM = Management.Network.Models;

    public class PSBastionSku
    {
        [Ps1Xml(Target = ViewControl.List)]
        public string Name { get; set; }

        public PSBastionSku()
        {
            this.Name = MNM.BastionHostSkuName.Basic;
        }

        public PSBastionSku(string skuName)
        {
            this.Name = skuName;
        }
    }
}
