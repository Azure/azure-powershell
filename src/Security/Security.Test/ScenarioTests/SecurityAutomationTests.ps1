# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
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
.SYNOPSIS
Set security Automation by resource level
#>
function Set-AzSecurityAutomation-ResourceGroupLevelResource
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1

	$resourceGroupName = "Sample-RG"
	$automationName = "sampleAutomation"
	$location = "centralus"
	$scopes = $automation.Scopes
	$sources = $automation.Sources
	$actions = Convert-ToAutomationActionRequest $automation.Actions

    $automation = Set-AzSecurityAutomation -Name $automationName -ResourceGroupName $resourceGroupName -Location $location -Scopes $scopes -Sources $sources -Actions $actions
	Validate-Automation $automation
}

<#
.SYNOPSIS
Set security Automation by resource Id
#>
function Set-AzSecurityAutomation-ResourceId
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1
	$location = $automation.Location
	$scopes = $automation.Scopes
	$sources = $automation.Sources
	$actions = Convert-ToAutomationActionRequest $automation.Actions

    $automation = Set-AzSecurityAutomation -ResourceId $automation.Id -Location $location -Scopes $scopes -Sources $sources -Actions $actions
	Validate-Automation $automation
}

<#
.SYNOPSIS
Set security Automation by InputObject
#>
function Set-AzSecurityAutomation-InputObject
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1
	$actions = Convert-ToAutomationActionRequest $automation.Actions

    $automation = Set-AzSecurityAutomation -InputObject $automation -Actions $actions
	Validate-Automation $automation
}

<#
.SYNOPSIS
Get security Automations on a subscription
#>
function Get-AzSecurityAutomation-SubscriptionScope
{
    $automations = Get-AzSecurityAutomation
	Validate-Automations $automations
}

<#
.SYNOPSIS
Get security Automations on a resource group
#>
function Get-AzSecurityAutomation-ResourceGroupScope
{
	$resourceGroupName = "Sample-RG"

    $automations = Get-AzSecurityAutomation -ResourceGroupName $resourceGroupName
	Validate-Automations $automations
}

<#
.SYNOPSIS
Get specific security Automation
#>
function Get-AzSecurityAutomation-ResourceGroupLevelResource
{
	$resourceGroupName = "Sample-RG"
	$automationName = "sampleAutomation"

    $automation = Get-AzSecurityAutomation -ResourceGroupName $resourceGroupName -Name $automationName
	Validate-Automation $automation
}

<#
.SYNOPSIS
Get specific security Automation by resource Id
#>
function Get-AzSecurityAutomation-ResourceId
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1

    $automation = Get-AzSecurityAutomation -ResourceId $automation.Id
	Validate-Automation $automation
}

<#
.SYNOPSIS
Validates security Automation by resource level
#>
function Confirm-AzSecurityAutomation-ResourceGroupLevelResource
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1

	$resourceGroupName = "Sample-RG"
	$automationName = "sampleAutomation"
	$location = "centralus"
	$scopes = $automation.Scopes
	$sources = $automation.Sources
	$actions = Convert-ToAutomationActionRequest $automation.Actions

    Confirm-AzSecurityAutomation -Name $automationName -ResourceGroupName $resourceGroupName -Location $location -Scopes $scopes -Sources $sources -Actions $actions
}

<#
.SYNOPSIS
Validates security Automation by resource Id
#>
function Confirm-AzSecurityAutomation-ResourceId
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1
	$location = $automation.Location
	$scopes = $automation.Scopes
	$sources = $automation.Sources
	$actions = Convert-ToAutomationActionRequest $automation.Actions

    Confirm-AzSecurityAutomation -ResourceId $automation.Id -Location $location -Scopes $scopes -Sources $sources -Actions $actions
}

<#
.SYNOPSIS
Validates security Automation by InputObject
#>
function Confirm-AzSecurityAutomation-InputObject
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1
	$actions = Convert-ToAutomationActionRequest $automation.Actions

    Confirm-AzSecurityAutomation -InputObject $automation -Actions $actions
}

<#
.SYNOPSIS
Remove security Automation by resource group and name
#>
function Remove-AzSecurityAutomation-ResourceGroupLevelResource
{
	$resourceGroupName = "Sample-RG"
	$automationName = "sampleAutomationToDelete"

    Remove-AzSecurityAutomation -ResourceGroupName $resourceGroupName -Name $automationName
}

<#
.SYNOPSIS
Remove security Automation by resource Id
#>
function Remove-AzSecurityAutomation-ResourceId
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1

    Remove-AzSecurityAutomation -ResourceId $automation.Id
}

<#
.SYNOPSIS
Remove security Automation by (input object)/piping
#>
function Remove-AzSecurityAutomation-InputObject
{
	$automations = Get-AzSecurityAutomation
	$automation = $automations | Select -First 1

    Remove-AzSecurityAutomation -InputObject $automation
}

<#
.SYNOPSIS
Validates a list of security automations
#>
function Validate-Automations
{
	param($automations)

    Assert-True { $automations.Count -gt 0 }

	Foreach($automation in $automations)
	{
		Validate-Automation $automation
	}
}

<#
.SYNOPSIS
Validates a single automation
#>
function Validate-Automation
{
	param($automation)

	Assert-NotNull $automation
}

<#
.SYNOPSIS
Converts Automation actions to actions object that can be used on the request body
#>
function Convert-ToAutomationActionRequest
{
    param($actions)

    Foreach($action in $actions)
	{
		if($action.LogicAppResourceId)
        {
            $action.Uri = "https://dummy.com/"
        }
        elseif($action.EventHubResourceId)
        {
            $action.ConnectionString = "Endpoint=sb://dummy/;SharedAccessKeyName=dummy;SharedAccessKey=dummy;EntityPath=dummy"
            $action.SasPolicyName = "dummy"
        }
	}

	$actions
}