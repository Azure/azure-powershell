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
	$mgId = "AzBlueprintAssignTest"
	$blueprintName = "Filiz-Ps-Test1"
	$subscriptionId = "28cbf98f-381d-4425-9ac4-cf342dab9753"
	$assignmentName = "PS-ScenarioTest-NewAssignment"
	$location = "East US"
	$params = @{audituseofclassicvirtualmachines_effect='Audit'}
	$rg1 = @{name='bp-testrg';location='eastus'}
	$rgs = @{ResourceGroup=$rg1}
	$identity = "/subscriptions/996a2f3f-ee01-4ffd-9765-d2c3fc98f30a/resourceGroups/user-assigned-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/owner-identity"

    $blueprint = Get-AzBlueprint -ManagementGroupId $mgId -Name $blueprintName
	Assert-NotNull $blueprint
	Assert-AreEqual $blueprintName $blueprint.Name
	
	$assignment = New-AzBlueprintAssignment -Name $assignmentName -Blueprint $blueprint -SubscriptionId $subscriptionId -Location $location -Parameters $params -ResourceGroups $rgs -UserAssignedIdentity $identity

	$expectedProvisioningState = "Creating"
	Assert-NotNull $assignment
	Assert-AreEqual $assignment.ProvisioningState $expectedProvisioningState
}

function Test-SetBlueprintAssignment
{
	$mgId = "AzBlueprintAssignTest"
	$blueprintName = "Filiz-Ps-Test1"
	$subscriptionId = "28cbf98f-381d-4425-9ac4-cf342dab9753"
	$assignmentName = "PS-ScenarioTest-SetAssignment"
	$location = "East US"
	$params = @{audituseofclassicvirtualmachines_effect='Audit'}
	$rg1 = @{name='bp-testrg';location='eastus'}
	$rgs = @{ResourceGroup=$rg1}
	$identity = "/subscriptions/996a2f3f-ee01-4ffd-9765-d2c3fc98f30a/resourceGroups/user-assigned-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/owner-identity"

	# Get the test blueprint
    $blueprint = Get-AzBlueprint -ManagementGroupId $mgId -Name $blueprintName
	Assert-NotNull $blueprint
	Assert-AreEqual $blueprintName $blueprint.Name

	# Assign blueprint
	$assignment = New-AzBlueprintAssignment -Name $assignmentName -Blueprint $blueprint -SubscriptionId $subscriptionId -Location $location -Parameters $params -ResourceGroups $rgs -UserAssignedIdentity $identity
	$expectedProvisioningState = "Creating"
	Assert-NotNull $assignment
	Assert-AreEqual $assignment.ProvisioningState $expectedProvisioningState

	# Retrieve assigned blueprint
	$assigned = Get-AzBlueprintAssignment -SubscriptionId $subscriptionId -Name $assignmentName
	# Wait till the provisioning state changes to succeeded
	$assigned = Get-AzBlueprintAssignment -SubscriptionId $subscriptionId -Name $assignmentName
	while($assigned.ProvisioningState -eq "Creating" -or $assigned.ProvisioningState -eq "Deploying")
    {
        Wait-Seconds 10
        $assigned = Get-AzBlueprintAssignment -SubscriptionId $subscriptionId -Name $assignmentName
    }
	
	#update rg name and re-assign
	$newTestRg = "bp-testrg-new"
	$rg1 = @{name= $newTestRg;location='eastus'}
	$rgs = @{ResourceGroup=$rg1}
	$assignment = Set-AzBlueprintAssignment -Name $assignmentName -Blueprint $blueprint -SubscriptionId $subscriptionId -Location $location -Parameters $params -ResourceGroups $rgs -UserAssignedIdentity $identity
	$expectedProvisioningState = "Creating"
	Assert-NotNull $assignment
	Assert-AreEqual $assignment.ProvisioningState $expectedProvisioningState
}

function Test-RemoveBlueprintAssignment
{
	$mgId = "AzBlueprintAssignTest"
	$blueprintName = "Filiz-Ps-Test1"
	$subscriptionId = "28cbf98f-381d-4425-9ac4-cf342dab9753"
	$assignmentName = "PS-ScenarioTest-RemoveAssignment"
	$location = "East US"
	$params = @{audituseofclassicvirtualmachines_effect='Audit'}
	$rg1 = @{name='bp-testrg';location='eastus'}
	$rgs = @{ResourceGroup=$rg1}
	$identity = "/subscriptions/996a2f3f-ee01-4ffd-9765-d2c3fc98f30a/resourceGroups/user-assigned-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/owner-identity"

	# Get the test blueprint
    $blueprint = Get-AzBlueprint -ManagementGroupId $mgId -Name $blueprintName
	Assert-NotNull $blueprint
	Assert-AreEqual $blueprintName $blueprint.Name

	# Assign blueprint
	$assignment = New-AzBlueprintAssignment -Name $assignmentName -Blueprint $blueprint -SubscriptionId $subscriptionId -Location $location -Parameters $params -ResourceGroups $rgs -UserAssignedIdentity $identity
	$expectedProvisioningState = "Creating"
	Assert-NotNull $assignment
	Assert-AreEqual $assignment.ProvisioningState $expectedProvisioningState

	# Retrieve assigned blueprint
	$assigned = Get-AzBlueprintAssignment -SubscriptionId $subscriptionId -Name $assignmentName
	while($assigned.ProvisioningState -eq "Creating" -or $assigned.ProvisioningState -eq "Deploying")
    {
        Wait-Seconds 10
        $assigned = Get-AzBlueprintAssignment -SubscriptionId $subscriptionId -Name $assignmentName
    }
	
	# remove assignment
	$removed = Remove-AzBlueprintAssignment -SubscriptionId $subscriptionId -Name $assignment.Name -PassThru
	$expectedProvisioningState = "Deleting"
	Assert-NotNull $removed
	Assert-AreEqual $removed.Name $assignment.Name
	Assert-AreEqual $removed.ProvisioningState $expectedProvisioningState
}

