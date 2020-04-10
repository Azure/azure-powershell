namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>The Value.</summary>
    public partial class WorkspaceCustomStringParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameter,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IWorkspaceCustomStringParameterInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? _type;

        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Type { get => this._type; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="WorkspaceCustomStringParameter" /> instance.</summary>
        public WorkspaceCustomStringParameter()
        {

        }
    }
    /// The Value.
    public partial interface IWorkspaceCustomStringParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>The type of variable that this is</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of variable that this is",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Type { get;  }
        /// <summary>The value which should be used for this field.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The value which should be used for this field.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// The Value.
    internal partial interface IWorkspaceCustomStringParameterInternal

    {
        /// <summary>The type of variable that this is</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Support.CustomParameterType? Type { get; set; }
        /// <summary>The value which should be used for this field.</summary>
        string Value { get; set; }

    }
}