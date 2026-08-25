// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>
    /// The policy set definition parameters that can be used in policy definition references.
    /// </summary>
    public partial class PolicySetDefinitionVersionPropertiesParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionVersionPropertiesParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinitionVersionPropertiesParametersInternal
    {

        /// <summary>
        /// Creates an new <see cref="PolicySetDefinitionVersionPropertiesParameters" /> instance.
        /// </summary>
        public PolicySetDefinitionVersionPropertiesParameters()
        {

        }
    }
    /// The policy set definition parameters that can be used in policy definition references.
    public partial interface IPolicySetDefinitionVersionPropertiesParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IParameterDefinitionsValue>
    {

    }
    /// The policy set definition parameters that can be used in policy definition references.
    internal partial interface IPolicySetDefinitionVersionPropertiesParametersInternal

    {

    }
}