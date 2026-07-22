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

#### Resource Group Scoped WhatIf ####

function Get-DeploymentStackWhatIfTestLocation
{
	param([string]$DefaultLocation)
	if ($env:AZURE_TEST_LOCATION)
	{
		return $env:AZURE_TEST_LOCATION
	}

	return $DefaultLocation
}

function Get-ResourceGroupDeploymentStackId
{
	param([string]$ResourceGroupName, [string]$StackName)
	$subId = (Get-AzContext).Subscription.Id
	return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.Resources/deploymentStacks/$StackName"
}

function Get-ResourceGroupDeploymentStackWhatIfResultId
{
	param([string]$ResourceGroupName, [string]$Name)
	$subId = (Get-AzContext).Subscription.Id
	return "/subscriptions/$subId/resourceGroups/$ResourceGroupName/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$Name"
}

function Get-SubscriptionDeploymentStackId
{
	param([string]$StackName)
	$subId = (Get-AzContext).Subscription.Id
	return "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacks/$StackName"
}

function Get-SubscriptionDeploymentStackWhatIfResultId
{
	param([string]$Name)
	$subId = (Get-AzContext).Subscription.Id
	return "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$Name"
}

function Get-ManagementGroupDeploymentStackId
{
	param([string]$ManagementGroupId, [string]$StackName)
	return "/providers/Microsoft.Management/managementGroups/$ManagementGroupId/providers/Microsoft.Resources/deploymentStacks/$StackName"
}

function Get-ManagementGroupDeploymentStackWhatIfResultId
{
	param([string]$ManagementGroupId, [string]$Name)
	return "/providers/Microsoft.Management/managementGroups/$ManagementGroupId/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$Name"
}

function Assert-DeploymentStackWhatIfResultSucceeded
{
  param($Result)
	Assert-NotNull $Result
	Assert-NotNull $Result.Properties
	Assert-NotNull $Result.Properties.ProvisioningState
	Assert-AreEqual "succeeded" $Result.Properties.ProvisioningState.ToLowerInvariant()
}

function ConvertTo-DeploymentStackWhatIfTimeSpan
{
	param($Value)
	if ($Value -is [System.TimeSpan])
	{
		return $Value
	}

	try
	{
		return [System.Xml.XmlConvert]::ToTimeSpan([string]$Value)
	}
	catch
	{
		return [System.TimeSpan]::Parse([string]$Value, [System.Globalization.CultureInfo]::InvariantCulture)
	}
}

function Assert-DeploymentStackWhatIfResultObject
{
	param(
		$Result,
		[string]$ExpectedName,
		[string]$ExpectedId,
		[string]$ExpectedStackResourceId,
		[string]$ExpectedRetentionInterval = "P1D"
	)

	Assert-DeploymentStackWhatIfResultSucceeded $Result
	Assert-AreEqual $ExpectedName $Result.Name
	Assert-AreEqual "Microsoft.Resources/deploymentStacksWhatIfResults" $Result.Type
	Assert-NotNull $Result.Id
	Assert-True { $Result.Id.Equals($ExpectedId, [System.StringComparison]::OrdinalIgnoreCase) }
	Assert-NotNull $Result.Properties.DeploymentStackResourceId
	Assert-True { $Result.Properties.DeploymentStackResourceId.Equals($ExpectedStackResourceId, [System.StringComparison]::OrdinalIgnoreCase) }
 $expectedRetention = ConvertTo-DeploymentStackWhatIfTimeSpan $ExpectedRetentionInterval
	$actualRetention = ConvertTo-DeploymentStackWhatIfTimeSpan $Result.Properties.RetentionInterval
	Assert-AreEqual $expectedRetention.Ticks $actualRetention.Ticks
}

<#
.SYNOPSIS
Tests New (create) operation on WhatIf results at the RG scope.
#>
function Test-NewResourceGroupDeploymentStackWhatIfResult
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-DeploymentStackWhatIfTestLocation "West Central US"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Success with template file
		$result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Success with parameter object
      $result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		Assert-ThrowsContains { New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile $missingFile -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force } $missingFile
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests Set (update) operation on WhatIf results at the RG scope.
#>
function Test-SetResourceGroupDeploymentStackWhatIfResult
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-DeploymentStackWhatIfTestLocation "West Central US"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create initial WhatIf result
		$result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Set (update) with same template
		$updated = Set-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $updated $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Set with different ActionOnUnmanage
		$updated = Set-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DeleteAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $updated $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests GET (list and get-by-name) operation on WhatIf results at the RG scope.
