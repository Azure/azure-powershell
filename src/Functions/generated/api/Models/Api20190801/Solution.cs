namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class Representing Solution for problems detected.</summary>
    public partial class Solution :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolution,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISolutionInternal
    {

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] _data;

        /// <summary>Solution Data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get => this._data; set => this._data = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the solution</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display Name of the solution</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private double? _id;

        /// <summary>Solution Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] _metadata;

        /// <summary>Solution Metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Metadata { get => this._metadata; set => this._metadata = value; }

        /// <summary>Backing field for <see cref="Order" /> property.</summary>
        private double? _order;

        /// <summary>Order of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? Order { get => this._order; set => this._order = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType? _type;

        /// <summary>Type of Solution</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Solution" /> instance.</summary>
        public Solution()
        {

        }
    }
    /// Class Representing Solution for problems detected.
    public partial interface ISolution :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Solution Data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Solution Data.",
        SerializedName = @"data",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get; set; }
        /// <summary>Description of the solution</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the solution",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Display Name of the solution</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Display Name of the solution",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Solution Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Solution Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(double) })]
        double? Id { get; set; }
        /// <summary>Solution Metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Solution Metadata.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Metadata { get; set; }
        /// <summary>Order of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Order of the solution.",
        SerializedName = @"order",
        PossibleTypes = new [] { typeof(double) })]
        double? Order { get; set; }
        /// <summary>Type of Solution</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of Solution",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType? Type { get; set; }

    }
    /// Class Representing Solution for problems detected.
    internal partial interface ISolutionInternal

    {
        /// <summary>Solution Data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get; set; }
        /// <summary>Description of the solution</summary>
        string Description { get; set; }
        /// <summary>Display Name of the solution</summary>
        string DisplayName { get; set; }
        /// <summary>Solution Id.</summary>
        double? Id { get; set; }
        /// <summary>Solution Metadata.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Metadata { get; set; }
        /// <summary>Order of the solution.</summary>
        double? Order { get; set; }
        /// <summary>Type of Solution</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SolutionType? Type { get; set; }

    }
}