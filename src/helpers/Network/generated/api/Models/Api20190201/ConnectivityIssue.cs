namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Information about an issue encountered in the process of checking for connectivity.
    /// </summary>
    public partial class ConnectivityIssue :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal
    {

        /// <summary>Backing field for <see cref="Context" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext[] _context;

        /// <summary>Provides additional context on the issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext[] Context { get => this._context; }

        /// <summary>Internal Acessors for Context</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal.Context { get => this._context; set { {_context = value;} } }

        /// <summary>Internal Acessors for Origin</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal.Origin { get => this._origin; set { {_origin = value;} } }

        /// <summary>Internal Acessors for Severity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal.Severity { get => this._severity; set { {_severity = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin? _origin;

        /// <summary>The origin of the issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin? Origin { get => this._origin; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity? _severity;

        /// <summary>The severity of the issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity? Severity { get => this._severity; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType? _type;

        /// <summary>The type of issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType? Type { get => this._type; }

        /// <summary>Creates an new <see cref="ConnectivityIssue" /> instance.</summary>
        public ConnectivityIssue()
        {

        }
    }
    /// Information about an issue encountered in the process of checking for connectivity.
    public partial interface IConnectivityIssue :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Provides additional context on the issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provides additional context on the issue.",
        SerializedName = @"context",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext[] Context { get;  }
        /// <summary>The origin of the issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The origin of the issue.",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin? Origin { get;  }
        /// <summary>The severity of the issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The severity of the issue.",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity? Severity { get;  }
        /// <summary>The type of issue.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of issue.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType? Type { get;  }

    }
    /// Information about an issue encountered in the process of checking for connectivity.
    internal partial interface IConnectivityIssueInternal

    {
        /// <summary>Provides additional context on the issue.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext[] Context { get; set; }
        /// <summary>The origin of the issue.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin? Origin { get; set; }
        /// <summary>The severity of the issue.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity? Severity { get; set; }
        /// <summary>The type of issue.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType? Type { get; set; }

    }
}