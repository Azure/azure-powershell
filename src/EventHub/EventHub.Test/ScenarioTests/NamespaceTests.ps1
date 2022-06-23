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
Tests EventHub Namespace AuthorizationRules Create List Remove operations.
#>

function NamespaceAuthTests
{
    # Setup    
    $location = Get-Location
	$locationKafka = "westus"
	$resourceGroupName = getAssetName "RGName"
	$namespaceName = getAssetName "Eventhub-Namespace-"
	$namespaceNameKafka = getAssetName "Eh-NamespaceKafka-"
	$authRuleName =  getAssetName "Eventhub-Namespace-AuthorizationRule"
	$authRuleName = getAssetName "authorule-"
	$authRuleNameListen = getAssetName "authorule-"
	$authRuleNameSend = getAssetName "authorule-"
	$authRuleNameAll = getAssetName "authorule-"
    
    Write-Debug " Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
    
	Write-Debug " Create new Eventhub Kafka namespace"
    Write-Debug "Kafka Namespace name : $namespaceNameKafka"	
    $resultkafka = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceNameKafka -Location $locationKafka -EnableKafka
	Assert-AreEqual $resultkafka.Name $namespaceNameKafka "Namespace created earlier is not found."
	Assert-True{$resultkafka.KafkaEnabled}

    Write-Debug " Create new Eventhub namespace"
    Write-Debug "Namespace name : $namespaceName"	
    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
    
	Write-Debug " Get the created namespace within the resource group"
    $createdNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	Assert-AreEqual $createdNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
	Assert-AreEqual $createdNamespace.ResourceGroupName $resourceGroupName "Namespace get : ResourceGroupName name matches"
    
	#Assert
    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."

    Write-Debug "Create a Namespace Authorization Rule"    
    Write-Debug "Auth Rule name : $authRuleName"
    $result = New-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen", "Send")																																	  

    Assert-AreEqual $authRuleName $result.Name
    Assert-AreEqual 2 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }

	$resultListen = New-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameListen -Rights @("Listen")
	Assert-AreEqual $authRuleNameListen $resultListen.Name
    Assert-AreEqual 1 $resultListen.Rights.Count
    Assert-True { $resultListen.Rights -Contains "Listen" }

	$resultSend = New-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameSend -Rights @("Send")
	Assert-AreEqual $authRuleNameSend $resultSend.Name
    Assert-AreEqual 1 $resultSend.Rights.Count
    Assert-True { $resultSend.Rights -Contains "Send" }

	$resultAll3 = New-AzEventHubAuthorizationRule -ResourceGroupName $resourceGroupName -Namespace $namespaceName -Name $authRuleNameAll -Rights @("Listen","Send","Manage")
	Assert-AreEqual $authRuleNameAll $resultAll3.Name
    Assert-AreEqual 3 $resultAll3.Rights.Count
    Assert-True { $resultAll3.Rights -Contains "Send" }
	Assert-True { $resultAll3.Rights -Contains "Listen" }
	Assert-True { $resultAll3.Rights -Contains "Manage" }

    Write-Debug "Get created authorizationRule"
    $createdAuthRule = Get-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-AreEqual $authRuleName $createdAuthRule.Name
    Assert-AreEqual 2 $createdAuthRule.Rights.Count
    Assert-True { $createdAuthRule.Rights -Contains "Listen" }
    Assert-True { $createdAuthRule.Rights -Contains "Send" }   

    Write-Debug "Get the default Namespace AuthorizationRule"
    $defaultNamespaceAuthRule = "RootManageSharedAccessKey"
    $result = Get-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $defaultNamespaceAuthRule

    Assert-AreEqual $defaultNamespaceAuthRule $result.Name
    Assert-AreEqual 3 $result.Rights.Count
    Assert-True { $result.Rights -Contains "Listen" }
    Assert-True { $result.Rights -Contains "Send" }
    Assert-True { $result.Rights -Contains "Manage" }  

    Write-Debug "Get All Namespace AuthorizationRule"
    $getallAuthrule = Get-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName 
    $count = $getallAuthrule.Count
    Write-Debug "Auth Rule Count : $count"

	Assert-True {$count -ge 1 } "List AuthorizationRule: Namespace AuthorizationRules created earlier is not found."

    for ($i = 0; $i -lt $getallAuthrule.Count; $i++)
    {
        if ($getallAuthrule[$i].Name -eq $authRuleName)
        {
            Assert-AreEqual 2 $getallAuthrule[$i].Rights.Count
            Assert-True { $getallAuthrule[$i].Rights -Contains "Listen" }
            Assert-True { $getallAuthrule[$i].Rights -Contains "Send" }                      
        }

        if ($getallAuthrule[$i].Name -eq $defaultNamespaceAuthRule)
        {            
            Assert-AreEqual 3 $getallAuthrule[$i].Rights.Count
            Assert-True { $getallAuthrule[$i].Rights -Contains "Listen" }
            Assert-True { $getallAuthrule[$i].Rights -Contains "Send" }
            Assert-True { $getallAuthrule[$i].Rights -Contains "Manage" }         
        }
    }
	
    Write-Debug "Update Namespace AuthorizationRules"   
    $createdAuthRule.Rights.Add("Manage")
    $updatedAuthRule = Set-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -InputObj $createdAuthRule
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 3 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
    Assert-True { $updatedAuthRule.Rights -Contains "Send" }
    Assert-True { $updatedAuthRule.Rights -Contains "Manage" }


	Write-Debug "Update Namespace AuthorizationRules"
    $updatedAuthRule = Set-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Rights @("Listen")
    
    Assert-AreEqual $authRuleName $updatedAuthRule.Name
    Assert-AreEqual 1 $updatedAuthRule.Rights.Count
    Assert-True { $updatedAuthRule.Rights -Contains "Listen" }
	
    Write-Debug "Get namespace authorizationRules connectionStrings"
    $namespaceListKeys = Get-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName

    Assert-True {$namespaceListKeys.PrimaryConnectionString -like "*$($updatedAuthRule.PrimaryKey)*"}
    Assert-True {$namespaceListKeys.SecondaryConnectionString -like "*$($updatedAuthRule.SecondaryKey)*"}

	Write-Debug "Regenrate Authorizationrules Keys"
	$policyKey = "PrimaryKey"

	$StartTime = Get-Date
	$EndTime = $StartTime.AddHours(2.0)
	$SasToken = New-AzEventHubAuthorizationRuleSASToken -ResourceId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime
	$SasToken = New-AzEventHubAuthorizationRuleSASToken -AuthorizationRuleId $updatedAuthRule.Id  -KeyType Primary -ExpiryTime $EndTime -StartTime $StartTime

	$namespaceRegenerateKeysDefault = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey
	Assert-True {$namespaceRegenerateKeysDefault.PrimaryKey -ne $namespaceListKeys.PrimaryKey}

	$namespaceRegenerateKeys = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey -KeyValue $namespaceListKeys.PrimaryKey
	Assert-True { $namespaceRegenerateKeys.PrimaryKey -eq $namespaceListKeys.PrimaryKey }

	$policyKey1 = "SecondaryKey"

	$namespaceRegenerateKeys1 = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey1
	Assert-True { $namespaceRegenerateKeys1.SecondaryKey -ne $namespaceListKeys.SecondaryKey }
	
	$namespaceRegenerateKeys1 = New-AzEventHubKey -ResourceGroup $resourceGroupName -Namespace $namespaceName  -Name $authRuleName -RegenerateKey $policyKey1
	Assert-AreEqual $namespaceRegenerateKeys1.PrimaryKey  $namespaceRegenerateKeys.PrimaryKey

	# Cleanup
    Write-Debug "Delete the created Namespace AuthorizationRule"
    $result = Remove-AzEventHubAuthorizationRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $authRuleName -Force
    
    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
    Remove-AzEventHubNamespace -ResourceId $resultkafka.Id

	Write-Debug " Delete resourcegroup"
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Tests New Parameter for EventHub Namespace Create List Remove operations.
#>

