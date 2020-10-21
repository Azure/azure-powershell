namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Job REST Resource.</summary>
    public partial class VMwareJob :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJob,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal
    {

        /// <summary>Activity Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ActivityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).ActivityId; }

        /// <summary>Client request Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ClientRequestId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).ClientRequestId; }

        /// <summary>Display name of the Job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).DisplayName; }

        /// <summary>Operation end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).EndTime; }

        /// <summary>Errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).Error; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for ActivityId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.ActivityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).ActivityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).ActivityId = value; }

        /// <summary>Internal Acessors for ClientRequestId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.ClientRequestId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).ClientRequestId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).ClientRequestId = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for EndTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).EndTime = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).Error = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.JobProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for StartTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).StartTime = value; }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobProperties _property;

        /// <summary>Nested properties of job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.JobProperties()); }

        /// <summary>Operation start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).StartTime; }

        /// <summary>Operation status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobPropertiesInternal)Property).Status; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/Jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="VMwareJob" /> instance.</summary>
        public VMwareJob()
        {

        }
    }
    /// Job REST Resource.
    public partial interface IVMwareJob :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Activity Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Activity Id used in the operation execution context.",
        SerializedName = @"activityId",
        PossibleTypes = new [] { typeof(string) })]
        string ActivityId { get;  }
        /// <summary>Client request Id used in the operation execution context.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Client request Id used in the operation execution context.",
        SerializedName = @"clientRequestId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientRequestId { get;  }
        /// <summary>Display name of the Job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name of the Job.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Operation end time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation end time.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(string) })]
        string EndTime { get;  }
        /// <summary>Errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Errors.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Error { get;  }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of the job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the job.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Operation start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation start time.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string StartTime { get;  }
        /// <summary>Operation status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Operation status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/Jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/VMWareSites/Jobs.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Job REST Resource.
    internal partial interface IVMwareJobInternal

    {
        /// <summary>Activity Id used in the operation execution context.</summary>
        string ActivityId { get; set; }
        /// <summary>Client request Id used in the operation execution context.</summary>
        string ClientRequestId { get; set; }
        /// <summary>Display name of the Job.</summary>
        string DisplayName { get; set; }
        /// <summary>Operation end time.</summary>
        string EndTime { get; set; }
        /// <summary>Errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IErrorDetails[] Error { get; set; }
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Name of the job.</summary>
        string Name { get; set; }
        /// <summary>Nested properties of job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IJobProperties Property { get; set; }
        /// <summary>Operation start time.</summary>
        string StartTime { get; set; }
        /// <summary>Operation status.</summary>
        string Status { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/Jobs.</summary>
        string Type { get; set; }

    }
}