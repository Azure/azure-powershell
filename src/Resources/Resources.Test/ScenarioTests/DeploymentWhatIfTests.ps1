﻿# ----------------------------------------------------------------------------------
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
Tests resource group level deployment what-if with blank template.
#>
function Test-WhatIfWithBlankTemplateAtResourceGroupScope
{
	try
	{
		# Arrange.
		$deploymentName = Get-ResourceName
		$location = "westus"
		$resourceGroupName = Get-ResourceGroupName

		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Act.
		$result = Get-AzResourceGroupDeploymentWhatIfResult `
			-ResourceGroupName $resourceGroupName `
			-Name $deploymentName `
			-TemplateFile blankTemplate.json

		# Assert.
		Assert-AreEqual "Succeeded" $result.Status
		Assert-NotNull $result.Changes
		Assert-True { $result.Changes.Count -eq 0 }
	}
	finally
	{
		# Cleanup.
		Clean-ResourceGroup $resourceGroupName
	}
}

<#
.SYNOPSIS
Tests resource group level deployment what-if with ResultFormat=ResourceIdOnly.
#>
function Test-WhatIfWithResourceIdOnlyAtResourceGroupScope
{
	try
	{
		# Arrange.
		$deploymentName = Get-ResourceName
		$location = "westus"
		$resourceGroupName = Get-ResourceGroupName
		$storageAccountName = Get-ResourceName

		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Act.
		$result = Get-AzResourceGroupDeploymentWhatIfResult `
			-ResourceGroupName $resourceGroupName `
			-Name $deploymentName `
			-ResultFormat ResourceIdOnly `
			-TemplateFile sampleDeploymentTemplate.json `
			-storageAccountName $storageAccountName

		# Assert.
		Assert-AreEqual "Succeeded" $result.Status
		Assert-NotNull $result.Changes
		Assert-True { $result.Changes.Count -gt 0 }

		foreach ($change in $result.Changes)
		{
			Assert-NotNull $change.FullyQualifiedResourceId
			Assert-AreNotEqual $change.FullyQualifiedResourceId ""
			Assert-Null $change.Before
			Assert-Null $change.After
			Assert-Null $change.Delta
		}

	}
	finally
	{
		# Cleanup.
		Clean-ResourceGroup $resourceGroupName
	}
}

<#
.SYNOPSIS
Tests resource group level deployment what-if with resource creation.
#>
function Test-WhatIfCreateResourcesAtResourceGroupScope
{
	try
	{
		# Arrange.
		$deploymentName = Get-ResourceName
		$location = "westus"
		$resourceGroupName = Get-ResourceGroupName
		$storageAccountName = Get-ResourceName

		New-AzResourceGroup -Name $resourceGroupName -Location $location

		# Act.
		$result = Get-AzResourceGroupDeploymentWhatIfResult `
			-ResourceGroupName $resourceGroupName `
			-Name $deploymentName `
			-ResultFormat ResourceIdOnly `
			-TemplateFile sampleDeploymentTemplate.json `
			-storageAccountName $storageAccountName

		# Assert.
		foreach ($change in $result.Changes)
		{
			Assert-AreEqual "Create" $change.ChangeType
		}

	}
	finally
	{
		# Cleanup.
		Clean-ResourceGroup $resourceGroupName
	}
}

<#
.SYNOPSIS
Tests resource group level deployment what-if with resource modification.
#>
function Test-WhatIfModifyResourcesAtResourceGroupScope
{
	try
	{
		# Arrange.
		$deploymentName = Get-ResourceName
		$location = "westus"
		$resourceGroupName = Get-ResourceGroupName
		$storageAccountName = Get-ResourceName

		New-AzResourceGroup -Name $resourceGroupName -Location $location
		New-AzResourceGroupDeployment `
			-ResourceGroupName $resourceGroupName `
			-Name $deploymentName `
			-TemplateFile sampleDeploymentTemplate.json `
			-storageAccountName $storageAccountName `
			-storageAccountType "Standard_LRS"

		# Act.
		$result = Get-AzResourceGroupDeploymentWhatIfResult `
			-ResourceGroupName $resourceGroupName `
			-Name $deploymentName `
			-ResultFormat FullResourcePayloads `
			-TemplateFile sampleDeploymentTemplate.json `
			-storageAccountName $storageAccountName `
			-storageAccountType "Standard_GRS"

		# Assert.
		Assert-AreEqual "Succeeded" $result.Status
		Assert-NotNull $result.Changes
		Assert-True { $result.Changes.Count -gt 0 }

		$storageAccountId = "Microsoft.Storage/storageAccounts/$storageAccountName"
		$storageAccountChangeArray = $result.Changes | where { $_.FullyQualifiedResourceId.EndsWith($storageAccountId) }
		Assert-True { $storageAccountChangeArray.Count -eq 1 }
		$storageAccountChange = $storageAccountChangeArray[0]

		Assert-NotNull $storageAccountChange
		Assert-AreEqual "Modify" $storageAccountChange.ChangeType

		Assert-NotNull $storageAccountChange.Delta
		Assert-True { $storageAccountChange.Delta.Count -gt 0 }

		$accountTypeChangeArray = $storageAccountChange.Delta | where { $_.Path -eq "properties.accountType" }
		Assert-True { $accountTypeChangeArray.Count -eq 1 }
		$accountTypeChange = $accountTypeChangeArray[0]

		Assert-NotNull $accountTypeChange
		Assert-AreEqual "Modify" $accountTypeChange.PropertyChangeType
		Assert-AreEqual "Standard_LRS" $accountTypeChange.Before.ToString()
		Assert-AreEqual "Standard_GRS" $accountTypeChange.After.ToString()
	}
	finally
	{
		# Cleanup.
		Clean-ResourceGroup $resourceGroupName
	}
}

