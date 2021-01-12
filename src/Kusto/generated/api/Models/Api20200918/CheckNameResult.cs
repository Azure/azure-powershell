namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The result returned from a check name availability request.</summary>
    public partial class CheckNameResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ICheckNameResult,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ICheckNameResultInternal
    {

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>
        /// Message indicating an unavailable name due to a conflict, or a description of the naming rules that are violated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name that was checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="NameAvailable" /> property.</summary>
        private bool? _nameAvailable;

        /// <summary>Specifies a Boolean value that indicates if the name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public bool? NameAvailable { get => this._nameAvailable; set => this._nameAvailable = value; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Reason? _reason;

        /// <summary>Message providing the reason why the given name is invalid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Reason? Reason { get => this._reason; set => this._reason = value; }

        /// <summary>Creates an new <see cref="CheckNameResult" /> instance.</summary>
        public CheckNameResult()
        {

        }
    }
    /// The result returned from a check name availability request.
    public partial interface ICheckNameResult :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Message indicating an unavailable name due to a conflict, or a description of the naming rules that are violated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message indicating an unavailable name due to a conflict, or a description of the naming rules that are violated.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>The name that was checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name that was checked.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Specifies a Boolean value that indicates if the name is available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies a Boolean value that indicates if the name is available.",
        SerializedName = @"nameAvailable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NameAvailable { get; set; }
        /// <summary>Message providing the reason why the given name is invalid.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Message providing the reason why the given name is invalid.",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Reason) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Reason? Reason { get; set; }

    }
    /// The result returned from a check name availability request.
    internal partial interface ICheckNameResultInternal

    {
        /// <summary>
        /// Message indicating an unavailable name due to a conflict, or a description of the naming rules that are violated.
        /// </summary>
        string Message { get; set; }
        /// <summary>The name that was checked.</summary>
        string Name { get; set; }
        /// <summary>Specifies a Boolean value that indicates if the name is available.</summary>
        bool? NameAvailable { get; set; }
        /// <summary>Message providing the reason why the given name is invalid.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Reason? Reason { get; set; }

    }
}