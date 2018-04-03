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
Tests create new automation AzureServicePrincipal connection.
#>
function Test-CreateNewAzureServicePrincipalConnection
{
	$automationAccount = CreateAutomationAccount
	$resourceGroupName = $automationAccount.ResourceGroupName
	$automationAccountName = $automationAccount.AutomationAccountName
    
	$connectionAssetName = "CreateNewAzureServicePrincipalConnection"
	$connectionTypeName = "AzureServicePrincipal"
	$applicationId = "applicationIdString"
	$tenantId = "tenantIdString"
	$thumbprint  = "thumbprintIdString"
	$subscriptionId  = "subscriptionIdString"
	$connectionFieldValues = @{"ApplicationId" = $applicationId; `
	                           "TenantId" = $tenantId; `
							   "CertificateThumbprint" = $thumbprint; `
							   "SubscriptionId" = $subscriptionId}

	$connectionAssetCreated = New-AzureRmAutomationConnection -ResourceGroupName $resourceGroupName `
	                                                          -AutomationAccountName $automationAccountName `
															  -Name $connectionAssetName `
															  -ConnectionTypeName $connectionTypeName `
															  -ConnectionFieldValues $connectionFieldValues
	$getConnectionAssetCreated = Get-AzureRmAutomationConnection -ResourceGroupName $resourceGroupName `
	                                                             -AutomationAccountName $automationAccountName `
																 -Name $connectionAssetName 

	Assert-AreEqual $connectionAssetName  $getConnectionAssetCreated.Name
	Assert-NotNull $getConnectionAssetCreated.FieldDefinitionValues
	Assert-AreEqual $applicationId.ToString() $getConnectionAssetCreated.FieldDefinitionValues.Item("ApplicationId")
	Assert-AreEqual $tenantId.ToString() $getConnectionAssetCreated.FieldDefinitionValues.Item("TenantId")
	Assert-AreEqual $thumbprint.ToString() $getConnectionAssetCreated.FieldDefinitionValues.Item("CertificateThumbprint")
	Assert-AreEqual $subscriptionId.ToString() $getConnectionAssetCreated.FieldDefinitionValues.Item("SubscriptionId")
 }

<#
.SYNOPSIS
Tests create new automation AzureServicePrincipal connection  and 
call Set-AzureRmAutomationConnectionFieldValue to update value for applicationId WithGetContent.
Test case for issue https://github.com/Azure/azure-powershell/issues/5607
#>
function Test-SetConnectionWithGetContent
{
	$connectionAssetCreated = CreateAutomationAccountAndConnectionAsset "SetConnectionWithGetContent"
    $resourceGroupName = $connectionAssetCreated.ResourceGroupName
	$automationAccountName = $connectionAssetCreated.AutomationAccountName
	$connectionAssetName = $connectionAssetCreated.Name

	$fileName = "$env:temp\SetConnectionWithGetContent.txt"	
	echo "testline1" > $fileName
    echo "testline2" >> $fileName
	$applicationId = Get-Content $fileName

	$connectionAssetUpdated=Set-AzureRmAutomationConnectionFieldValue -ResourceGroupName $resourceGroupName `
	                                                                  -AutomationAccountName $automationAccountName `
																	  -Name $connectionAssetName `
	                                                                  -ConnectionFieldName "ApplicationId" `
																	  -Value $applicationId															  																	  

    Assert-AreEqual $connectionAssetName  $connectionAssetUpdated.Name
	# ApplicationId was not validated as it is complesx object. 
	# All other FieldDefinitionValues should remain the same and added the validation for the same.
	Assert-AreEqual $connectionAssetCreated.FieldDefinitionValues.Item("TenantId") `
	                $connectionAssetUpdated.FieldDefinitionValues.Item("TenantId")
	Assert-AreEqual $connectionAssetCreated.FieldDefinitionValues.Item("CertificateThumbprint") `
	                $connectionAssetUpdated.FieldDefinitionValues.Item("CertificateThumbprint")
	Assert-AreEqual $connectionAssetCreated.FieldDefinitionValues.Item("SubscriptionId") `
	                $connectionAssetUpdated.FieldDefinitionValues.Item("SubscriptionId")

    Remove-Item $fileName
 }


 <#
.SYNOPSIS
Tests create new automation AzureServicePrincipal connection  and 
call Set-AzureRmAutomationConnectionFieldValue to update value with lage value throws time out.
Test case for issue https://github.com/Azure/azure-powershell/issues/5607
#>
function Test-SetConnectionWithLargeValueThrowsTimeOut
{
	$connectionAssetCreated = CreateAutomationAccountAndConnectionAsset "SetConnectionWithLargeValueThrowsTimeOut"
    $resourceGroupName = $connectionAssetCreated.ResourceGroupName
	$automationAccountName = $connectionAssetCreated.AutomationAccountName
	$connectionAssetName = $connectionAssetCreated.Name

	$fileName = "$env:temp\SetConnectionWithLargeDataThrowsTimeOut.txt"
	
	echo "testlines" > $fileName
    for($i = 0; $i -lt 1000; $i++)
    {
      echo "testline$i" >> $fileName
    }
	
	$applicationId = Get-Content $fileName

	Set-AzureRmAutomationConnectionFieldValue -ResourceGroupName $resourceGroupName `
	                                          -AutomationAccountName $automationAccountName `
											  -Name $connectionAssetName `
	                                          -ConnectionFieldName "ApplicationId" `
											  -Value $applicationId `
											  -ErrorAction SilentlyContinue	

	Assert-True { $Error[0] -like "Input value could not be serialized to json. Operation had timed out in*" }
	$Error.Clear()
	
	Remove-Item $fileName
 }
