namespace Microsoft.Azure.Commands.Network.Models.Bastion
{
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSBastionSku
    {
        [Ps1Xml(Target = ViewControl.List)]
        public string Name { get; set; }

        public PSBastionSku()
        {
            this.Name = "Basic";
        }

        public PSBastionSku(string skuName)
        {
            this.Name = skuName;
        }
    }
}
