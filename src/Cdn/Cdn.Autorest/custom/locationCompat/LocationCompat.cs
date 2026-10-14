namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models
{
    public partial interface ICustomDomain { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface ICustomDomainInternal { string Location { get; set; } }
    public partial class CustomDomain { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string ICustomDomainInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IOrigin { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IOriginInternal { string Location { get; set; } }
    public partial class Origin { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IOriginInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IOriginGroup { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IOriginGroupInternal { string Location { get; set; } }
    public partial class OriginGroup { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IOriginGroupInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IAfdDomain { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IAfdDomainInternal { string Location { get; set; } }
    public partial class AfdDomain { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IAfdDomainInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IAfdOrigin { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IAfdOriginInternal { string Location { get; set; } }
    public partial class AfdOrigin { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IAfdOriginInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IAfdOriginGroup { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IAfdOriginGroupInternal { string Location { get; set; } }
    public partial class AfdOriginGroup { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IAfdOriginGroupInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IRoute { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IRouteInternal { string Location { get; set; } }
    public partial class Route { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IRouteInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IRule { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IRuleInternal { string Location { get; set; } }
    public partial class Rule { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IRuleInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface ISecret { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface ISecretInternal { string Location { get; set; } }
    public partial class Secret { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string ISecretInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface ISecurityPolicy { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface ISecurityPolicyInternal { string Location { get; set; } }
    public partial class SecurityPolicy { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string ISecurityPolicyInternal.Location { get => this._location; set => this._location = value ?? null; } }

    public partial interface IMigrateResult { [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(Required = false, ReadOnly = true, Read = true, Create = false, Update = false, Description = @"The geo-location where the resource lives", SerializedName = @"location", PossibleTypes = new [] { typeof(string) })] string Location { get; } }
    internal partial interface IMigrateResultInternal { string Location { get; set; } }
    public partial class MigrateResult { private string _location; [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)] public string Location { get => this._location; set => this._location = value ?? null; } string IMigrateResultInternal.Location { get => this._location; set => this._location = value ?? null; } }
}
