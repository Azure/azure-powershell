using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightPrivateLinkConfiguration"), OutputType(typeof(AzureHDInsightPrivateLinkConfiguration))]
    public class NewAzureHDInsightPrivateLinkConfiguration : HDInsightCmdletBase
    {
        private readonly AzureHDInsightPrivateLinkConfiguration _privateLinkConfiguration;

        [Parameter(HelpMessage = "Gets or sets the private link configuration name.")]
        public string Name
        {
            get { return _privateLinkConfiguration.Name; }
            set { _privateLinkConfiguration.Name = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the group id of the private link.")]
        public string GroupId
        {
            get { return _privateLinkConfiguration.GroupId; }
            set { _privateLinkConfiguration.GroupId = value; }
        }

        [Parameter(HelpMessage = "Gets or sets the ip configurations of the private link.")]
        public AzureHDInsightIPConfiguration[] IpConfiguration
        {
            get { return _privateLinkConfiguration.IpConfigurations.ToArray(); }
            set { _privateLinkConfiguration.IpConfigurations = value.ToList(); }
        }

        public NewAzureHDInsightPrivateLinkConfiguration()
        {
            _privateLinkConfiguration = new AzureHDInsightPrivateLinkConfiguration();
        }

        public override void ExecuteCmdlet()
        {
            WriteObject(_privateLinkConfiguration);
        }
    }
}
