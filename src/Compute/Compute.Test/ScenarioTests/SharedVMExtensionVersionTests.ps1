<#
.SYNOPSIS
Creates a shared VM extension version through Azure REST and verifies Get-AzSharedVMExtensionVersion and Set-AzSharedVMExtensionVersionDeprecation against the live resource.
#>
function Test-SharedVMExtensionVersionDeprecation
{
	$rgname = Get-ComputeTestResourceName
	$extensionName = 'sharedext' + $rgname
	$version = '1.0.0'
	$location = (Get-ComputeVMLocation).Replace(' ', '')
	$subscriptionId = (Get-AzContext).Subscription.Id
	$extensionPath = "/subscriptions/$subscriptionId/resourceGroups/$rgname/providers/Microsoft.Compute/sharedVMExtensions/$extensionName"
	$versionPath = "$extensionPath/versions/$version"
	$apiVersion = '2026-03-03'

	try
	{
		# Step 1: Create the resource group and shared VM extension prerequisite with live Azure REST calls.
		New-AzResourceGroup -Name $rgname -Location $location -Force | Out-Null

		$extensionBody = @{
			location = $location
			properties = @{
				label = 'Azure PowerShell scenario test extension'
				description = 'Shared VM extension used to test deprecation commands.'
				companyName = 'Microsoft'
				identifier = @{
					publisher = $extensionName
					type = 'ScenarioTest'
				}
			}
		} | ConvertTo-Json -Depth 5

		$extensionResponse = Invoke-AzRestMethod -Path "${extensionPath}?api-version=$apiVersion" -Method PUT -Payload $extensionBody
		Assert-True { $extensionResponse.StatusCode -eq 200 -or $extensionResponse.StatusCode -eq 201 }

		$versionBody = @{
			location = $location
			tags = @{
				scenario = 'SharedVMExtensionVersionDeprecation'
			}
			properties = @{
				releaseCategory = 'Other'
				urgencyLevel = 'Regular'
				runProfile = 'LongRunning'
				isInternalExtension = $true
				computeRole = 'IaaS'
				supportedOS = 'Windows'
				supportedArchitectures = @('x64')
				releaseNotes = 'Azure PowerShell live scenario test version.'
				deprecationStatus = @{
					state = 'Active'
				}
			}
		} | ConvertTo-Json -Depth 6

		$versionResponse = Invoke-AzRestMethod -Path "${versionPath}?api-version=$apiVersion" -Method PUT -Payload $versionBody
		Assert-True { $versionResponse.StatusCode -eq 200 -or $versionResponse.StatusCode -eq 201 }

		# Step 2: Get the live version by name and verify mapped properties.
		$versionByName = Get-AzSharedVMExtensionVersion -ResourceGroupName $rgname -SharedVMExtensionName $extensionName -Version $version
		Assert-NotNull $versionByName
		Assert-AreEqual $version $versionByName.Name
		Assert-AreEqual 'Other' $versionByName.ReleaseCategory
		Assert-AreEqual 'LongRunning' $versionByName.RunProfile
		Assert-AreEqual 'IaaS' $versionByName.ComputeRole
		Assert-AreEqual 'Windows' $versionByName.SupportedOS
		Assert-AreEqual 1 $versionByName.SupportedArchitectures.Count
		Assert-AreEqual 'x64' $versionByName.SupportedArchitectures[0]
		Assert-AreEqual 'SharedVMExtensionVersionDeprecation' $versionByName.Tags['scenario']
		Assert-AreEqual 'Active' $versionByName.DeprecationStatus.State
		Assert-Null $versionByName.DeprecationStatus.DeprecationTime
		Assert-Null $versionByName.DeprecationStatus.DeprecationType

		# Step 3: Get the same live version by resource ID.
		$versionById = Get-AzSharedVMExtensionVersion -ResourceId $versionByName.Id
		Assert-AreEqual $versionByName.Id $versionById.Id
		Assert-AreEqual $versionByName.Name $versionById.Name
		Assert-AreEqual $versionByName.ReleaseNotes $versionById.ReleaseNotes

		# Step 4: Verify invalid scheduling is rejected after reading the live version.
		Assert-ThrowsContains {
			Set-AzSharedVMExtensionVersionDeprecation `
				-ResourceGroupName $rgname `
				-SharedVMExtensionName $extensionName `
				-Version $version `
				-DeprecationState ScheduledForDeprecation
		} '-DaysUntilDeprecation must be specified'

		# Step 5: Schedule deprecation with the day parameter alone and verify it persisted server-side.
		$scheduled = Set-AzSharedVMExtensionVersionDeprecation `
			-ResourceGroupName $rgname `
			-SharedVMExtensionName $extensionName `
			-Version $version `
			-DeprecationState ScheduledForDeprecation `
			-DaysUntilDeprecation 30

		Assert-AreEqual 'ScheduledForDeprecation' $scheduled.DeprecationStatus.State
		Assert-Null $scheduled.DeprecationStatus.DeprecationType
		Assert-NotNull $scheduled.DeprecationStatus.DeprecationTime
		Assert-AreEqual 'SharedVMExtensionVersionDeprecation' $scheduled.Tags['scenario']
		Assert-AreEqual 'Azure PowerShell live scenario test version.' $scheduled.ReleaseNotes

		$persistedSchedule = Get-AzSharedVMExtensionVersion -ResourceId $scheduled.Id
		Assert-AreEqual 'ScheduledForDeprecation' $persistedSchedule.DeprecationStatus.State
		Assert-Null $persistedSchedule.DeprecationStatus.DeprecationType
		Assert-AreEqual $scheduled.DeprecationStatus.DeprecationTime $persistedSchedule.DeprecationStatus.DeprecationTime
		Assert-AreEqual 'SharedVMExtensionVersionDeprecation' $persistedSchedule.Tags['scenario']
		Assert-AreEqual 'Azure PowerShell live scenario test version.' $persistedSchedule.ReleaseNotes

		# Step 6: Set the deprecation type alone through the resource-ID parameter set and preserve the schedule.
		$typedSchedule = Set-AzSharedVMExtensionVersionDeprecation `
			-ResourceId $persistedSchedule.Id `
			-DeprecationState ScheduledForDeprecation `
			-DeprecationType Minor

		Assert-AreEqual 'ScheduledForDeprecation' $typedSchedule.DeprecationStatus.State
		Assert-AreEqual 'Minor' $typedSchedule.DeprecationStatus.DeprecationType
		Assert-AreEqual $persistedSchedule.DeprecationStatus.DeprecationTime $typedSchedule.DeprecationStatus.DeprecationTime

		$persistedTypedSchedule = Get-AzSharedVMExtensionVersion -ResourceId $typedSchedule.Id
		Assert-AreEqual 'ScheduledForDeprecation' $persistedTypedSchedule.DeprecationStatus.State
		Assert-AreEqual 'Minor' $persistedTypedSchedule.DeprecationStatus.DeprecationType
		Assert-AreEqual $typedSchedule.DeprecationStatus.DeprecationTime $persistedTypedSchedule.DeprecationStatus.DeprecationTime

		# Step 7: Set both optional parameters together and verify unrelated resource state is preserved.
		$combinedSchedule = Set-AzSharedVMExtensionVersionDeprecation `
			-ResourceGroupName $rgname `
			-SharedVMExtensionName $extensionName `
			-Version $version `
			-DeprecationState ScheduledForDeprecation `
			-DaysUntilDeprecation 45 `
			-DeprecationType Patch

		Assert-AreEqual 'ScheduledForDeprecation' $combinedSchedule.DeprecationStatus.State
		Assert-AreEqual 'Patch' $combinedSchedule.DeprecationStatus.DeprecationType
		Assert-NotNull $combinedSchedule.DeprecationStatus.DeprecationTime
		Assert-AreEqual 'SharedVMExtensionVersionDeprecation' $combinedSchedule.Tags['scenario']
		Assert-AreEqual 'Azure PowerShell live scenario test version.' $combinedSchedule.ReleaseNotes

		$persistedCombinedSchedule = Get-AzSharedVMExtensionVersion -ResourceId $combinedSchedule.Id
		Assert-AreEqual 'ScheduledForDeprecation' $persistedCombinedSchedule.DeprecationStatus.State
		Assert-AreEqual 'Patch' $persistedCombinedSchedule.DeprecationStatus.DeprecationType
		Assert-AreEqual $combinedSchedule.DeprecationStatus.DeprecationTime $persistedCombinedSchedule.DeprecationStatus.DeprecationTime

		# Step 8: Change state through the resource-ID parameter set and preserve existing deprecation details.
		$deprecated = Set-AzSharedVMExtensionVersionDeprecation `
			-ResourceId $persistedCombinedSchedule.Id `
			-DeprecationState Deprecated

		Assert-AreEqual 'Deprecated' $deprecated.DeprecationStatus.State
		Assert-AreEqual 'Patch' $deprecated.DeprecationStatus.DeprecationType
		Assert-AreEqual $persistedCombinedSchedule.DeprecationStatus.DeprecationTime $deprecated.DeprecationStatus.DeprecationTime

		$persistedDeprecated = Get-AzSharedVMExtensionVersion -ResourceId $deprecated.Id
		Assert-AreEqual 'Deprecated' $persistedDeprecated.DeprecationStatus.State
		Assert-AreEqual 'Patch' $persistedDeprecated.DeprecationStatus.DeprecationType
		Assert-AreEqual $deprecated.DeprecationStatus.DeprecationTime $persistedDeprecated.DeprecationStatus.DeprecationTime

		# Step 9: Verify partial override validation and reactivate through the input-object parameter set.
		Assert-ThrowsContains {
			$persistedDeprecated | Set-AzSharedVMExtensionVersionDeprecation `
				-DeprecationState Active `
				-DaysUntilDeprecation 10
		} '-DaysUntilDeprecation and -DeprecationType must be specified together'

		$active = $persistedDeprecated | Set-AzSharedVMExtensionVersionDeprecation -DeprecationState Active
		Assert-AreEqual 'Active' $active.DeprecationStatus.State
		Assert-Null $active.DeprecationStatus.DeprecationTime
		Assert-Null $active.DeprecationStatus.DeprecationType

		$persistedActive = Get-AzSharedVMExtensionVersion `
			-ResourceGroupName $rgname `
			-SharedVMExtensionName $extensionName `
			-Version $version
		Assert-AreEqual 'Active' $persistedActive.DeprecationStatus.State
		Assert-Null $persistedActive.DeprecationStatus.DeprecationTime
		Assert-Null $persistedActive.DeprecationStatus.DeprecationType
		Assert-AreEqual 'SharedVMExtensionVersionDeprecation' $persistedActive.Tags['scenario']
		Assert-AreEqual 'Azure PowerShell live scenario test version.' $persistedActive.ReleaseNotes
	}
	finally
	{
		Remove-AzResourceGroup -Name $rgname -Force -ErrorAction SilentlyContinue
	}
}
