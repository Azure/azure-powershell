// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>
    /// The parameter definitions for parameters used in the policy rule. The keys are the parameter names.
    /// </summary>
    public partial class PolicyDefinitionVersionPropertiesParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionVersionPropertiesParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionVersionPropertiesParametersInternal
    {

        /// <summary>
        /// Creates an new <see cref="PolicyDefinitionVersionPropertiesParameters" /> instance.
        /// </summary>
        public PolicyDefinitionVersionPropertiesParameters()
        {

        }
    }
    /// The parameter definitions for parameters used in the policy rule. The keys are the parameter names.
    public partial interface IPolicyDefinitionVersionPropertiesParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterDefinitionsValue>
    {

    }
    /// The parameter definitions for parameters used in the policy rule. The keys are the parameter names.
    internal partial interface IPolicyDefinitionVersionPropertiesParametersInternal

    {

    }
}