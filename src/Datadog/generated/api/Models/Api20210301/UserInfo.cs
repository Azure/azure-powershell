namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>User info</summary>
    public partial class UserInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfoInternal
    {

        /// <summary>Backing field for <see cref="EmailAddress" /> property.</summary>
        private string _emailAddress;

        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string EmailAddress { get => this._emailAddress; set => this._emailAddress = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the user</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="PhoneNumber" /> property.</summary>
        private string _phoneNumber;

        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string PhoneNumber { get => this._phoneNumber; set => this._phoneNumber = value; }

        /// <summary>Creates an new <see cref="UserInfo" /> instance.</summary>
        public UserInfo()
        {

        }
    }
    /// User info
    public partial interface IUserInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Email of the user used by Datadog for contacting them if needed",
        SerializedName = @"emailAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EmailAddress { get; set; }
        /// <summary>Name of the user</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the user",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Phone number of the user used by Datadog for contacting them if needed",
        SerializedName = @"phoneNumber",
        PossibleTypes = new [] { typeof(string) })]
        string PhoneNumber { get; set; }

    }
    /// User info
    internal partial interface IUserInfoInternal

    {
        /// <summary>Email of the user used by Datadog for contacting them if needed</summary>
        string EmailAddress { get; set; }
        /// <summary>Name of the user</summary>
        string Name { get; set; }
        /// <summary>Phone number of the user used by Datadog for contacting them if needed</summary>
        string PhoneNumber { get; set; }

    }
}