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

		# Step 4: ScheduledForDeprecation requires both -DaysUntilDeprecation and -DeprecationType.
		Assert-ThrowsContains {
			Set-AzSharedVMExtensionVersionDeprecation `
				-ResourceGroupName $rgname `
				-SharedVMExtensionName $extensionName `
				-Version $version `
				-DeprecationState ScheduledForDeprecation
		} '-DaysUntilDeprecation and -DeprecationType are both required'

		# Step 5: ScheduledForDeprecation with only -DaysUntilDeprecation is rejected.
		Assert-ThrowsContains {
			Set-AzSharedVMExtensionVersionDeprecation `
				-ResourceGroupName $rgname `
				-SharedVMExtensionName $extensionName `
				-Version $version `
				-DeprecationState ScheduledForDeprecation `
				-DaysUntilDeprecation 30
		} '-DaysUntilDeprecation and -DeprecationType are both required'

		# Step 6: ScheduledForDeprecation with only -DeprecationType is rejected.
		Assert-ThrowsContains {
			Set-AzSharedVMExtensionVersionDeprecation `
				-ResourceGroupName $rgname `
				-SharedVMExtensionName $extensionName `
				-Version $version `
				-DeprecationState ScheduledForDeprecation `
				-DeprecationType Minor
		} '-DaysUntilDeprecation and -DeprecationType are both required'

		# Step 7: Schedule deprecation with both parameters and verify it persisted server-side.
		$scheduled = Set-AzSharedVMExtensionVersionDeprecation `
			-ResourceGroupName $rgname `
			-SharedVMExtensionName $extensionName `
			-Version $version `
			-DeprecationState ScheduledForDeprecation `
			-DaysUntilDeprecation 30 `
			-DeprecationType Minor

		Assert-AreEqual 'ScheduledForDeprecation' $scheduled.DeprecationStatus.State
		Assert-AreEqual 'Minor' $scheduled.DeprecationStatus.DeprecationType
		Assert-NotNull $scheduled.DeprecationStatus.DeprecationTime
		Assert-AreEqual 'SharedVMExtensionVersionDeprecation' $scheduled.Tags['scenario']
		Assert-AreEqual 'Azure PowerShell live scenario test version.' $scheduled.ReleaseNotes

		$persistedSchedule = Get-AzSharedVMExtensionVersion -ResourceId $scheduled.Id
		Assert-AreEqual 'ScheduledForDeprecation' $persistedSchedule.DeprecationStatus.State
		Assert-AreEqual 'Minor' $persistedSchedule.DeprecationStatus.DeprecationType
		Assert-AreEqual $scheduled.DeprecationStatus.DeprecationTime $persistedSchedule.DeprecationStatus.DeprecationTime

		# Step 8: Re-schedule with new values and verify the status is rebuilt from the supplied data.
		$reScheduled = Set-AzSharedVMExtensionVersionDeprecation `
			-ResourceId $persistedSchedule.Id `
			-DeprecationState ScheduledForDeprecation `
			-DaysUntilDeprecation 45 `
			-DeprecationType Patch

		Assert-AreEqual 'ScheduledForDeprecation' $reScheduled.DeprecationStatus.State
		Assert-AreEqual 'Patch' $reScheduled.DeprecationStatus.DeprecationType
		Assert-NotNull $reScheduled.DeprecationStatus.DeprecationTime
		Assert-AreNotEqual $persistedSchedule.DeprecationStatus.DeprecationTime $reScheduled.DeprecationStatus.DeprecationTime

		$persistedReSchedule = Get-AzSharedVMExtensionVersion -ResourceId $reScheduled.Id
		Assert-AreEqual 'ScheduledForDeprecation' $persistedReSchedule.DeprecationStatus.State
		Assert-AreEqual 'Patch' $persistedReSchedule.DeprecationStatus.DeprecationType
		Assert-AreEqual $reScheduled.DeprecationStatus.DeprecationTime $persistedReSchedule.DeprecationStatus.DeprecationTime

		# Step 9: Deprecated requires -DeprecationType.
		Assert-ThrowsContains {
			Set-AzSharedVMExtensionVersionDeprecation `
				-ResourceId $persistedReSchedule.Id `
				-DeprecationState Deprecated
		} '-DeprecationType is required'

		# Step 10: Deprecated does not allow -DaysUntilDeprecation.
		Assert-ThrowsContains {
			Set-AzSharedVMExtensionVersionDeprecation `
				-ResourceId $persistedReSchedule.Id `
				-DeprecationState Deprecated `
				-DeprecationType Major `
				-DaysUntilDeprecation 5
		} "-DaysUntilDeprecation cannot be specified when -DeprecationState is 'Deprecated'"

		# Step 11: Deprecate the version immediately with -DeprecationType only.
		$deprecated = Set-AzSharedVMExtensionVersionDeprecation `
			-ResourceId $persistedReSchedule.Id `
			-DeprecationState Deprecated `
			-DeprecationType Major

		Assert-AreEqual 'Deprecated' $deprecated.DeprecationStatus.State
		Assert-AreEqual 'Major' $deprecated.DeprecationStatus.DeprecationType
		Assert-NotNull $deprecated.DeprecationStatus.DeprecationTime

		$persistedDeprecated = Get-AzSharedVMExtensionVersion -ResourceId $deprecated.Id
		Assert-AreEqual 'Deprecated' $persistedDeprecated.DeprecationStatus.State
		Assert-AreEqual 'Major' $persistedDeprecated.DeprecationStatus.DeprecationType
		Assert-AreEqual $deprecated.DeprecationStatus.DeprecationTime $persistedDeprecated.DeprecationStatus.DeprecationTime

		# Step 12: Active does not allow deprecation parameters.
		Assert-ThrowsContains {
			$persistedDeprecated | Set-AzSharedVMExtensionVersionDeprecation `
				-DeprecationState Active `
				-DaysUntilDeprecation 10
		} "-DaysUntilDeprecation and -DeprecationType cannot be specified when -DeprecationState is 'Active'"

		# Step 13: Reactivate through the input-object parameter set and verify the status is cleared.
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
