function Get-TestSubscriptionScope
{
	return "subscriptions/a1bfa635-f2bf-42f1-86b5-848c674fc321"
}

<#
.SYNOPSIS
Test Blueprint assignment cmdlets. Get a single Blueprint and assignment it to a subscription and delete.
#>

function Test-GetBlueprintAssignment
{ 
	$assignments = Get-AzBlueprintAssignment

    Assert-True { $assignments.Count -ge 1 }
	Assert-NotNull $assignments[0].Name
	Assert-NotNull $assignments[0].Id
	Assert-NotNull $assignments[0].BlueprintId
	Assert-NotNull $assignments[0].Scope
	Assert-NotNull $assignments[0].Location
}

function Test-NewBlueprintAssignment
{
	$mgId = "AzBlueprint"
	$blueprintName = "Filiz_Powershell_Test"
	$subscriptionId = "28cbf98f-381d-4425-9ac4-cf342dab9753"
	$assignmentName = "PS-ScenarioTest-NewAssignment"
	$location = "East US"
	$params = @{audituseofclassicvirtualmachines_effect='Audit'}
	$rg1 = @{name='filiz-ps-testrgName5';location='eastus'}
	$rgs = @{ResourceGroup=$rg1}

    $blueprint = Get-AzBlueprint -ManagementGroupId $mgId -Name $blueprintName
	Assert-NotNull $blueprint
	Assert-AreEqual $blueprintName $blueprint.Name
	
	$assignment = New-AzBlueprintAssignment -Name $assignmentName -Blueprint $blueprint -SubscriptionId $subscriptionId -Location $location -Parameters $params -ResourceGroups $rgs

	$expectedProvisioningState = "Creating"

	Assert-NotNull $assignment
	Assert-AreEqual $assignment.ProvisioningState $expectedProvisioningState

}

function Test-SetBlueprintAssingment
{
	$mgId = "AzBlueprint";
	$blueprintName = "Filiz_Powershell_Test";
	$subscriptionId = "4ce8c9fe-cadc-47d6-9c76-335812fd59df";
	$assignmentName = "PS-ScenarioTest-NewAssignment"
	$location = "East US";
	$param=@{audituseofclassicvirtualmachines_effect='Audit'}
	$rg1 = @{name='filiz-ps-testrgName5';location='eastus'}
	$rgs = @{ResourceGroup=$rg1}

    $blueprint = Get-AzureRmBlueprint -ManagementGroupId $mgId -Name $blueprintName
	Assert-NotNull $blueprint
	Assert-AreEqual $blueprintName $blueprint.Name
	
	$assignment = SetBlueprintAssingment-AzureRMBlueprintAssignment -Name $assignmentName -Blueprint $blueprint -SubscriptionId $subscriptionId -Location $location -Parameters $params -ResourceGroups $rgs

	$expectedProvisioningState = "Creating"

	Assert-NotNull $assignment
}

function Test-RemoveBlueprintAssignment
{
	$subscriptionScope = Get-TestSubscriptionScope
	$assignments = Get-AzBlueprintAssignment | where { $_.Scope -eq $subscriptionScope }

    Assert-True {$blueprints.Count -ge 1}
	Assert-NotNull $assignments[0].Name
	Assert-NotNull $assignments[0].Id
	Assert-NotNull $assignments[0].BlueprintId
	Assert-NotNull $assignments[0].Scope
	Assert-NotNull $assignments[0].Location
	Assert-NotNull $assignments[0].Description
}