function NamespaceTests
{
    # Setup    
    $location = "eastus"	
	$locationKafka = "eastus"
	$namespaceName = getAssetName "Eventhub-Namespace1-"
	$namespaceName2 = getAssetName "Eventhub-Namespace2-"
    $namespaceName3 = getAssetName "Eventhub-Namespace3-"
    $namespace4 = getAssetName "Eventhub-Namespace4-"
    $resourceGroupName = getAssetName "RGName1-"
	$secondResourceGroup = getAssetName "RGName2-"
	$namespaceNameKafka = getAssetName "Eh-NamespaceKafka-"


    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
	New-AzResourceGroup -Name $resourceGroupName -Location $location -Force 

    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
	New-AzResourceGroup -Name $secondResourceGroup -Location $location -Force 

	# Check Namespace Name Availability

	$checkNameResult = Test-AzEventHubName -Namespace $namespaceName 
	Assert-True {$checkNameResult.NameAvailable}

    $result1 = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespace4 -Location northeurope -SkuName Standard
    Assert-AreEqual $result1.Name $namespace4
    Assert-AreEqual $result1.Location "North Europe"

    $result1 = Set-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespace4 -EnableAutoInflate -MaximumThroughputUnits 12
    Assert-AreEqual $result1.Name $namespace4
    Assert-AreEqual $result1.Location "North Europe"
    Assert-True {$result1.IsAutoInflateEnabled}
    Assert-True {$result1.KafkaEnabled}
    Assert-AreEqual $result1.MaximumThroughputUnits 12

    $result1 = Set-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespace4 -EnableKafka
    Assert-AreEqual $result1.Name $namespace4
    Assert-AreEqual $result1.Location "North Europe"
    Assert-True {$result1.IsAutoInflateEnabled}
    Assert-True {$result1.KafkaEnabled}
    Assert-AreEqual $result1.MaximumThroughputUnits 12


	Write-Debug " Create new Eventhub Kafka namespace"
    Write-Debug "Kafka Namespace name : $namespaceNameKafka"	
    $resultkafka = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceNameKafka -Location $locationKafka -EnableKafka -DisableLocalAuth
	Assert-AreEqual $resultkafka.Name $namespaceNameKafka "Namespace created earlier is not found."
	Assert-True {$resultkafka.KafkaEnabled}    
    Assert-True {$resultkafka.DisableLocalAuth}
    
    Write-Debug " Create new eventHub namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -SkuName "Standard" -SkuCapacity "1" -EnableAutoInflate -MaximumThroughputUnits 10
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"

    Write-Debug " Create new eventHub premium namespace"
    Write-Debug "NamespaceName : $namespaceName3" 
    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName3 -Location $location -SkuName "Premium" -DisableLocalAuth
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"    
    Assert-True { $result.DisableLocalAuth }
    Assert-AreEqual $result.Sku.Name "Premium" "Namespace Premium"


    $result = Set-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName3 -IdentityType "SystemAssigned" -Location $location
	Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
	Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"    
    Assert-True { $result.DisableLocalAuth }
    Assert-True { $result.Identity }
    Assert-AreEqual $result.Sku.Name "Premium" "Namespace Premium"
	
	# Assert 
	Assert-AreEqual $result.ProvisioningState "Succeeded"

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	Assert-AreEqual $createdNamespace.ResourceGroup $resourceGroupName "Namespace get : ResourceGroup name matches"
	Assert-AreEqual $createdNamespace.ResourceGroupName $resourceGroupName "Namespace get: ResourceGroupName name matches"

    Assert-AreEqual $createdNamespace.Name $namespaceName "Namespace created earlier is not found."	  
    
    Write-Debug "Namespace name : $namespaceName2"
    $result = New-AzEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2 -Location $location

    ### change the Namespace SKU to Basic
    Write-Debug "Namespace name : $namespaceName2"
    $result = Set-AzEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2 -Location $location -SkuName "Basic"
    Assert-AreEqual $result.Sku.Name "Basic" "Namespace SKU not changed."
       
    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzEventHubNamespace -ResourceGroup $secondResourceGroup
    
    #Assert
    Assert-True {$allCreatedNamespace.Count -ge 0 } "Namespace created earlier is not found. in list"
    
    #Write-Debug "Get all the namespaces created in the subscription"
    #$allCreatedNamespace = Get-AzEventHubNamespace
    
    #Assert-True {$allCreatedNamespace.Count -ge 0} "Namespaces created earlier is not found."

    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

    Write-Debug " Delete resourcegroup"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}



