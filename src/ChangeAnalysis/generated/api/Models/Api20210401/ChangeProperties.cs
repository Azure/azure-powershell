namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Extensions;

    /// <summary>The properties of a change.</summary>
    public partial class ChangeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangeProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IChangePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ChangeType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? _changeType;

        /// <summary>The type of the change.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get => this._changeType; set => this._changeType = value; }

        /// <summary>Backing field for <see cref="InitiatedByList" /> property.</summary>
        private string[] _initiatedByList;

        /// <summary>
        /// The list of identities who might initiated the change.
        /// The identity could be user name (email address) or the object ID of the Service Principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string[] InitiatedByList { get => this._initiatedByList; set => this._initiatedByList = value; }

        /// <summary>Backing field for <see cref="PropertyChange" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[] _propertyChange;

        /// <summary>The list of detailed changes at json property level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[] PropertyChange { get => this._propertyChange; set => this._propertyChange = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The resource id that the change is attached to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="TimeStamp" /> property.</summary>
        private global::System.DateTime? _timeStamp;

        /// <summary>The time when the change is detected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeStamp { get => this._timeStamp; set => this._timeStamp = value; }

        /// <summary>Creates an new <see cref="ChangeProperties" /> instance.</summary>
        public ChangeProperties()
        {

        }
    }
    /// The properties of a change.
    public partial interface IChangeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IJsonSerializable
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
    /// The properties of a change.
    internal partial interface IChangePropertiesInternal

    {
        /// <summary>The type of the change.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Support.ChangeType? ChangeType { get; set; }
        /// <summary>
        /// The list of identities who might initiated the change.
        /// The identity could be user name (email address) or the object ID of the Service Principal.
        /// </summary>
        string[] InitiatedByList { get; set; }
        /// <summary>The list of detailed changes at json property level.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IPropertyChange[] PropertyChange { get; set; }
        /// <summary>The resource id that the change is attached to.</summary>
        string ResourceId { get; set; }
        /// <summary>The time when the change is detected.</summary>
        global::System.DateTime? TimeStamp { get; set; }

    }
}