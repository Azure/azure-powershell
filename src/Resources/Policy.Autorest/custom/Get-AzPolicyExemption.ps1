
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
Gets policy exemptions.
.Description
The **Get-AzPolicyExemption** cmdlet gets a collection of policy exemptions or a specific policy exemption identified by name or ID.
.Notes
## RELATED LINKS

[New-AzPolicyExemption](./New-AzPolicyExemption.md)

[Remove-AzPolicyExemption](./Remove-AzPolicyExemption.md)

[Update-AzPolicyExemption](./Update-AzPolicyExemption.md)
.Link
https://learn.microsoft.com/powershell/module/az.resources/get-azpolicyexemption
#>
function Get-AzPolicyExemption {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption])]
[CmdletBinding(DefaultParameterSetName='Name')]
param(
    [Parameter(ParameterSetName='Name', ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('PolicyExemptionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The name of the policy exemption.
    ${Name},

    [Parameter(ParameterSetName='Name',ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='IncludeDescendent', ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The scope of the policy exemption.
    # Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'
    ${Scope},

    [Parameter(ParameterSetName='Id', Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('ResourceId')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The fully qualified resource Id of the exemption.
    ${Id},

    [Parameter(ParameterSetName='Name', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Id', ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The policy assignment id filter.
    ${PolicyAssignmentIdFilter},

    [Parameter(ParameterSetName='IncludeDescendent', Mandatory, ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # Causes the list of returned policy exemptions to include all exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes.
    ${IncludeDescendent},

    [Parameter()]
    [Obsolete('This parameter is a temporary bridge to new types and formats and will be removed in a future release.')]
    [System.Management.Automation.SwitchParameter]
    # Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.
    ${BackwardCompatible} = $false,

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Query')]
    [System.String]
    # The filter to apply on the operation.
    # Valid values for $filter are: 'atScope()', 'atExactScope()', 'excludeExpired()' or 'policyAssignmentId eq '{value}''.
    # If $filter is not provided, no filtering is performed.
    # If $filter is not provided, the unfiltered list includes all policy exemptions associated with the scope, including those that apply directly or apply from containing scopes.
    # If $filter=atScope() is provided, the returned list only includes all policy exemptions that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope.
    # If $filter=atExactScope() is provided, the returned list only includes all policy exemptions that at the given scope.
    # If $filter=excludeExpired() is provided, the returned list only includes all policy exemptions that either haven't expired or didn't set expiration date.
    # If $filter=policyAssignmentId eq '{value}' is provided.
    # the returned list only includes all policy exemptions that are associated with the give policyAssignmentId.
    ${Filter},

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
        Write-Host -ForegroundColor Cyan "begin:Get-AzPolicyExemption(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }

    # make mapping table
    $mapping = @{
        Get = 'Az.Policy.private\Get-AzPolicyExemption_Get';
        GetViaIdentity = 'Az.Policy.private\Get-AzPolicyExemption_GetViaIdentity';
        List = 'Az.Policy.private\Get-AzPolicyExemption_List';
        List1 = 'Az.Policy.private\Get-AzPolicyExemption_List1';
        List2 = 'Az.Policy.private\Get-AzPolicyExemption_List2';
        List3 = 'Az.Policy.private\Get-AzPolicyExemption_List3';
    }
}

process {
    if ($writeln) {
        Write-Host -ForegroundColor Cyan "process:Get-AzPolicyExemption(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }

    $calledParameters = $PSBoundParameters

    if ($Id) {
        $parsed = ParsePolicyExemptionId $Id

        if ($parsed.Name) {
            $Name = $parsed.Name
        }

        if ($parsed.Scope) {
            $Scope = $parsed.Scope
        }
    }

    if (!$Scope) {
        $Scope = "/subscriptions/$($(Get-SubscriptionId))"
    }

    if ($Name) {
        $calledParameterSet = 'Get'
        $calledParameters.Name = $Name
        $calledParameters.Scope = $Scope
    }
    else {
        # set up filter values for list case
        if ($PolicyAssignmentIdFilter) {
            $calledParameters.Filter = "policyAssignmentId eq '$($PolicyAssignmentIdFilter)'"
        }
        elseif (!$IncludeDescendent) {
            $calledParameters.Filter = 'atScope()'
        }

        if ($Scope) {
            $resolved = ResolvePolicyExemption $null $Scope $null
            switch ($resolved.ScopeType) {
                'mgName' {
                    if ($IncludeDescendent) {
                        throw 'The IncludeDescendent switch is not supported for management group scopes.'
                    }

                    $calledParameterSet = 'List3'
                    $calledParameters.ManagementGroupId = $resolved.ManagementGroupName
                }
                'subId' {
                    $calledParameterSet = 'List'
                    $calledParameters.SubscriptionId = @($resolved.SubscriptionId)
                }
                'rgname' {
                    $calledParameterSet = 'List1'
                    $calledParameters.SubscriptionId = @($resolved.SubscriptionId)
                    $calledParameters.ResourceGroupName = $resolved.ResourceGroupName
                }
                'resource' {
                    $calledParameterSet = 'List2'
                    $calledParameters.ResourceProviderNamespace = $resolved.ResourceNamespace
                    $calledParameters.ResourceName = $resolved.ResourceName
                    $calledParameters.ResourceType = $resolved.ResourceType
                    $calledParameters.ParentResourcePath = '.'
                    $calledParameters.SubscriptionId = @($resolved.SubscriptionId)
                    $calledParameters.ResourceGroupName = $resolved.ResourceGroupName
                }
                'none' {
                    throw '[MissingSubscription] : The request did not have a subscription or a valid tenant level resource provider.'
                }
            }
        }

        $null = $calledParameters.Remove('Scope')
    }

    $null = $calledParameters.Remove('Id')
    $null = $calledParameters.Remove('PolicyAssignmentIdFilter')
    $null = $calledParameters.Remove('IncludeDescendent')
    $null = $calledParameters.Remove('BackwardCompatible')

    if ($writeln) {
        Write-Host -ForegroundColor Blue -> $mapping[$calledParameterSet]'(' $calledParameters ')'
    }

    $cmdInfo = Get-Command -Name $mapping[$calledParameterSet]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $calledParameterSet, $PSCmdlet)
    $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$calledParameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
    $scriptCmd = {& $wrappedCmd @calledParameters}
    $object = Invoke-Command -ScriptBlock $scriptCmd

    foreach ($item in $object) {
        # add property bag for backward compatibility with previous SDK cmdlets
        if ($BackwardCompatible) {
            $propertyBag = @{
                Description = $item.Description;
                DisplayName = $item.DisplayName;
                ExpiresOn = $item.ExpiresOn;
                ExemptionCategory = $item.ExemptionCategory;
                Metadata = (ConvertObjectToPSObject $item.Metadata);
                PolicyDefinitionReferenceIds = (ConvertObjectToPSObject $item.PolicyDefinitionReferenceId);
                PolicyAssignmentId = $item.PolicyAssignmentId
            }

            $item | Add-Member -MemberType NoteProperty -Name 'Properties' -Value ([PSCustomObject]($propertyBag))
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceId' -Value $item.Id
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceName' -Value $item.Name
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceType' -Value $item.Type
        }

        $item | Add-Member -MemberType NoteProperty -Name 'Metadata' -Value (ConvertObjectToPSObject $item.Metadata) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'PolicyDefinitionReferenceId' -Value (ConvertObjectToPSObject $item.PolicyDefinitionReferenceId) -Force
        $PSCmdlet.WriteObject($item)
    }
}

end {
} 
}