function SchemaRegistryTest {

    $location = "eastus"
    $resourceGroupName = getAssetName "PS-SDK-Testing-RG"
    $namespaceName = getAssetName "PS-SDK-Testing-Namespace"
    $schemaGroupName1 = getAssetName "SchemaGroup1"
    $schemaGroupName2 = getAssetName "SchemaGroup2"
    $schemaGroupName3 = getAssetName "SchemaGroup3"
    $schemaGroupName4 = getAssetName "SchemaGroup4"
    $schemaGroupName5 = getAssetName "SchemaGroup5"
    $schemaGroupName6 = getAssetName "SchemaGroup6"

    
    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force 

    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -SkuName "Premium"
    Assert-AreEqual $result.ResourceGroup $resourceGroupName "Namespace create : ResourceGroup name matches"
    Assert-AreEqual $result.ResourceGroupName $resourceGroupName "Namespace create : ResourceGroupName name matches"
    Assert-AreEqual $result.Sku.Name "Premium" "Namespace Premium"


    #Create Schema Group
    $resultSchemaGroup1 = New-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName1 -SchemaCompatibility Forward -SchemaType Avro -GroupProperty @{"name"="name"}
    
    Assert-AreEqual $schemaGroupName1 $resultSchemaGroup1.Name
    Assert-AreEqual "Forward" $resultSchemaGroup1.SchemaCompatibility
    Assert-AreEqual "Avro" $resultSchemaGroup1.SchemaType

    #Create Schema Group
    $resultSchemaGroup2 = New-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName2 -SchemaCompatibility Backward -SchemaType Avro -GroupProperty @{"name"="name";"key1"="value1"}
    
    Assert-AreEqual $schemaGroupName2 $resultSchemaGroup2.Name
    Assert-AreEqual "Backward" $resultSchemaGroup2.SchemaCompatibility
    Assert-AreEqual "Avro" $resultSchemaGroup2.SchemaType

    #Create Schema Group
    $resultSchemaGroup3 = New-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName3 -SchemaCompatibility None -SchemaType Avro
    
    Assert-AreEqual $schemaGroupName3 $resultSchemaGroup3.Name
    Assert-AreEqual "None" $resultSchemaGroup3.SchemaCompatibility
    Assert-AreEqual "Avro" $resultSchemaGroup3.SchemaType

    $getSchemaGroup1 = Get-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName1
    Assert-AreEqual $schemaGroupName1 $getSchemaGroup1.Name
    Assert-AreEqual "Forward" $getSchemaGroup1.SchemaCompatibility
    Assert-AreEqual "Avro" $getSchemaGroup1.SchemaType

    $getSchemaGroup2 = Get-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName2
    Assert-AreEqual $schemaGroupName2 $getSchemaGroup2.Name
    Assert-AreEqual "Backward" $getSchemaGroup2.SchemaCompatibility
    Assert-AreEqual "Avro" $getSchemaGroup2.SchemaType

    $getSchemaGroup3 = Get-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName3
    Assert-AreEqual $schemaGroupName3 $getSchemaGroup3.Name
    Assert-AreEqual "None" $getSchemaGroup3.SchemaCompatibility
    Assert-AreEqual "Avro" $getSchemaGroup3.SchemaType
    
    Assert-AreEqual $schemaGroupName3 $resultSchemaGroup3.Name
    Assert-AreEqual "None" $resultSchemaGroup3.SchemaCompatibility
    Assert-AreEqual "Avro" $resultSchemaGroup3.SchemaType

    $resultSchemaGroup4 = New-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName4 -SchemaCompatibility None -SchemaType Avro

    Assert-AreEqual $schemaGroupName4 $resultSchemaGroup4.Name
    Assert-AreEqual "None" $resultSchemaGroup4.SchemaCompatibility
    Assert-AreEqual "Avro" $resultSchemaGroup4.SchemaType

    $getSchemaGroup4 = Get-AzEventHubSchemaGroup -ResourceId $resultSchemaGroup4.Id

    Assert-AreEqual $resultSchemaGroup4.Name $getSchemaGroup4.Name
    Assert-AreEqual "None" $getSchemaGroup4.SchemaCompatibility
    Assert-AreEqual "Avro" $getSchemaGroup4.SchemaType

    $resultSchemaGroup5 = New-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName5 -SchemaCompatibility None -SchemaType Avro

    Assert-AreEqual $schemaGroupName5 $resultSchemaGroup5.Name
    Assert-AreEqual "None" $resultSchemaGroup5.SchemaCompatibility
    Assert-AreEqual "Avro" $resultSchemaGroup5.SchemaType

    $getAllSchemaGroups = Get-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName
    Assert-True {$getAllSchemaGroups.Count -ge 0} "All 3 schema groups are not there"

    $resultRemove = Remove-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName1
    $resultRemove = Remove-AzEventHubSchemaGroup -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $schemaGroupName2
    $resultRemove = Remove-AzEventHubSchemaGroup -ResourceId $getSchemaGroup4.Id
    $resultRemove = Remove-AzEventHubSchemaGroup -InputObject $getSchemaGroup3

    Write-Debug " Delete namespaces"
    Remove-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

    Write-Debug " Delete resourcegroup"
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}

