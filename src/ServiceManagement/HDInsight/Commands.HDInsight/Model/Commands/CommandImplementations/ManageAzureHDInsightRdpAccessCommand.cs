// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    class ManageAzureHDInsightRdpAccessCommand: AzureHDInsightClusterCommand<AzureHDInsightCluster>, IManageAzureHDInsightRdpAccessCommand
    {
        public DateTime RdpAccessExpiry { get; set; }

        public PSCredential RdpCredential { get; set; }

        public bool Enable { get; set; }

        public string Location { get; set; }

        public override async Task EndProcessing()
        {
            this.Name.ArgumentNotNullOrEmpty("Name");
            this.Location.ArgumentNotNullOrEmpty("Location");

            IHDInsightClient client = this.GetClient(IgnoreSslErrors);
            if (this.Enable)
            {
                this.RdpCredential.ArgumentNotNull("RdpCredential");
                await client.EnableRdpAsync(this.Name, this.Location, this.RdpCredential.UserName, this.RdpCredential.GetCleartextPassword(), RdpAccessExpiry);
            }
            else
            {
                await client.DisableRdpAsync(this.Name, this.Location);
            }

            var getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
            getCommand.CurrentSubscription = this.CurrentSubscription;
            getCommand.Name = this.Name;
            await getCommand.EndProcessing();
            this.Output.AddRange(getCommand.Output);
        }
    }
}
