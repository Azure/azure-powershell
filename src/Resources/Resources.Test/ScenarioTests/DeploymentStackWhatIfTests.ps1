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

function Get-TestManagementGroupId
{
	if ($env:AZURE_TEST_MANAGEMENT_GROUP_ID)
	{
		return $env:AZURE_TEST_MANAGEMENT_GROUP_ID
	}

	return "AzBlueprintAssignTest"
}

function Assert-DeploymentStackWhatIfResultCompletedOrUnavailable
{
    param($Result)
	Assert-NotNull $Result
	Assert-NotNull $Result.Properties
	Assert-NotNull $Result.Properties.ProvisioningState
    if (Test-DeploymentStackWhatIfResultUnavailable $Result)
	{
		Assert-DeploymentStackWhatIfResultUnavailable $Result
		return
	}
 Assert-AreNotEqual "failed" $Result.Properties.ProvisioningState.ToLowerInvariant()
}

function Test-DeploymentStackWhatIfResultUnavailable
{
	param($Result)
	return $Result -and $Result.Properties.ProvisioningState -eq "What-If API not available"
}

function Assert-DeploymentStackWhatIfResultUnavailable
{
	param($Result)
	Assert-NotNull $Result
	Assert-NotNull $Result.Properties
	Assert-AreEqual "What-If API not available" $Result.Properties.ProvisioningState

	if ($env:AZURE_TEST_FAIL_ON_WHATIF_UNAVAILABLE -eq "true")
	{
		throw "Deployment Stacks What-If API is not available for this scope, region, or subscription."
	}
}

function Assert-DeploymentStackWhatIfResultIdentity
{
	param([object]$Result, [string]$Name, [string]$ExpectedId, [string]$ExpectedStackResourceId)
	if (Test-DeploymentStackWhatIfResultUnavailable $Result)
	{
		Assert-DeploymentStackWhatIfResultUnavailable $Result
		return
	}

	Assert-AreEqual $Name $Result.Name
	Assert-NotNull $Result.Id
	Assert-NotNull $Result.Properties.DeploymentStackResourceId
	Assert-True { $Result.Id.ToLowerInvariant() -eq $ExpectedId.ToLowerInvariant() }
	Assert-True { $Result.Properties.DeploymentStackResourceId.ToLowerInvariant() -eq $ExpectedStackResourceId.ToLowerInvariant() }
}

function Assert-DeploymentStackWhatIfListContains
{
	param($List, [string]$Name)
	Assert-AreNotEqual 0 @($List).Count
	Assert-True { @($List).Name -contains $Name }
}

