﻿using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Synapse.Common;
using Microsoft.Azure.Commands.Synapse.Models;
using Microsoft.Azure.Commands.Synapse.Models.Exceptions;
using Microsoft.Azure.Commands.Synapse.Properties;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Azure.Synapse.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Synapse
{
    [Cmdlet(VerbsLifecycle.Submit, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + SynapseConstants.SynapsePrefix + SynapseConstants.SparkJob, DefaultParameterSetName = RunSparkJobParameterSetName)]
    [OutputType(typeof(PSSynapseSparkJob))]
    public class SubmitAzureSynapseSparkJob : SynapseCmdletBase
    {
        private const string RunSparkJobParameterSetName = nameof(RunSparkJobParameterSetName);
        private const string RunSparkJobByParentObjectParameterSet = nameof(RunSparkJobByParentObjectParameterSet);

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.WorkspaceName)]
        [ResourceNameCompleter(ResourceTypes.Workspace, "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = false, ParameterSetName = RunSparkJobParameterSetName,
            Mandatory = true, HelpMessage = HelpMessages.SparkPoolName)]
        [ResourceNameCompleter(
            ResourceTypes.SparkPool,
            "ResourceGroupName",
            nameof(WorkspaceName))]
        [ValidateNotNullOrEmpty]
        public string SparkPoolName { get; set; }

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
                    throw new SynapseException(Resources.MissingMainClassName);
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
            var batchRequest = new ExtendedLivyBatchRequest
            {
                Name = this.Name,
                File = isSparkDotNet
                    ? SynapseConstants.SparkDotNetJarFile
                    : this.MainDefinitionFile,
                ClassName = isSparkDotNet
                    ? SynapseConstants.SparkDotNetClassName
                    : (this.Language == LanguageType.PySpark ? null : this.MainClassName),
                Args = isSparkDotNet
                    ? new List<string> { this.MainDefinitionFile, this.MainClassName }
                        .Concat(this.CommandLineArgument ?? new string[0]).ToArray()
                    : this.CommandLineArgument,
                Jars = jars,
                Files = files,
                Archives = isSparkDotNet
                    ? new List<string> { $"{this.MainDefinitionFile}#{SynapseConstants.SparkDotNetUdfsFolderName}" }
                    : null,
                Conf = this.Configuration?.ToDictionary(),
                ExecutorMemory = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory + "g",
                ExecutorCores = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores,
                DriverMemory = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Memory + "g",
                DriverCores = SynapseConstants.ComputeNodeSizes[this.ExecutorSize].Cores,
                NumExecutors = this.ExecutorCount
            };

            // Ensure the relative path of UDFs is add to "--conf".
            if (isSparkDotNet)
            {
                batchRequest.Conf = batchRequest.Conf ?? new Dictionary<string, string>();
                string udfsRelativePath = "./" + SynapseConstants.SparkDotNetUdfsFolderName;
                batchRequest.Conf.TryGetValue(SynapseConstants.SparkDotNetAssemblySearchPathsKey, out string pathValue);
                var paths = pathValue?.Split(',').Select(path => path.Trim()).Where(path => !string.IsNullOrEmpty(path)).ToList() ?? new List<string>();
                if (!paths.Contains(udfsRelativePath))
                {
                    paths.Add(udfsRelativePath);
                }

                batchRequest.Conf[SynapseConstants.SparkDotNetAssemblySearchPathsKey] = string.Join(",", paths);
            }

            var jobInformation = SynapseAnalyticsClient.SubmitSparkBatchJob(this.WorkspaceName, this.SparkPoolName, batchRequest, waitForCompletion:false);
            WriteObject(new PSSynapseSparkJob(jobInformation));
        }
    }
}
