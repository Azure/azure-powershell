namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Confluent Offer detail</summary>
    public partial class OfferDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetail,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOfferDetailInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Offer Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="PlanId" /> property.</summary>
        private string _planId;

        /// <summary>Offer Plan Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string PlanId { get => this._planId; set => this._planId = value; }

        /// <summary>Backing field for <see cref="PlanName" /> property.</summary>
        private string _planName;

        /// <summary>Offer Plan Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string PlanName { get => this._planName; set => this._planName = value; }

        /// <summary>Backing field for <see cref="PublisherId" /> property.</summary>
        private string _publisherId;

        /// <summary>Publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string PublisherId { get => this._publisherId; set => this._publisherId = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? _status;

        /// <summary>SaaS Offer Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="TermUnit" /> property.</summary>
        private string _termUnit;

        /// <summary>Offer Plan Term unit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string TermUnit { get => this._termUnit; set => this._termUnit = value; }

        /// <summary>Creates an new <see cref="OfferDetail" /> instance.</summary>
        public OfferDetail()
        {

        }
    }
    /// Confluent Offer detail
    public partial interface IOfferDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>Offer Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Offer Plan Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Plan Id",
        SerializedName = @"planId",
        PossibleTypes = new [] { typeof(string) })]
        string PlanId { get; set; }
        /// <summary>Offer Plan Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Plan Name",
        SerializedName = @"planName",
        PossibleTypes = new [] { typeof(string) })]
        string PlanName { get; set; }
        /// <summary>Publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Publisher Id",
        SerializedName = @"publisherId",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherId { get; set; }
        /// <summary>SaaS Offer Status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SaaS Offer Status",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? Status { get; set; }
        /// <summary>Offer Plan Term unit</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Offer Plan Term unit",
        SerializedName = @"termUnit",
        PossibleTypes = new [] { typeof(string) })]
        string TermUnit { get; set; }

    }
    /// Confluent Offer detail
    internal partial interface IOfferDetailInternal

    {
        /// <summary>Offer Id</summary>
        string Id { get; set; }
        /// <summary>Offer Plan Id</summary>
        string PlanId { get; set; }
        /// <summary>Offer Plan Name</summary>
        string PlanName { get; set; }
        /// <summary>Publisher Id</summary>
        string PublisherId { get; set; }
        /// <summary>SaaS Offer Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Support.SaaSOfferStatus? Status { get; set; }
        /// <summary>Offer Plan Term unit</summary>
        string TermUnit { get; set; }

    }
}