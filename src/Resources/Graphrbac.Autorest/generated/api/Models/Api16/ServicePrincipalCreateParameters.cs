namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for creating a new service principal.</summary>
    public partial class ServicePrincipalCreateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalCreateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBase __servicePrincipalBase = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ServicePrincipalBase();

        /// <summary>whether or not the service principal account is enabled</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? AccountEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).AccountEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).AccountEnabled = value; }

        /// <summary>Backing field for <see cref="AppId" /> property.</summary>
        private string _appId;

        /// <summary>The application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AppId { get => this._appId; set => this._appId = value; }

        /// <summary>
        /// Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token
        /// to the application.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public bool? AppRoleAssignmentRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).AppRoleAssignmentRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).AppRoleAssignmentRequired = value; }

        /// <summary>The collection of key credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[] KeyCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).KeyCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).KeyCredentials = value; }

        /// <summary>The collection of password credentials associated with the service principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[] PasswordCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).PasswordCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).PasswordCredentials = value; }

        /// <summary>the type of the service principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string ServicePrincipalType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).ServicePrincipalType; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).ServicePrincipalType = value; }

        /// <summary>
        /// Optional list of tags that you can apply to your service principals. Not nullable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Inherited)]
        public string[] Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal)__servicePrincipalBase).Tag = value; }

        /// <summary>Creates an new <see cref="ServicePrincipalCreateParameters" /> instance.</summary>
        public ServicePrincipalCreateParameters()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__servicePrincipalBase), __servicePrincipalBase);
            await eventListener.AssertObjectIsValid(nameof(__servicePrincipalBase), __servicePrincipalBase);
        }
    }
    /// Request parameters for creating a new service principal.
    public partial interface IServicePrincipalCreateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBase
    {
        /// <summary>The application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The application ID.",
        SerializedName = @"appId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get; set; }

    }
    /// Request parameters for creating a new service principal.
    internal partial interface IServicePrincipalCreateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal
    {
        /// <summary>The application ID.</summary>
        string AppId { get; set; }

    }
}