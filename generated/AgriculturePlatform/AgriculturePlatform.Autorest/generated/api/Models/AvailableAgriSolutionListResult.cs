// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>The list of available agri solutions.</summary>
    public partial class AvailableAgriSolutionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAvailableAgriSolutionListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IAvailableAgriSolutionListResultInternal
    {

        /// <summary>Backing field for <see cref="Solution" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution> _solution;

        /// <summary>Agri solutions list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution> Solution { get => this._solution; set => this._solution = value; }

        /// <summary>Creates an new <see cref="AvailableAgriSolutionListResult" /> instance.</summary>
        public AvailableAgriSolutionListResult()
        {

        }
    }
    /// The list of available agri solutions.
    public partial interface IAvailableAgriSolutionListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>Agri solutions list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Agri solutions list.",
        SerializedName = @"solutions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution> Solution { get; set; }

    }
    /// The list of available agri solutions.
    internal partial interface IAvailableAgriSolutionListResultInternal

    {
        /// <summary>Agri solutions list.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution> Solution { get; set; }

    }
}