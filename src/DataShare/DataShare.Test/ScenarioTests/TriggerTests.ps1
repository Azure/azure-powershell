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
Full Account CRUD cycle
#>
function Test-TriggerCrud
{
    $ResourceGroupName = getAssetName

	try{
		$AccountName = getAssetName
		$SubName = getAssetName
		$TriggerName = getAssetName

		$RecurrenceInterval = "hour"
		$SynchronizationTime = "06/19/2019 22:53:33"

		$newTrigger = New-AzDataShareTrigger -ResourceGroupName $ResourceGroupName -AccountName $AccountName -ShareSubscriptionName $SubName -RecurrenceInterval $RecurrenceInterval -SynchronizationTime $SynchronizationTime -Name $TriggerName

		Assert-NotNull $newTrigger
		Assert-AreEqual $newTrigger.Name $TriggerName
		Assert-AreEqual $newTrigger.ProvisioningState "Succeeded"

		$gottenTrigger = Get-AzDataShareTrigger -ResourceGroupName $ResourceGroupName -AccountName $AccountName -ShareSubscriptionName $SubName

		Assert-NotNull $newTrigger
		Assert-AreEqual $newTrigger.Name $TriggerName
		Assert-AreEqual $newTrigger.ProvisioningState "Succeeded"

		$gottenTrigger = Get-AzDataShareTrigger -ResourceGroupName $ResourceGroupName -AccountName $AccountName -ShareSubscriptionName $SubName -Name $TriggerName

		Assert-NotNull $newTrigger
		Assert-AreEqual $newTrigger.Name $TriggerName
		Assert-AreEqual $newTrigger.ProvisioningState "Succeeded"

		$gottenTrigger = Get-AzDataShareTrigger -ResourceId $gottenTrigger.Id
	
		Assert-NotNull $newTrigger
		Assert-AreEqual $newTrigger.Name $TriggerName
		Assert-AreEqual $newTrigger.ProvisioningState "Succeeded"

		$removedTrigger = Remove-AzDataShareTrigger -InputObject $gottenTrigger
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}