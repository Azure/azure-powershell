namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>Parameter to pass to ARM template</summary>
    public partial class ArmTemplateParameter :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IArmTemplateParameter,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IArmTemplateParameterInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>name of the parameter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>value for the parameter. In Jtoken</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ArmTemplateParameter" /> instance.</summary>
        public ArmTemplateParameter()
        {

        }
    }
    /// Parameter to pass to ARM template
    public partial interface IArmTemplateParameter :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>name of the parameter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"name of the parameter.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>value for the parameter. In Jtoken</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"value for the parameter. In Jtoken ",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Parameter to pass to ARM template
    internal partial interface IArmTemplateParameterInternal

    {
        /// <summary>name of the parameter.</summary>
        string Name { get; set; }
        /// <summary>value for the parameter. In Jtoken</summary>
        string Value { get; set; }

    }
}