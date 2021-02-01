namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>
    /// Contains information about a sign-in name of a local account user in an Azure Active Directory B2C tenant.
    /// </summary>
    public partial class SignInName :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInNameInternal
    {

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>
        /// A string value that can be used to classify user sign-in types in your directory, such as 'emailAddress' or 'userName'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>
        /// The sign-in used by the local account. Must be unique across the company/tenant. For example, 'johnc@example.com'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="SignInName" /> instance.</summary>
        public SignInName()
        {

        }
    }
    /// Contains information about a sign-in name of a local account user in an Azure Active Directory B2C tenant.
    public partial interface ISignInName :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>
        /// A string value that can be used to classify user sign-in types in your directory, such as 'emailAddress' or 'userName'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A string value that can be used to classify user sign-in types in your directory, such as 'emailAddress' or 'userName'.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>
        /// The sign-in used by the local account. Must be unique across the company/tenant. For example, 'johnc@example.com'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The sign-in used by the local account. Must be unique across the company/tenant. For example, 'johnc@example.com'.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Contains information about a sign-in name of a local account user in an Azure Active Directory B2C tenant.
    internal partial interface ISignInNameInternal

    {
        /// <summary>
        /// A string value that can be used to classify user sign-in types in your directory, such as 'emailAddress' or 'userName'.
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// The sign-in used by the local account. Must be unique across the company/tenant. For example, 'johnc@example.com'.
        /// </summary>
        string Value { get; set; }

    }
}