
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
Gets policy assignments.
.Description
The **Get-AzPolicyAssignment** cmdlet gets all policy assignments or particular assignments.
Identify a policy assignment to get by name and scope or by ID.
.Notes
## RELATED LINKS

[New-AzPolicyAssignment](./New-AzPolicyAssignment.md)

[Remove-AzPolicyAssignment](./Remove-AzPolicyAssignment.md)

[Update-AzPolicyAssignment](./Update-AzPolicyAssignment.md)
.Link
https://learn.microsoft.com/powershell/module/az.resources/get-azpolicyassignment
#>
function Get-AzPolicyAssignment {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20220601.IPolicyAssignment])]
[CmdletBinding(DefaultParameterSetName='Default')]
param(
    [Parameter(ParameterSetName='Name', Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('PolicyAssignmentName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The name of the policy assignment to get.
    ${Name},

    [Parameter(ParameterSetName='Name', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='PolicyDefinitionId', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='IncludeDescendent', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Scope', Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The scope of the policy assignment.
    # Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'
    ${Scope},

    [Parameter(ParameterSetName='Id', Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('PolicyAssignmentId')]
    [Alias('ResourceId')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The ID of the policy assignment to get.
    # Use the format '{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.
    ${Id},

    [Parameter(ParameterSetName='PolicyDefinitionId', Mandatory, ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # Get all policy assignments that target the given policy definition [fully qualified] ID.
    ${PolicyDefinitionId},

    [Parameter(ParameterSetName='IncludeDescendent', Mandatory, ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # Get all policy assignments that target the given policy definition [fully qualified] ID.
    ${IncludeDescendent},

    # This switch is implemented and working, but confusing, since -Top is a misleading name. Due to backend implementation
    # of $top, this parameter should actually be called -Pagesize. Addressing this issue is beyond the scope of the initial
    # port to autorest: we will address this in the future and hide the parameter for now to avoid future backcompat complexity.
    [Parameter(ParameterSetName='Default', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Scope', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='PolicyDefinitionId', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='IncludeDescendent', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Top', Mandatory, ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Query')]
    [System.Int32]
    # Maximum number of records to return.
    # When -Top is not provided, this cmdlet will return 500 or fewer records.
    [Parameter(DontShow)]
    ${Top},

    [Parameter()]
    [System.Management.Automation.SwitchParameter]
    # Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.
    ${BackwardCompatible} = $false,

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Query')]
    [System.String]
    # The filter to apply on the operation.
    # Valid values for $filter are: 'atScope()', 'atExactScope()' or 'policyDefinitionId eq '{value}''.
    # If $filter is not provided, no filtering is performed.
    # If $filter=atScope() is provided, the returned list only includes all policy assignments that apply to the scope, which is everything in the unfiltered list except those applied to sub scopes contained within the given scope.
    # If $filter=atExactScope() is provided, the returned list only includes all policy assignments that at the given scope.
    # If $filter=policyDefinitionId eq '{value}' is provided, the returned list includes all policy assignments of the policy definition whose id is {value}.
    ${Filter},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The name of the resource group that contains policy assignments.
    ${ResourceGroupName},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The parent resource path.
    # Use empty string if there is none.
    ${ParentResourcePath},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The name of the resource.
    ${ResourceName},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The namespace of the resource provider.
    # For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)
    ${ResourceProviderNamespace},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The resource type name.
    # For example the type name of a web app is 'sites' (from Microsoft.Web/sites).
    ${ResourceType},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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
        Write-Host -ForegroundColor Cyan "begin:Get-AzPolicyAssignment(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }

    # load nested module containing common code
    Import-Module ((Get-Module -Name 'Az.Policy').NestedModules | ?{ $_.Name -eq 'Helpers' })

    # make mapping table
    $mapping = @{
        Get = 'Az.Policy.private\Get-AzPolicyAssignment_Get';
        Get1 = 'Az.Policy.private\Get-AzPolicyAssignment_Get1';
        GetViaIdentity = 'Az.Policy.private\Get-AzPolicyAssignment_GetViaIdentity';
        GetViaIdentity1 = 'Az.Policy.private\Get-AzPolicyAssignment_GetViaIdentity1';
        List = 'Az.Policy.private\Get-AzPolicyAssignment_List';
        List1 = 'Az.Policy.private\Get-AzPolicyAssignment_List1';
        List2 = 'Az.Policy.private\Get-AzPolicyAssignment_List2';
        List3 = 'Az.Policy.private\Get-AzPolicyAssignment_List3';
    }
}

process {
    if ($writeln) {
        Write-Host -ForegroundColor Cyan "process:Get-AzPolicyAssignment(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }

    $calledParameters = $PSBoundParameters

    # SubscriptionId is autorest-generated and mandatory so gets populated with default value.
    # This customized cmdlet doesn't allow/use it, so we must remove it, otherwise the parameter set is broken.
    $null = $calledParameters.Remove('SubscriptionId')

    if ($Name) {
        $calledParameterSet = 'Get'
        $calledParameters.NameInternal = $Name

        if (!$Scope) {
            $Scope = "/subscriptions/$($(Get-AzContext).Subscription.Id)"
        }

        $calledParameters.ScopeInternal = $Scope
    }
    elseif ($Id) {
        $calledParameterSet = 'Get1'
        $calledParameters.IdInternal = $Id
    }
    else {
        # set up filter values for list case
        if ($PolicyDefinitionId) {
            $calledParameters.Filter = "policyDefinitionId eq '$($PolicyDefinitionId)'"
        }
        elseif (!$IncludeDescendent) {
            $calledParameters.Filter = 'atScope()'
        }

        $calledParameterSet = 'List3'

        if ($Scope) {
            $resolved = Helpers\ResolvePolicyAssignment $null $Scope $null
            switch ($resolved.ScopeType) {
                'mgName' {
                    if ($IncludeDescendent) {
                        throw 'The -IncludeDescendent switch is not supported for management group scopes.'
                    }

                    $calledParameterSet = 'List2'
                    $calledParameters.ManagementGroupId = $resolved.ManagementGroupName
                }
                'subId' {
                    $calledParameters.SubscriptionId = @($resolved.SubscriptionId)
                }
                'rgname' {
                    $calledParameterSet = 'List'
                    $calledParameters.SubscriptionId = @($resolved.SubscriptionId)
                    $calledParameters.ResourceGroupName = $resolved.ResourceGroupName
                }
                'resource' {
                    $resourceId = $resolved.Scope
                    $parts = ($resourceId -split '/')
                    $first = 1
                    $last = $parts.Length - 2
                    $calledParameterSet = 'List1'
                    $calledParameters.ResourceProviderNamespace = $parts[0]
                    $calledParameters.ResourceName = $parts[$parts.Length-1]
                    $calledParameters.ResourceType = [System.String]::Join('/', $parts[$first..$last])
                    $calledParameters.SubscriptionId = @($resolved.SubscriptionId)
                    $calledParameters.ResourceGroupName = $resolved.ResourceGroupName
                }
                'none' {
                    # This will fail, but return a helpful message
                    $calledParameterSet = 'Get1'
                    $calledParameters = @{ IdInternal = $resolved.Scope }
                }
            }
        }
        else {
            $calledParameters.SubscriptionId = @((Get-AzContext).Subscription.Id)
        }
    }

    $null = $calledParameters.Remove('Name')
    $null = $calledParameters.Remove('Scope')
    $null = $calledParameters.Remove('Id')
    $null = $calledParameters.Remove('PolicyDefinitionId')
    $null = $calledParameters.Remove('IncludeDescendent')
    $null = $calledParameters.Remove('BackwardCompatible')

    if ($writeln) {
        Write-Host -ForegroundColor Blue -> $mapping[$calledParameterSet]'(' $calledParameters ')'
    }

    $cmdInfo = Get-Command -Name $mapping[$calledParameterSet]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
    $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$calledParameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
    $scriptCmd = {& $wrappedCmd @calledParameters}
    $object = Invoke-Command -ScriptBlock $scriptCmd

    foreach ($item in $object) {
        # add property bag for backward compatibility with previous SDK cmdlets
        if ($BackwardCompatible) {
            $propertyBag = @{
                Description = $item.Description;
                DisplayName = $item.DisplayName;
                EnforcementMode = $item.EnforcementMode;
                Metadata = (Helpers\ConvertObjectToPSObject $item.Metadata);
                NonComplianceMessages = (Helpers\ConvertObjectToPSObject $item.NonComplianceMessage);
                NotScopes = (Helpers\ConvertObjectToPSObject $item.NotScope);
                Parameters = (Helpers\ConvertObjectToPSObject $item.Parameter);
                PolicyDefinitionId = $item.PolicyDefinitionId;
                Scope = $item.Scope
            }

            $identity = @{
                IdentityType = $item.IdentityType;
                PrincipalId = $item.IdentityPrincipalId;
                TenantId = $item.IdentityTenantId;
                UserAssignedIdentities = [PSCustomObject]$item.IdentityUserAssignedIdentity
            }

            $item | Add-Member -MemberType NoteProperty -Name 'Identity' -Value ([PSCustomObject]($identity))
            $item | Add-Member -MemberType NoteProperty -Name 'Properties' -Value ([PSCustomObject]($propertyBag))
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceId' -Value $item.Id
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceName' -Value $item.Name
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceType' -Value $item.Type
            $item | Add-Member -MemberType NoteProperty -Name 'PolicyAssignmentId' -Value $item.Id
        }

        $item | Add-Member -MemberType NoteProperty -Name 'Metadata' -Value (Helpers\ConvertObjectToPSObject $item.Metadata) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'NonComplianceMessage' -Value (Helpers\ConvertObjectToPSObject $item.NonComplianceMessage) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'NotScope' -Value (Helpers\ConvertObjectToPSObject $item.NotScope) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'Parameter' -Value (Helpers\ConvertObjectToPSObject $item.Parameter) -Force
        $PSCmdlet.WriteObject($item)
    }
}

end {
} 
}
