using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public partial class PSHost
    {
        // Gets or sets the property of 'ResourceGroupName'
        public string ResourceGroupName
        {
            get
            {
                if (string.IsNullOrEmpty(Id)) return null;
                Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
                Match m = r.Match(Id);
                return m.Success ? m.Groups["rgname"].Value : null;
            }
        }

        public int? PlatformFaultDomain { get; set; }
        public bool? AutoReplaceOnFailure { get; set; }
        public string HostId { get; set; }
        public IList<SubResourceReadOnly> VirtualMachines { get; set; }
        public DedicatedHostLicenseTypes? LicenseType { get; set; }
        public DateTime? ProvisioningTime { get; set; }
        public string ProvisioningState { get; set; }
        public DedicatedHostInstanceView InstanceView { get; set; }
        public Sku Sku { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public bool? Redeploy { get; set; }
    }
}