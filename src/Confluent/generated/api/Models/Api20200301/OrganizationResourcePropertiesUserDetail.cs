namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Subscriber detail</summary>
    public partial class OrganizationResourcePropertiesUserDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesUserDetail,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesUserDetailInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail __userDetail = new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.UserDetail();

        /// <summary>Email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string EmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)__userDetail).EmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)__userDetail).EmailAddress = value ?? null; }

        /// <summary>First name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string FirstName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)__userDetail).FirstName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)__userDetail).FirstName = value ?? null; }

        /// <summary>Last name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string LastName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)__userDetail).LastName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)__userDetail).LastName = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="OrganizationResourcePropertiesUserDetail" /> instance.
        /// </summary>
        public OrganizationResourcePropertiesUserDetail()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__userDetail), __userDetail);
            await eventListener.AssertObjectIsValid(nameof(__userDetail), __userDetail);
        }
    }
    /// Subscriber detail
    public partial interface IOrganizationResourcePropertiesUserDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail
    {

    }
    /// Subscriber detail
    internal partial interface IOrganizationResourcePropertiesUserDetailInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal
    {

    }
}