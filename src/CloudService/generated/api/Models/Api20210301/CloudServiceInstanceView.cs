namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>InstanceView of CloudService as a whole</summary>
    public partial class CloudServiceInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceView,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceViewInternal
    {

        /// <summary>Internal Acessors for PrivateId</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceViewInternal.PrivateId { get => this._privateId; set { {_privateId = value;} } }

        /// <summary>Internal Acessors for RoleInstance</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummary Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceViewInternal.RoleInstance { get => (this._roleInstance = this._roleInstance ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InstanceViewStatusesSummary()); set { {_roleInstance = value;} } }

        /// <summary>Internal Acessors for RoleInstanceStatusesSummary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceViewInternal.RoleInstanceStatusesSummary { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummaryInternal)RoleInstance).StatusesSummary; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummaryInternal)RoleInstance).StatusesSummary = value; }

        /// <summary>Internal Acessors for SdkVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceViewInternal.SdkVersion { get => this._sdkVersion; set { {_sdkVersion = value;} } }

        /// <summary>Internal Acessors for Statuses</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceViewInternal.Statuses { get => this._statuses; set { {_statuses = value;} } }

        /// <summary>Backing field for <see cref="PrivateId" /> property.</summary>
        private string[] _privateId;

        /// <summary>
        /// Specifies a list of unique identifiers generated internally for the cloud service. <br /><br /> NOTE: If you are using
        /// Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string[] PrivateId { get => this._privateId; }

        /// <summary>Backing field for <see cref="RoleInstance" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummary _roleInstance;

        /// <summary>Instance view statuses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummary RoleInstance { get => (this._roleInstance = this._roleInstance ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InstanceViewStatusesSummary()); set => this._roleInstance = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 1)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] RoleInstanceStatusesSummary { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummaryInternal)RoleInstance).StatusesSummary; }

        /// <summary>Backing field for <see cref="SdkVersion" /> property.</summary>
        private string _sdkVersion;

        /// <summary>
        /// The version of the SDK that was used to generate the package for the cloud service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string SdkVersion { get => this._sdkVersion; }

        /// <summary>Backing field for <see cref="Statuses" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] _statuses;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 0)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] Statuses { get => this._statuses; }

        /// <summary>Creates an new <see cref="CloudServiceInstanceView" /> instance.</summary>
        public CloudServiceInstanceView()
        {

        }
    }
    /// InstanceView of CloudService as a whole
    public partial interface ICloudServiceInstanceView :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Specifies a list of unique identifiers generated internally for the cloud service. <br /><br /> NOTE: If you are using
        /// Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies a list of unique identifiers generated internally for the cloud service. <br /><br /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.",
        SerializedName = @"privateIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] PrivateId { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"statusesSummary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] RoleInstanceStatusesSummary { get;  }
        /// <summary>
        /// The version of the SDK that was used to generate the package for the cloud service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The version of the SDK that was used to generate the package for the cloud service.",
        SerializedName = @"sdkVersion",
        PossibleTypes = new [] { typeof(string) })]
        string SdkVersion { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"statuses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] Statuses { get;  }

    }
    /// InstanceView of CloudService as a whole
    internal partial interface ICloudServiceInstanceViewInternal

    {
        /// <summary>
        /// Specifies a list of unique identifiers generated internally for the cloud service. <br /><br /> NOTE: If you are using
        /// Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        string[] PrivateId { get; set; }
        /// <summary>Instance view statuses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceViewStatusesSummary RoleInstance { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IStatusCodeCount[] RoleInstanceStatusesSummary { get; set; }
        /// <summary>
        /// The version of the SDK that was used to generate the package for the cloud service.
        /// </summary>
        string SdkVersion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] Statuses { get; set; }

    }
}