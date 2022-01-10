using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightIPConfiguration
    {
        public AzureHDInsightIPConfiguration() { }

        public AzureHDInsightIPConfiguration(IPConfiguration ipConfiguration)
        {
            Id = ipConfiguration.Id;
            Name = ipConfiguration.Name;
            Type = ipConfiguration.Type;
            ProvisioningState = ipConfiguration.ProvisioningState;
            Primary = ipConfiguration.Primary;
            PrivateIPAddress = ipConfiguration.PrivateIPAddress;
            PrivateIPAllocationMethod = ipConfiguration.PrivateIPAllocationMethod;
            Subnet = ipConfiguration.Subnet?.Id;
        }

        public IPConfiguration ToIPConfiguration()
        {
            return new IPConfiguration()
            {
                Name = this.Name,
                Primary = this.Primary,
                PrivateIPAddress = this.PrivateIPAddress,
                PrivateIPAllocationMethod = this.PrivateIPAllocationMethod,
                Subnet = new ResourceId(this.Subnet)
            };
        }

        public string Id { get; }

        public string Name { get; set; }

        public string Type { get; }

        public string ProvisioningState { get; }

        public bool? Primary { get; set; }

        public string PrivateIPAddress { get; set; }

        public string PrivateIPAllocationMethod { get; set; }

        public string Subnet { get; set; }
    }
}