#>
function Test-GetResourceGroupDeploymentStackWhatIfResult
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rname2 = Get-ResourceName
	$rglocation = Get-DeploymentStackWhatIfTestLocation "West Central US"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create a WhatIf result to get
		New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname2 -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname2) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - List - Success
		$list = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname
        Assert-True { @($list).Count -ge 2 }
		Assert-True { @($list.Name) -contains $rname }
		Assert-True { @($list.Name) -contains $rname2 }

		$listResult = $list | Where-Object Name -eq $rname
		$listResult2 = $list | Where-Object Name -eq $rname2
		Assert-DeploymentStackWhatIfResultObject $listResult $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)
		Assert-DeploymentStackWhatIfResultObject $listResult2 $rname2 (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname2) (Get-ResourceGroupDeploymentStackId $rgname $rname2)

		# Test - GetByName - Success
		$getByName = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $rname
		Assert-DeploymentStackWhatIfResultObject $getByName $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - GetByName - Failure - NotFound
		$badName = "badwhatif1928273615"
		Assert-Throws { Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $badName }
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests Remove (delete) operation on WhatIf results at the RG scope.
#>
function Test-RemoveResourceGroupDeploymentStackWhatIfResult
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-DeploymentStackWhatIfTestLocation "West Central US"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create a WhatIf result to delete
		New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Remove - Success
		Remove-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -Force

		# Test - Confirm deleted - List should not contain it
		$list = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname
		Assert-True { -not ($list.name -contains $rname) }
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

#### Subscription Scoped WhatIf ####

<#
.SYNOPSIS
Tests New (create) operation on WhatIf results at the subscription scope.
#>
function Test-NewSubscriptionDeploymentStackWhatIfResult
{
	# Setup
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Test - Success with template file
		$result = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Success with parameter object
		$result = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		Assert-ThrowsContains { New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile $missingFile -ActionOnUnmanage DetachAll -DenySettingsMode None -Force } $missingFile
	}
	finally
	{
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Set (update) operation on WhatIf results at the subscription scope.
#>
function Test-SetSubscriptionDeploymentStackWhatIfResult
{
	# Setup
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create initial WhatIf result
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Set (update)
		$updated = Set-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $updated $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Set with different ActionOnUnmanage
		$updated = Set-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $updated $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)
	}
	finally
	{
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests GET (list and get-by-name) operation on WhatIf results at the subscription scope.
#>
function Test-GetSubscriptionDeploymentStackWhatIfResult
{
	# Setup
	$rname = Get-ResourceName
	$rname2 = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create a WhatIf result to get
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		$created2 = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname2 -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname2) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - List - Success
		$list = Get-AzSubscriptionDeploymentStackWhatIfResult
        Assert-True { @($list).Count -ge 2 }
		Assert-True { @($list.Name) -contains $rname }
		Assert-True { @($list.Name) -contains $rname2 }

		$listResult = $list | Where-Object Name -eq $rname
		$listResult2 = $list | Where-Object Name -eq $rname2
		Assert-DeploymentStackWhatIfResultObject $listResult $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)
		Assert-DeploymentStackWhatIfResultObject $listResult2 $rname2 (Get-SubscriptionDeploymentStackWhatIfResultId $rname2) (Get-SubscriptionDeploymentStackId $rname2)

		# Test - GetByName - Success
		$getByName = Get-AzSubscriptionDeploymentStackWhatIfResult -Name $rname
		Assert-DeploymentStackWhatIfResultObject $getByName $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - GetByName - Failure - NotFound
		$badName = "badwhatif1928273615"
		Assert-Throws { Get-AzSubscriptionDeploymentStackWhatIfResult -Name $badName }
	}
	finally
	{
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force -ErrorAction SilentlyContinue
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname2 -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Remove (delete) operation on WhatIf results at the subscription scope.
#>
function Test-RemoveSubscriptionDeploymentStackWhatIfResult
{
	# Setup
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create a WhatIf result to delete
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Remove - Success
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force

		# Test - Confirm deleted
		$list = Get-AzSubscriptionDeploymentStackWhatIfResult
		Assert-True { -not ($list.name -contains $rname) }
	}
	finally
	{
		# No cleanup needed, stack was deleted in test
	}
}

#### WithPropertyChanges Tests ####

