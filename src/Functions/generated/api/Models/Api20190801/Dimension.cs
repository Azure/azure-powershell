namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Dimension of a resource metric. For e.g. instance specific HTTP requests for a web app,
    /// where instance name is dimension of the metric HTTP request
    /// </summary>
    public partial class Dimension :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDimension,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDimensionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimension"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimension __dimension = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.Dimension();

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimensionInternal)__dimension).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimensionInternal)__dimension).DisplayName = value; }

        /// <summary>Backing field for <see cref="InternalName" /> property.</summary>
        private string _internalName;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InternalName { get => this._internalName; set => this._internalName = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimensionInternal)__dimension).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimensionInternal)__dimension).Name = value; }

        /// <summary>Backing field for <see cref="ToBeExportedForShoebox" /> property.</summary>
        private bool? _toBeExportedForShoebox;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ToBeExportedForShoebox { get => this._toBeExportedForShoebox; set => this._toBeExportedForShoebox = value; }

        /// <summary>Creates an new <see cref="Dimension" /> instance.</summary>
        public Dimension()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__dimension), __dimension);
            await eventListener.AssertObjectIsValid(nameof(__dimension), __dimension);
        }
    }
    /// Dimension of a resource metric. For e.g. instance specific HTTP requests for a web app,
    /// where instance name is dimension of the metric HTTP request
    public partial interface IDimension :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimension
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"internalName",
        PossibleTypes = new [] { typeof(string) })]
        string InternalName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"toBeExportedForShoebox",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ToBeExportedForShoebox { get; set; }

    }
    /// Dimension of a resource metric. For e.g. instance specific HTTP requests for a web app,
    /// where instance name is dimension of the metric HTTP request
    internal partial interface IDimensionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IDimensionInternal
    {
        string InternalName { get; set; }

        bool? ToBeExportedForShoebox { get; set; }

    }
}