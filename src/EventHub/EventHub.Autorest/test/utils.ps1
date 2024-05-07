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
function setupEnv(
    $location = 'eastus',
    $secondaryLocation = 'southcentralus',
    $useZoneRedundancy = $true,
    $verbose = $false) {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id

    $resourceGroup = "Autorest-PS-EventHub-" + (RandomString -allChars $false -len 6)
    $namespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $systemAssignedNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $dependentResourcesPrefix = "eh-ps-" + (RandomString -allChars $false -len 6)
    $keyVaultName = $dependentResourcesPrefix + "-kv1"
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
    $resourceGroupArmId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/" + $resourceGroup
    $namespaceResourceId = "$resourceGroupArmId/providers/Microsoft.EventHub/namespaces/$namespaceName"
    $primaryNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $primaryNamespaceResourceId = "$resourceGroupArmId/providers/Microsoft.EventHub/namespaces/$primaryNamespaceName"
    $secondaryNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $secondaryNamespaceResourceId = "$resourceGroupArmId/providers/Microsoft.EventHub/namespaces/$secondaryNamespaceName"
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
    $eventHub4 = "eventHub" + (RandomString -allChars $false -len 6)
    $eventHub5 = "eventHub" + (RandomString -allChars $false -len 6)
    $eventHub9 = "eventHub9" + (RandomString -allChars $false -len 6)
    $cluster = "cluster" + (RandomString -allChars $false -len 6)
    $cluster2 = "cluster" + (RandomString -allChars $false -len 6)
    $alias = "alias" + (RandomString -allChars $false -len 6)
    $pe1 = "privateEndpoint-" + (RandomString -allChars $false -len 6)
    $pe2 = "privateEndpoint-" + (RandomString -allChars $false -len 6)
    $storageAccountName1 = "$dependentResourcesPrefix-sa1".Replace('-', '').ToLower()
    $storageAccountId1 = "$resourceGroupArmId/providers/Microsoft.Storage/storageAccounts/$storageAccountName1"
    $vnetResourceId = "$resourceGroupArmId/providers/Microsoft.Network/virtualNetworks/$dependentResourcesPrefix-vnet"
    $subnet1ResourceId = "$vnetResourceId/subnets/default"
    $subnet2ResourceId = "$vnetResourceId/subnets/default2"
    $subnet3ResourceId = "$vnetResourceId/subnets/default3"
    $msi1Name = "$dependentResourcesPrefix-msi1"
    $msi2Name = "$dependentResourcesPrefix-msi2"
    $msi1ResourceId = "$resourceGroupArmId/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$msi1Name"
    $msi2ResourceId = "$resourceGroupArmId/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$msi2Name"

    $namespacePrimaryKey = GenerateSASKey
    $namespaceSecondaryKey = GenerateSASKey
    $eventHubPrimaryKey = GenerateSASKey
    $eventHubSecondaryKey = GenerateSASKey

    $env.Add("location", $location)
    $env.Add("secondaryLocation", $secondaryLocation)
    $env.Add("useZoneRedundancy", $useZoneRedundancy)
    $env.Add("resourceGroup", $resourceGroup)
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
    $env.Add("systemAssignedNamespaceName", $systemAssignedNamespaceName)
    $env.Add("keyVaultUri", $keyVaultUri)
    $env.Add("primaryNamespace", $primaryNamespaceName)
    $env.Add("secondaryNamespace", $secondaryNamespaceName)
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
    $env.Add("eventHub4", $eventHub4)
    $env.Add("eventHub5", $eventHub5)
    $env.Add("createdCluster", "TestClusterAutomatic")
    $env.Add("cluster", $cluster)
    $env.Add("cluster2", $cluster2)
    $env.Add("clusterResourceGroup", "AutomatedPowershellTesting")
    $env.Add("clusterSubscriptionId", "326100e2-f69d-4268-8503-075374f62b6e")
    $env.Add("consumerGroup", '$Default')
    $env.Add("consumerGroup2", $consumerGroup2)
    $env.Add("consumerGroup3", $consumerGroup3)
    $env.Add('pe1', $peName1)
    $env.Add('pe2', $peName2)
    $env.Add('alias', $alias)
    $env.Add("subnetId1", $subnet1ResourceId)
    $env.Add("subnetId2", $subnet2ResourceId)
    $env.Add("subnetId3", $subnet3ResourceId)
    $env.Add("msi1", $msi1ResourceId)
    $env.Add("msi2", $msi2ResourceId)
    $env.Add("storageAccountId", $storageAccountId1)
    $env.Add("blobContainer", 'container')
    $env.Add("namespacePrimaryKey", $namespacePrimaryKey)
    $env.Add("namespaceSecondaryKey", $namespaceSecondaryKey)
    $env.Add("eventHubPrimaryKey", $eventHubPrimaryKey)
    $env.Add("eventHubSecondaryKey", $eventHubSecondaryKey)

    Write-Host -ForegroundColor Magenta "Creating resource group $resourceGroup in $location"

    New-AzResourceGroup -Name $resourceGroup -Location $location -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deploying dependencies ARM template"

    $dependentResourcesTemplate = Get-Content .\test\deployment-template\DependentResourcesParameters.json | ConvertFrom-Json
    $dependentResourcesTemplate.parameters.resource_name_prefix.value = $dependentResourcesPrefix
    $dependentResourcesTemplate.parameters.useZoneRedundancy.value = $useZoneRedundancy
    Set-Content -Path .\test\deployment-template\DependentResourcesParameters.json -Value (ConvertTo-Json $dependentResourcesTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\DependentResourcesTemplate.json -TemplateParameterFile .\test\deployment-template\DependentResourcesParameters.json -Name dependenciesTemplate -ResourceGroupName $resourceGroup -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deployed dependencies ARM template"

    # RBAC is best setup via PowerShell as ARM template experience is extremely lacking
    Write-Host -ForegroundColor Magenta "Setting up RBAC permissions"
    $token = Get-AzAccessToken
    $appIdGuid = [Guid]::Empty
    if ([Guid]::TryParse($token.UserId, [ref]$appIdGuid)) {
        # If the user id is a Guid, the login identity is an AAD App.
        New-AzRoleAssignment -ApplicationId $token.UserId -RoleDefinitionName "Storage Blob Data Contributor" -Scope $env.storageAccountId -Verbose:$verbose
    }
    else {
        New-AzRoleAssignment -SignInName $token.UserId -RoleDefinitionName "Storage Blob Data Contributor" -Scope $env.storageAccountId -Verbose:$verbose
    }

    $msi1 = Get-AzUserAssignedIdentity -Name $msi1Name -ResourceGroupName $resourceGroup
    $msi2 = Get-AzUserAssignedIdentity -Name $msi2Name -ResourceGroupName $resourceGroup
    New-AzRoleAssignment -ObjectId $msi1.PrincipalId -RoleDefinitionName "Storage Blob Data Contributor" -Scope $env.storageAccountId -Verbose:$verbose
    New-AzRoleAssignment -ObjectId $msi2.PrincipalId -RoleDefinitionName "Storage Blob Data Contributor" -Scope $env.storageAccountId -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Successfully set up RBAC permissions"

    Write-Host -ForegroundColor Magenta "Deploying Event Hubs namespace template"

    $eventHubTemplate = Get-Content .\test\deployment-template\parameter.json | ConvertFrom-Json
    $eventHubTemplate.parameters.secondaryLocation.value = $secondaryLocation
    $eventHubTemplate.parameters.namespace_name.value = $namespaceName
    $eventHubTemplate.parameters.system_assigned_namespace_name.value = $systemAssignedNamespaceName
    $eventHubTemplate.parameters.primary_namespace_name.value = $primaryNamespaceName
    $eventHubTemplate.parameters.secondary_namespace_name.value = $secondaryNamespaceName
    $eventHubTemplate.parameters.namespace_auth_rule_name.value = $authRule
    $eventHubTemplate.parameters.eventhub_auth_rule_name.value = $eventHubAuthRule
    $eventHubTemplate.parameters.eventhub_name.value = $eventHub
    $eventHubTemplate.parameters.schema_group_name.value = $schemaGroup
    $eventHubTemplate.parameters.appgroup_name.value = $appGroup
    $eventHubTemplate.parameters.subnet1Id.value = $subnet1ResourceId
    $eventHubTemplate.parameters.peName1.value = $pe1
    $eventHubTemplate.parameters.peName2.value = $pe2
    $eventHubTemplate.parameters.namespaceResourceId.value = $namespaceResourceId
    $eventHubTemplate.parameters.useZoneRedundancy.value = $useZoneRedundancy
    Set-Content -Path .\test\deployment-template\parameter.json -Value (ConvertTo-Json $eventHubTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\template.json -TemplateParameterFile .\test\deployment-template\parameter.json -Name eventHubTemplate -ResourceGroupName $resourceGroup -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deployed Event Hubs namespace template"

    Write-Host -ForegroundColor Magenta "Deploying KeyVault ARM template"

    $keyVaultTemplate = Get-Content .\test\deployment-template\KeyVaultParameters.json | ConvertFrom-Json
    $keyVaultTemplate.parameters.resource_name_prefix.value = $dependentResourcesPrefix
    $keyVaultTemplate.parameters.system_assigned_namespace_name.value = $systemAssignedNamespaceName
    Set-Content -Path .\test\deployment-template\KeyVaultParameters.json -Value (ConvertTo-Json $keyVaultTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\KeyVaultTemplate.json -TemplateParameterFile .\test\deployment-template\KeyVaultParameters.json -Name keyVaultTemplate -ResourceGroupName $resourceGroup -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deployed KeyVault ARM template"

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

function cleanupEnv(
    $verbose = $false) {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup -Confirm:$false -Verbose:$verbose
}

