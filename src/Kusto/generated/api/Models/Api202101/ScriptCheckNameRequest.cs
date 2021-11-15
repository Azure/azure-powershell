namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A script name availability request.</summary>
    public partial class ScriptCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptCheckNameRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptCheckNameRequestInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IScriptCheckNameRequestInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Script name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type= @"Microsoft.Kusto/Clusters/Databases/scripts";

        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/scripts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ScriptCheckNameRequest" /> instance.</summary>
        public ScriptCheckNameRequest()
        {

        }
    }
    /// A script name availability request.
    public partial interface IScriptCheckNameRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Script name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Script name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/scripts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"The type of resource, Microsoft.Kusto/Clusters/Databases/scripts.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// A script name availability request.
    internal partial interface IScriptCheckNameRequestInternal

    {
        /// <summary>Script name.</summary>
        string Name { get; set; }
        /// <summary>The type of resource, Microsoft.Kusto/Clusters/Databases/scripts.</summary>
        string Type { get; set; }

    }
}