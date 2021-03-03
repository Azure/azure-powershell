namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Day of the week</summary>
    public partial class Day :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDay,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDayInternal
    {

        /// <summary>Backing field for <see cref="Date" /> property.</summary>
        private int? _date;

        /// <summary>Date of the month</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public int? Date { get => this._date; set => this._date = value; }

        /// <summary>Backing field for <see cref="IsLast" /> property.</summary>
        private bool? _isLast;

        /// <summary>Whether Date is last date of month</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool? IsLast { get => this._isLast; set => this._isLast = value; }

        /// <summary>Creates an new <see cref="Day" /> instance.</summary>
        public Day()
        {

        }
    }
    /// Day of the week
    public partial interface IDay :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Date of the month</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date of the month",
        SerializedName = @"date",
        PossibleTypes = new [] { typeof(int) })]
        int? Date { get; set; }
        /// <summary>Whether Date is last date of month</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether Date is last date of month",
        SerializedName = @"isLast",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsLast { get; set; }

    }
    /// Day of the week
    internal partial interface IDayInternal

    {
        /// <summary>Date of the month</summary>
        int? Date { get; set; }
        /// <summary>Whether Date is last date of month</summary>
        bool? IsLast { get; set; }

    }
}