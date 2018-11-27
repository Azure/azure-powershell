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
function Test-E2EConnections
{
    $resourceGroupName = "to-delete-01"
    $automationAccountName = "fbs-aa-01"
    $output = Get-AzureRmAutomationAccount -ResourceGroupName $resourceGroupName -AutomationAccountName $automationAccountName -ErrorAction SilentlyContinue
    $connectionAssetName = "CreateNewAzureServicePrincipalConnection"
    $connectionTypeName = "AzureServicePrincipal"
    $applicationId = "applicationIdString"
    $tenantId = "tenantIdString"
    $tenantIdChanged = "ContosoCertificate2"
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

    Remove-AzureRmAutomationConnection -Name $connectionAssetName `
                                       -ResourceGroupName $resourceGroupName `
                                       -AutomationAccountName $automationAccountName `
                                       -Force

    $output = Get-AzureRmAutomationConnection -ResourceGroupName $resourceGroupName `
                                              -AutomationAccountName $automationAccountName `
                                              -Name $connectionAssetName -ErrorAction SilentlyContinue

    Assert-True {$output -eq $null}
}