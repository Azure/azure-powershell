namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Extensions;

    /// <summary>Represents a SessionHost definition.</summary>
    public partial class SessionHost :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHost,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.Resource();

        /// <summary>Version of agent on SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string AgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).AgentVersion = value; }

        /// <summary>Allow a new session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public bool? AllowNewSession { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).AllowNewSession; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).AllowNewSession = value; }

        /// <summary>User assigned to SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string AssignedUser { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).AssignedUser; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).AssignedUser = value; }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Last heart beat from SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastHeartBeat { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).LastHeartBeat; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).LastHeartBeat = value; }

        /// <summary>The timestamp of the last update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastUpdateTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).LastUpdateTime; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for LastUpdateTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostInternal.LastUpdateTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).LastUpdateTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).LastUpdateTime = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostProperties Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.SessionHostProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostInternal.ResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).ResourceId = value; }

        /// <summary>Internal Acessors for StatusTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostInternal.StatusTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).StatusTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).StatusTimestamp = value; }

        /// <summary>Internal Acessors for VirtualMachineId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostInternal.VirtualMachineId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).VirtualMachineId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).VirtualMachineId = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>The version of the OS on the session host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string OSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).OSVersion = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostProperties _property;

        /// <summary>Detailed properties for SessionHost</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.SessionHostProperties()); set => this._property = value; }

        /// <summary>Resource Id of SessionHost's underlying virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string ResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).ResourceId; }

        /// <summary>Number of sessions on SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public int? Session { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).Session; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).Session = value; }

        /// <summary>Status for a SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.Status? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).Status = value; }

        /// <summary>The timestamp of the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public global::System.DateTime? StatusTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).StatusTimestamp; }

        /// <summary>The version of the side by side stack on the session host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string SxSStackVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).SxSStackVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).SxSStackVersion = value; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string UpdateErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).UpdateErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).UpdateErrorMessage = value; }

        /// <summary>Update state of a SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.UpdateState? UpdateState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).UpdateState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).UpdateState = value; }

        /// <summary>Virtual Machine Id of SessionHost's underlying virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Origin(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.PropertyOrigin.Inlined)]
        public string VirtualMachineId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostPropertiesInternal)Property).VirtualMachineId; }

        /// <summary>Creates an new <see cref="SessionHost" /> instance.</summary>
        public SessionHost()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Represents a SessionHost definition.
    public partial interface ISessionHost :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResource
    {
        /// <summary>Version of agent on SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of agent on SessionHost.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string AgentVersion { get; set; }
        /// <summary>Allow a new session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allow a new session.",
        SerializedName = @"allowNewSession",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowNewSession { get; set; }
        /// <summary>User assigned to SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"User assigned to SessionHost.",
        SerializedName = @"assignedUser",
        PossibleTypes = new [] { typeof(string) })]
        string AssignedUser { get; set; }
        /// <summary>Last heart beat from SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Last heart beat from SessionHost.",
        SerializedName = @"lastHeartBeat",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastHeartBeat { get; set; }
        /// <summary>The timestamp of the last update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp of the last update.",
        SerializedName = @"lastUpdateTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdateTime { get;  }
        /// <summary>The version of the OS on the session host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of the OS on the session host.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get; set; }
        /// <summary>Resource Id of SessionHost's underlying virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id of SessionHost's underlying virtual machine.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get;  }
        /// <summary>Number of sessions on SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of sessions on SessionHost.",
        SerializedName = @"sessions",
        PossibleTypes = new [] { typeof(int) })]
        int? Session { get; set; }
        /// <summary>Status for a SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status for a SessionHost.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.Status? Status { get; set; }
        /// <summary>The timestamp of the status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp of the status.",
        SerializedName = @"statusTimestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StatusTimestamp { get;  }
        /// <summary>The version of the side by side stack on the session host.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of the side by side stack on the session host.",
        SerializedName = @"sxSStackVersion",
        PossibleTypes = new [] { typeof(string) })]
        string SxSStackVersion { get; set; }
        /// <summary>The error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The error message.",
        SerializedName = @"updateErrorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string UpdateErrorMessage { get; set; }
        /// <summary>Update state of a SessionHost.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Update state of a SessionHost.",
        SerializedName = @"updateState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.UpdateState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.UpdateState? UpdateState { get; set; }
        /// <summary>Virtual Machine Id of SessionHost's underlying virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual Machine Id of SessionHost's underlying virtual machine.",
        SerializedName = @"virtualMachineId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualMachineId { get;  }

    }
    /// Represents a SessionHost definition.
    internal partial interface ISessionHostInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api10.IResourceInternal
    {
        /// <summary>Version of agent on SessionHost.</summary>
        string AgentVersion { get; set; }
        /// <summary>Allow a new session.</summary>
        bool? AllowNewSession { get; set; }
        /// <summary>User assigned to SessionHost.</summary>
        string AssignedUser { get; set; }
        /// <summary>Last heart beat from SessionHost.</summary>
        global::System.DateTime? LastHeartBeat { get; set; }
        /// <summary>The timestamp of the last update.</summary>
        global::System.DateTime? LastUpdateTime { get; set; }
        /// <summary>The version of the OS on the session host.</summary>
        string OSVersion { get; set; }
        /// <summary>Detailed properties for SessionHost</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.ISessionHostProperties Property { get; set; }
        /// <summary>Resource Id of SessionHost's underlying virtual machine.</summary>
        string ResourceId { get; set; }
        /// <summary>Number of sessions on SessionHost.</summary>
        int? Session { get; set; }
        /// <summary>Status for a SessionHost.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.Status? Status { get; set; }
        /// <summary>The timestamp of the status.</summary>
        global::System.DateTime? StatusTimestamp { get; set; }
        /// <summary>The version of the side by side stack on the session host.</summary>
        string SxSStackVersion { get; set; }
        /// <summary>The error message.</summary>
        string UpdateErrorMessage { get; set; }
        /// <summary>Update state of a SessionHost.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.UpdateState? UpdateState { get; set; }
        /// <summary>Virtual Machine Id of SessionHost's underlying virtual machine.</summary>
        string VirtualMachineId { get; set; }

    }
}