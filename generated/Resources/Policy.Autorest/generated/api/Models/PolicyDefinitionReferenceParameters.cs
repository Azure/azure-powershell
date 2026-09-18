// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>
    /// The parameter values for the referenced policy rule. The keys are the parameter names.
    /// </summary>
    public partial class PolicyDefinitionReferenceParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionReferenceParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionReferenceParametersInternal
    {

        /// <summary>Creates an new <see cref="PolicyDefinitionReferenceParameters" /> instance.</summary>
        public PolicyDefinitionReferenceParameters()
        {

        }
    }
    /// The parameter values for the referenced policy rule. The keys are the parameter names.
    public partial interface IPolicyDefinitionReferenceParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterValuesValue>
    {

    }
    /// The parameter values for the referenced policy rule. The keys are the parameter names.
    internal partial interface IPolicyDefinitionReferenceParametersInternal

    {

    }
}