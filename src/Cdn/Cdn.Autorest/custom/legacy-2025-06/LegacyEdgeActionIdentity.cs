namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models
{
    public partial class CdnIdentity
    {
        private string _edgeActionName;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string EdgeActionName { get => this._edgeActionName; set => this._edgeActionName = value; }

        private string _version;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        private string _executionFilter;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string ExecutionFilter { get => this._executionFilter; set => this._executionFilter = value; }
    }

    public partial interface ICdnIdentity
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Edge Action",
        SerializedName = @"edgeActionName",
        PossibleTypes = new [] { typeof(string) })]
        string EdgeActionName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Edge Action version",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Edge Action execution filter",
        SerializedName = @"executionFilter",
        PossibleTypes = new [] { typeof(string) })]
        string ExecutionFilter { get; set; }
    }

    internal partial interface ICdnIdentityInternal
    {
        string EdgeActionName { get; set; }
        string Version { get; set; }
        string ExecutionFilter { get; set; }
    }
}