function Assert-DeploymentStackWhatIfHasResourceChanges
{
	param($Result)
	if (Test-DeploymentStackWhatIfResultUnavailable $Result)
	{
		Assert-DeploymentStackWhatIfResultUnavailable $Result
		return
	}

	Assert-NotNull $Result.Properties.Changes
	Assert-NotNull $Result.Properties.Changes.ResourceChanges
	Assert-AreNotEqual 0 @($Result.Properties.Changes.ResourceChanges).Count
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
 $rglocation = "West US 2"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - Success with template file
		$result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)
		Assert-DeploymentStackWhatIfHasResourceChanges $result

		# Test - Success with parameter object
      $result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterObject @{templateSpecName = "StacksScenarioTestSpec"} -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)
		Assert-DeploymentStackWhatIfHasResourceChanges $result

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
 $rglocation = "West US 2"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create initial WhatIf result
		$result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Set (update) with same template
		$updated = Set-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $updated
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $updated
		Assert-DeploymentStackWhatIfResultIdentity $updated $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Set with different ActionOnUnmanage
		$updated = Set-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DeleteAll -DenySettingsMode None -Force
		Assert-NotNull $updated
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $updated
       Assert-DeploymentStackWhatIfResultIdentity $updated $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)
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
 $rglocation = "West US 2"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

     # Create a WhatIf result to get
		$created = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - List - Success
		$list = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname
        Assert-DeploymentStackWhatIfListContains $list $rname

		# Test - GetByName - Success
		$getByName = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $rname
		Assert-NotNull $getByName
		Assert-DeploymentStackWhatIfResultIdentity $getByName $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - GetByName - Failure - NotFound
		$badName = "badwhatif1928273615"
      Assert-ThrowsContains { Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $badName } "not found"
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
 $rglocation = "West US 2"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

      # Create a WhatIf result to delete
		$created = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Remove - Success
		Remove-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -Force
		Assert-ThrowsContains { Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $rname } "not found"

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
	$location = "West US 2"

	try
	{
		# Test - Success with template file
		$result = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Success with parameter object
		$result = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

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
	$location = "West US 2"

	try
	{
		# Create initial WhatIf result
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Set (update)
		$updated = Set-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $updated
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $updated
		Assert-DeploymentStackWhatIfResultIdentity $updated $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Set with different ActionOnUnmanage
		$updated = Set-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteAll -DenySettingsMode None -Force
		Assert-NotNull $updated
		Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $updated
       Assert-DeploymentStackWhatIfResultIdentity $updated $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)
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
	$location = "West US 2"

	try
	{
		# Create a WhatIf result to get
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - List - Success
		$list = Get-AzSubscriptionDeploymentStackWhatIfResult
        Assert-DeploymentStackWhatIfListContains $list $rname

		# Test - GetByName - Success
		$getByName = Get-AzSubscriptionDeploymentStackWhatIfResult -Name $rname
		Assert-NotNull $getByName
		Assert-DeploymentStackWhatIfResultIdentity $getByName $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - GetByName - Failure - NotFound
		$badName = "badwhatif1928273615"
      Assert-ThrowsContains { Get-AzSubscriptionDeploymentStackWhatIfResult -Name $badName } "not found"
	}
	finally
	{
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force -ErrorAction SilentlyContinue
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
	$location = "West US 2"

	try
	{
		# Create a WhatIf result to delete
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Remove - Success
		Remove-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Force
		Assert-ThrowsContains { Get-AzSubscriptionDeploymentStackWhatIfResult -Name $rname } "not found"

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
 $rglocation = "West US 2"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Test - New returns result with property changes populated by default
		$result = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
     Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
       Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)
		Assert-DeploymentStackWhatIfHasResourceChanges $result
		Assert-NotNull $result.Properties

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
	$location = "West US 2"

	try
	{
		# Test - New returns result with property changes populated by default
		$result = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
     Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
      if (Test-DeploymentStackWhatIfResultUnavailable $result) { Assert-DeploymentStackWhatIfResultUnavailable $result; return }
       Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)
		Assert-NotNull $result.Properties

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
 $mgid = Get-TestManagementGroupId
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Test - New returns result with property changes populated by default
		$result = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
     Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
        Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)
      if (Test-DeploymentStackWhatIfResultUnavailable $result) { Assert-DeploymentStackWhatIfResultUnavailable $result; return }
		Assert-NotNull $result.Properties

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
 $rglocation = "West US 2"

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

      # Create a WhatIf result first
		$created = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Get without -WithPropertyChanges (uses GET, no delta)
		$resultGet = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $rname
		Assert-NotNull $resultGet
        Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $resultGet
		Assert-DeploymentStackWhatIfResultIdentity $resultGet $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

		# Test - Get with -WithPropertyChanges (uses POST, returns delta)
		$resultPost = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceGroupName $rgname -Name $rname -WithPropertyChanges
		Assert-NotNull $resultPost
        Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $resultPost
		Assert-DeploymentStackWhatIfResultIdentity $resultPost $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)
		Assert-DeploymentStackWhatIfHasResourceChanges $resultPost

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
	$location = "West US 2"

	try
	{
		# Create a WhatIf result first
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Get without -WithPropertyChanges (uses GET, no delta)
		$resultGet = Get-AzSubscriptionDeploymentStackWhatIfResult -Name $rname
		Assert-NotNull $resultGet
        Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $resultGet
		Assert-DeploymentStackWhatIfResultIdentity $resultGet $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Get with -WithPropertyChanges (uses POST, returns delta)
		$resultPost = Get-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -WithPropertyChanges
		Assert-NotNull $resultPost
        Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $resultPost
		Assert-DeploymentStackWhatIfResultIdentity $resultPost $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

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
 $mgid = Get-TestManagementGroupId
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Create a WhatIf result first
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Get without -WithPropertyChanges (uses GET, no delta)
		$resultGet = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $rname
		Assert-NotNull $resultGet
       Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $resultGet
		Assert-DeploymentStackWhatIfResultIdentity $resultGet $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Get with -WithPropertyChanges (uses POST, returns delta)
		$resultPost = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $rname -WithPropertyChanges
		Assert-NotNull $resultPost
      Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $resultPost
		Assert-DeploymentStackWhatIfResultIdentity $resultPost $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

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
 $mgid = Get-TestManagementGroupId
	$rname = Get-ResourceName
	$location = "West US 2"
	$subId = (Get-AzContext).Subscription.SubscriptionId

	try
	{
		# Test - Success with template file
		$result = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $result
     Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result

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
 $mgid = Get-TestManagementGroupId
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Create initial WhatIf result
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Set (update)
		$updated = Set-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
		Assert-NotNull $updated
        Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $updated
		Assert-DeploymentStackWhatIfResultIdentity $updated $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Set with different ActionOnUnmanage
		$updated = Set-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DeleteAll -DenySettingsMode None -Force
		Assert-NotNull $updated
        Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $updated
       Assert-DeploymentStackWhatIfResultIdentity $updated $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)
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
 $mgid = Get-TestManagementGroupId
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Create a WhatIf result to get
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - List - Success
		$list = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid
        Assert-DeploymentStackWhatIfListContains $list $rname

		# Test - GetByName - Success
		$getByName = Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $rname
		Assert-NotNull $getByName
		Assert-DeploymentStackWhatIfResultIdentity $getByName $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - GetByName - Failure - NotFound
		$badName = "badwhatif1928273615"
      Assert-ThrowsContains { Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $badName } "not found"
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}

