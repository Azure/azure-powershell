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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Rest.Azure;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsLifecycle.Submit, "AzureRmDataLakeAnalyticsJob"), OutputType(typeof(JobInformation))]
    [Alias("Submit-AdlJob")]
    public class SubmitAzureDataLakeAnalyticsJob : DataLakeAnalyticsCmdletBase
    {
        internal const string USqlJobWithScriptPath = "Submit job with script path for U-SQL";
        internal const string USqlJobParameterSetName = "Submit U-SQL Job";
        internal const string USqlJobWithScriptPathAndRecurrence = "Submit job with script path for U-SQL with reucurrence information";
        internal const string USqlJobParameterSetNameAndRecurrence = "Submit U-SQL Job with recurrence information";
        internal const string USqlJobWithScriptPathAndPipeline = "Submit job with script path for U-SQL with reucurrence and pipeline information";
        internal const string USqlJobParameterSetNameAndPipeline = "Submit U-SQL Job with recurrence and pipeline information";

        private int _degreeOfParallelism = 1;
        private int _priority = 1000;

        // TODO: Remove this once other job types are enabled
        private SwitchParameter usql = true;

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 0,
            Mandatory = true, HelpMessage = "Name of Data Lake Analytics account under which the job will be submitted."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 0,
            Mandatory = true, HelpMessage = "Name of Data Lake Analytics account under which the job will be submitted."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 0,
            Mandatory = true, HelpMessage = "Name of Data Lake Analytics account under which the job will be submitted."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 0,
            Mandatory = true, HelpMessage = "Name of Data Lake Analytics account under which the job will be submitted."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 0,
            Mandatory = true, HelpMessage = "Name of Data Lake Analytics account under which the job will be submitted."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 0,
            Mandatory = true, HelpMessage = "Name of Data Lake Analytics account under which the job will be submitted."
            )]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 1,
            Mandatory = true, HelpMessage = "The friendly name of the job to submit.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 1,
            Mandatory = true, HelpMessage = "The friendly name of the job to submit.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 1,
            Mandatory = true, HelpMessage = "The friendly name of the job to submit.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 1,
            Mandatory = true, HelpMessage = "The friendly name of the job to submit.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 1,
            Mandatory = true, HelpMessage = "The friendly name of the job to submit.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 1,
            Mandatory = true, HelpMessage = "The friendly name of the job to submit.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 2,
            Mandatory = true, HelpMessage = "Path to the script file to submit.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 2,
            Mandatory = true, HelpMessage = "Path to the script file to submit.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 2,
            Mandatory = true, HelpMessage = "Path to the script file to submit.")]
        [ValidateNotNullOrEmpty]
        public string ScriptPath { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Position = 2,
            ParameterSetName = USqlJobParameterSetName, Mandatory = true,
            HelpMessage = "Script to execute (written inline).")]
        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Position = 2,
            ParameterSetName = USqlJobParameterSetNameAndRecurrence, Mandatory = true,
            HelpMessage = "Script to execute (written inline).")]
        [Parameter(ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Position = 2,
            ParameterSetName = USqlJobParameterSetNameAndPipeline, Mandatory = true,
            HelpMessage = "Script to execute (written inline).")]
        [ValidateNotNullOrEmpty]
        public string Script { get; set; }

        // TODO: re-work into a parameter once other job types are enabled
        public SwitchParameter USql
        {
            get { return usql; }
            set { usql = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 3,
            Mandatory = false,
            HelpMessage =
                "Optionally set the version of the runtime to use for the job. If left unset, the default runtime is used."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 3,
            Mandatory = false,
            HelpMessage =
                "Optionally set the version of the runtime to use for the job. If left unset, the default runtime is used."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 3,
            Mandatory = false,
            HelpMessage =
                "Optionally set the version of the runtime to use for the job. If left unset, the default runtime is used."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 3,
            Mandatory = false,
            HelpMessage =
                "Optionally set the version of the runtime to use for the job. If left unset, the default runtime is used."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 3,
            Mandatory = false,
            HelpMessage =
                "Optionally set the version of the runtime to use for the job. If left unset, the default runtime is used."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 3,
            Mandatory = false,
            HelpMessage =
                "Optionally set the version of the runtime to use for the job. If left unset, the default runtime is used."
            )]
        [ValidateNotNullOrEmpty]
        public string Runtime { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only erforms semantic checks and necessary sanity checks), 'Full' (full compilation) and 'SingleBox' (Full compilation performed locally)."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only erforms semantic checks and necessary sanity checks), 'Full' (full compilation) and 'SingleBox' (Full compilation performed locally)"
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only erforms semantic checks and necessary sanity checks), 'Full' (full compilation) and 'SingleBox' (Full compilation performed locally)."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only erforms semantic checks and necessary sanity checks), 'Full' (full compilation) and 'SingleBox' (Full compilation performed locally)"
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only erforms semantic checks and necessary sanity checks), 'Full' (full compilation) and 'SingleBox' (Full compilation performed locally)."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only erforms semantic checks and necessary sanity checks), 'Full' (full compilation) and 'SingleBox' (Full compilation performed locally)"
            )]
        [ValidateSet("Semantic", "Full", "SingleBox")]
        public string CompileMode { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 5,
            Mandatory = false,
            HelpMessage = "Indicates that the submission should only build the job and not execute if set to true.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 5,
            Mandatory = false,
            HelpMessage = "Indicates that the submission should only build the job and not execute if set to true.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 5,
            Mandatory = false,
            HelpMessage = "Indicates that the submission should only build the job and not execute if set to true.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 5,
            Mandatory = false,
            HelpMessage = "Indicates that the submission should only build the job and not execute if set to true.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 5,
            Mandatory = false,
            HelpMessage = "Indicates that the submission should only build the job and not execute if set to true.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 5,
            Mandatory = false,
            HelpMessage = "Indicates that the submission should only build the job and not execute if set to true.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter CompileOnly { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The degree of parallelism to use for this job. Typically, a higher degree of parallelism dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The degree of parallelism to use for this job. Typically, a higher degree of parallelism dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The degree of parallelism to use for this job. Typically, a higher degree of parallelism dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The degree of parallelism to use for this job. Typically, a higher degree of parallelism dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The degree of parallelism to use for this job. Typically, a higher degree of parallelism dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The degree of parallelism to use for this job. Typically, a higher degree of parallelism dedicated to a script results in faster script execution time."
            )]
        public int DegreeOfParallelism
        {
            get { return _degreeOfParallelism; }
            set { _degreeOfParallelism = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority for this job with a range from 1 to 1000, where 1000 is the lowest priority and 1 is the highest."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority for this job with a range from 1 to 1000, where 1000 is the lowest priority and 1 is the highest."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority for this job with a range from 1 to 1000, where 1000 is the lowest priority and 1 is the highest."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority for this job with a range from 1 to 1000, where 1000 is the lowest priority and 1 is the highest."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority for this job with a range from 1 to 1000, where 1000 is the lowest priority and 1 is the highest."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority for this job with a range from 1 to 1000, where 1000 is the lowest priority and 1 is the highest."
            )]
        [ValidateRange(0, int.MaxValue)]
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence,
            Mandatory = true,
            HelpMessage = "An ID that indicates the submission of this job is a part of a set of recurring jobs with the same recurrence ID.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence,
            Mandatory = true,
            HelpMessage = "An ID that indicates the submission of this job is a part of a set of recurring jobs with the same recurrence ID.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline,
            Mandatory = true,
            HelpMessage = "An ID that indicates the submission of this job is a part of a set of recurring jobs with the same recurrence ID.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline,
            Mandatory = true,
            HelpMessage = "An ID that indicates the submission of this job is a part of a set of recurring jobs with the same recurrence ID.")]
        [ValidateNotNullOrEmpty]
        public Guid RecurrenceId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence,
            Mandatory = false,
            HelpMessage = "An optional friendly name for the recurrence correlation between jobs.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence,
            Mandatory = false,
            HelpMessage = "An optional friendly name for the recurrence correlation between jobs.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline,
            Mandatory = false,
            HelpMessage = "An optional friendly name for the recurrence correlation between jobs.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline,
            Mandatory = false,
            HelpMessage = "An optional friendly name for the recurrence correlation between jobs.")]
        [ValidateNotNullOrEmpty]
        public string RecurrenceName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline,
            Mandatory = true,
            HelpMessage = "An ID that indicates the submission of this job is a part of a set of recurring jobs and also associated with a job pipeline.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline,
            Mandatory = true,
            HelpMessage = "An ID that indicates the submission of this job is a part of a set of recurring jobs and also associated with a job pipeline.")]
        [ValidateNotNullOrEmpty]
        public Guid PipelineId { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline,
            Mandatory = false,
            HelpMessage = "An optional friendly name for the pipeline associated with this job.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline,
            Mandatory = false,
            HelpMessage = "An optional friendly name for the pipeline associated with this job.")]
        [ValidateNotNullOrEmpty]
        public string PipelineName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline,
            Mandatory = false,
            HelpMessage = "An optional uri that links to the originating service associated with this pipeline.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline,
            Mandatory = false,
            HelpMessage = "An optional uri that links to the originating service associated with this pipeline.")]
        [ValidateNotNullOrEmpty]
        public string PipelineUri { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline,
            Mandatory = false,
            HelpMessage = "An ID that identifies this specific run iteration of the pipeline.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline,
            Mandatory = false,
            HelpMessage = "An ID that identifies this specific run iteration of the pipeline.")]
        [ValidateNotNullOrEmpty]
        public Guid? RunId { get; set; }

        public override void ExecuteCmdlet()
        {
            if(DegreeOfParallelism < 1)
            {
                WriteWarning(Resources.InvalidDegreeOfParallelism);
            }

            // error handling for not passing or passing both script and script path
            if ((string.IsNullOrEmpty(Script) && string.IsNullOrEmpty(ScriptPath)) ||
                (!string.IsNullOrEmpty(Script) && !string.IsNullOrEmpty(ScriptPath)))
            {
                throw new CloudException(Resources.AmbiguousScriptParameter);
            }

            // get the script
            if (string.IsNullOrEmpty(Script))
            {
                var powerShellDestinationPath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(ScriptPath);
                if (!File.Exists(powerShellDestinationPath))
                {
                    throw new CloudException(string.Format(Resources.ScriptFilePathDoesNotExist,
                        powerShellDestinationPath));
                }

                Script = File.ReadAllText(powerShellDestinationPath);
            }

            JobType jobType;
            JobProperties properties;
            if (USql)
            {
                jobType = JobType.USql;
                var sqlIpProperties = new USqlJobProperties
                {
                    Script = Script
                };

                if (!string.IsNullOrEmpty(CompileMode))
                {
                    CompileMode toUse;
                    if (Enum.TryParse(CompileMode, out toUse))
                    {
                        sqlIpProperties.CompileMode = toUse;
                    }
                }

                if (!string.IsNullOrEmpty(Runtime))
                {
                    sqlIpProperties.RuntimeVersion = Runtime;
                }

                properties = sqlIpProperties;
            }
            else
            {
                throw new CloudException(Resources.InvalidJobType);
            }

            var jobInfo = new JobInformation
            (
                jobId: DataLakeAnalyticsClient.JobIdQueue.Count == 0 ? Guid.NewGuid() : DataLakeAnalyticsClient.JobIdQueue.Dequeue(),
                name: Name,
                properties: properties,
                type: jobType,
                degreeOfParallelism: DegreeOfParallelism,
                priority: Priority
            );

            if (ParameterSetName.Equals(USqlJobParameterSetNameAndRecurrence) ||
                    ParameterSetName.Equals(USqlJobParameterSetNameAndPipeline) ||
                    ParameterSetName.Equals(USqlJobWithScriptPathAndRecurrence) ||
                    ParameterSetName.Equals(USqlJobWithScriptPathAndPipeline))
            {
                jobInfo.Related = new JobRelationshipProperties
                {
                    RecurrenceId = RecurrenceId,
                    RecurrenceName = RecurrenceName
                };

                if (ParameterSetName.Equals(USqlJobParameterSetNameAndPipeline) ||
                    ParameterSetName.Equals(USqlJobWithScriptPathAndPipeline))
                {
                    jobInfo.Related.PipelineId = PipelineId;
                    jobInfo.Related.PipelineName = PipelineName;
                    jobInfo.Related.PipelineUri = PipelineUri;
                    jobInfo.Related.RunId = RunId;
                }
            }

            WriteObject(CompileOnly
                ? DataLakeAnalyticsClient.BuildJob(Account, jobInfo)
                : DataLakeAnalyticsClient.SubmitJob(Account, jobInfo));
        }
    }
}