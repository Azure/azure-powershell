namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Organization resource property</summary>
    public partial class OrganizationResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTime" /> property.</summary>
        private global::System.DateTime? _createdTime;

        /// <summary>The creation time of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTime { get => this._createdTime; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal.CreatedTime { get => this._createdTime; set { {_createdTime = value;} } }

        /// <summary>Internal Acessors for OfferDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal.OfferDetail { get => (this._offerDetail = this._offerDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OfferDetail()); set { {_offerDetail = value;} } }

        /// <summary>Internal Acessors for OrganizationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal.OrganizationId { get => this._organizationId; set { {_organizationId = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SsoUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal.SsoUrl { get => this._ssoUrl; set { {_ssoUrl = value;} } }

        /// <summary>Internal Acessors for UserDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal.UserDetail { get => (this._userDetail = this._userDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.UserDetail()); set { {_userDetail = value;} } }

        /// <summary>Backing field for <see cref="OfferDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail _offerDetail;

        /// <summary>Confluent offer detail</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail OfferDetail { get => (this._offerDetail = this._offerDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OfferDetail()); set => this._offerDetail = value; }

        /// <summary>Offer Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).Id = value ?? null; }

        /// <summary>Offer Plan Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailPlanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).PlanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).PlanId = value ?? null; }

        /// <summary>Offer Plan Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailPlanName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).PlanName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).PlanName = value ?? null; }

        /// <summary>Publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailPublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).PublisherId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).PublisherId = value ?? null; }

        /// <summary>SaaS Offer Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? OfferDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus)""); }

        /// <summary>Offer Plan Term unit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailTermUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).TermUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)OfferDetail).TermUnit = value ?? null; }

        /// <summary>Backing field for <see cref="OrganizationId" /> property.</summary>
        private string _organizationId;

        /// <summary>Id of the Confluent organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string OrganizationId { get => this._organizationId; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? _provisioningState;

        /// <summary>Provision states for confluent RP</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SsoUrl" /> property.</summary>
        private string _ssoUrl;

        /// <summary>SSO url for the Confluent organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string SsoUrl { get => this._ssoUrl; }

        /// <summary>Backing field for <see cref="UserDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail _userDetail;

        /// <summary>Subscriber detail</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail UserDetail { get => (this._userDetail = this._userDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.UserDetail()); set => this._userDetail = value; }

        /// <summary>Email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string UserDetailEmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)UserDetail).EmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)UserDetail).EmailAddress = value ?? null; }

        /// <summary>First name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string UserDetailFirstName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)UserDetail).FirstName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)UserDetail).FirstName = value ?? null; }

        /// <summary>Last name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string UserDetailLastName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)UserDetail).LastName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetailInternal)UserDetail).LastName = value ?? null; }

        /// <summary>Creates an new <see cref="OrganizationResourceProperties" /> instance.</summary>
        public OrganizationResourceProperties()
        {

        }
    }
    /// Organization resource property
    public partial interface IOrganizationResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>The creation time of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The creation time of the resource.",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get;  }
        /// <summary>Offer Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string OfferDetailId { get; set; }
        /// <summary>Offer Plan Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Plan Id",
        SerializedName = @"planId",
        PossibleTypes = new [] { typeof(string) })]
        string OfferDetailPlanId { get; set; }
        /// <summary>Offer Plan Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Plan Name",
        SerializedName = @"planName",
        PossibleTypes = new [] { typeof(string) })]
        string OfferDetailPlanName { get; set; }
        /// <summary>Publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Publisher Id",
        SerializedName = @"publisherId",
        PossibleTypes = new [] { typeof(string) })]
        string OfferDetailPublisherId { get; set; }
        /// <summary>SaaS Offer Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SaaS Offer Status",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? OfferDetailStatus { get; set; }
        /// <summary>Offer Plan Term unit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Plan Term unit",
        SerializedName = @"termUnit",
        PossibleTypes = new [] { typeof(string) })]
        string OfferDetailTermUnit { get; set; }
        /// <summary>Id of the Confluent organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the Confluent organization.",
        SerializedName = @"organizationId",
        PossibleTypes = new [] { typeof(string) })]
        string OrganizationId { get;  }
        /// <summary>Provision states for confluent RP</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provision states for confluent RP",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? ProvisioningState { get;  }
        /// <summary>SSO url for the Confluent organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SSO url for the Confluent organization.",
        SerializedName = @"ssoUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SsoUrl { get;  }
        /// <summary>Email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Email address",
        SerializedName = @"emailAddress",
        PossibleTypes = new [] { typeof(string) })]
        string UserDetailEmailAddress { get; set; }
        /// <summary>First name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"First name",
        SerializedName = @"firstName",
        PossibleTypes = new [] { typeof(string) })]
        string UserDetailFirstName { get; set; }
        /// <summary>Last name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Last name",
        SerializedName = @"lastName",
        PossibleTypes = new [] { typeof(string) })]
        string UserDetailLastName { get; set; }

    }
    /// Organization resource property
    internal partial interface IOrganizationResourcePropertiesInternal

    {
        /// <summary>The creation time of the resource.</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Confluent offer detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail OfferDetail { get; set; }
        /// <summary>Offer Id</summary>
        string OfferDetailId { get; set; }
        /// <summary>Offer Plan Id</summary>
        string OfferDetailPlanId { get; set; }
        /// <summary>Offer Plan Name</summary>
        string OfferDetailPlanName { get; set; }
        /// <summary>Publisher Id</summary>
        string OfferDetailPublisherId { get; set; }
        /// <summary>SaaS Offer Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? OfferDetailStatus { get; set; }
        /// <summary>Offer Plan Term unit</summary>
        string OfferDetailTermUnit { get; set; }
        /// <summary>Id of the Confluent organization.</summary>
        string OrganizationId { get; set; }
        /// <summary>Provision states for confluent RP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? ProvisioningState { get; set; }
        /// <summary>SSO url for the Confluent organization.</summary>
        string SsoUrl { get; set; }
        /// <summary>Subscriber detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail UserDetail { get; set; }
        /// <summary>Email address</summary>
        string UserDetailEmailAddress { get; set; }
        /// <summary>First name</summary>
        string UserDetailFirstName { get; set; }
        /// <summary>Last name</summary>
        string UserDetailLastName { get; set; }

    }
}