<#
.SYNOPSIS
Tests Remove (delete) operation on WhatIf results at the management group scope.
#>
function Test-RemoveManagementGroupDeploymentStackWhatIfResult
{
	# Setup
 $mgid = Get-TestManagementGroupId
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		# Create a WhatIf result to delete
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Remove - Success
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force
		Assert-ThrowsContains { Get-AzManagementGroupDeploymentStackWhatIfResult -ManagementGroupId $mgid -Name $rname } "not found"

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
 $rglocation = "West US 2"
	$subId = (Get-AzContext).Subscription.Id

	try
	{
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create a WhatIf result first
		$created = New-AzResourceGroupDeploymentStackWhatIfResult -Name $rname -ResourceGroupName $rgname -TemplateFile StacksRGTemplate.json -TemplateParameterFile StacksRGTemplateParams.json -StackResourceId (Get-ResourceGroupDeploymentStackId $rgname $rname) -RetentionInterval "P1D" -ActionOnUnmanage DetachAll -DenySettingsMode None -Force

		# Test - Success: Get by valid ResourceId
		$resourceId = "/subscriptions/$subId/resourceGroups/$rgname/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$rname"
		$result = Get-AzResourceGroupDeploymentStackWhatIfResult -ResourceId $resourceId
		Assert-NotNull $result
     Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-ResourceGroupDeploymentStackWhatIfResultId $rgname $rname) (Get-ResourceGroupDeploymentStackId $rgname $rname)

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
	$location = "West US 2"
	$subId = (Get-AzContext).Subscription.Id

	try
	{
		$created = New-AzSubscriptionDeploymentStackWhatIfResult -Name $rname -Location $location -StackResourceId (Get-SubscriptionDeploymentStackId $rname) -RetentionInterval "P1D" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

		# Test - Success: Get by valid ResourceId
		$resourceId = "/subscriptions/$subId/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$rname"
		$result = Get-AzSubscriptionDeploymentStackWhatIfResult -ResourceId $resourceId
		Assert-NotNull $result
     Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-SubscriptionDeploymentStackWhatIfResultId $rname) (Get-SubscriptionDeploymentStackId $rname)

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
 $mgid = Get-TestManagementGroupId
	$rname = Get-ResourceName
	$location = "West US 2"

	try
	{
		$created = New-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Location $location -StackResourceId (Get-ManagementGroupDeploymentStackId $mgid $rname) -RetentionInterval "P1D" -DeploymentScope "/subscriptions/$((Get-AzContext).Subscription.Id)" -TemplateFile blankTemplate.json -ActionOnUnmanage DetachAll -DenySettingsMode None -Force
        if (Test-DeploymentStackWhatIfResultUnavailable $created) { Assert-DeploymentStackWhatIfResultUnavailable $created; return }
		Assert-DeploymentStackWhatIfResultIdentity $created $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Success: Get by valid ResourceId
		$resourceId = "/providers/Microsoft.Management/managementGroups/$mgid/providers/Microsoft.Resources/deploymentStacksWhatIfResults/$rname"
		$result = Get-AzManagementGroupDeploymentStackWhatIfResult -ResourceId $resourceId
		Assert-NotNull $result
     Assert-DeploymentStackWhatIfResultCompletedOrUnavailable $result
		Assert-DeploymentStackWhatIfResultIdentity $result $rname (Get-ManagementGroupDeploymentStackWhatIfResultId $mgid $rname) (Get-ManagementGroupDeploymentStackId $mgid $rname)

		# Test - Failure: Invalid ResourceId format
		$badResourceId = "not-a-valid-resource-id"
		Assert-ThrowsContains { Get-AzManagementGroupDeploymentStackWhatIfResult -ResourceId $badResourceId } "not in correct form"
	}
	finally
	{
		Remove-AzManagementGroupDeploymentStackWhatIfResult -Name $rname -ManagementGroupId $mgid -Force -ErrorAction SilentlyContinue
	}
}