function MSITest{
    $resourceGroupName = "PS-Testing"
    $msi1 = "PS-Testing-MSI1"
    $msi2 = "PS-Testing-MSI2"
    $msi3 = "PS-Testing-MSI3"
    $namespace1 = getAssetName "Namespace1-"
    $namespace2 = getAssetName "Namespace2-"
    try{

        $uad1 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI1"
        $uad2 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI2"
        $uad3 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI3"

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -SkuName Standard -Location eastus
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "SystemAssigned"
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "UserAssigned" -IdentityId $uad1,$uad2
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "SystemAssigned, UserAssigned"
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-AreEqual $namespace.IdentityType "SystemAssignedUserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -IdentityType "None" -IdentityId @()
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Standard"
        Assert-Null $namespace.Identity
    }
    finally{
        Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
    }
}

function EncryptionTest{
    try{
        $resourceGroupName = "PS-Testing"
        $msi1 = "PS-Testing-MSI1"
        $msi2 = "PS-Testing-MSI2"
        $msi3 = "PS-Testing-MSI3"
        $kv1 = "PS-Test-kv1"
        $kv2 = "PS-Test-kv2"
        $kv1uri = "https://ps-test-kv1.vault.azure.net/"
        $kv2uri = "https://ps-test-kv2.vault.azure.net"
        $namespace1 = getAssetName "Namespace1-"
        $namespace2 = getAssetName "Namespace2-"

        $uad1 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI1"
        $uad2 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI2"
        $uad3 = "/subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/PS-Testing/providers/Microsoft.ManagedIdentity/userAssignedIdentities/PS-Testing-MSI3"

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace2 -SkuName Premium -Location eastus -IdentityType SystemAssigned
        Assert-AreEqual $namespace.Name $namespace2
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"

        Set-AzKeyVaultAccessPolicy -VaultName $kv1 -ObjectId $namespace.Identity.PrincipalId -PermissionsToKeys wrapkey,unwrapkey,get -BypassObjectIdValidation

        $ec1 = New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri $kv1uri
        $ec2 = New-AzEventHubEncryptionConfig -KeyName key2 -KeyVaultUri $kv1uri

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace2 -EncryptionConfig $ec1,$ec2
        Assert-AreEqual $namespace.Name $namespace2
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "SystemAssigned"
        Assert-True { $namespace.EncryptionConfig.Count -eq 2 }

        $ec1 = New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri $kv1uri -UserAssignedIdentity $uad1
        $ec2 = New-AzEventHubEncryptionConfig -KeyName key2 -KeyVaultUri $kv1uri -UserAssignedIdentity $uad1

        $namespace = New-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -SkuName Premium -Location northeurope -IdentityType UserAssigned -IdentityId $uad1,$uad2 -EncryptionConfig $ec1,$ec2
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 2 }

        $ec3 = New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri $kv2uri -UserAssignedIdentity $uad1
        $namespace.EncryptionConfig += $ec3

        $namespace = Set-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1 -EncryptionConfig $namespace.EncryptionConfig -Location northeurope
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 3 }


        $namespace = Get-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
        Assert-AreEqual $namespace.Name $namespace1
        Assert-AreEqual $namespace.Sku.Name "Premium"
        Assert-AreEqual $namespace.IdentityType "UserAssigned"
        Assert-True { $namespace.IdentityId.Count -eq 2 }
        Assert-True { $namespace.EncryptionConfig.Count -eq 3 }

    }
     
    finally{
        Remove-AzEventHubNamespace -ResourceGroupName $resourceGroupName -Name $namespace1
    }
}


