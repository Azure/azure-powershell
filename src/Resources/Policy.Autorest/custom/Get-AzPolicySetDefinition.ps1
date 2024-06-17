
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
Gets policy set definitions.
.Description
The **Get-AzPolicySetDefinition** cmdlet gets a collection of policy set definitions or a specific policy set definition identified by name or ID.
.Notes
## RELATED LINKS

[New-AzPolicySetDefinition](./New-AzPolicySetDefinition.md)

[Remove-AzPolicySetDefinition](./Remove-AzPolicySetDefinition.md)

[Update-AzPolicySetDefinition](./Update-AzPolicySetDefinition.md)
.Link
https://learn.microsoft.com/powershell/module/az.resources/get-azpolicysetdefinition
#>
function Get-AzPolicySetDefinition {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinition])]
[CmdletBinding(DefaultParameterSetName='Name')]
param(
    [Parameter(ParameterSetName='Name', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='ManagementGroupName', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='SubscriptionId', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Version', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='ListVersion', ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('PolicySetDefinitionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The name of the policy definition to get.
    ${Name},

    [Parameter(ParameterSetName='Id', Mandatory, ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Version', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='ListVersion', ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Alias('ResourceId')]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The full Id of the policy definition to get.
    ${Id},

    [Parameter(ParameterSetName='ManagementGroupName', Mandatory, ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Builtin', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Custom', ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The name of the management group.
    ${ManagementGroupName},

    [Parameter(ParameterSetName='SubscriptionId', Mandatory, ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Builtin', ValueFromPipelineByPropertyName)]
    [Parameter(ParameterSetName='Custom', ValueFromPipelineByPropertyName)]
    [ValidateNotNullOrEmpty()]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Builtin', Mandatory, ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Query')]
    [System.Management.Automation.SwitchParameter]
    # Causes cmdlet to return only built-in policy definitions.
    ${Builtin},

    [Parameter(ParameterSetName='Custom', Mandatory, ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Query')]
    [System.Management.Automation.SwitchParameter]
    # Causes cmdlet to return only custom policy definitions.
    ${Custom},

    [Parameter(ParameterSetName='Version', Mandatory, ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Body')]
    [ValidateNotNullOrEmpty()]
    [Alias('PolicySetDefinitionVersion')]
    [System.String]
    # The policy definition version in #.#.# format.
    ${Version},

    [Parameter(ParameterSetName='ListVersion', Mandatory, ValueFromPipelineByPropertyName)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Query')]
    [System.Management.Automation.SwitchParameter]
    # Causes cmdlet to return only custom policy definitions.
    ${ListVersion},

    [Parameter()]
    [Obsolete('This parameter is a temporary bridge to new types and formats and will be removed in a future release.')]
    [System.Management.Automation.SwitchParameter]
    # Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.
    ${BackwardCompatible} = $false,

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Category('Query')]
    [System.String]
    # The filter to apply on the operation.
    # Valid values for $filter are: 'atExactScope()', 'policyType -eq {value}' or 'category eq '{value}''.
    # If $filter is not provided, no filtering is performed.
    # If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope.
    # If $filter='policyType -eq {value}' is provided, the returned list only includes all policy set definitions whose type match the {value}.
    # Possible policyType values are NotSpecified, Builtin, Custom, and Static.
    # If $filter='category -eq {value}' is provided, the returned list only includes all policy set definitions whose category match the {value}.
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
        Write-Host -ForegroundColor Cyan "begin:Get-AzPolicySetDefinition(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }

    # mapping table of generated cmdlet parameter sets
    if ($Version -or $ListVersion) {
        $mapping = @{
            NameSub = 'Az.Policy.private\Get-AzPolicySetDefinitionVersion_Get';               # Name, SubscriptionId
            NameMG = 'Az.Policy.private\Get-AzPolicySetDefinitionVersion_Get1';               # Name, ManagementGroupName
            MG = 'Az.Policy.private\Get-AzPolicySetDefinitionVersion_List';                   # ManagementGroupName
            Sub = 'Az.Policy.private\Get-AzPolicySetDefinitionVersion_List1';                 # SubscriptionId
            BuiltinId='Az.Policy.private\Get-AzPolicySetDefinitionVersionBuilt_Get';          # Id
            BuiltinGet='Az.Policy.private\Get-AzPolicySetDefinitionVersionBuilt_Get';         # Name
        }
    }
    else {
        $mapping = @{
            NameSub = 'Az.Policy.private\Get-AzPolicySetDefinition_Get';                      # Name, SubscriptionId
            NameMG = 'Az.Policy.private\Get-AzPolicySetDefinition_Get1';                      # Name, ManagementGroupName
            Sub = 'Az.Policy.private\Get-AzPolicySetDefinition_List';                         # SubscriptionId
            MG = 'Az.Policy.private\Get-AzPolicySetDefinition_List1';                         # ManagementGroupName
            BuiltinId='Az.Policy.private\Get-AzPolicySetDefinitionBuilt_Get';                 # Id
            BuiltinGet='Az.Policy.private\Get-AzPolicySetDefinitionBuilt_Get';                # Name
        }
    }

    if ($ListVersion) {
        $mapping['NameSub'] = 'Az.Policy.private\Get-AzPolicySetDefinitionVersion_List2';         # Name, SubscriptionId
        $mapping['NameMG'] = 'Az.Policy.private\Get-AzPolicySetDefinitionVersion_List3';          # Name, ManagementGroup
        $mapping['BuiltinId'] = 'Az.Policy.private\Get-AzPolicySetDefinitionVersionBuilt_List';   # Id
        $mapping['BuiltinGet'] = 'Az.Policy.private\Get-AzPolicySetDefinitionVersionBuilt_List';  # Name
   }
}

process {
    if ($writeln) {
        Write-Host -ForegroundColor Cyan "process:Get-AzPolicySetDefinition(" $PSBoundParameters ") - (ParameterSet: $($PSCmdlet.ParameterSetName))"
    }

    # ensure fallback try/catch is invoked if necessary
    $PSBoundParameters['ErrorAction'] = 'Stop'

    # handle disallowed cases not handled by PS parameter attributes
    if ($PSBoundParameters['SubscriptionId'] -and $PSBoundParameters['ManagementGroupName']) {
        throw 'Only ManagementGroupName or SubscriptionId can be provided, not both.'
    }

    if ($PSBoundParameters['Version'] -and !$PSBoundParameters['Name'] -and !$PSBoundParameters['Id']) {
        throw 'Version is only allowed if Name or Id  are provided.'
    }

    if ($PSBoundParameters['ListVersion'] -and !$PSBoundParameters['Name'] -and !$PSBoundParameters['Id']) {
        throw 'ListVersion is only allowed if Name or Id  are provided.'
    }

    # handle specific parameter sets
    $parameterSet = $PSCmdlet.ParameterSetName
    $calledParameterSet = 'Sub'

    switch ($parameterSet) {
        'Builtin' {
            $PSBoundParameters.Add('Filter', "policyType eq 'Builtin'")
        }
        'Custom' {
            $PSBoundParameters.Add('Filter', "policyType eq 'Custom'")
        }
        default {
            if ($Id) {
                $parsed = ParsePolicySetDefinitionId $Id   # function is imported from Helpers.psm1
                switch ($parsed.ScopeType)
                {
                    'subid' {
                        $PSBoundParameters['SubscriptionId'] = $parsed['SubscriptionId']
                        if ($parsed['Name']) {
                            $calledParameterSet = 'NameSub';
                            $PSBoundParameters['Name'] = $parsed['Name']
                        }
                    }
                    'mgname' {
                        $PSBoundParameters['ManagementGroupName'] = $parsed['ManagementGroupName']
                        $PSBoundParameters['Name'] = $parsed['Name']
                        $calledParameterSet = 'NameMG';
                    }
                    'builtin' {
                        $calledParameterSet = 'BuiltinId'
                        $PSBoundParameters['PolicySetDefinitionName'] = $parsed['Name']
                    }
                }
            }
        }
    }

    # this check is needed because builtin Ids are special (no subId, no mgId)
    if ($calledParameterSet -ne 'BuiltinId') {
        # determine parameter set for call to generated cmdlet
        if ($PSBoundParameters['SubscriptionId']) {
            if ($PSBoundParameters['Name']) {
                $calledParameterSet = 'NameSub';
            }
            else {
                $calledParameterSet = 'Sub';
            }
        }
        elseif ($PSBoundParameters['ManagementGroupName']) {
            $PSBoundParameters['ManagementGroupId'] = $PSBoundParameters['ManagementGroupName']
            if ($PSBoundParameters['Name']) {
                $calledParameterSet = 'NameMG'
            }
            else {
                $calledParameterSet = 'MG'
            }
        }
        elseif ($parameterSet -ne 'Id') {
            $PSBoundParameters['SubscriptionId'] = (Get-SubscriptionId)
            if ($PSBoundParameters['Name']) {
                $calledParameterSet = 'NameSub'
            }
        }
    }

    if ($PSBoundParameters['Name']) {
        $PSBoundParameters['PolicySetDefinitionName'] = $PSBoundParameters['Name']
        $null = $PSBoundParameters.Remove('Name')
    }

    if ($PSBoundParameters['Version']) {
        $PSBoundParameters['PolicyDefinitionVersion'] = $PSBoundParameters['Version']
        $null = $PSBoundParameters.Remove('Version')
    }

    # remove parameters not used by generated cmdlets
    $null = $PSBoundParameters.Remove('BackwardCompatible')
    $null = $PSBoundParameters.Remove('ManagementGroupName')
    $null = $PSBoundParameters.Remove('Id')
    $null = $PSBoundParameters.Remove('Builtin')
    $null = $PSBoundParameters.Remove('Custom')
    $null = $PSBoundParameters.Remove('ListVersion')

    if ($writeln) {
        Write-Host -ForegroundColor Blue -> $mapping[$calledParameterSet]'(' $PSBoundParameters ')'
    }

    $cmdInfo = Get-Command -Name $mapping[$calledParameterSet]
    [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $calledParameterSet, $PSCmdlet)
    $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$calledParameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
    $scriptCmd = {& $wrappedCmd @PSBoundParameters}

    # get output and fix up for backward compatibility
    try {
        $output = Invoke-Command -ScriptBlock $scriptCmd
    }
    catch {
        if (($_.Exception.Message -like '*PolicySetDefinitionNotFound*') -and $PSBoundParameters.PolicySetDefinitionName -and $PSBoundParameters.SubscriptionId) {

            # failed by name at subscription level, try builtins
            $null = $PSBoundParameters.Remove('SubscriptionId')

            $cmdInfo = Get-Command -Name $mapping['BuiltinGet']
            [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $calledParameterSet, $PSCmdlet)
            $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping['BuiltinGet']), [System.Management.Automation.CommandTypes]::Cmdlet)
            $scriptCmd = {& $wrappedCmd @PSBoundParameters}

            if ($writeln) {
                Write-Host -ForegroundColor Blue -> $mapping['BuiltinGet']'(' $PSBoundParameters ')'
            }

            $output = Invoke-Command -ScriptBlock $scriptCmd
        }
        else {
            throw
        }
    }

    foreach ($item in $output) {
        # add property bag for backward compatibility with previous SDK cmdlets
        if ($BackwardCompatible) {
            $propertyBag = @{
                Description = $item.Description;
                DisplayName = $item.DisplayName;
                Metadata = ConvertObjectToPSObject $item.Metadata;
                Parameters = ConvertObjectToPSObject $item.Parameter;
                PolicyDefinitionGroups = ConvertObjectToPSObject $item.PolicyDefinitionGroup;
                PolicyDefinitions = ConvertObjectToPSObject $item.PolicyDefinition;
                PolicyType = $item.PolicyType
            }

            $item | Add-Member -MemberType NoteProperty -Name 'Properties' -Value ([PSCustomObject]($propertyBag))
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceId' -Value $item.Id
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceName' -Value $item.Name
            $item | Add-Member -MemberType NoteProperty -Name 'ResourceType' -Value $item.Type
            $item | Add-Member -MemberType NoteProperty -Name 'PolicySetDefinitionId' -Value $item.Id
        }

        # use PSCustomObject for JSON properties
        $item | Add-Member -MemberType NoteProperty -Name 'Metadata' -Value (ConvertObjectToPSObject $item.Metadata) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'Parameter' -Value (ConvertObjectToPSObject $item.Parameter) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'PolicyDefinitionGroup' -Value (ConvertObjectToPSObject $item.PolicyDefinitionGroup) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'PolicyDefinition' -Value (ConvertObjectToPSObject $item.PolicyDefinition) -Force
        $item | Add-Member -MemberType NoteProperty -Name 'Versions' -Value ([array]($item.Versions)) -Force
        $PSCmdlet.WriteObject($item)
    }
}

end {
}
}
