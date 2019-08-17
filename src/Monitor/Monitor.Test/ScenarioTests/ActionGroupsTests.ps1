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
		$email2 = New-AzActionGroupReceiver -EmailReceiver -Name 'emailreceiver1' -EmailAddress 'some email' -UseCommonAlertSchema $t
		Assert-NotNull $email2
		Assert-AreEqual 'emailreceiver1' $email2.Name
		Assert-AreEqual 'some email' $email2.EmailAddress
		Assert-AreEqual true $email2.UseCommonAlertSchema
		
		Write-Verbose " ****** Creating a new sms receiver"
		$sms1 = New-AzActionGroupReceiver -SmsReceiver -Name 'smsreceiver' -SmsCountryCode '1' -SmsPhoneNumber '4254251234'
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
		$webhook1 = New-AzActionGroupReceiver -WebhookReceiver -Name 'webhookreceiver' -ServiceUri 'http://test.com' -UseCommonAlertSchema $t -UseAadAuth $t -ObjectId 'someObjectId' -IdentifierUri 'someIdentifierUri' -TenantId 'someTenantId'
 		Assert-NotNull $webhook1
		Assert-AreEqual 'webhookreceiver' $webhook1.Name
		Assert-AreEqual 'http://test.com' $webhook1.ServiceUri
		Assert-AreEqual true $webhook1.UseCommonAlertSchema
		Assert-AreEqual true $webhook1.UseAadAuth
		Assert-AreEqual 'someObjectId' $webhook1.ObjectId
		Assert-AreEqual 'someIdentifierUri' $webhook1.IdentifierUri
		Assert-AreEqual 'someTenantId' $webhook1.TenantId

		Write-Verbose " ****** Creating a new itsm receiver "
		$itsm = New-AzActionGroupReceiver -ItsmReceiver -Name 'itsmReceiver' -WorkspaceId 'someworkspaceId' -ConnectionId 'connectionId'  -TicketConfiguration 'ticketConfiguration' -Region 'someRegion' 
 		Assert-NotNull $itsm
		Assert-AreEqual 'itsmReceiver' $itsm.Name
		Assert-AreEqual 'someworkspaceId' $itsm.WorkspaceId
		Assert-AreEqual 'connectionId' $itsm.ConnectionId
		Assert-AreEqual 'ticketConfiguration' $itsm.TicketConfiguration
		Assert-AreEqual 'someRegion' $itsm.Region

		Write-Verbose " ****** Creating a new voice receiver"
		$voice = New-AzActionGroupReceiver -VoiceReceiver -Name 'VoiceReceiver' -VoiceCountryCode '1' -VoicePhoneNumber '4254251234'
		Assert-NotNull $voice
		Assert-AreEqual 'VoiceReceiver' $voice.Name
		Assert-AreEqual '1' $voice.CountryCode
		Assert-AreEqual '4254251234' $voice.PhoneNumber

		Write-Verbose " ****** Creating a new armrole receiver with default use common alert schema"
		$armrole = New-AzActionGroupReceiver -ArmRoleReceiver -Name 'armroleReceiver' -RoleId 'someRoleId' 
		Assert-NotNull $armrole
		Assert-AreEqual 'armroleReceiver' $armrole.Name
		Assert-AreEqual 'someRoleId' $armrole.RoleId
		Assert-AreEqual false $armrole.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new armrole receiver with use common alert schema explicitly se"
		$armrole = New-AzActionGroupReceiver -ArmRoleReceiver -Name 'armroleReceiver' -RoleId 'someRoleId'  -UseCommonAlertSchema $t
		Assert-NotNull $armrole
		Assert-AreEqual 'armroleReceiver' $armrole.Name
		Assert-AreEqual 'someRoleId' $armrole.RoleId
		Assert-AreEqual true $armrole.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new azure function receiver with  default use common alert schema"
		$azureFunc = New-AzActionGroupReceiver -AzureFunctionReceiver -Name 'azfunreceiver' -FunctionAppResourceId 'somereosurceid'  -FunctionName 'somefunc' -HttpTriggerUrl 'someHttpTrigUrl'
		Assert-NotNull $azureFunc
		Assert-AreEqual 'azfunreceiver' $azureFunc.Name
		Assert-AreEqual 'somereosurceid' $azureFunc.FunctionAppResourceId
		Assert-AreEqual 'somefunc' $azureFunc.FunctionName
		Assert-AreEqual 'someHttpTrigUrl' $azureFunc.HttpTriggerUrl
		Assert-AreEqual false $azureFunc.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new azure function receiver with  use common alert schema explicitly set"
		$azureFunc = New-AzActionGroupReceiver -AzureFunctionReceiver -Name 'azfunreceiver' -FunctionAppResourceId 'somereosurceid' -UseCommonAlertSchema $t -FunctionName 'somefunc' -HttpTriggerUrl 'someHttpTrigUrl'
		Assert-NotNull $azureFunc
		Assert-AreEqual 'azfunreceiver' $azureFunc.Name
		Assert-AreEqual 'somereosurceid' $azureFunc.FunctionAppResourceId
		Assert-AreEqual 'somefunc' $azureFunc.FunctionName
		Assert-AreEqual 'someHttpTrigUrl' $azureFunc.HttpTriggerUrl
		Assert-AreEqual true $azureFunc.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new logic app  receiver with  default use common alert schema"
		$logicapp = New-AzActionGroupReceiver -LogicAppReceiver -Name 'logicapp' -ResourceId 'somereosurceid'  -CallbackUrl 'somecallback' 
		Assert-NotNull $logicapp
		Assert-AreEqual 'logicapp' $logicapp.Name
		Assert-AreEqual 'somereosurceid' $logicapp.ResourceId
		Assert-AreEqual 'somecallback' $logicapp.CallbackUrl
		Assert-AreEqual false $logicapp.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new logic app  receiver with   use common alert schema explicitly set"
		$logicapp = New-AzActionGroupReceiver -LogicAppReceiver -Name 'logicapp' -ResourceId 'somereosurceid'  -CallbackUrl 'somecallback' -UseCommonAlertSchema $t
		Assert-NotNull $logicapp
		Assert-AreEqual 'logicapp' $logicapp.Name
		Assert-AreEqual 'somereosurceid' $logicapp.ResourceId
		Assert-AreEqual 'somecallback' $logicapp.CallbackUrl
		Assert-AreEqual true $logicapp.UseCommonAlertSchema

		Write-Verbose " ****** Creating a new automation run book receiver with  default use common alert schema"
		$runbook = New-AzActionGroupReceiver -AutomationRunbookReceiver -Name 'runbook' -AutomationAccountId 'accoutId'  -RunbookName 'runbook' -WebhookResourceId 'webhookresourceid' -IsGlobalRunbook  $t -AutomationRunbookServiceUri 'someserviceUrl'
		Assert-NotNull $runbook
		Assert-AreEqual 'runbook' $runbook.Name
		Assert-AreEqual 'accoutId' $runbook.AutomationAccountId
		Assert-AreEqual 'runbook' $runbook.RunbookName
		Assert-AreEqual 'webhookresourceid' $runbook.WebhookResourceId
		Assert-AreEqual true $runbook.IsGlobalRunbook
		Assert-AreEqual false $runbook.UseCommonAlertSchema
		Assert-AreEqual 'someserviceUrl' $runbook.ServiceUri

		Write-Verbose " ****** Creating a new automation run book receiver with  use common alert schema set explicitly"
		$runbook = New-AzActionGroupReceiver -AutomationRunbookReceiver -Name 'runbook' -AutomationAccountId 'accoutId'  -RunbookName 'runbook' -WebhookResourceId 'webhookresourceid' -IsGlobalRunbook $t -AutomationRunbookServiceUri 'someserviceUrl' -UseCommonAlertSchema $t
		Assert-NotNull $runbook
		Assert-AreEqual 'runbook' $runbook.Name
		Assert-AreEqual 'accoutId' $runbook.AutomationAccountId
		Assert-AreEqual 'runbook' $runbook.RunbookName
		Assert-AreEqual 'webhookresourceid' $runbook.WebhookResourceId
		Assert-AreEqual true $runbook.IsGlobalRunbook
		Assert-AreEqual true $runbook.UseCommonAlertSchema
		Assert-AreEqual 'someserviceUrl' $runbook.ServiceUri
		
		Write-Verbose " ****** Creating a new app push receiver"
		$apppush = New-AzActionGroupReceiver -AzureAppPushReceiver -Name 'apppsuh' -AzureAppPushEmailAddress 'someemaild'  
		Assert-NotNull $apppush
		Assert-AreEqual 'apppsuh' $apppush.Name
		Assert-AreEqual 'someemaild' $apppush.EmailAddress
		
		Write-Verbose " ****** Creating a new action group"
		$actual =  Set-AzActionGroup -Name $actionGroupName -ResourceGroup $resourceGroupName -ShortName $shortName -Receiver $email1,$email2,$sms1,$webhook1
		Assert-NotNull $actual
		Assert-AreEqual $actionGroupName $actual.Name

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
