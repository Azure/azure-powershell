namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Organization resource.</summary>
    public partial class OrganizationResource :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResource,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal
    {

        /// <summary>The creation time of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).CreatedTime; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ARM id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Location of Organization resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for CreatedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.CreatedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).CreatedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).CreatedTime = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for OfferDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.OfferDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetail = value; }

        /// <summary>Internal Acessors for OrganizationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.OrganizationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OrganizationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OrganizationId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for SsoUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.SsoUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).SsoUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).SsoUrl = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UserDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IUserDetail Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceInternal.UserDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetail = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Offer Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailId = value ?? null; }

        /// <summary>Offer Plan Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailPlanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailPlanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailPlanId = value ?? null; }

        /// <summary>Offer Plan Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailPlanName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailPlanName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailPlanName = value ?? null; }

        /// <summary>Publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailPublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailPublisherId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailPublisherId = value ?? null; }

        /// <summary>SaaS Offer Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? OfferDetailStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus)""); }

        /// <summary>Offer Plan Term unit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OfferDetailTermUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailTermUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OfferDetailTermUnit = value ?? null; }

        /// <summary>Id of the Confluent organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string OrganizationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).OrganizationId; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceProperties _property;

        /// <summary>Organization resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourceProperties()); set => this._property = value; }

        /// <summary>Provision states for confluent RP</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).ProvisioningState; }

        /// <summary>SSO url for the Confluent organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string SsoUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).SsoUrl; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTags _tag;

        /// <summary>Organization resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OrganizationResourceTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Email address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string UserDetailEmailAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetailEmailAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetailEmailAddress = value ?? null; }

        /// <summary>First name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string UserDetailFirstName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetailFirstName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetailFirstName = value ?? null; }

        /// <summary>Last name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inlined)]
        public string UserDetailLastName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetailLastName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesInternal)Property).UserDetailLastName = value ?? null; }

        /// <summary>Creates an new <see cref="OrganizationResource" /> instance.</summary>
        public OrganizationResource()
        {

        }
    }
    /// Organization resource.
    public partial interface IOrganizationResource :
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
        /// <summary>The ARM id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ARM id of the resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Location of Organization resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Location of Organization resource",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
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
        /// <summary>Organization resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Organization resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTags Tag { get; set; }
        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the resource.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
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
    /// Organization resource.
    internal partial interface IOrganizationResourceInternal

    {
        /// <summary>The creation time of the resource.</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>The ARM id of the resource.</summary>
        string Id { get; set; }
        /// <summary>Location of Organization resource</summary>
        string Location { get; set; }
        /// <summary>The name of the resource.</summary>
        string Name { get; set; }
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
        /// <summary>Organization resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceProperties Property { get; set; }
        /// <summary>Provision states for confluent RP</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.ProvisionState? ProvisioningState { get; set; }
        /// <summary>SSO url for the Confluent organization.</summary>
        string SsoUrl { get; set; }
        /// <summary>Organization resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourceTags Tag { get; set; }
        /// <summary>The type of the resource.</summary>
        string Type { get; set; }
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