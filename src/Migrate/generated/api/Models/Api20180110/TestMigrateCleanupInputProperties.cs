namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Test migrate cleanup input properties.</summary>
    public partial class TestMigrateCleanupInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestMigrateCleanupInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Comment" /> property.</summary>
        private string _comment;

        /// <summary>Test migrate cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Comment { get => this._comment; set => this._comment = value; }

        /// <summary>Creates an new <see cref="TestMigrateCleanupInputProperties" /> instance.</summary>
        public TestMigrateCleanupInputProperties()
        {

        }
    }
    /// Test migrate cleanup input properties.
    public partial interface ITestMigrateCleanupInputProperties :
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
    /// Test migrate cleanup input properties.
    internal partial interface ITestMigrateCleanupInputPropertiesInternal

    {
        /// <summary>Test migrate cleanup comments.</summary>
        string Comment { get; set; }

    }
}