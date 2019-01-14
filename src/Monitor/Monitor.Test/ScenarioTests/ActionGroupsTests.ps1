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
function Test-AddGetListSetRemoveActionGroup
{
	Write-Output "Starting Test-SetActivityLogAlert" 

    # Setup
	$resourceGroupName = 'Default-ActivityLogAlerts'
	$actionGroupName = 'andygroup-donotuse'
	$shortName = 'andygroup'
	
	try
	{
		Write-Verbose " ****** Creating a new email receiver"
		$email1 = New-AzureRmActionGroupReceiver -EmailReceiver -Name 'emailreceiver' -EmailAddress 'andyshen@microsoft.com'
		Assert-NotNull $email1
		Assert-AreEqual 'emailreceiver' $email1.Name
		Assert-AreEqual 'andyshen@microsoft.com' $email1.EmailAddress
		
		Write-Verbose " ****** Creating a new sms receiver"
		$sms1 = New-AzureRmActionGroupReceiver -SmsReceiver -Name 'smsreceiver' -CountryCode '1' -PhoneNumber '4254251234'
		Assert-NotNull $sms1
		Assert-AreEqual 'smsreceiver' $sms1.Name
		Assert-AreEqual '1' $sms1.CountryCode
		Assert-AreEqual '4254251234' $sms1.PhoneNumber
		
		Write-Verbose " ****** Creating a new webhook receiver"
		$webhook1 = New-AzureRmActionGroupReceiver -WebhookReceiver -Name 'webhookreceiver' -ServiceUri 'http://test.com'
		Assert-NotNull $webhook1
		Assert-AreEqual 'webhookreceiver' $webhook1.Name
		Assert-AreEqual 'http://test.com' $webhook1.ServiceUri
		
		Write-Verbose " ****** Creating a new action group"
		$actual =  Set-AzureRmActionGroup -Name $actionGroupName -ResourceGroup $resourceGroupName -ShortName $shortName -Receiver $email1,$sms1,$webhook1
		Assert-NotNull $actual
		Assert-AreEqual $actionGroupName $actual.Name

		Write-Verbose " ****** Getting the action group by name"
		$retrieved = Get-AzureRmActionGroup -ResourceGroup $resourceGroupName -Name $actionGroupName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Assert-AreEqual $actionGroupName $retrieved[0].Name
		
		Write-Verbose " ****** Getting the action group by subscriptionId"
		$retrieved = Get-AzureRmActionGroup
		Assert-NotNull $retrieved
		Assert-AreEqual 2 $retrieved.Length
		Assert-AreEqual $actionGroupName $retrieved[0].Name
		
		Write-Verbose " ****** Getting the action group by resource group"
		$retrieved = Get-AzureRmActionGroup -ResourceGroupName $resourceGroupName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Assert-AreEqual $actionGroupName $retrieved[0].Name

		Write-Verbose " ****** Removing the action group"
		Remove-AzureRmActionGroup -ResourceGroup $resourceGroupName -Name $actionGroupName

    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
