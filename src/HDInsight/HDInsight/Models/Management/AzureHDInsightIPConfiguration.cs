using Azure.Core;
using Azure.ResourceManager.HDInsight.Models;
using Azure.ResourceManager.Resources.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightIPConfiguration
    {
        public AzureHDInsightIPConfiguration() { }

        public AzureHDInsightIPConfiguration(HDInsightIPConfiguration ipConfiguration)
        {
            Id = ipConfiguration.Id;
            Name = ipConfiguration.Name;
            Type = ipConfiguration.ResourceType;
            ProvisioningState = ipConfiguration.ProvisioningState.ToString();
            Primary = ipConfiguration.IsPrimary;
            PrivateIPAddress = ipConfiguration.PrivateIPAddress?.ToString();
            PrivateIPAllocationMethod = ipConfiguration.PrivateIPAllocationMethod.ToString();
            Subnet = ipConfiguration.SubnetId;
        }

        public HDInsightIPConfiguration ToIPConfiguration()
        {
            return new HDInsightIPConfiguration(Name)
            {
                IsPrimary = Primary,
                PrivateIPAddress = this.PrivateIPAddress != null? IPAddress.Parse(this.PrivateIPAddress) : null,
                PrivateIPAllocationMethod = this.PrivateIPAllocationMethod,
                SubnetId = this.Subnet != null ? new ResourceIdentifier(this.Subnet) : null
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