<#
.SYNOPSIS
Tests that New-AzResourceGroupDeploymentStackWhatIfResult returns property changes automatically (via WhatIf POST).
#>
function Test-NewResourceGroupDeploymentStackWhatIfReturnsPropertyChanges
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-DeploymentStackWhatIfTestLocation "West Central US"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New returns result with property changes populated by default
		$result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Verify output does not contain '= DeploymentScope: null'
		$output = $result.ToString()
		Assert-False { $output -match "= DeploymentScope: null" }
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests that New-AzSubscriptionDeploymentStackWhatIfResult returns property changes automatically (via WhatIf POST).
#>
function Test-NewSubscriptionDeploymentStackWhatIfReturnsPropertyChanges
{
	# Setup
	$rname = Get-ResourceName
 $location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Test - New returns result with property changes populated by default
		$result = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Verify output does not contain '= DeploymentScope: null'
		$output = $result.ToString()
		Assert-False { $output -match "= DeploymentScope: null" }
	}
	finally
	{
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests that New-AzManagementGroupDeploymentStackWhatIfResult returns property changes automatically (via WhatIf POST).
#>
function Test-NewManagementGroupDeploymentStackWhatIfReturnsPropertyChanges
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
    $location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Test - New returns result with property changes populated by default
		$result = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Verify output does not contain '= DeploymentScope: null'
		$output = $result.ToString()
		Assert-False { $output -match "= DeploymentScope: null" }
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Get-AzResourceGroupDeploymentStackWhatIfResult with -WithPropertyChanges switch (calls WhatIf POST).
#>
function Test-GetResourceGroupDeploymentStackWhatIfWithPropertyChanges
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
 $rglocation = Get-DeploymentStackWhatIfTestLocation "West Central US"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create a WhatIf result first
		New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Get without -WithPropertyChanges (uses GET, no delta)
		$resultGet = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $rname
		Assert-DeploymentStackWhatIfResultObject $resultGet $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Get with -WithPropertyChanges (uses POST, returns delta)
		$resultPost = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $rname -WithPropertyChanges
		Assert-DeploymentStackWhatIfResultObject $resultPost $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Verify output does not contain '= DeploymentScope: null'
		$output = $resultPost.ToString()
		Assert-False { $output -match "= DeploymentScope: null" }
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests Get-AzSubscriptionDeploymentStackWhatIfResult with -WithPropertyChanges switch (calls WhatIf POST).
#>
function Test-GetSubscriptionDeploymentStackWhatIfWithPropertyChanges
{
	# Setup
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create a WhatIf result first
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Get without -WithPropertyChanges (uses GET, no delta)
		$resultGet = Get-AzSubscriptionDeploymentStackWhatIfResult -Name $rname
		Assert-DeploymentStackWhatIfResultObject $resultGet $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Get with -WithPropertyChanges (uses POST, returns delta)
		$resultPost = Get-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -WithPropertyChanges
		Assert-DeploymentStackWhatIfResultObject $resultPost $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Verify output does not contain '= DeploymentScope: null'
		$output = $resultPost.ToString()
		Assert-False { $output -match "= DeploymentScope: null" }
	}
	finally
	{
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Get-AzManagementGroupDeploymentStackWhatIfResult with -WithPropertyChanges switch (calls WhatIf POST).
#>
function Test-GetManagementGroupDeploymentStackWhatIfWithPropertyChanges
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create a WhatIf result first
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Get without -WithPropertyChanges (uses GET, no delta)
		$resultGet = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $rname
       Assert-DeploymentStackWhatIfResultObject $resultGet $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Get with -WithPropertyChanges (uses POST, returns delta)
		$resultPost = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $rname -WithPropertyChanges
      Assert-DeploymentStackWhatIfResultObject $resultPost $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Verify output does not contain '= DeploymentScope: null'
		$output = $resultPost.ToString()
		Assert-False { $output -match "= DeploymentScope: null" }
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}

#### Management Group Scoped WhatIf ####

<#
.SYNOPSIS
Tests New (create) operation on WhatIf results at the management group scope.
#>
function Test-NewManagementGroupDeploymentStackWhatIfResult
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Test - Success with template file
		$result = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $result $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Failure - template file not found
		$missingFile = "missingFile142.json"
		Assert-ThrowsContains { New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile $missingFile -ActionOnUnmanage DetachAll -DenySettingsMode None -Force } $missingFile
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Set (update) operation on WhatIf results at the management group scope.
#>
function Test-SetManagementGroupDeploymentStackWhatIfResult
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create initial WhatIf result
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Set (update)
		$updated = Set-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $updated $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Set with different ActionOnUnmanage
		$updated = Set-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultObject $updated $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests GET (list and get-by-name) operation on WhatIf results at the management group scope.
#>
function Test-GetManagementGroupDeploymentStackWhatIfResult
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$rname2 = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create a WhatIf result to get
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		$created2 = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname2 -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname2) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - List - Success
		$list = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid
        Assert-True { @($list).Count -ge 2 }
		Assert-True { @($list.Name) -contains $rname }
		Assert-True { @($list.Name) -contains $rname2 }

		$listResult = $list | Where-Object Name -eq $rname
		$listResult2 = $list | Where-Object Name -eq $rname2
		Assert-DeploymentStackWhatIfResultObject $listResult $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)
		Assert-DeploymentStackWhatIfResultObject $listResult2 $rname2 (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname2) (Get-ManagementGroupDeploymentStackId $mgid $rname2)

		# Test - GetByName - Success
		$getByName = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $rname
		Assert-DeploymentStackWhatIfResultObject $getByName $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - GetByName - Failure - NotFound
		$badName = "badwhatif1928273615"
		Assert-Throws { Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $badName }
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname2 -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Remove (delete) operation on WhatIf results at the management group scope.
#>
function Test-RemoveManagementGroupDeploymentStackWhatIfResult
{
	# Setup
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		# Create a WhatIf result to delete
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Remove - Success
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force

		# Test - Confirm deleted
		$list = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid
		Assert-True { -not ($list.name -contains $rname) }
	}
	finally
	{
		# No cleanup needed, stack was deleted in test
	}
}

