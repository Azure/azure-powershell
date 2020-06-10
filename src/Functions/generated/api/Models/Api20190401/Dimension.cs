namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Dimension of a resource metric. For e.g. instance specific HTTP requests for a web app,
    /// where instance name is dimension of the metric HTTP request
    /// </summary>
    public partial class Dimension :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimension,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimensionInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Dimension" /> instance.</summary>
        public Dimension()
        {

        }
    }
    /// Dimension of a resource metric. For e.g. instance specific HTTP requests for a web app,
    /// where instance name is dimension of the metric HTTP request
    public partial interface IDimension :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Dimension of a resource metric. For e.g. instance specific HTTP requests for a web app,
    /// where instance name is dimension of the metric HTTP request
    internal partial interface IDimensionInternal

    {
        string DisplayName { get; set; }

        string Name { get; set; }

    }
}