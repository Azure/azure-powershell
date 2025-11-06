// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>UTC DateTime filter for dependency map visualization apis</summary>
    public partial class DateTimeFilter :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilter,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilterInternal
    {

        /// <summary>Backing field for <see cref="EndDateTimeUtc" /> property.</summary>
        private global::System.DateTime? _endDateTimeUtc;

        /// <summary>End date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public global::System.DateTime? EndDateTimeUtc { get => this._endDateTimeUtc; set => this._endDateTimeUtc = value; }

        /// <summary>Backing field for <see cref="StartDateTimeUtc" /> property.</summary>
        private global::System.DateTime? _startDateTimeUtc;

        /// <summary>Start date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public global::System.DateTime? StartDateTimeUtc { get => this._startDateTimeUtc; set => this._startDateTimeUtc = value; }

        /// <summary>Creates an new <see cref="DateTimeFilter" /> instance.</summary>
        public DateTimeFilter()
        {

        }
    }
    /// UTC DateTime filter for dependency map visualization apis
    public partial interface IDateTimeFilter :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>End date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End date time for dependency map visualization query",
        SerializedName = @"endDateTimeUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndDateTimeUtc { get; set; }
        /// <summary>Start date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start date time for dependency map visualization query",
        SerializedName = @"startDateTimeUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartDateTimeUtc { get; set; }

    }
    /// UTC DateTime filter for dependency map visualization apis
    internal partial interface IDateTimeFilterInternal

    {
        /// <summary>End date time for dependency map visualization query</summary>
        global::System.DateTime? EndDateTimeUtc { get; set; }
        /// <summary>Start date time for dependency map visualization query</summary>
        global::System.DateTime? StartDateTimeUtc { get; set; }

    }
}