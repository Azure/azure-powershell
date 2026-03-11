// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The billing period</summary>
    public partial class BillingPeriod :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriodInternal
    {

        /// <summary>Backing field for <see cref="Core" /> property.</summary>
        private int _core;

        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public int Core { get => this._core; set => this._core = value; }

        /// <summary>Backing field for <see cref="EndDate" /> property.</summary>
        private global::System.DateTime? _endDate;

        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public global::System.DateTime? EndDate { get => this._endDate; }

        /// <summary>Internal Acessors for EndDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriodInternal.EndDate { get => this._endDate; set { {_endDate = value;} } }

        /// <summary>Internal Acessors for StartDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriodInternal.StartDate { get => this._startDate; set { {_startDate = value;} } }

        /// <summary>Backing field for <see cref="PricingModel" /> property.</summary>
        private string _pricingModel;

        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string PricingModel { get => this._pricingModel; set => this._pricingModel = value; }

        /// <summary>Backing field for <see cref="StartDate" /> property.</summary>
        private global::System.DateTime? _startDate;

        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public global::System.DateTime? StartDate { get => this._startDate; }

        /// <summary>Creates an new <see cref="BillingPeriod" /> instance.</summary>
        public BillingPeriod()
        {

        }
    }
    /// The billing period
    public partial interface IBillingPeriod :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The number of cores</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of cores",
        SerializedName = @"cores",
        PossibleTypes = new [] { typeof(int) })]
        int Core { get; set; }
        /// <summary>The billing end date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing end date",
        SerializedName = @"endDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndDate { get;  }
        /// <summary>The pricing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The pricing model",
        SerializedName = @"pricingModel",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string PricingModel { get; set; }
        /// <summary>The billing start date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing start date",
        SerializedName = @"startDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartDate { get;  }

    }
    /// The billing period
    internal partial interface IBillingPeriodInternal

    {
        /// <summary>The number of cores</summary>
        int Core { get; set; }
        /// <summary>The billing end date</summary>
        global::System.DateTime? EndDate { get; set; }
        /// <summary>The pricing model</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Trial", "Annual")]
        string PricingModel { get; set; }
        /// <summary>The billing start date</summary>
        global::System.DateTime? StartDate { get; set; }

    }
}