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
Get security tasks at subscription scope
#>
function Get-AzureRmSecurityTask-SubscriptionScope
{
    $tasks = Get-AzSecurityTask
	Validate-Tasks $tasks
}

<#
.SYNOPSIS
Get security tasks at a resource group scope
#>
function Get-AzureRmSecurityTask-ResourceGroupScope
{
	$rgName = Get-TestResourceGroupName

    $tasks = Get-AzSecurityTask -ResourceGroupName $rgName
	Validate-Tasks $tasks
}

<#
.SYNOPSIS
Get a subscription level security task
#>
function Get-AzureRmSecurityTask-SubscriptionLevelResource
{
	$task = Get-AzSecurityTask | where { $_.Id -notlike "*resourceGroups*" } | Select -First 1
    $fetchedTask = Get-AzSecurityTask -Name $task.Name
	Validate-Task $fetchedTask
}

<#
.SYNOPSIS
Get a resource group level security task
#>
function Get-AzureRmSecurityTask-ResourceGroupLevelResource
{
	$task = Get-AzSecurityTask | where { $_.Id -like "*resourceGroups*" } | Select -First 1
	$rgName = Extract-ResourceGroup -ResourceId $task.Id

    $fetchedTask = Get-AzSecurityTask -ResourceGroupName $rgName -Name $task.Name
	Validate-Task $fetchedTask
}

<#
.SYNOPSIS
Get a security task by ID
#>
function Get-AzureRmSecurityTask-ResourceId
{
	$task = Get-AzSecurityTask | Select -First 1

    $fetchedTask = Get-AzSecurityTask -ResourceId $task.Id
	Validate-Task $fetchedTask
}

<#
.SYNOPSIS
Validates a list of security tasks
#>
function Validate-Tasks
{
	param($tasks)

    Assert-True { $tasks.Count -gt 0 }

	Foreach($task in $tasks)
	{
		Validate-Task $task
	}
}

<#
.SYNOPSIS
Validates a single task
#>
function Validate-Task
{
	param($task)

	Assert-NotNull $task
}