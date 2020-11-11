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
Get security workspace settings on a subscription scope
#>
function Get-AzureRmSecurityWorkspaceSetting-SubscriptionScope
{
	Set-AzureRmSecurityWorkspaceSetting-SubscriptionLevelResource

    $workspaceSettings = Get-AzSecurityWorkspaceSetting
	Validate-WorkspaceSettings $workspaceSettings
}

<#
.SYNOPSIS
Get a security workspace setting on a subscription
#>
function Get-AzureRmSecurityWorkspaceSetting-SubscriptionLevelResource
{
	Set-AzureRmSecurityWorkspaceSetting-SubscriptionLevelResource

    $workspaceSettings = Get-AzSecurityWorkspaceSetting -Name "default"
	Validate-WorkspaceSettings $workspaceSettings
}

<#
.SYNOPSIS
Get a security workspace setting by a resource ID
#>
function Get-AzureRmSecurityWorkspaceSetting-ResourceId
{
	$workspaceSetting = Set-AzureRmSecurityWorkspaceSetting-SubscriptionLevelResource
    $fetchedWorkspaceSettings = Get-AzSecurityWorkspaceSetting -ResourceId $workspaceSetting.Id
	Validate-WorkspaceSetting $fetchedWorkspaceSettings
}

<#
.SYNOPSIS
Set a security workspace setting on a subscription
#>
function Set-AzureRmSecurityWorkspaceSetting-SubscriptionLevelResource
{
	$rgName = Get-TestResourceGroupName
	$wsName = "securityuserws"

	return Set-AzSecurityWorkspaceSetting -Name "default" -Scope "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869" -WorkspaceId  "/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourcegroups/mainws/providers/microsoft.operationalinsights/workspaces/securityuserws"
}

<#
.SYNOPSIS
Delete a security workspace setting on a subscription
#>
function Remove-AzureRmSecurityWorkspaceSetting-SubscriptionLevelResource
{
	Set-AzureRmSecurityWorkspaceSetting-SubscriptionLevelResource

    Remove-AzSecurityWorkspaceSetting -Name "default"
}

<#
.SYNOPSIS
Validates a list of security workspaceSettings
#>
function Validate-WorkspaceSettings
{
	param($workspaceSettings)

    Assert-True { $workspaceSettings.Count -gt 0 }

	Foreach($workspaceSetting in $workspaceSettings)
	{
		Validate-WorkspaceSetting $workspaceSetting
	}
}

<#
.SYNOPSIS
Validates a single workspaceSetting
#>
function Validate-WorkspaceSetting
{
	param($workspaceSetting)

	Assert-NotNull $workspaceSetting
}