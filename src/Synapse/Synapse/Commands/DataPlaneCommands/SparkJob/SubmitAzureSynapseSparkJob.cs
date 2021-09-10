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

using Azure.Analytics.Synapse.Spark.Models;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Submit, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkJob, DefaultParameterSetName = RunSparkJobParameterSetName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSSynapseSparkJob))]
    public class SubmitAzureSynapseSparkJob : SynapseSparkCmdletBase
    {
        private const string RunSparkJobParameterSetName = nameof(RunSparkJobParameterSetName);
        private const string RunSparkJobByParentObjectParameterSet = nameof(RunSparkJobByParentObjectParameterSet);

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public override string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public override string SparkPoolName { get; set; }

        [Parameter(ValueFromPipeline = true, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolObject)]
        [ValidateNotNullOrEmpty]
        public PSSynapseSparkPool SparkPoolObject { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobLanguage)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobLanguage)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Spark", "Scala", "PySpark", "Python", "SparkDotNet", "CSharp", IgnoreCase = true)]
        public string Language { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.SparkJobName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.MainDefinitionFile)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.MainDefinitionFile)]
        [ValidateNotNullOrEmpty]
        public string MainDefinitionFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.MainClassName)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.MainClassName)]
        [ValidateNotNullOrEmpty]
        [Alias(SynapseConstants.MainExecutableFile)]
        public string MainClassName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.CommandLineArgument)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.CommandLineArgument)]
        [ValidateNotNullOrEmpty]
        public string[] CommandLineArgument { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.ReferenceFile)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.ReferenceFile)]
        [ValidateNotNullOrEmpty]
        public string[] ReferenceFile { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.ExecutorCount)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ExecutorCount)]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, 80)]
        public int ExecutorCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.ExecutorSize)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = true, HelpMessage = HelpMessages.ExecutorSize)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(NodeSize.Small, NodeSize.Medium, NodeSize.Large, IgnoreCase = true)]
        [PSArgumentCompleter(NodeSize.Small, NodeSize.Medium, NodeSize.Large)]
        public string ExecutorSize { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = false, HelpMessage = HelpMessages.Configuration)]
        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobByParentObjectParameterSet,
            Mandatory = false, HelpMessage = HelpMessages.Configuration)]
        [ValidateNotNullOrEmpty]
        public Hashtable Configuration { get; set; }

        public override void ExecuteCmdlet()
        {
            this.Language = LanguageType.Parse(this.Language);
            if (string.IsNullOrEmpty(this.MainClassName))
            {
                if (LanguageType.SparkDotNet == this.Language || LanguageType.Spark == this.Language)
                {
                    throw new AzPSInvalidOperationException(Resources.MissingMainClassName);
                }
            }

            if (this.IsParameterBound(c => c.SparkPoolObject))
            {
                var resourceIdentifier = new ResourceIdentifier(this.SparkPoolObject.Id);
                this.WorkspaceName = resourceIdentifier.ParentResource;
                this.WorkspaceName = this.WorkspaceName.Substring(this.WorkspaceName.LastIndexOf('/') + 1);
                this.SparkPoolName = resourceIdentifier.ResourceName;
            }

            this.MainDefinitionFile = Utils.NormalizeUrl(this.MainDefinitionFile);
            if (this.CommandLineArgument != null)
            {
                for (int i = 0; i < this.CommandLineArgument.Length; i++)
                {
                    this.CommandLineArgument[i] = Utils.NormalizeUrl(this.CommandLineArgument[i]);
                }
            }

            if (this.ReferenceFile != null)
            {
                for (int i = 0; i < this.ReferenceFile.Length; i++)
                {
                    this.ReferenceFile[i] = Utils.NormalizeUrl(this.ReferenceFile[i]);
                }
            }

            Utils.CategorizedFiles(this.ReferenceFile, out IList<string> jars, out IList<string> files);
            bool isSparkDotNet = this.Language == LanguageType.SparkDotNet;
            var batchRequest = new SparkBatchJobOptions(this.Name, isSparkDotNet ? SynapseConstants.SparkDotNetJarFile : this.MainDefinitionFile)
            {
                ClassName = isSparkDotNet
                    ? SynapseConstants.SparkDotNetClassName
                    : (this.Language == LanguageType.PySpark ? null : this.MainClassName),
                ExecutorMemory = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory + "g",
                ExecutorCores = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores,
                DriverMemory = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory + "g",
                DriverCores = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores,
                ExecutorCount = this.ExecutorCount
            };
            var arguments = isSparkDotNet
                    ? new List<string> { this.MainDefinitionFile, this.MainClassName }
                        .Concat(this.CommandLineArgument ?? new string[0]).ToArray()
                    : this.CommandLineArgument;
            arguments?.ForEach(item => batchRequest.Arguments.Add(item));
            jars?.ForEach(item => batchRequest.Jars.Add(item));
            files?.ForEach(item => batchRequest.Files.Add(item));
            var archives = isSparkDotNet
                    ? new List<string> { $"{this.MainDefinitionFile}#{SynapseConstants.SparkDotNetUdfsFolderName}" }
                    : null;
            archives?.ForEach(item => batchRequest.Archives.Add(item));
            this.Configuration?.ToDictionary()?.ForEach(item => batchRequest.Configuration.Add(item));

            // Ensure the relative path of UDFs is add to "--conf".
            if (isSparkDotNet)
            {
                string udfsRelativePath = "./" + SynapseConstants.SparkDotNetUdfsFolderName;
                batchRequest.Configuration.TryGetValue(SynapseConstants.SparkDotNetAssemblySearchPathsKey, out string pathValue);
                var paths = pathValue?.Split(',').Select(path => path.Trim()).Where(path => !string.IsNullOrEmpty(path)).ToList() ?? new List<string>();
                if (!paths.Contains(udfsRelativePath))
                {
                    paths.Add(udfsRelativePath);
                }

                batchRequest.Configuration[SynapseConstants.SparkDotNetAssemblySearchPathsKey] = string.Join(",", paths);
            }

            if (this.ShouldProcess(this.SparkPoolName, string.Format(Resources.SubmittingSynapseSparkJob, this.SparkPoolName, this.WorkspaceName)))
            {
                var jobInformation = SynapseAnalyticsClient.SubmitSparkBatchJob(batchRequest, waitForCompletion: false);
                WriteObject(new PSSynapseSparkJob(jobInformation));
            }
        }
    }
}
