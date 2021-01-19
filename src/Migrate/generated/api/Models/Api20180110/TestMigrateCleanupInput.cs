namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input for test migrate cleanup.</summary>
    public partial class TestMigrateCleanupInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputInternal
    {

        /// <summary>Test migrate cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Comment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputPropertiesInternal)Property).Comment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputPropertiesInternal)Property).Comment = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestMigrateCleanupInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputProperties _property;

        /// <summary>Test migrate cleanup input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestMigrateCleanupInputProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="TestMigrateCleanupInput" /> instance.</summary>
        public TestMigrateCleanupInput()
        {

        }
    }
    /// Input for test migrate cleanup.
    public partial interface ITestMigrateCleanupInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Test migrate cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Test migrate cleanup comments.",
        SerializedName = @"comments",
        PossibleTypes = new [] { typeof(string) })]
        string Comment { get; set; }

    }
    /// Input for test migrate cleanup.
    internal partial interface ITestMigrateCleanupInputInternal

    {
        /// <summary>Test migrate cleanup comments.</summary>
        string Comment { get; set; }
        /// <summary>Test migrate cleanup input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputProperties Property { get; set; }

    }
}