namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input definition for test failover cleanup.</summary>
    public partial class TestFailoverCleanupInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputInternal
    {

        /// <summary>Test failover cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Comment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputPropertiesInternal)Property).Comment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputPropertiesInternal)Property).Comment = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverCleanupInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputProperties _property;

        /// <summary>Test failover cleanup input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverCleanupInputProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="TestFailoverCleanupInput" /> instance.</summary>
        public TestFailoverCleanupInput()
        {

        }
    }
    /// Input definition for test failover cleanup.
    public partial interface ITestFailoverCleanupInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Test failover cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Test failover cleanup comments.",
        SerializedName = @"comments",
        PossibleTypes = new [] { typeof(string) })]
        string Comment { get; set; }

    }
    /// Input definition for test failover cleanup.
    internal partial interface ITestFailoverCleanupInputInternal

    {
        /// <summary>Test failover cleanup comments.</summary>
        string Comment { get; set; }
        /// <summary>Test failover cleanup input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputProperties Property { get; set; }

    }
}