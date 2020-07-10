namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>The container for solution.</summary>
    public partial class Solution :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolution,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionInternal
    {

        /// <summary>
        /// The azure resources that will be contained within the solutions. They will be locked and gets deleted automatically when
        /// the solution is deleted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string[] ContainedResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).ContainedResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).ContainedResource = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.FormatTable(Index = 2)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Plan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlan Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionInternal.Plan { get => (this._plan = this._plan ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.SolutionPlan()); set { {_plan = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionProperties Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.SolutionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.FormatTable(Index = 0)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Plan" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlan _plan;

        /// <summary>
        /// Plan for solution object supported by the OperationsManagement resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlan Plan { get => (this._plan = this._plan ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.SolutionPlan()); set => this._plan = value; }

        /// <summary>
        /// name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName).
        /// SolutionType part is case sensitive. For third party solution, it can be anything.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string PlanName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).Name = value; }

        /// <summary>
        /// name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>.
        /// This is case sensitive
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string PlanProduct { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).Product; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).Product = value; }

        /// <summary>promotionCode, Not really used now, can you left as empty</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string PlanPromotionCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).PromotionCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).PromotionCode = value; }

        /// <summary>Publisher name. For gallery solution, it is Microsoft.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string PlanPublisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).Publisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlanInternal)Plan).Publisher = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionProperties _property;

        /// <summary>
        /// Properties for solution object supported by the OperationsManagement resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.SolutionProperties()); set => this._property = value; }

        /// <summary>The provisioning state for the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// The resources that will be referenced from this solution. Deleting any of those solution out of band will break the solution.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string[] ReferencedResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).ReferencedResource; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).ReferencedResource = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.SolutionTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.FormatTable(Index = 1)]
        public string Type { get => this._type; }

        /// <summary>
        /// The azure resourceId for the workspace where the solution will be deployed/enabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.DoNotFormat]
        public string WorkspaceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).WorkspaceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPropertiesInternal)Property).WorkspaceResourceId = value; }

        /// <summary>Creates an new <see cref="Solution" /> instance.</summary>
        public Solution()
        {

        }
    }
    /// The container for solution.
    public partial interface ISolution :
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
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName).
        /// SolutionType part is case sensitive. For third party solution, it can be anything.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName). SolutionType part is case sensitive. For third party solution, it can be anything.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PlanName { get; set; }
        /// <summary>
        /// name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>.
        /// This is case sensitive
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>. This is case sensitive",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string PlanProduct { get; set; }
        /// <summary>promotionCode, Not really used now, can you left as empty</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"promotionCode, Not really used now, can you left as empty",
        SerializedName = @"promotionCode",
        PossibleTypes = new [] { typeof(string) })]
        string PlanPromotionCode { get; set; }
        /// <summary>Publisher name. For gallery solution, it is Microsoft.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Publisher name. For gallery solution, it is Microsoft.",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string PlanPublisher { get; set; }
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
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags Tag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
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
    /// The container for solution.
    internal partial interface ISolutionInternal

    {
        /// <summary>
        /// The azure resources that will be contained within the solutions. They will be locked and gets deleted automatically when
        /// the solution is deleted.
        /// </summary>
        string[] ContainedResource { get; set; }
        /// <summary>Resource ID.</summary>
        string Id { get; set; }
        /// <summary>Resource location</summary>
        string Location { get; set; }
        /// <summary>Resource name.</summary>
        string Name { get; set; }
        /// <summary>
        /// Plan for solution object supported by the OperationsManagement resource provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionPlan Plan { get; set; }
        /// <summary>
        /// name of the solution to be created. For Microsoft published solution it should be in the format of solutionType(workspaceName).
        /// SolutionType part is case sensitive. For third party solution, it can be anything.
        /// </summary>
        string PlanName { get; set; }
        /// <summary>
        /// name of the solution to enabled/add. For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>.
        /// This is case sensitive
        /// </summary>
        string PlanProduct { get; set; }
        /// <summary>promotionCode, Not really used now, can you left as empty</summary>
        string PlanPromotionCode { get; set; }
        /// <summary>Publisher name. For gallery solution, it is Microsoft.</summary>
        string PlanPublisher { get; set; }
        /// <summary>
        /// Properties for solution object supported by the OperationsManagement resource provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionProperties Property { get; set; }
        /// <summary>The provisioning state for the solution.</summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// The resources that will be referenced from this solution. Deleting any of those solution out of band will break the solution.
        /// </summary>
        string[] ReferencedResource { get; set; }
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags Tag { get; set; }
        /// <summary>Resource type.</summary>
        string Type { get; set; }
        /// <summary>
        /// The azure resourceId for the workspace where the solution will be deployed/enabled.
        /// </summary>
        string WorkspaceResourceId { get; set; }

    }
}