namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Confluent offer detail</summary>
    public partial class OrganizationResourcePropertiesOfferDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesOfferDetail,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOrganizationResourcePropertiesOfferDetailInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail __offerDetail = new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.OfferDetail();

        /// <summary>Offer Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).Id = value ?? null; }

        /// <summary>Offer Plan Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string PlanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).PlanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).PlanId = value ?? null; }

        /// <summary>Offer Plan Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string PlanName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).PlanName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).PlanName = value ?? null; }

        /// <summary>Publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string PublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).PublisherId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).PublisherId = value ?? null; }

        /// <summary>SaaS Offer Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus)""); }

        /// <summary>Offer Plan Term unit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Inherited)]
        public string TermUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).TermUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal)__offerDetail).TermUnit = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="OrganizationResourcePropertiesOfferDetail" /> instance.
        /// </summary>
        public OrganizationResourcePropertiesOfferDetail()
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
            await eventListener.AssertNotNull(nameof(__offerDetail), __offerDetail);
            await eventListener.AssertObjectIsValid(nameof(__offerDetail), __offerDetail);
        }
    }
    /// Confluent offer detail
    public partial interface IOrganizationResourcePropertiesOfferDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail
    {

    }
    /// Confluent offer detail
    internal partial interface IOrganizationResourcePropertiesOfferDetailInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal
    {

    }
}