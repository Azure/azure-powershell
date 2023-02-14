using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightIPConfiguration"), OutputType(typeof(AzureHDInsightIPConfiguration))]
    public class NewAzureHDInsightIPConfigurationCommand : HDInsightCmdletBase
    {
        private readonly AzureHDInsightIPConfiguration _ipConfiguration;

        [Parameter(HelpMessage = "Gets or sets the ip configuration name.")]
        public string Name
        {
            get { return _ipConfiguration.Name; }
            set { _ipConfiguration.Name = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the flag indicates whether this IP configuration is primary for the corresponding NIC.")]
        public SwitchParameter Primary
        {
            get { return _ipConfiguration.Primary.Value; }
            set { _ipConfiguration.Primary = value.IsPresent; }
        }

        [Parameter(HelpMessage = "Gets or sets the private ip address.")]
        public string PrivateIPAddress
        {
            get { return _ipConfiguration.PrivateIPAddress; }
            set { _ipConfiguration.PrivateIPAddress = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the private ip allocation method.")]
        [PSArgumentCompleter("dynamic", "static")]
        public string PrivateIPAllocationMethod
        {
            get { return _ipConfiguration.PrivateIPAllocationMethod; }
            set { _ipConfiguration.PrivateIPAllocationMethod = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the subnet resource id.")]
        public string SubnetId
        {
            get { return _ipConfiguration.Subnet; }
            set { _ipConfiguration.Subnet = value; }
        }

        public NewAzureHDInsightIPConfigurationCommand()
        {
            _ipConfiguration = new AzureHDInsightIPConfiguration();
        }

        public override void ExecuteCmdlet()
        {
            WriteObject(_ipConfiguration);
        }
    }
}
