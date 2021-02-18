$managementGroupId = "AzBlueprintAssignTest"
$subscriptionId = "a1bfa635-f2bf-42f1-86b5-848c674fc321"
$location = "West US"
$blueprintName = "shenglol-ps-test-bp"
$permanentAssignmentName = "shenglol-ps-test-permanent-assignment"
$transientAssignmentName = "shenglol-ps-test-transient-assignment"

<#
.SYNOPSIS
Test getting Blueprint assignments in a management group.
#>
function Test-GetAssignmentsInManagementGroup
{ 
	$assignments = Get-AzBlueprintAssignment -ManagementGroupId $managementGroupId
    Assert-True { $assignments.Count -ge 1 }

	$assignment = $assignments | where { $_.Name -eq $permanentAssignmentName }
	Assert-NotNull $assignment
}

<#
.SYNOPSIS
Test getting single Blueprint assignment in a management group.
#>
function Test-GetSingleAssignmentInManagementGroup
{ 
	$assignment = Get-AzBlueprintAssignment -Name $permanentAssignmentName -ManagementGroupId $managementGroupId
	Assert-NotNull $assignment
	Assert-AreEqual $permanentAssignmentName $assignment.Name
}

<#
.SYNOPSIS
Test creating a Blueprint assignment in a management group.
#>
function Test-CreateAssignmentInManagementGroup
{
	$blueprint = $blueprint = Get-AzBlueprint -Name $blueprintName -ManagementGroupId $managementGroupId
	$rgParameters = @{ProdRG=@{name='shenglol-ps-test-02';location='westus'}}

	$assignment = New-AzBlueprintAssignment `
		-Name $transientAssignmentName `
		-Location $location `
		-Blueprint $blueprint `
		-ResourceGroupParameter $rgParameters `
		-ManagementGroupId $managementGroupId `
		-SubscriptionId $subscriptionId

	Assert-NotNull $assignment
	Assert-AreEqual "Creating" $assignment.ProvisioningState
 
	$timeout = New-TimeSpan -Minutes 4
	$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()

	while ($assignment.ProvisioningState -ne "Succeeded" -and $assignment.ProvisioningState -ne "Failed" -and $stopwatch.elapsed -lt $timeout)
	{
		Wait-Seconds 10
		$assignment = Get-AzBlueprintAssignment -Name $transientAssignmentName -ManagementGroupId $managementGroupId
	} 

	Assert-AreEqual "Succeeded" $assignment.ProvisioningState
}

<#
.SYNOPSIS
Test updating a Blueprint assignment in a management group.
#>
function Test-updateAssignmentInManagementGroup
{
	$blueprint = $blueprint = Get-AzBlueprint -Name $blueprintName -ManagementGroupId $managementGroupId
	# Update resource group name.
	$rgParameters = @{ProdRG=@{name='shenglol-ps-test-03';location='westus'}}

	$assignment = Set-AzBlueprintAssignment `
		-Name $transientAssignmentName `
		-Location $location `
		-Blueprint $blueprint `
		-ResourceGroupParameter $rgParameters `
		-ManagementGroupId $managementGroupId `
		-SubscriptionId $subscriptionId

	Assert-NotNull $assignment
	Assert-AreEqual "Creating" $assignment.ProvisioningState
 
	$timeout = New-TimeSpan -Minutes 4
	$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()

	while ($assignment.ProvisioningState -ne "Succeeded" -and $assignment.ProvisioningState -ne "Failed" -and $stopwatch.elapsed -lt $timeout)
	{
		Wait-Seconds 10
		$assignment = Get-AzBlueprintAssignment -Name $transientAssignmentName -ManagementGroupId $managementGroupId
	} 

	Assert-AreEqual "Succeeded" $assignment.ProvisioningState
}

<#
.SYNOPSIS
Test removing a Blueprint assignment in a management group.
#>
function Test-RemoveAssignmentInManagementGroup
{
	$assignment = Remove-AzBlueprintAssignment `
		-Name $transientAssignmentName `
		-ManagementGroupId $managementGroupId `
		-PassThru

	Assert-NotNull $assignment
	Assert-AreEqual "Deleting" $assignment.ProvisioningState
}
