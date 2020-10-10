namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>CS Accounts Details.</summary>
    public partial class RunAsAccount :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccountInternal
    {

        /// <summary>Backing field for <see cref="AccountId" /> property.</summary>
        private string _accountId;

        /// <summary>The CS RunAs account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AccountId { get => this._accountId; set => this._accountId = value; }

        /// <summary>Backing field for <see cref="AccountName" /> property.</summary>
        private string _accountName;

        /// <summary>The CS RunAs account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AccountName { get => this._accountName; set => this._accountName = value; }

        /// <summary>Creates an new <see cref="RunAsAccount" /> instance.</summary>
        public RunAsAccount()
        {

        }
    }
    /// CS Accounts Details.
    public partial interface IRunAsAccount :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The CS RunAs account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CS RunAs account Id.",
        SerializedName = @"accountId",
        PossibleTypes = new [] { typeof(string) })]
        string AccountId { get; set; }
        /// <summary>The CS RunAs account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CS RunAs account name.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string AccountName { get; set; }

    }
    /// CS Accounts Details.
    internal partial interface IRunAsAccountInternal

    {
        /// <summary>The CS RunAs account Id.</summary>
        string AccountId { get; set; }
        /// <summary>The CS RunAs account name.</summary>
        string AccountName { get; set; }

    }
}