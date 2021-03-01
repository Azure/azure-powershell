namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Subscriber detail</summary>
    public partial class UserDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal
    {

        /// <summary>Backing field for <see cref="EmailAddress" /> property.</summary>
        private string _emailAddress;

        /// <summary>Email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string EmailAddress { get => this._emailAddress; set => this._emailAddress = value; }

        /// <summary>Backing field for <see cref="FirstName" /> property.</summary>
        private string _firstName;

        /// <summary>First name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string FirstName { get => this._firstName; set => this._firstName = value; }

        /// <summary>Backing field for <see cref="LastName" /> property.</summary>
        private string _lastName;

        /// <summary>Last name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string LastName { get => this._lastName; set => this._lastName = value; }

        /// <summary>Creates an new <see cref="UserDetail" /> instance.</summary>
        public UserDetail()
        {

        }
    }
    /// Subscriber detail
    public partial interface IUserDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>Email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Email address",
        SerializedName = @"emailAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EmailAddress { get; set; }
        /// <summary>First name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"First name",
        SerializedName = @"firstName",
        PossibleTypes = new [] { typeof(string) })]
        string FirstName { get; set; }
        /// <summary>Last name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Last name",
        SerializedName = @"lastName",
        PossibleTypes = new [] { typeof(string) })]
        string LastName { get; set; }

    }
    /// Subscriber detail
    internal partial interface IUserDetailInternal

    {
        /// <summary>Email address</summary>
        string EmailAddress { get; set; }
        /// <summary>First name</summary>
        string FirstName { get; set; }
        /// <summary>Last name</summary>
        string LastName { get; set; }

    }
}