<#
.SYNOPSIS
Tests resource group level deployment what-if with resource deletion.
#>
function Test-WhatIfDeleteResourcesAtResourceGroupScope
{
	try
	{
		# Arrange.
		$deploymentName = Get-ResourceName
		$location = "westus"
		$resourceGroupName = Get-ResourceGroupName
		$storageAccountName = Get-ResourceName

		New-AzResourceGroup -Name $resourceGroupName -Location $location
		New-AzResourceGroupDeployment `
			-ResourceGroupName $resourceGroupName `
			-Name $deploymentName `
			-TemplateFile sampleDeploymentTemplate.json `
			-storageAccountName $storageAccountName

		# Act.
		$result = Get-AzResourceGroupDeploymentWhatIfResult `
			-Mode "Complete" `
			-ResourceGroupName $resourceGroupName `
			-Name $deploymentName `
			-ResultFormat ResourceIdOnly `
			-TemplateFile blankTemplate.json

		# Assert.
		Assert-AreEqual "Succeeded" $result.Status
		Assert-NotNull $result.Changes
		Assert-True { $result.Changes.Count -gt 0 }

		foreach ($change in $result.Changes)
		{
			Assert-AreEqual "Delete" $change.ChangeType
		}
	}
	finally
	{
		# Cleanup.
		Clean-ResourceGroup $resourceGroupName
	}
}

<#
.SYNOPSIS
Tests subscription level deployment what-if with empty template.
#>
function Test-WhatIfWithBlankTemplateAtSubscriptionScope
{
	# Arrange.
	$deploymentName = Get-ResourceName
	$location = "westus"

	# Act.
	$result = Get-AzDeploymentWhatIfResult -Name $deploymentName -Location $location -TemplateFile blankTemplate.json

	# Assert.
	Assert-AreEqual "Succeeded" $result.Status
	Assert-NotNull $result.Changes
	Assert-True { $result.Changes.Count -eq 0 }
}

<#
.SYNOPSIS
Tests subscription level deployment what-if with ResultFormat=ResourceIdOnly.
#>
function Test-WhatIfWithResourceIdOnlyAtSubscriptionScope
{
	# Arrange.
	$deploymentName = Get-ResourceName
	$storageAccountName = Get-ResourceName
	$location = "westus"

	# Act.
	$result = Get-AzDeploymentWhatIfResult `
		-Name $deploymentName `
		-Location $location `
		-ResultFormat ResourceIdOnly `
		-TemplateFile subscription_level_template.json `
		-storageAccountName $storageAccountName

	# Assert.
	Assert-AreEqual "Succeeded" $result.Status
	Assert-NotNull $result.Changes
	Assert-True { $result.Changes.Count -gt 0 }

	foreach ($change in $result.Changes)
	{
		Assert-NotNull $change.FullyQualifiedResourceId
		Assert-AreNotEqual $change.FullyQualifiedResourceId ""
		Assert-Null $change.Before
		Assert-Null $change.After
		Assert-Null $change.Delta
	}
}

<#
.SYNOPSIS
Tests subscription level deployment what-if with resource creation.
#>
function Test-WhatIfCreateResourcesAtSubscriptionScope
{
	# Arrange.
	$deploymentName = Get-ResourceName
	$storageAccountName = Get-ResourceName
	$location = "westus"

	# Act.
	$result = Get-AzDeploymentWhatIfResult `
		-Name $deploymentName `
		-Location $location `
		-ResultFormat ResourceIdOnly `
		-TemplateFile subscription_level_template.json `
		-storageAccountName $storageAccountName

	# Assert.
	foreach ($change in $result.Changes)
	{
		Assert-AreEqual "Create" $change.ChangeType
	}
}

<#
.SYNOPSIS
Tests subscription level deployment what-if with resource modification.
#>
function Test-WhatIfModifyResourcesAtSubscriptionScope
{
	# Arrange.
	$deploymentName = Get-ResourceName
	$storageAccountName = Get-ResourceName
	$location = "westus"

	New-AzDeployment `
		-Name $deploymentName `
		-Location $location `
		-TemplateFile subscription_level_template.json `
		-storageAccountName $storageAccountName

	# Act.
	$result = Get-AzDeploymentWhatIfResult `
		-Name $deploymentName `
		-Location $location `
		-ResultFormat FullResourcePayloads `
		-TemplateFile subscription_level_template.json `
		-storageAccountName $storageAccountName `
		-policyLocation "westeurope"


	# Assert.
	Assert-AreEqual "Succeeded" $result.Status
	Assert-NotNull $result.Changes
	Assert-True { $result.Changes.Count -gt 0 }

	$policyChangeArray = $result.Changes | where { $_.FullyQualifiedResourceId.EndsWith("Microsoft.Authorization/policyDefinitions/policy2") }
	Assert-True { $policyChangeArray.Count -eq 1 }
	$policyChange = $policyChangeArray[0]

	Assert-NotNull $policyChange
	Assert-AreEqual "Modify" $policyChange.ChangeType
	Assert-NotNull $policyChange.Delta
	Assert-True { $policyChange.Delta.Count -gt 0 }

	$policyRuleChangeArray = $policyChange.Delta | where { $_.Path.Equals("properties.policyRule.if.equals") }
	Assert-True { $policyChangeArray.Count -eq 1 }
	$policyRuleChange = $policyRuleChangeArray[0]

	Assert-NotNull $policyRuleChange
	Assert-AreEqual "Modify" $policyRuleChange.PropertyChangeType
	Assert-AreEqual "northeurope" $policyRuleChange.Before.ToString()
	Assert-AreEqual "westeurope" $policyRuleChange.After.ToString()
}