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

using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     Represents the New-AzureHDInsightConfig Power Shell Cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureHdInsightPowerShellConstants.AzureHDInsightPigJobDefinition)]
    [OutputType(typeof(AzureHDInsightPigJobDefinition))]
    public class NewAzureHDInsightPigDefinitionCmdlet : AzureHDInsightCmdlet, INewAzureHDInsightPigJobDefinitionBase
    {
        private readonly INewAzureHDInsightPigJobDefinitionCommand command;

        /// <summary>
        ///     Initializes a new instance of the NewAzureHDInsightPigDefinitionCmdlet class.
        /// </summary>
        public NewAzureHDInsightPigDefinitionCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewPigJobDefinition();
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The Arguments for the jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasArguments)]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Need collections for input parameters")]
        public string[] Arguments
        {
            get { return this.command.Arguments; }
            set { this.command.Arguments = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The query to use for a pig jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasQueryFile)]
        public string File
        {
            get { return this.command.File; }
            set { this.command.File = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The resources for the jobDetails.")]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Need collections for input parameters")]
        public string[] Files
        {
            get { return this.command.Files; }
            set { this.command.Files = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The query to use for a pig jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasQuery)]
        public string Query
        {
            get { return this.command.Query; }
            set { this.command.Query = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The output location to use for the jobDetails.")]
        public string StatusFolder
        {
            get { return this.command.StatusFolder; }
            set { this.command.StatusFolder = value; }
        }

        /// <summary>
        ///     Finishes the execution of the cmdlet by writing out the config object.
        /// </summary>
        protected override void EndProcessing()
        {
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "New-AzureRmHDInsightPigJobDefinition"));
            if (this.File.IsNullOrEmpty() && this.Query.IsNullOrEmpty())
            {
                throw new PSArgumentException("Either File or Query should be specified for Pig jobs.");
            }

            this.command.EndProcessing().Wait();
            foreach (AzureHDInsightPigJobDefinition output in this.command.Output)
            {
                this.WriteObject(output);
            }
            this.WriteDebugLog();
        }

        /// <inheritdoc />
        protected override void StopProcessing()
        {
            this.command.Cancel();
        }
    }
}
