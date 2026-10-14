
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Creates or updates a policy set definition.
.Description
The **New-AzPolicySetDefinition** cmdlet creates or updates a policy set definition in the given subscription or management group with the given name.
.Notes
## RELATED LINKS

[Get-AzPolicySetDefinition](./Get-AzPolicySetDefinition.md)

[Remove-AzPolicySetDefinition](./Remove-AzPolicySetDefinition.md)

[Update-AzPolicySetDefinition](./Update-AzPolicySetDefinition.md)
.Link
https://learn.microsoft.com/powershell/module/az.resources/new-azpolicysetdefinition
#>
function New-AzPolicySetDefinition {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinition])]
[CmdletBinding(DefaultParameterSetName='Name', SupportsShouldProcess=$true, ConfirmImpact='Low')]
param(
    [Parameter(Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('PolicySetDefinitionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The name of the policy set definition to create.
    ${Name},

    [Parameter(ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [System.String]
    # The display name of the policy set definition.
    ${DisplayName},

    [Parameter(ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [System.String]
    # The policy set definition description.
    ${Description},

    [Parameter(ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [System.String]
    # The policy set definition metadata.
    # Metadata is an open ended object and is typically a collection of key value pairs.
    ${Metadata},

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionReference[]]))]
    [System.String]
    # The policy definition array in JSON string form.
    ${PolicyDefinition},

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [System.String]
    # The parameter definitions for parameters used in the policy rule.
    # The keys are the parameter names.
    ${Parameter},

    [Parameter(ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [Alias('PolicySetDefinitionVersion')]
    [System.String]
    # The policy set definition version in #.#.# format.
    ${Version},

    [Parameter(ParameterSetName='ManagementGroupName', Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('ManagementGroupName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The ID of the management group.
    ${ManagementGroupId},

    [Parameter(ParameterSetName='SubscriptionId', Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Alias('GroupDefinition')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinitionGroup[]]))]
    [System.String]
    # The metadata describing groups of policy definition references within the policy set definition.
    # To construct, see NOTES section for POLICYDEFINITIONGROUP properties and create a hash table.
    ${PolicyDefinitionGroup},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    # turn on console debug messages
    $writeln = ($PSCmdlet.MyInvocation.BoundParameters.Debug -as [bool]) -or ($PSCmdlet.MyInvocation.BoundParameters.Verbose -as [bool])

    if ($writeln) {
        Write-Host -ForegroundColor Cyan "begin:New-AzPolicySetDefinition(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }
}

process {
    if ($writeln) {
        Write-Host -ForegroundColor Cyan "process:New-AzPolicySetDefinition(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }

    # parameters hash table for called cmdlet
    $calledParameters = $PSBoundParameters

    # convert input/legacy policy parameter to correct set of parameters and remove
    if ($PolicyDefinition) {
        $calledParameters.PolicyDefinition = (GetFileUriOrStringParameterValue $PolicyDefinition)
        $calledParameters.PolicyDefinition = (ConvertFrom-JsonSafe $calledParameters.PolicyDefinition -AsHashtable)
    }

    # resolve [string] 'metadata' input parameter to [hashtable]
    if ($Metadata) {
        $calledParameters.Metadata = (ResolvePolicyMetadataParameter -MetadataValue $Metadata -Debug $writeln)
    }
    elseif ($calledParameters.Metadata) {
        $calledParameters.Metadata = (ResolvePolicyMetadataParameter -MetadataValue $calledParameters.Metadata -Debug $writeln)
    }

    # resolve [string] 'parameter' input parameter (could be a path)
    if ($Parameter) {
        $calledParameters.Parameter = (GetFileUriOrStringParameterValue $Parameter)
    }

    # rename [string] 'parameter' parameter to 'parametertable' (needs to be string to construct properly)
    if ($calledParameters.Parameter) {
        $calledParameters.ParameterTable = (ConvertFrom-JsonSafe $calledParameters.Parameter -AsHashtable)
        $null = $calledParameters.Remove('Parameter')
    }

    # resolve [string] 'PolicyDefinitionGroup' input parameter to [hashtable]
    if ($PolicyDefinitionGroup) {
        $calledParameters.PolicyDefinitionGroup = (GetFileUriOrStringParameterValue $PolicyDefinitionGroup)
    }
    if ($calledParameters.PolicyDefinitionGroup) {
        $calledParameters.PolicyDefinitionGroup = (ConvertFrom-JsonSafe $calledParameters.PolicyDefinitionGroup -AsHashtable)
    }

    # ensure we have a subscription ID if the user did not provide a management group ID
    if (!$calledParameters.ManagementGroupId) {
        if (!$SubscriptionId) {
            $calledParameters.SubscriptionId = (Get-SubscriptionId)
        }
    }

    # call the internal cmdlet with the parsed parameters
    $item = Az.Policy.internal\New-AzPolicySetDefinition @calledParameters

    $item | Add-Member -MemberType NoteProperty -Name 'Metadata' -Value (ConvertObjectToPSObject $item.Metadata) -Force
    $item | Add-Member -MemberType NoteProperty -Name 'Parameter' -Value (ConvertObjectToPSObject $item.Parameter) -Force
    $item | Add-Member -MemberType NoteProperty -Name 'PolicyDefinition' -Value (ConvertObjectToPSObject $item.PolicyDefinition) -Force
    $item | Add-Member -MemberType NoteProperty -Name 'PolicyDefinitionGroup' -Value (ConvertObjectToPSObject $item.PolicyDefinitionGroup) -Force
    $item | Add-Member -MemberType NoteProperty -Name 'Versions' -Value ([array]($item.Versions)) -Force
    $PSCmdlet.WriteObject($item)
}

end {
}
}