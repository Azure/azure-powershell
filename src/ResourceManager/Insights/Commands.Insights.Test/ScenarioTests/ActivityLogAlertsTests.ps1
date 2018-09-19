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
Tests getting the logs associated to a correlation Id.
#>
function Test-SetGetListUpdateRemoveActivityLogAlert
{
	Write-Output "Starting Test-AddActivityLogAlert" 

    # Setup
	$resourceGroupName = 'Default-ActivityLogAlerts'
	$alertName = 'andy0307rule'
	$location = 'Global'

	try
	{
		Write-Verbose " ****** Creating a new LeafCondition object"
		$condition1 = New-AzureRmActivityLogAlertCondition -Field 'field1' -Equal 'equals1'

		Assert-NotNull $condition1
		Assert-AreEqual 'field1' $condition1.Field
		Assert-AreEqual 'equals1' $condition1.Equals

        $condition2 = New-AzureRmActivityLogAlertCondition -Field 'field2' -Equal 'equals2'

		Assert-NotNull $condition1
		Assert-AreEqual 'field1' $condition1.Field
		Assert-AreEqual 'equals1' $condition1.Equals

		Write-Verbose " ****** Creating a new ActionGroup object"
		# Could also be $dict = @{}
		$dict = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$dict.Add('key1', 'value1')

		Assert-NotNull $dict

		$actionGrp1 = New-AzureRmActionGroup -ActionGroupId 'actiongr1' -WebhookProperty $dict

		Assert-NotNull $actionGrp1
		Assert-AreEqual 'actiongr1' $actionGrp1.ActionGroupId
		Assert-NotNull $actionGrp1.WebhookProperties
		Assert-AreEqual 'value1' $actionGrp1.WebhookProperties['key1']

		Write-Verbose " ****** Creating a new ActivityLogAlert"
		$actual = Set-AzureRmActivityLogAlert -Location $location -Name $alertName -ResourceGroupName $resourceGroupName -Scope 'scope1','scope2' -Action $actionGrp1 -Condition $condition1
		# , $condition2

		Assert-NotNull $actual
		Assert-AreEqual $alertName $actual.Name
		Assert-AreEqual $location $actual.Location
		Assert-AreEqual 1 $actual.Actions.Length
		Assert-AreEqual 1 $actual.Condition.Length

		Write-Verbose " ****** Getting the ActivityLogAlerts by subscriptionId"
		$retrievedSubId = Get-AzureRmActivityLogAlert

		Assert-NotNull $retrievedSubId
		Assert-AreEqual 2 $retrievedSubId.Length
		Assert-AreEqual $alertName $retrievedSubId[0].Name
		Assert-AreEqual $location $retrievedSubId[0].Location

		Write-Verbose " ****** Getting the ActivityLogAlerts by resource group"
		$retrievedRg = Get-AzureRmActivityLogAlert -ResourceGroup $resourceGroupName

		Assert-NotNull $retrievedRg
		Assert-AreEqual 1 $retrievedRg.Length
		Assert-AreEqual $alertName $retrievedRg[0].Name
		Assert-AreEqual $location $retrievedRg[0].Location

		Write-Verbose " ****** Getting the ActivityLogAlerts by name"
		$retrieved = Get-AzureRmActivityLogAlert -ResourceGroup $resourceGroupName -Name $alertName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Assert-AreEqual $alertName $retrieved[0].Name
		#Assert-AreEqual $location $retrieved[0].Location

		Write-Verbose " ****** Creating a new Tags object"
		# Could also be $dict = @{}
		$dict = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
		$dict.Add('key1', 'value1')

		Assert-NotNull $dict

		Write-Verbose " ****** Patching the ActivityLogAlert"
		Assert-ThrowsContains 
			{
				$updated = Disable-AzureRmActivityLogAlert -ResourceGroupName $resourceGroupName -Name $alertName -Tag $dict

				Assert-NotNull $updated
				Assert-AreEqual $alertName $updated.Name
				Assert-AreEqual $location $updated.Location
				Assert-NotNull $updated.Tags
				Assert-False { $updated.Enabled }
			}
			"BadRequest"

		Assert-ThrowsContains 
			{
				$updated = Disable-AzureRmActivityLogAlert -InputObject $actual

				Assert-NotNull $updated
				Assert-AreEqual $alertName $updated.Name
				Assert-AreEqual $location $updated.Location
				Assert-NotNull $updated.Tags
				Assert-False { $updated.Enabled }
			}
			"BadRequest"

		Assert-ThrowsContains 
			{
				$updated = Disable-AzureRmActivityLogAlert -ResourceId $actual.Id

				Assert-NotNull $updated
				Assert-AreEqual $alertName $updated.Name
				Assert-AreEqual $location $updated.Location
				Assert-NotNull $updated.Tags
				Assert-False { $updated.Enabled }
			}
			"BadRequest"

         Assert-ThrowsContains 
			{
				$updated = Enable-AzureRmActivityLogAlert -ResourceGroupName $resourceGroupName -Name $alertName -Tag $dict

				Assert-NotNull $updated
				Assert-AreEqual $alertName $updated.Name
				Assert-AreEqual $location $updated.Location
				Assert-NotNull $updated.Tags
				Assert-False { $updated.Enabled }
			}
			"BadRequest"

		Assert-ThrowsContains 
			{
				$updated = Enable-AzureRmActivityLogAlert -InputObject $actual

				Assert-NotNull $updated
				Assert-AreEqual $alertName $updated.Name
				Assert-AreEqual $location $updated.Location
				Assert-NotNull $updated.Tags
				Assert-False { $updated.Enabled }
			}
			"BadRequest"

		Assert-ThrowsContains 
			{
				$updated = Enable-AzureRmActivityLogAlert -ResourceId $actual.Id

				Assert-NotNull $updated
				Assert-AreEqual $alertName $updated.Name
				Assert-AreEqual $location $updated.Location
				Assert-NotNull $updated.Tags
				Assert-False { $updated.Enabled }
			}
			"BadRequest"

		Write-Verbose " ****** NOP: setting an activity log alert using the value from the pipe (InputObject)"
		Get-AzureRmActivityLogAlert -ResourceGroup $resourceGroupName -Name $alertName | Set-AzureRmActivityLogAlert

		Write-Verbose " ****** Disabling an activity log alert using the value of ResourceId plus another parameter"
		Set-AzureRmActivityLogAlert -ResourceId '/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-ActivityLogAlerts/providers/microsoft.insights/activityLogAlerts/andy0307rule' -DisableAlert

		Write-Verbose " ****** Removing the ActivityLogAlert using pileline"
		Get-AzureRmActivityLogAlert -ResourceGroup $resourceGroupName -Name $alertName | Remove-AzureRmActivityLogAlert

		Write-Verbose " ****** Removing (again) the ActivityLogAlert"
		Remove-AzureRmActivityLogAlert -ResourceGroupName $resourceGroupName -Name $alertName

		Write-Verbose " ****** Removing (again) the ActivityLogAlert using ResourceId param"
		Remove-AzureRmActivityLogAlert -ResourceId $actual.Id
    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
