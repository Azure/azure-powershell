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
using System.Collections;
using System.IO;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsLifecycle.Submit, "AzureRmDataLakeAnalyticsJob"), OutputType(typeof(JobInformation))]
    [Alias("Submit-AdlJob")]
    public class SubmitAzureDataLakeAnalyticsJob : DataLakeAnalyticsCmdletBase
    {
        internal const string USqlJobWithScriptPath = "SubmitUSqlJobWithScriptPath";
        internal const string USqlJobParameterSetName = "SubmitUSqlJob";
        internal const string USqlJobWithScriptPathAndRecurrence = "SubmitUSqlJobWithScriptPathAndRecurrence";
        internal const string USqlJobParameterSetNameAndRecurrence = "SubmitUSqlJobWithRecurrence";
        internal const string USqlJobWithScriptPathAndPipeline = "SubmitUSqlJobWithScriptPathAndPipeline";
        internal const string USqlJobParameterSetNameAndPipeline = "SubmitUSqlJobWithPipeline";

        private int _analyticsUnits = 1;
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
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only performs semantic checks and necessary sanity checks), 'Full' (Full compilation) and 'SingleBox' (Full compilation performed locally)."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only performs semantic checks and necessary sanity checks), 'Full' (Full compilation) and 'SingleBox' (Full compilation performed locally)"
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only performs semantic checks and necessary sanity checks), 'Full' (Full compilation) and 'SingleBox' (Full compilation performed locally)."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only performs semantic checks and necessary sanity checks), 'Full' (Full compilation) and 'SingleBox' (Full compilation performed locally)"
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only performs semantic checks and necessary sanity checks), 'Full' (Full compilation) and 'SingleBox' (Full compilation performed locally)."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 4,
            Mandatory = false,
            HelpMessage =
                "The type of compilation to be done on this job. Valid values are: 'Semantic' (Only performs semantic checks and necessary sanity checks), 'Full' (Full compilation) and 'SingleBox' (Full compilation performed locally)"
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
                "The analytics units to use for this job. Typically, more analytics units dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The analytics units to use for this job. Typically, more analytics units dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The analytics units to use for this job. Typically, more analytics units dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The analytics units to use for this job. Typically, more analytics units dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The analytics units to use for this job. Typically, more analytics units dedicated to a script results in faster script execution time."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 6,
            Mandatory = false,
            HelpMessage =
                "The analytics units to use for this job. Typically, more analytics units dedicated to a script results in faster script execution time."
            )]
        [Alias("DegreeOfParallelism")]
        public int AnalyticsUnits
        {
            get { return _analyticsUnits; }
            set { _analyticsUnits = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority of the job. If not specified, the priority is 1000. A lower number indicates a higher job priority."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority of the job. If not specified, the priority is 1000. A lower number indicates a higher job priority."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority of the job. If not specified, the priority is 1000. A lower number indicates a higher job priority."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority of the job. If not specified, the priority is 1000. A lower number indicates a higher job priority."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority of the job. If not specified, the priority is 1000. A lower number indicates a higher job priority."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline, Position = 7,
            Mandatory = false,
            HelpMessage =
                "The priority of the job. If not specified, the priority is 1000. A lower number indicates a higher job priority."
            )]
        [ValidateRange(0, int.MaxValue)]
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPath,
            Mandatory = false,
            HelpMessage =
                "The script parameters for this job, as a dictionary of parameter names (string) to values (any combination of byte, sbyte, int, uint (or uint32), long, ulong (or uint64), float, double, decimal, short (or int16), ushort (or uint16), char, string, DateTime, bool, Guid, or byte[])."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetName,
            Mandatory = false,
            HelpMessage =
                "The script parameters for this job, as a dictionary of parameter names (string) to values (any combination of byte, sbyte, int, uint (or uint32), long, ulong (or uint64), float, double, decimal, short (or int16), ushort (or uint16), char, string, DateTime, bool, Guid, or byte[])."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndRecurrence,
            Mandatory = false,
            HelpMessage =
                "The script parameters for this job, as a dictionary of parameter names (string) to values (any combination of byte, sbyte, int, uint (or uint32), long, ulong (or uint64), float, double, decimal, short (or int16), ushort (or uint16), char, string, DateTime, bool, Guid, or byte[])."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndRecurrence,
            Mandatory = false,
            HelpMessage =
                "The script parameters for this job, as a dictionary of parameter names (string) to values (any combination of byte, sbyte, int, uint (or uint32), long, ulong (or uint64), float, double, decimal, short (or int16), ushort (or uint16), char, string, DateTime, bool, Guid, or byte[])."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobWithScriptPathAndPipeline,
            Mandatory = false,
            HelpMessage =
                "The script parameters for this job, as a dictionary of parameter names (string) to values (any combination of byte, sbyte, int, uint (or uint32), long, ulong (or uint64), float, double, decimal, short (or int16), ushort (or uint16), char, string, DateTime, bool, Guid, or byte[])."
            )]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = USqlJobParameterSetNameAndPipeline,
            Mandatory = false,
            HelpMessage =
                "The script parameters for this job, as a dictionary of parameter names (string) to values (any combination of byte, sbyte, int, uint (or uint32), long, ulong (or uint64), float, double, decimal, short (or int16), ushort (or uint16), char, string, DateTime, bool, Guid, or byte[])."
            )]
        [ValidateNotNullOrEmpty]
        public IDictionary ScriptParameter { get; set; }

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
            if (AnalyticsUnits < 1)
            {
                WriteWarning(Resources.InvalidAnalyticsUnits);
            }

            // Error handling for not passing or passing both script and script path
            if ((string.IsNullOrEmpty(Script) && string.IsNullOrEmpty(ScriptPath)) ||
                (!string.IsNullOrEmpty(Script) && !string.IsNullOrEmpty(ScriptPath)))
            {
                throw new CloudException(Resources.AmbiguousScriptParameter);
            }

            // Get the script
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

            // Check for script parameters
            if (ScriptParameter != null)
            {
                StringBuilder paramBuilder = new StringBuilder();
                string paramVar = null;
                string paramValue = null;
                Type paramType = null;

                // Build the parameter string in order to prepend it to the script
                foreach (DictionaryEntry param in ScriptParameter)
                {
                    if (param.Value == null)
                    {
                        throw new CloudException(string.Format(Resources.ScriptParameterValueIsNull,
                            param.Key.ToString()));
                    }

                    paramVar = param.Key.ToString();
                    paramValue = param.Value.ToString();
                    paramType = param.Value.GetType();
                    
                    if (paramType.Equals(typeof(byte)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} byte = {1};\n", 
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(sbyte)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} sbyte = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(int)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} int = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(uint)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} uint = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(long)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} long = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(ulong)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} ulong = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(float)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} float = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(double)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} double = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(decimal)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} decimal = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(short)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} short = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(ushort)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} ushort = {1};\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(char)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} char = '{1}';\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(string)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} string = \"{1}\";\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(DateTime)))
                    {
                        DateTime datetime = (DateTime)param.Value;

                        paramBuilder.Append(string.Format("DECLARE @{0} DateTime = new DateTime({1}, {2}, {3}, {4}, {5}, {6}, {7});\n",
                            paramVar,
                            datetime.Year,
                            datetime.Month,
                            datetime.Day,
                            datetime.Hour,
                            datetime.Minute,
                            datetime.Second,
                            datetime.Millisecond));
                    }
                    else if (paramType.Equals(typeof(bool)))
                    {
                        if ((bool)param.Value)
                        {
                            paramBuilder.Append(string.Format("DECLARE @{0} bool = true;\n", paramVar));
                        }
                        else
                        {
                            paramBuilder.Append(string.Format("DECLARE @{0} bool = false;\n", paramVar));
                        }
                    }
                    else if (paramType.Equals(typeof(Guid)))
                    {
                        paramBuilder.Append(string.Format("DECLARE @{0} Guid = new Guid(\"{1}\");\n",
                            paramVar,
                            paramValue));
                    }
                    else if (paramType.Equals(typeof(byte[])))
                    {
                        StringBuilder byteArrayBuilder = new StringBuilder(string.Format("DECLARE @{0} byte[] = new byte[] {{", paramVar));
                        byte[] byteArray = (byte[])param.Value;

                        if (byteArray.Length > 0)
                        {
                            foreach (byte b in byteArray)
                            {
                                byteArrayBuilder.Append(string.Format("\n  {0},", b.ToString()));
                            }

                            byteArrayBuilder.Append("\n};\n");
                        }
                        else
                        {
                            byteArrayBuilder.Append(" };\n");
                        }

                        paramBuilder.Append(byteArrayBuilder.ToString());
                    }
                    else
                    {
                        throw new CloudException(string.Format(Resources.InvalidScriptParameterType,
                            paramType.ToString()));
                    }
                }

                Script = Script.Insert(0, paramBuilder.ToString());
            }

            JobType jobType;
            CreateJobProperties properties;
            if (USql)
            {
                jobType = JobType.USql;
                var sqlIpProperties = new CreateUSqlJobProperties
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

            if (CompileOnly)
            {
                var buildJobParameters = new BuildJobParameters
                {
                    Type = jobType,
                    Name = Name,
                    Properties = properties
                };

                WriteObject(DataLakeAnalyticsClient.BuildJob(Account, buildJobParameters));
            }
            else
            {
                var jobId = DataLakeAnalyticsClient.JobIdQueue.Count == 0 ? Guid.NewGuid() : DataLakeAnalyticsClient.JobIdQueue.Dequeue();

                var createJobParameters = new CreateJobParameters
                {
                    Type = jobType,
                    Name = Name,
                    DegreeOfParallelism = AnalyticsUnits,
                    Priority = Priority,
                    Properties = properties,
                };

                if (ParameterSetName.Equals(USqlJobParameterSetNameAndRecurrence) ||
                        ParameterSetName.Equals(USqlJobParameterSetNameAndPipeline) ||
                        ParameterSetName.Equals(USqlJobWithScriptPathAndRecurrence) ||
                        ParameterSetName.Equals(USqlJobWithScriptPathAndPipeline))
                {
                    createJobParameters.Related = new JobRelationshipProperties
                    {
                        RecurrenceId = RecurrenceId,
                        RecurrenceName = RecurrenceName
                    };

                    if (ParameterSetName.Equals(USqlJobParameterSetNameAndPipeline) ||
                        ParameterSetName.Equals(USqlJobWithScriptPathAndPipeline))
                    {
                        createJobParameters.Related.PipelineId = PipelineId;
                        createJobParameters.Related.PipelineName = PipelineName;
                        createJobParameters.Related.PipelineUri = PipelineUri;
                        createJobParameters.Related.RunId = RunId;
                    }
                }

                WriteObject(DataLakeAnalyticsClient.SubmitJob(Account, jobId, createJobParameters));
            }
        }
    }
}
