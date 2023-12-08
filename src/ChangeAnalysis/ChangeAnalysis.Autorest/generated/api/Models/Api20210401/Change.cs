namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Extensions;

    /// <summary>The detected change.</summary>
    public partial class Change :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChange,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.Resource();

        /// <summary>The type of the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).ChangeType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).ChangeType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType)""); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Id; }

        /// <summary>
        /// The list of identities who might initiated the change.
        /// The identity could be user name (email address) or the object ID of the Service Principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public string[] InitiatedByList { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).InitiatedByList; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).InitiatedByList = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangeProperties()); set { {_property = value;} } }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties _property;

        /// <summary>The properties of a change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ChangeProperties()); set => this._property = value; }

        /// <summary>The list of detailed changes at json property level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[] PropertyChange { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).PropertyChange; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).PropertyChange = value ?? null /* arrayOf */; }

        /// <summary>The resource id that the change is attached to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public string ResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).ResourceId = value ?? null; }

        /// <summary>The time when the change is detected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public global::System.DateTime? TimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).TimeStamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal)Property).TimeStamp = value ?? default(global::System.DateTime); }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="Change" /> instance.</summary>
        public Change()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// The detected change.
    public partial interface IChange :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResource
    {
        /// <summary>The type of the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the change.",
        SerializedName = @"changeType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get; set; }
        /// <summary>
        /// The list of identities who might initiated the change.
        /// The identity could be user name (email address) or the object ID of the Service Principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of identities who might initiated the change.
        The identity could be user name (email address) or the object ID of the Service Principal.",
        SerializedName = @"initiatedByList",
        PossibleTypes = new [] { typeof(string) })]
        string[] InitiatedByList { get; set; }
        /// <summary>The list of detailed changes at json property level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of detailed changes at json property level.",
        SerializedName = @"propertyChanges",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange) })]
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[] PropertyChange { get; set; }
        /// <summary>The resource id that the change is attached to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id that the change is attached to.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>The time when the change is detected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time when the change is detected.",
        SerializedName = @"timeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeStamp { get; set; }

    }
    /// The detected change.
    internal partial interface IChangeInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20.IResourceInternal
    {
        /// <summary>The type of the change.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get; set; }
        /// <summary>
        /// The list of identities who might initiated the change.
        /// The identity could be user name (email address) or the object ID of the Service Principal.
        /// </summary>
        string[] InitiatedByList { get; set; }
        /// <summary>The properties of a change.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties Property { get; set; }
        /// <summary>The list of detailed changes at json property level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[] PropertyChange { get; set; }
        /// <summary>The resource id that the change is attached to.</summary>
        string ResourceId { get; set; }
        /// <summary>The time when the change is detected.</summary>
        global::System.DateTime? TimeStamp { get; set; }

    }
}