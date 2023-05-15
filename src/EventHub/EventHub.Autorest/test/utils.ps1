function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    $resourceGroup = "resourceGroupAutorest" + (RandomString -allChars $false -len 6)
    $namespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $systemAssignedNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $keyVaultName = "keyVaultName" + (RandomString -allChars $false -len 6)
    $keyVaultUri = "https://" + $keyVaultName + ".vault.azure.net/"
    $namespaceV1 = "namespaceV1" + (RandomString -allChars $false -len 6)
    $namespaceV2 = "namespaceV2" + (RandomString -allChars $false -len 6)
    $namespaceV3 = "namespaceV3" + (RandomString -allChars $false -len 6)
    $namespaceV4 = "namespaceV4" + (RandomString -allChars $false -len 6)
    $namespaceV5 = "namespaceV5" + (RandomString -allChars $false -len 6)
    $namespaceV6 = "namespaceV6" + (RandomString -allChars $false -len 6)
    $namespaceV7 = "namespaceV7" + (RandomString -allChars $false -len 6)
    $namespaceV8 = "namespaceV8" + (RandomString -allChars $false -len 6)
    $namespaceV9 = "namespaceV9" + (RandomString -allChars $false -len 6)
    $namespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.EventHub/namespaces/" + $namespaceName
    $primaryNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $primaryNamespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.EventHub/namespaces/" + $primaryNamespaceName
    $secondaryNamespace = "namespaceName" + (RandomString -allChars $false -len 6)
    $secondaryNamespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.EventHub/namespaces/" + $secondaryNamespace
    $authRule = "auth-rule" + (RandomString -allChars $false -len 6)
    $authRule2 = "auth-rule" + (RandomString -allChars $false -len 6)
    $authRule3 = "auth-rule" + (RandomString -allChars $false -len 6)
    $eventHubAuthRule = "auth-rule" + (RandomString -allChars $false -len 6)
    $eventHubAuthRule2 = "auth-rule" + (RandomString -allChars $false -len 6)
    $eventHubAuthRule3 = "auth-rule" + (RandomString -allChars $false -len 6)
    $appGroup = "appGroup" + (RandomString -allChars $false -len 6)
    $appGroup2 = "appGroup" + (RandomString -allChars $false -len 6)
    $appGroup3 = "appGroup" + (RandomString -allChars $false -len 6)
    $schemaGroup = "schemaGroup" + (RandomString -allChars $false -len 6)
    $schemaGroup2 = "schemaGroup" + (RandomString -allChars $false -len 6)
    $schemaGroup3 = "schemaGroup" + (RandomString -allChars $false -len 6)
    $consumerGroup2 = "consumerGroup" + (RandomString -allChars $false -len 6)
    $consumerGroup3 = "consumerGroup" + (RandomString -allChars $false -len 6)
    $eventHub = "eventHub" + (RandomString -allChars $false -len 6)
    $eventHub2 = "eventHub" + (RandomString -allChars $false -len 6)
    $eventHub3 = "eventHub" + (RandomString -allChars $false -len 6)
    $eventHub9 = "eventHub9" + (RandomString -allChars $false -len 6)
    $cluster = "cluster" + (RandomString -allChars $false -len 6)
    $cluster2 = "cluster" + (RandomString -allChars $false -len 6)
    $alias = "alias" + (RandomString -allChars $false -len 6)
    $pe1 = "privateEndpoint-" + (RandomString -allChars $false -len 6)
    $pe2 = "privateEndpoint-" + (RandomString -allChars $false -len 6)

    $namespacePrimaryKey = GenerateSASKey
    $namespaceSecondaryKey = GenerateSASKey
    $eventHubPrimaryKey = GenerateSASKey
    $eventHubSecondaryKey = GenerateSASKey

    New-AzResourceGroup -Name $resourceGroup -Location eastus

    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("systemAssignedNamespaceName", $systemAssignedNamespaceName)
    $env.Add("keyVaultUri", $keyVaultUri)
    $env.Add("namespace", $namespaceName)
    $env.Add("namespaceV1", $namespaceV1)
    $env.Add("namespaceV2", $namespaceV2)
    $env.Add("namespaceV3", $namespaceV3)
    $env.Add("namespaceV4", $namespaceV4)
    $env.Add("namespaceV5", $namespaceV5)
    $env.Add("namespaceV6", $namespaceV6)
    $env.Add("namespaceV7", $namespaceV7)
    $env.Add("namespaceV8", $namespaceV8)
    $env.Add("namespaceV9", $namespaceV9)
    $env.Add("primaryNamespace", $primaryNamespaceName)
    $env.Add("secondaryNamespace", $secondaryNamespace)
    $env.Add("primaryNamespaceResourceId", $primaryNamespaceResourceId)
    $env.Add("secondaryNamespaceResourceId", $secondaryNamespaceResourceId)
    $env.Add("authRule", $authRule)
    $env.Add("authRule2", $authRule2)
    $env.Add("authRule3", $authRule3)
    $env.Add("eventHubAuthRule", $eventHubAuthRule)
    $env.Add("eventHubAuthRule2", $eventHubAuthRule2)
    $env.Add("eventHubAuthRule3", $eventHubAuthRule3)
    $env.Add("appGroup", $appGroup)
    $env.Add("appGroup2", $appGroup2)
    $env.Add("appGroup3", $appGroup3)
    $env.Add("schemaGroup", $schemaGroup)
    $env.Add("schemaGroup2", $schemaGroup2)
    $env.Add("schemaGroup3", $schemaGroup3)
    $env.Add("eventHub", $eventHub)
    $env.Add("eventHub2", $eventHub2)
    $env.Add("eventHub3", $eventHub3)
    $env.Add("eventHub9", $eventHub9)
    $env.Add("createdCluster", "TestClusterAutomatic")
    $env.Add("cluster", $cluster)
    $env.Add("cluster2", $cluster2)
    $env.Add("clusterResourceGroup", "AutomatedPowershellTesting")
    $env.Add("consumerGroup", '$Default')
    $env.Add("consumerGroup2", $consumerGroup2)
    $env.Add("consumerGroup3", $consumerGroup3)
    $env.Add("alias", $alias)
    $env.Add("namespacePrimaryKey", $namespacePrimaryKey)
    $env.Add("namespaceSecondaryKey", $namespaceSecondaryKey)
    $env.Add("eventHubPrimaryKey", $eventHubPrimaryKey)
    $env.Add("eventHubSecondaryKey", $eventHubSecondaryKey)

    $eventHubTemplate = Get-Content .\test\deployment-template\parameter.json | ConvertFrom-Json
    $eventHubTemplate.parameters.namespace_name.value = $namespaceName
    $eventHubTemplate.parameters.system_assigned_namespace_name.value = $systemAssignedNamespaceName
    $eventHubTemplate.parameters.namespace_auth_rule_name.value = $authRule
    $eventHubTemplate.parameters.eventhub_auth_rule_name.value = $eventHubAuthRule
    $eventHubTemplate.parameters.eventhub_name.value = $eventHub
    $eventHubTemplate.parameters.schema_group_name.value = $schemaGroup
    $eventHubTemplate.parameters.appgroup_name.value = $appGroup
    $eventHubTemplate.parameters.namespaceResourceId.value = $namespaceResourceId
    $eventHubTemplate.parameters.peName1.value = $pe1
    $eventHubTemplate.parameters.peName2.value = $pe2
    Set-Content -Path .\test\deployment-template\parameter.json -Value (ConvertTo-Json $eventHubTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\template.json -TemplateParameterFile .\test\deployment-template\parameter.json -Name eventHubTemplate -ResourceGroupName $resourceGroup

    Write-Host -ForegroundColor Magenta "Deployed EventHubs namespace template"

    $eventHubTemplate = Get-Content .\test\deployment-template\disasterRecoveryParameter.json | ConvertFrom-Json
    $eventHubTemplate.parameters.secondarynamespace_name.value = $secondaryNamespace
    $eventHubTemplate.parameters.namespace_name.value = $primaryNamespaceName
    Set-Content -Path .\test\deployment-template\disasterRecoveryParameter.json -Value (ConvertTo-Json $eventHubTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\disasterRecoveryTemplate.json -TemplateParameterFile .\test\deployment-template\disasterRecoveryParameter.json -Name DRConfigTemplate -ResourceGroupName $resourceGroup

    Write-Host -ForegroundColor Magenta "Deploying KeyVault ARM template"

    $namespace = Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -NamespaceName $env.systemAssignedNamespaceName
    $keyVaultTemplate = Get-Content .\test\deployment-template\keyVaultParameter.json | ConvertFrom-Json
    $keyVaultTemplate.parameters.key_Vault_Name.value = $keyVaultName
    $keyVaultTemplate.parameters.tenant_id.value = $env.Tenant
    $keyVaultTemplate.parameters.object_id.value = $namespace.PrincipalId
    Set-Content -Path .\test\deployment-template\keyVaultParameter.json -Value (ConvertTo-Json $keyVaultTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\keyVaultTemplate.json -TemplateParameterFile .\test\deployment-template\keyVaultParameter.json -Name keyVaultTemplate -ResourceGroupName $resourceGroup
    
    Write-Host -ForegroundColor Magenta "Deployed KeyVault ARM template"

    $resourceNames = Get-Content .\test\deployment-template\pre-created-resources\parameter.json | ConvertFrom-Json
    $env.Add("storageAccountId", $resourceNames.parameters.storageAccountId.Value)
    $env.Add("blobContainer", $resourceNames.parameters.blobContainer.Value)
    $env.Add("subnetId1", $resourceNames.parameters.virtualNetworkId.Value)
    $env.Add("subnetId2", $resourceNames.parameters.virtualNetworkId2.Value)
    $env.Add("subnetId3", $resourceNames.parameters.virtualNetworkId3.Value)
    #msi 1 and msi 2 are Resource ID's of already existing managed identities
    $env.Add("msi1", $resourceNames.parameters.msi1.Value)
    $env.Add("msi2", $resourceNames.parameters.msi2.Value)

    Write-Host -ForegroundColor Magenta "Deployed Disaster Recovery template"

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function GenerateSASKey {
    [Reflection.Assembly]::LoadWithPartialName("System.Web")| out-null
    $URI="myNamespace.servicebus.windows.net/myEventHub"
    $Access_Policy_Name="RootManageSharedAccessKey"
    $Access_Policy_Key="myPrimaryKey"
    #Token expires now+300
    $Expires=([DateTimeOffset]::Now.ToUnixTimeSeconds())+300
    $SignatureString=[System.Web.HttpUtility]::UrlEncode($URI)+ "`n" + [string]$Expires
    $HMAC = New-Object System.Security.Cryptography.HMACSHA256
    $HMAC.key = [Text.Encoding]::ASCII.GetBytes($Access_Policy_Key)
    $Signature = $HMAC.ComputeHash([Text.Encoding]::ASCII.GetBytes($SignatureString))
    $Signature = [Convert]::ToBase64String($Signature)
    $Signature
}

function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

