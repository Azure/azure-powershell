namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSVirtualMachineScaleSet
    {
        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        public bool? EnableResilientVMCreate { get; set; }

        public bool? EnableResilientVMDelete { get; set; }
    }
}