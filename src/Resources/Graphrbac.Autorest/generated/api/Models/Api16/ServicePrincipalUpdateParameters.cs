namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Request parameters for update an existing service principal.</summary>
    public partial class ServicePrincipalUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalUpdateParametersInternal,
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

        /// <summary>Creates an new <see cref="ServicePrincipalUpdateParameters" /> instance.</summary>
        public ServicePrincipalUpdateParameters()
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
    /// Request parameters for update an existing service principal.
    public partial interface IServicePrincipalUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBase
    {

    }
    /// Request parameters for update an existing service principal.
    internal partial interface IServicePrincipalUpdateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalBaseInternal
    {

    }
}