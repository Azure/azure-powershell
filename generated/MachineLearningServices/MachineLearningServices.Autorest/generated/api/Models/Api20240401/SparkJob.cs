// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Extensions;

    /// <summary>Spark job definition.</summary>
    public partial class SparkJob :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJob,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInternal,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBaseProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBaseProperties __jobBaseProperties = new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.JobBaseProperties();

        /// <summary>Backing field for <see cref="Archive" /> property.</summary>
        private string[] _archive;

        /// <summary>Archive files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string[] Archive { get => this._archive; set => this._archive = value; }

        /// <summary>Backing field for <see cref="Arg" /> property.</summary>
        private string _arg;

        /// <summary>Arguments for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string Arg { get => this._arg; set => this._arg = value; }

        /// <summary>Backing field for <see cref="CodeId" /> property.</summary>
        private string _codeId;

        /// <summary>[Required] arm-id of the code asset.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string CodeId { get => this._codeId; set => this._codeId = value; }

        /// <summary>ARM resource ID of the component resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string ComponentId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).ComponentId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).ComponentId = value ?? null; }

        /// <summary>ARM resource ID of the compute resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string ComputeId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).ComputeId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).ComputeId = value ?? null; }

        /// <summary>Backing field for <see cref="Conf" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobConf _conf;

        /// <summary>Spark configured properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobConf Conf { get => (this._conf = this._conf ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkJobConf()); set => this._conf = value; }

        /// <summary>The asset description text.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseInternal)__jobBaseProperties).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseInternal)__jobBaseProperties).Description = value ?? null; }

        /// <summary>Display name of job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).DisplayName = value ?? null; }

        /// <summary>Backing field for <see cref="Entry" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEntry _entry;

        /// <summary>[Required] The entry to execute on startup of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEntry Entry { get => (this._entry = this._entry ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkJobEntry()); set => this._entry = value; }

        /// <summary>[Required] Type of the job's entry point.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.SparkJobEntryType EntrySparkJobEntryType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEntryInternal)Entry).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEntryInternal)Entry).Type = value ; }

        /// <summary>Backing field for <see cref="EnvironmentId" /> property.</summary>
        private string _environmentId;

        /// <summary>The ARM resource ID of the Environment specification for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string EnvironmentId { get => this._environmentId; set => this._environmentId = value; }

        /// <summary>Backing field for <see cref="EnvironmentVariable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEnvironmentVariables _environmentVariable;

        /// <summary>Environment variables included in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEnvironmentVariables EnvironmentVariable { get => (this._environmentVariable = this._environmentVariable ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkJobEnvironmentVariables()); set => this._environmentVariable = value; }

        /// <summary>
        /// The name of the experiment the job belongs to. If not set, the job is placed in the "Default" experiment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string ExperimentName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).ExperimentName; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).ExperimentName = value ?? null; }

        /// <summary>Backing field for <see cref="File" /> property.</summary>
        private string[] _file;

        /// <summary>Files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string[] File { get => this._file; set => this._file = value; }

        /// <summary>
        /// Identity configuration. If set, this should be one of AmlToken, ManagedIdentity, UserIdentity or null.
        /// Defaults to AmlToken if null.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IIdentityConfiguration Identity { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).Identity; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).Identity = value ?? null /* model class */; }

        /// <summary>[Required] Specifies the type of identity framework.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.IdentityConfigurationType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).IdentityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).IdentityType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.IdentityConfigurationType)""); }

        /// <summary>Backing field for <see cref="Input" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInputs _input;

        /// <summary>Mapping of input data bindings used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInputs Input { get => (this._input = this._input ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkJobInputs()); set => this._input = value; }

        /// <summary>Is the asset archived?</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public bool? IsArchived { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).IsArchived; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).IsArchived = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Jar" /> property.</summary>
        private string[] _jar;

        /// <summary>Jar files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string[] Jar { get => this._jar; set => this._jar = value; }

        /// <summary>[Required] Specifies the type of job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobType JobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).JobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).JobType = value ; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobStatus? Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).Status = value; }

        /// <summary>Internal Acessors for Entry</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEntry Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInternal.Entry { get => (this._entry = this._entry ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkJobEntry()); set { {_entry = value;} } }

        /// <summary>Internal Acessors for QueueSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IQueueSettings Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInternal.QueueSetting { get => (this._queueSetting = this._queueSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.QueueSettings()); set { {_queueSetting = value;} } }

        /// <summary>Internal Acessors for Resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfiguration Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInternal.Resource { get => (this._resource = this._resource ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkResourceConfiguration()); set { {_resource = value;} } }

        /// <summary>Notification setting for the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.INotificationSetting NotificationSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSetting = value ?? null /* model class */; }

        /// <summary>
        /// This is the email recipient list which has a limitation of 499 characters in total concat with comma separator
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public string[] NotificationSettingEmail { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSettingEmail; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSettingEmail = value ?? null /* arrayOf */; }

        /// <summary>Send email notification to user on specified notification type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EmailNotificationEnableType[] NotificationSettingEmailOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSettingEmailOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSettingEmailOn = value ?? null /* arrayOf */; }

        /// <summary>
        /// Send webhook callback to a service. Key is a user-provided name for the webhook.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.INotificationSettingWebhooks NotificationSettingWebhook { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSettingWebhook; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).NotificationSettingWebhook = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="Output" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobOutputs _output;

        /// <summary>Mapping of output data bindings used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobOutputs Output { get => (this._output = this._output ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkJobOutputs()); set => this._output = value; }

        /// <summary>The asset property dictionary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseProperties Property { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseInternal)__jobBaseProperties).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseInternal)__jobBaseProperties).Property = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="PyFile" /> property.</summary>
        private string[] _pyFile;

        /// <summary>Python files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        public string[] PyFile { get => this._pyFile; set => this._pyFile = value; }

        /// <summary>Backing field for <see cref="QueueSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IQueueSettings _queueSetting;

        /// <summary>Queue settings for the job</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IQueueSettings QueueSetting { get => (this._queueSetting = this._queueSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.QueueSettings()); set => this._queueSetting = value; }

        /// <summary>Controls the compute job tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobTier? QueueSettingJobTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IQueueSettingsInternal)QueueSetting).JobTier; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IQueueSettingsInternal)QueueSetting).JobTier = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobTier)""); }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfiguration _resource;

        /// <summary>Compute Resource configuration for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfiguration Resource { get => (this._resource = this._resource ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.SparkResourceConfiguration()); set => this._resource = value; }

        /// <summary>Optional type of VM used as supported by the compute target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public string ResourceInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfigurationInternal)Resource).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfigurationInternal)Resource).InstanceType = value ?? null; }

        /// <summary>Version of spark runtime used for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inlined)]
        public string ResourceRuntimeVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfigurationInternal)Resource).RuntimeVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfigurationInternal)Resource).RuntimeVersion = value ?? null; }

        /// <summary>
        /// List of JobEndpoints.
        /// For local jobs, a job endpoint will have an endpoint value of FileStreamObject.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBaseServices Service { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).Service; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).Service = value ?? null /* model class */; }

        /// <summary>Status of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal)__jobBaseProperties).Status; }

        /// <summary>Tag dictionary. Tags can be added, removed, and updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseInternal)__jobBaseProperties).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseInternal)__jobBaseProperties).Tag = value ?? null /* model class */; }

        /// <summary>Creates an new <see cref="SparkJob" /> instance.</summary>
        public SparkJob()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__jobBaseProperties), __jobBaseProperties);
            await eventListener.AssertObjectIsValid(nameof(__jobBaseProperties), __jobBaseProperties);
        }
    }
    /// Spark job definition.
    public partial interface ISparkJob :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBaseProperties
    {
        /// <summary>Archive files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Archive files used in the job.",
        SerializedName = @"archives",
        PossibleTypes = new [] { typeof(string) })]
        string[] Archive { get; set; }
        /// <summary>Arguments for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Arguments for the job.",
        SerializedName = @"args",
        PossibleTypes = new [] { typeof(string) })]
        string Arg { get; set; }
        /// <summary>[Required] arm-id of the code asset.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"[Required] arm-id of the code asset.",
        SerializedName = @"codeId",
        PossibleTypes = new [] { typeof(string) })]
        string CodeId { get; set; }
        /// <summary>Spark configured properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Spark configured properties.",
        SerializedName = @"conf",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobConf) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobConf Conf { get; set; }
        /// <summary>[Required] Type of the job's entry point.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"[Required] Type of the job's entry point.",
        SerializedName = @"sparkJobEntryType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.SparkJobEntryType) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.SparkJobEntryType EntrySparkJobEntryType { get; set; }
        /// <summary>The ARM resource ID of the Environment specification for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM resource ID of the Environment specification for the job.",
        SerializedName = @"environmentId",
        PossibleTypes = new [] { typeof(string) })]
        string EnvironmentId { get; set; }
        /// <summary>Environment variables included in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Environment variables included in the job.",
        SerializedName = @"environmentVariables",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEnvironmentVariables) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEnvironmentVariables EnvironmentVariable { get; set; }
        /// <summary>Files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Files used in the job.",
        SerializedName = @"files",
        PossibleTypes = new [] { typeof(string) })]
        string[] File { get; set; }
        /// <summary>Mapping of input data bindings used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mapping of input data bindings used in the job.",
        SerializedName = @"inputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInputs) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInputs Input { get; set; }
        /// <summary>Jar files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Jar files used in the job.",
        SerializedName = @"jars",
        PossibleTypes = new [] { typeof(string) })]
        string[] Jar { get; set; }
        /// <summary>Mapping of output data bindings used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mapping of output data bindings used in the job.",
        SerializedName = @"outputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobOutputs) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobOutputs Output { get; set; }
        /// <summary>Python files used in the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Python files used in the job.",
        SerializedName = @"pyFiles",
        PossibleTypes = new [] { typeof(string) })]
        string[] PyFile { get; set; }
        /// <summary>Controls the compute job tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Controls the compute job tier",
        SerializedName = @"jobTier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobTier? QueueSettingJobTier { get; set; }
        /// <summary>Optional type of VM used as supported by the compute target.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional type of VM used as supported by the compute target.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceInstanceType { get; set; }
        /// <summary>Version of spark runtime used for the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of spark runtime used for the job.",
        SerializedName = @"runtimeVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceRuntimeVersion { get; set; }

    }
    /// Spark job definition.
    internal partial interface ISparkJobInternal :
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IJobBasePropertiesInternal
    {
        /// <summary>Archive files used in the job.</summary>
        string[] Archive { get; set; }
        /// <summary>Arguments for the job.</summary>
        string Arg { get; set; }
        /// <summary>[Required] arm-id of the code asset.</summary>
        string CodeId { get; set; }
        /// <summary>Spark configured properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobConf Conf { get; set; }
        /// <summary>[Required] The entry to execute on startup of the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEntry Entry { get; set; }
        /// <summary>[Required] Type of the job's entry point.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.SparkJobEntryType EntrySparkJobEntryType { get; set; }
        /// <summary>The ARM resource ID of the Environment specification for the job.</summary>
        string EnvironmentId { get; set; }
        /// <summary>Environment variables included in the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobEnvironmentVariables EnvironmentVariable { get; set; }
        /// <summary>Files used in the job.</summary>
        string[] File { get; set; }
        /// <summary>Mapping of input data bindings used in the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobInputs Input { get; set; }
        /// <summary>Jar files used in the job.</summary>
        string[] Jar { get; set; }
        /// <summary>Mapping of output data bindings used in the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkJobOutputs Output { get; set; }
        /// <summary>Python files used in the job.</summary>
        string[] PyFile { get; set; }
        /// <summary>Queue settings for the job</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IQueueSettings QueueSetting { get; set; }
        /// <summary>Controls the compute job tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.JobTier? QueueSettingJobTier { get; set; }
        /// <summary>Compute Resource configuration for the job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.ISparkResourceConfiguration Resource { get; set; }
        /// <summary>Optional type of VM used as supported by the compute target.</summary>
        string ResourceInstanceType { get; set; }
        /// <summary>Version of spark runtime used for the job.</summary>
        string ResourceRuntimeVersion { get; set; }

    }
}