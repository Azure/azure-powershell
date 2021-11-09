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

	[bool]$t = $true
	[bool]$f = $false
	$emptyString=""
 	
	try
	{
		Write-Verbose " ****** Creating a new email receiver with default UseCommonAlertSchema not explicitly set"
		$email1 = New-AzActionGroupReceiver -EmailReceiver -Name 'emailreceiver' -EmailAddress 'andyshen@microsoft.com'
		Assert-NotNull $email1
		Assert-AreEqual 'emailreceiver' $email1.Name
		Assert-AreEqual 'andyshen@microsoft.com' $email1.EmailAddress
		# when UseCommonAlertSchema is not set explicitly , then it is false
		Assert-AreEqual false $email1.UseCommonAlertSchema
		
		Write-Verbose " ****** Creating a new email receiver with  UseCommonAlertSchema  explicitly set to true"
		$email2 = New-AzActionGroupReceiver -EmailReceiver -Name 'emailreceiver1' -EmailAddress 'some email' -UseCommonAlertSchema
		Assert-NotNull $email2
		Assert-AreEqual 'emailreceiver1' $email2.Name
		Assert-AreEqual 'some email' $email2.EmailAddress
		Assert-AreEqual true $email2.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new event hub receiver with default UseCommonAlertSchema not explicitly set"
		$eventhub1 = New-AzActionGroupReceiver -EventHubReceiver -Name 'eventhub1receiver' -SubscriptionId '5def922a-3ed4-49c1-b9fd-05ec533819a3' -EventHubNameSpace 'eventhubNameSpace1' -EventHubName 'testEventHubName1'
		Assert-NotNull $eventhub1
		Assert-AreEqual 'eventhub1receiver' $eventhub1.Name
		Assert-AreEqual '5def922a-3ed4-49c1-b9fd-05ec533819a3' $eventhub1.SubscriptionId
		Assert-AreEqual 'eventhubNameSpace1' $eventhub1.EventHubNameSpace
		Assert-AreEqual 'testEventHubName1' $eventhub1.EventHubName
		# when UseCommonAlertSchema is not set explicitly , then it is false
		Assert-AreEqual false $eventhub1.UseCommonAlertSchema
		
		Write-Verbose " ****** Creating a new event hub receiver with  UseCommonAlertSchema  explicitly set to true"
		$eventhub2 = New-AzActionGroupReceiver -EventHubReceiver -Name 'eventhub2receiver' -SubscriptionId '5def922a-3ed4-49c1-b9fd-05ec533819a3' -EventHubNameSpace 'eventhubNameSpace2' -EventHubName 'testEventHubName2' -UseCommonAlertSchema
		Assert-NotNull $eventhub2
		Assert-AreEqual 'eventhub2receiver' $eventhub2.Name
		Assert-AreEqual '5def922a-3ed4-49c1-b9fd-05ec533819a3' $eventhub2.SubscriptionId
		Assert-AreEqual 'eventhubNameSpace2' $eventhub2.EventHubNameSpace
		Assert-AreEqual 'testEventHubName2' $eventhub2.EventHubName
		Assert-AreEqual true $eventhub2.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new sms receiver"
		$sms1 = New-AzActionGroupReceiver -SmsReceiver -Name 'smsreceiver' -CountryCode '1' -PhoneNumber '4254251234'
		Assert-NotNull $sms1
		Assert-AreEqual 'smsreceiver' $sms1.Name
		Assert-AreEqual '1' $sms1.CountryCode
		Assert-AreEqual '4254251234' $sms1.PhoneNumber
		
		Write-Verbose " ****** Creating a new webhook receiver with default UseCommonAlertSchema not explicitly set and use aad auth not set"
		$webhook1 = New-AzActionGroupReceiver -WebhookReceiver -Name 'webhookreceiver' -ServiceUri 'http://test.com'
		Assert-NotNull $webhook1
		Assert-AreEqual 'webhookreceiver' $webhook1.Name
		Assert-AreEqual 'http://test.com' $webhook1.ServiceUri
		Assert-AreEqual false $webhook1.UseCommonAlertSchema
		Assert-AreEqual false $webhook1.UseAadAuth
		Assert-AreEqual $emptyString $webhook1.ObjectId
		Assert-AreEqual $emptyString $webhook1.IdentifierUri
		Assert-AreEqual $emptyString $webhook1.TenantId

		Write-Verbose " ****** Creating a new webhook receiver with  UseCommonAlertSchema  explicitly set and use aad auth  set"
		$webhook2 = New-AzActionGroupReceiver -WebhookReceiver -Name 'webhookreceiver' -ServiceUri 'http://test.com' -UseCommonAlertSchema -UseAadAuth -ObjectId 'someObjectId' -IdentifierUri 'someIdentifierUri' -TenantId 'someTenantId'
 		Assert-NotNull $webhook1
		Assert-AreEqual 'webhookreceiver' $webhook2.Name
		Assert-AreEqual 'http://test.com' $webhook2.ServiceUri
		Assert-AreEqual true $webhook2.UseCommonAlertSchema
		Assert-AreEqual true $webhook2.UseAadAuth
		Assert-AreEqual 'someObjectId' $webhook2.ObjectId
		Assert-AreEqual 'someIdentifierUri' $webhook2.IdentifierUri
		Assert-AreEqual 'someTenantId' $webhook2.TenantId

		Write-Verbose " ****** Creating a new itsm receiver "
		$itsm1 = New-AzActionGroupReceiver -ItsmReceiver -Name 'itsmReceiver' -WorkspaceId 'someworkspaceId' -ConnectionId 'connectionId'  -TicketConfiguration 'ticketConfiguration' -Region 'someRegion' 
 		Assert-NotNull $itsm1
		Assert-AreEqual 'itsmReceiver' $itsm1.Name
		Assert-AreEqual 'someworkspaceId' $itsm1.WorkspaceId
		Assert-AreEqual 'connectionId' $itsm1.ConnectionId
		Assert-AreEqual 'ticketConfiguration' $itsm1.TicketConfiguration
		Assert-AreEqual 'someRegion' $itsm1.Region

		Write-Verbose " ****** Creating a new voice receiver"
		$voice1 = New-AzActionGroupReceiver -VoiceReceiver -Name 'VoiceReceiver' -VoiceCountryCode '1' -VoicePhoneNumber '4254251234'
		Assert-NotNull $voice1
		Assert-AreEqual 'VoiceReceiver' $voice1.Name
		Assert-AreEqual '1' $voice1.CountryCode
		Assert-AreEqual '4254251234' $voice1.PhoneNumber

		Write-Verbose " ****** Creating a new armrole receiver with default use common alert schema"
		$armrole1 = New-AzActionGroupReceiver -ArmRoleReceiver -Name 'armroleReceiver' -RoleId 'someRoleId' 
		Assert-NotNull $armrole1
		Assert-AreEqual 'armroleReceiver' $armrole1.Name
		Assert-AreEqual 'someRoleId' $armrole1.RoleId
		Assert-AreEqual false $armrole1.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new armrole receiver with use common alert schema explicitly set"
		$armrole2 = New-AzActionGroupReceiver -ArmRoleReceiver -Name 'armroleReceiver' -RoleId 'someRoleId'  -UseCommonAlertSchema
		Assert-NotNull $armrole2
		Assert-AreEqual 'armroleReceiver' $armrole2.Name
		Assert-AreEqual 'someRoleId' $armrole2.RoleId
		Assert-AreEqual true $armrole2.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new azure function receiver with  default use common alert schema"
		$azureFunc1 = New-AzActionGroupReceiver -AzureFunctionReceiver -Name 'azfunreceiver' -FunctionAppResourceId 'somereosurceid'  -FunctionName 'somefunc' -HttpTriggerUrl 'someHttpTrigUrl'
		Assert-NotNull $azureFunc1
		Assert-AreEqual 'azfunreceiver' $azureFunc1.Name
		Assert-AreEqual 'somereosurceid' $azureFunc1.FunctionAppResourceId
		Assert-AreEqual 'somefunc' $azureFunc1.FunctionName
		Assert-AreEqual 'someHttpTrigUrl' $azureFunc1.HttpTriggerUrl
		Assert-AreEqual false $azureFunc1.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new azure function receiver with  use common alert schema explicitly set"
		$azureFunc2 = New-AzActionGroupReceiver -AzureFunctionReceiver -Name 'azfunreceiver' -FunctionAppResourceId 'somereosurceid' -UseCommonAlertSchema -FunctionName 'somefunc' -HttpTriggerUrl 'someHttpTrigUrl'
		Assert-NotNull $azureFunc2
		Assert-AreEqual 'azfunreceiver' $azureFunc2.Name
		Assert-AreEqual 'somereosurceid' $azureFunc2.FunctionAppResourceId
		Assert-AreEqual 'somefunc' $azureFunc2.FunctionName
		Assert-AreEqual 'someHttpTrigUrl' $azureFunc2.HttpTriggerUrl
		Assert-AreEqual true $azureFunc2.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new logic app  receiver with  default use common alert schema"
		$logicapp1 = New-AzActionGroupReceiver -LogicAppReceiver -Name 'logicapp' -ResourceId 'somereosurceid'  -CallbackUrl 'somecallback' 
		Assert-NotNull $logicapp1
		Assert-AreEqual 'logicapp' $logicapp1.Name
		Assert-AreEqual 'somereosurceid' $logicapp1.ResourceId
		Assert-AreEqual 'somecallback' $logicapp1.CallbackUrl
		Assert-AreEqual false $logicapp1.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new logic app  receiver with   use common alert schema explicitly set"
		$logicapp2 = New-AzActionGroupReceiver -LogicAppReceiver -Name 'logicapp' -ResourceId 'somereosurceid'  -CallbackUrl 'somecallback' -UseCommonAlertSchema
		Assert-NotNull $logicapp2
		Assert-AreEqual 'logicapp' $logicapp2.Name
		Assert-AreEqual 'somereosurceid' $logicapp2.ResourceId
		Assert-AreEqual 'somecallback' $logicapp2.CallbackUrl
		Assert-AreEqual true $logicapp2.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new automation run book receiver with  default use common alert schema"
		$runbook1 = New-AzActionGroupReceiver -AutomationRunbookReceiver -Name 'runbook' -AutomationAccountId 'accoutId'  -RunbookName 'runbook' -WebhookResourceId 'webhookresourceid' -IsGlobalRunbook  -AutomationRunbookServiceUri 'someserviceUrl'
		Assert-NotNull $runbook1
		Assert-AreEqual 'runbook' $runbook1.Name
		Assert-AreEqual 'accoutId' $runbook1.AutomationAccountId
		Assert-AreEqual 'runbook' $runbook1.RunbookName
		Assert-AreEqual 'webhookresourceid' $runbook1.WebhookResourceId
		Assert-AreEqual true $runbook1.IsGlobalRunbook
		Assert-AreEqual false $runbook1.UseCommonAlertSchema
		Assert-AreEqual 'someserviceUrl' $runbook1.ServiceUri

		Write-Verbose " ****** Creating a new automation run book receiver with  use common alert schema set explicitly"
		$runbook2 = New-AzActionGroupReceiver -AutomationRunbookReceiver -Name 'runbook' -AutomationAccountId 'accoutId'  -RunbookName 'runbook' -WebhookResourceId 'webhookresourceid' -IsGlobalRunbook -AutomationRunbookServiceUri 'someserviceUrl' -UseCommonAlertSchema
		Assert-NotNull $runbook2
		Assert-AreEqual 'runbook' $runbook2.Name
		Assert-AreEqual 'accoutId' $runbook2.AutomationAccountId
		Assert-AreEqual 'runbook' $runbook2.RunbookName
		Assert-AreEqual 'webhookresourceid' $runbook2.WebhookResourceId
		Assert-AreEqual true $runbook2.IsGlobalRunbook
		Assert-AreEqual true $runbook2.UseCommonAlertSchema
		Assert-AreEqual 'someserviceUrl' $runbook2.ServiceUri
		
		Write-Verbose " ****** Creating a new app push receiver"
		$apppush1 = New-AzActionGroupReceiver -AzureAppPushReceiver -Name 'apppsuh' -AzureAppPushEmailAddress 'someemaild'  
		Assert-NotNull $apppush1
		Assert-AreEqual 'apppsuh' $apppush1.Name
		Assert-AreEqual 'someemaild' $apppush1.EmailAddress
		
		Write-Verbose " ****** Creating a new action group"
		$actual =  Set-AzActionGroup -Name $actionGroupName -ResourceGroup $resourceGroupName -ShortName $shortName -Receiver $email1,$email2,$eventhub1, $eventhub2, $sms1,$webhook1,$webhook2,$itsm1,$voice1,$armrole1,$armrole2,$azureFunc1,$azureFunc2,$logicapp1,$logicapp2,$runbook1,$runbook2,$apppush1
		Assert-NotNull $actual
		Assert-AreEqual $actionGroupName $actual.Name
		
		$json = $actual | ConvertTo-Json

		Write-Verbose $json

		Write-Verbose " ****** Getting the action group by name"
		$retrieved = Get-AzActionGroup -ResourceGroup $resourceGroupName -Name $actionGroupName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Assert-AreEqual $actionGroupName $retrieved[0].Name

		Write-Verbose " ****** Getting the action group by subscriptionId"
		$retrieved = Get-AzActionGroup
		Assert-NotNull $retrieved
		Assert-AreEqual 2 $retrieved.Length
		Assert-AreEqual $actionGroupName $retrieved[0].Name
		
		Write-Verbose " ****** Getting the action group by resource group"
		$retrieved = Get-AzActionGroup -ResourceGroupName $resourceGroupName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Assert-AreEqual $actionGroupName $retrieved[0].Name

		Write-Verbose " ****** Removing the action group"
		Remove-AzActionGroup -ResourceGroup $resourceGroupName -Name $actionGroupName

    }
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}
