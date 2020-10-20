namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareV2 fabric specific details.</summary>
    public partial class VMwareV2FabricSpecificDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails __fabricSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetails();

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)__fabricSpecificDetails).InstanceType = value; }

        /// <summary>Internal Acessors for MigrationSolutionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal.MigrationSolutionId { get => this._migrationSolutionId; set { {_migrationSolutionId = value;} } }

        /// <summary>Internal Acessors for PhysicalSiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal.PhysicalSiteId { get => this._physicalSiteId; set { {_physicalSiteId = value;} } }

        /// <summary>Internal Acessors for ServiceEndpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal.ServiceEndpoint { get => this._serviceEndpoint; set { {_serviceEndpoint = value;} } }

        /// <summary>Internal Acessors for ServiceResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal.ServiceResourceId { get => this._serviceResourceId; set { {_serviceResourceId = value;} } }

        /// <summary>Internal Acessors for VmwareSiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal.VmwareSiteId { get => this._vmwareSiteId; set { {_vmwareSiteId = value;} } }

        /// <summary>Backing field for <see cref="MigrationSolutionId" /> property.</summary>
        private string _migrationSolutionId;

        /// <summary>The Migration solution ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MigrationSolutionId { get => this._migrationSolutionId; }

        /// <summary>Backing field for <see cref="PhysicalSiteId" /> property.</summary>
        private string _physicalSiteId;

        /// <summary>The ARM Id of the physical site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PhysicalSiteId { get => this._physicalSiteId; }

        /// <summary>Backing field for <see cref="ServiceEndpoint" /> property.</summary>
        private string _serviceEndpoint;

        /// <summary>The service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServiceEndpoint { get => this._serviceEndpoint; }

        /// <summary>Backing field for <see cref="ServiceResourceId" /> property.</summary>
        private string _serviceResourceId;

        /// <summary>The service resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ServiceResourceId { get => this._serviceResourceId; }

        /// <summary>Backing field for <see cref="VmwareSiteId" /> property.</summary>
        private string _vmwareSiteId;

        /// <summary>The ARM Id of the VMware site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VmwareSiteId { get => this._vmwareSiteId; }

        /// <summary>Creates an new <see cref="VMwareV2FabricSpecificDetails" /> instance.</summary>
        public VMwareV2FabricSpecificDetails()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__fabricSpecificDetails), __fabricSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__fabricSpecificDetails), __fabricSpecificDetails);
        }
    }
    /// VMwareV2 fabric specific details.
    public partial interface IVMwareV2FabricSpecificDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails
    {
        /// <summary>The Migration solution ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Migration solution ARM Id.",
        SerializedName = @"migrationSolutionId",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationSolutionId { get;  }
        /// <summary>The ARM Id of the physical site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ARM Id of the physical site.",
        SerializedName = @"physicalSiteId",
        PossibleTypes = new [] { typeof(string) })]
        string PhysicalSiteId { get;  }
        /// <summary>The service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The service endpoint.",
        SerializedName = @"serviceEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceEndpoint { get;  }
        /// <summary>The service resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The service resource Id.",
        SerializedName = @"serviceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceResourceId { get;  }
        /// <summary>The ARM Id of the VMware site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ARM Id of the VMware site.",
        SerializedName = @"vmwareSiteId",
        PossibleTypes = new [] { typeof(string) })]
        string VmwareSiteId { get;  }

    }
    /// VMwareV2 fabric specific details.
    internal partial interface IVMwareV2FabricSpecificDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal
    {
        /// <summary>The Migration solution ARM Id.</summary>
        string MigrationSolutionId { get; set; }
        /// <summary>The ARM Id of the physical site.</summary>
        string PhysicalSiteId { get; set; }
        /// <summary>The service endpoint.</summary>
        string ServiceEndpoint { get; set; }
        /// <summary>The service resource Id.</summary>
        string ServiceResourceId { get; set; }
        /// <summary>The ARM Id of the VMware site.</summary>
        string VmwareSiteId { get; set; }

    }
}