function ApplicationGroupTest{
    $location = "eastus"
    $resourceGroupName =  getAssetName "PSSDKTesting-RG"
    $namespaceName = getAssetName "PSSDKTesting-NS"
    $appGroupName = getAssetName "appGroupName"
    $appGroupName2 = getAssetName "appGroupName2"
    $appGroupName3 = getAssetName "appGroupName3"
    $appGroupName4 = getAssetName "appGroupName3"
    $throttlingPolicy1 = "ThrottlingPolicy1"
    $throttlingPolicy2 = "ThrottlingPolicy2"
    $throttlingPolicy3 = "ThrottlingPolicy3"
    $throttlingPolicy4 = "ThrottlingPolicy4"
    $clientGroupId = getAssetName "SASKeyName=authkey"
    $clientGroupId2 = getAssetName "SASKeyName=authkey"
    $clientGroupId3 = getAssetName "SASKeyName=authkey"
    $clientGroupId4 = getAssetName "SASKeyName=authkey"

    try{
        # Create Resource Group
	    Write-Debug "Create resource group"    
	    Write-Debug " Resource Group Name : $resourceGroupName"
	    New-AzResourceGroup -Name $resourceGroupName -Location $location -Force
	
		
	    # Create EventHub Namespace
	    Write-Debug "  Create new eventhub namespace"
	    Write-Debug " Namespace name : $namespaceName"
	    $result = New-AzEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location -SkuName Premium

        $t1 = New-AzEventHubThrottlingPolicyConfig -Name $throttlingPolicy1 -MetricId IncomingMessages -RateLimitThreshold 1032
        $t2 = New-AzEventHubThrottlingPolicyConfig -Name $throttlingPolicy2 -MetricId OutgoingBytes -RateLimitThreshold 10567
        $t3 = New-AzEventHubThrottlingPolicyConfig -Name $throttlingPolicy3 -MetricId OutgoingMessages -RateLimitThreshold 9058
        $t4 = New-AzEventHubThrottlingPolicyConfig -Name $throttlingPolicy4 -MetricId IncomingBytes -RateLimitThreshold 1896

        $appGroup1 = New-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName -IsEnabled -ThrottlingPolicyConfig $t1, $t2 -ClientAppGroupIdentifier $clientGroupId

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-True { $appGroup1.IsEnabled }

        $appGroup1 = Get-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-True { $appGroup1.IsEnabled }

        $appGroup1 = Set-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName -IsEnabled:$false

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-False { $appGroup1.IsEnabled }

        $appGroup1 = Set-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName -IsEnabled

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-True { $appGroup1.IsEnabled }


        #Testing INPUT OBJECT parameter set
        
        $appGroup1.ThrottlingPolicyConfig += $t3

        $appGroup1 = Set-AzEventHubApplicationGroup -InputObject $appGroup1

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 3
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].Name $throttlingPolicy3
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].MetricId "OutgoingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].RateLimitThreshold 9058
        Assert-True { $appGroup1.IsEnabled }

        $appGroup1.IsEnabled = $false

        $appGroup1 = Set-AzEventHubApplicationGroup -InputObject $appGroup1

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 3
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].Name $throttlingPolicy3
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].MetricId "OutgoingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].RateLimitThreshold 9058
        Assert-False { $appGroup1.IsEnabled }

        #Testing RESOURCE ID

        $appGroup1 = Set-AzEventHubApplicationGroup -ResourceId $appGroup1.Id -IsEnabled

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 3
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].Name $throttlingPolicy3
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].MetricId "OutgoingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].RateLimitThreshold 9058
        Assert-True { $appGroup1.IsEnabled }

        $appGroup1.ThrottlingPolicyConfig += $t4

        $appGroup1 = Set-AzEventHubApplicationGroup -ResourceId $appGroup1.Id -ThrottlingPolicyConfig $appGroup1.ThrottlingPolicyConfig

        Assert-AreEqual $appGroup1.ClientAppGroupIdentifier $clientGroupId
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig.Count 4
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].Name $throttlingPolicy1
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].MetricId "IncomingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[0].RateLimitThreshold 1032
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].Name $throttlingPolicy2
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].MetricId "OutgoingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[1].RateLimitThreshold 10567
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].Name $throttlingPolicy3
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].MetricId "OutgoingMessages"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[2].RateLimitThreshold 9058
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[3].Name $throttlingPolicy4
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[3].MetricId "IncomingBytes"
        Assert-AreEqual $appGroup1.ThrottlingPolicyConfig[3].RateLimitThreshold 1896
        Assert-True { $appGroup1.IsEnabled }

        $appGroup2 = New-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName2 -ClientAppGroupIdentifier $clientGroupId2 -ThrottlingPolicyConfig $t3
        $appGroup3 = New-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName3 -ClientAppGroupIdentifier $clientGroupId3 -ThrottlingPolicyConfig $t1
        $appGroup4 = New-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName4 -ClientAppGroupIdentifier $clientGroupId4 -ThrottlingPolicyConfig $t2

        $listOfAppGroups = Get-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
        Assert-AreEqual $listOfAppGroups.Count 4

        Remove-AzEventHubApplicationGroup -ResourceGroup $resourceGroupName -NamespaceName $namespaceName -Name $appGroupName
        
        $listOfAppGroups = Get-AzEventHubApplicationGroup -ResourceId $result.Id
        Assert-AreEqual $listOfAppGroups.Count 3

        Remove-AzEventHubApplicationGroup -ResourceId $appGroup2.Id
        Get-AzEventHubApplicationGroup -ResourceId $appGroup3.Id | Remove-AzEventHubApplicationGroup
        Remove-AzEventHubApplicationGroup -InputObject $appGroup4

        Start-Sleep -Seconds 10

        $listOfAppGroups = Get-AzEventHubApplicationGroup -ResourceGroupName $resourceGroupName -NamespaceName $namespaceName
        Assert-AreEqual $listOfAppGroups.Count 0
    }

    finally{
        Write-Debug " Delete resourcegroup"
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}
