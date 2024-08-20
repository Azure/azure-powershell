namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        public string DiffDiskPlacement { get; set; }
    }
}