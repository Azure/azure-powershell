namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>Solution properties supported by the OperationsManagement resource provider.</summary>
    public partial class SolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ContainedResource" /> property.</summary>
        private string[] _containedResource;

        /// <summary>
        /// The azure resources that will be contained within the solutions. They will be locked and gets deleted automatically when
        /// the solution is deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string[] ContainedResource { get => this._containedResource; set => this._containedResource = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state for the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ReferencedResource" /> property.</summary>
        private string[] _referencedResource;

        /// <summary>
        /// The resources that will be referenced from this solution. Deleting any of those solution out of band will break the solution.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string[] ReferencedResource { get => this._referencedResource; set => this._referencedResource = value; }

        /// <summary>Backing field for <see cref="WorkspaceResourceId" /> property.</summary>
        private string _workspaceResourceId;

        /// <summary>
        /// The azure resourceId for the workspace where the solution will be deployed/enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string WorkspaceResourceId { get => this._workspaceResourceId; set => this._workspaceResourceId = value; }

        /// <summary>Creates an new <see cref="SolutionProperties" /> instance.</summary>
        public SolutionProperties()
        {

        }
    }
    /// Solution properties supported by the OperationsManagement resource provider.
    public partial interface ISolutionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The azure resources that will be contained within the solutions. They will be locked and gets deleted automatically when
        /// the solution is deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The azure resources that will be contained within the solutions. They will be locked and gets deleted automatically when the solution is deleted.",
        SerializedName = @"containedResources",
        PossibleTypes = new [] { typeof(string) })]
        string[] ContainedResource { get; set; }
        /// <summary>The provisioning state for the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state for the solution.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// The resources that will be referenced from this solution. Deleting any of those solution out of band will break the solution.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resources that will be referenced from this solution. Deleting any of those solution out of band will break the solution.",
        SerializedName = @"referencedResources",
        PossibleTypes = new [] { typeof(string) })]
        string[] ReferencedResource { get; set; }
        /// <summary>
        /// The azure resourceId for the workspace where the solution will be deployed/enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The azure resourceId for the workspace where the solution will be deployed/enabled.",
        SerializedName = @"workspaceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceResourceId { get; set; }

    }
    /// Solution properties supported by the OperationsManagement resource provider.
    internal partial interface ISolutionPropertiesInternal

    {
        /// <summary>
        /// The azure resources that will be contained within the solutions. They will be locked and gets deleted automatically when
        /// the solution is deleted.
        /// </summary>
        string[] ContainedResource { get; set; }
        /// <summary>The provisioning state for the solution.</summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// The resources that will be referenced from this solution. Deleting any of those solution out of band will break the solution.
        /// </summary>
        string[] ReferencedResource { get; set; }
        /// <summary>
        /// The azure resourceId for the workspace where the solution will be deployed/enabled.
        /// </summary>
        string WorkspaceResourceId { get; set; }

    }
}