namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Input definition for test failover cleanup input properties.</summary>
    public partial class TestFailoverCleanupInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverCleanupInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Comment" /> property.</summary>
        private string _comment;

        /// <summary>Test failover cleanup comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Comment { get => this._comment; set => this._comment = value; }

        /// <summary>Creates an new <see cref="TestFailoverCleanupInputProperties" /> instance.</summary>
        public TestFailoverCleanupInputProperties()
        {

        }
    }
    /// Input definition for test failover cleanup input properties.
    public partial interface ITestFailoverCleanupInputProperties :
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
    /// Input definition for test failover cleanup input properties.
    internal partial interface ITestFailoverCleanupInputPropertiesInternal

    {
        /// <summary>Test failover cleanup comments.</summary>
        string Comment { get; set; }

    }
}