#### Get by ResourceId Tests ####

<#
.SYNOPSIS
Tests Get-AzResourceGroupDeploymentStackWhatIfResult with -ResourceId (success and invalid format).
#>
function Test-GetResourceGroupDeploymentStackWhatIfResultByResourceId
{
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-DeploymentStackWhatIfTestLocation "West Central US"
	$subId = (Get-AzContext).Subscription.Id

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create a WhatIf result first
		$created = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Success: Get by valid ResourceId
		$resourceId = "/subscriptions/$subId/resourceGroups/$rgname/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$rname"
		$result = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceId $resourceId
		Assert-DeploymentStackWhatIfResultObject $result $rname $resourceId (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Failure: Invalid ResourceId format
		$badResourceId = "not-a-valid-resource-id"
		Assert-ThrowsContains { Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceId $badResourceId } "not in correct form"
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Tests Get-AzSubscriptionDeploymentStackWhatIfResult with -ResourceId (success and invalid format).
#>
function Test-GetSubscriptionDeploymentStackWhatIfResultByResourceId
{
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"
	$subId = (Get-AzContext).Subscription.Id

	try
	{
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Success: Get by valid ResourceId
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$rname"
		$result = Get-AzSubscriptionDeploymentStackWhatIfResult -ResourceId $resourceId
		Assert-DeploymentStackWhatIfResultObject $result $rname $resourceId (Get-SubscriptionDeploymentStackId $rname)

		# Test - Failure: Invalid ResourceId format
		$badResourceId = "not-a-valid-resource-id"
		Assert-ThrowsContains { Get-AzSubscriptionDeploymentStackWhatIfResult -ResourceId $badResourceId } "not in correct form"
	}
	finally
	{
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Get-AzManagementGroupDeploymentStackWhatIfResult with -ResourceId (success and invalid format).
#>
function Test-GetManagementGroupDeploymentStackWhatIfResultByResourceId
{
	$mgid = "AzBlueprintAssignTest"
	$rname = Get-ResourceName
	$location = Get-DeploymentStackWhatIfTestLocation "West US 2"

	try
	{
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Success: Get by valid ResourceId
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgid/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$rname"
		$result = Get-AzManagementGroupDeploymentStackWhatIfResult -ResourceId $resourceId
		Assert-DeploymentStackWhatIfResultObject $result $rname $resourceId (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Failure: Invalid ResourceId format
		$badResourceId = "not-a-valid-resource-id"
		Assert-ThrowsContains { Get-AzManagementGroupDeploymentStackWhatIfResult -ResourceId $badResourceId } "not in correct form"
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}

