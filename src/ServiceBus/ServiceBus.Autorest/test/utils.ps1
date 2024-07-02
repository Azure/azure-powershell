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
    $usePartitionedNamespace = $true,
    $useZoneRedundancy = $true,
    $verbose = $false) {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $resourceGroup = "Autorest-PS-ServiceBus-" + (RandomString -allChars $false -len 6)
    $namespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $namespaceV2 = "namespaceV2" + (RandomString -allChars $false -len 6)
    $namespaceV3 = "namespaceV3" + (RandomString -allChars $false -len 6)
    $namespaceV4 = "namespaceV4" + (RandomString -allChars $false -len 6)
    $namespaceV5 = "namespaceV5" + (RandomString -allChars $false -len 6)
    $namespaceV6 = "namespaceV6" + (RandomString -allChars $false -len 6)
    $namespaceV7 = "namespaceV7" + (RandomString -allChars $false -len 6)
    $namespaceV8 = "namespaceV8" + (RandomString -allChars $false -len 6)
    $namespaceV9 = "namespaceV9" + (RandomString -allChars $false -len 6)
    $standardNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $systemAssignedNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $dependentResourcesPrefix = "sb-ps-" + (RandomString -allChars $false -len 6)
    $keyVaultName = $dependentResourcesPrefix + "-kv1"
    $keyVaultUri = "https://" + $keyVaultName + ".vault.azure.net/"
    $resourceGroupArmId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup
    $namespaceResourceId = $resourceGroupArmId + "/providers/Microsoft.ServiceBus/namespaces/" + $namespaceName
    $primaryNamespaceName = "primaryNS" + (RandomString -allChars $false -len 6)
    $primaryNamespaceResourceId = $resourceGroupArmId + "/providers/Microsoft.ServiceBus/namespaces/" + $primaryNamespaceName
    $secondaryNamespaceName = "secondaryNS" + (RandomString -allChars $false -len 6)
    $secondaryNamespaceResourceId = $resourceGroupArmId + "/providers/Microsoft.ServiceBus/namespaces/" + $secondaryNamespaceName
    $migrationPrimaryNamespaceName = "primaryNS" + (RandomString -allChars $false -len 6)
    $migrationPrimaryNamespaceResourceId = $resourceGroupArmId + "/providers/Microsoft.ServiceBus/namespaces/" + $migrationPrimaryNamespaceName
    $migrationSecondaryNamespaceName = "secondaryNS" + (RandomString -allChars $false -len 6)
    $migrationSecondaryNamespaceResourceId = $resourceGroupArmId + "/providers/Microsoft.ServiceBus/namespaces/" + $migrationSecondaryNamespaceName
    $vnetResourceId = "$resourceGroupArmId/providers/Microsoft.Network/virtualNetworks/$dependentResourcesPrefix-vnet"
    $subnet1ResourceId = "$vnetResourceId/subnets/default"
    $subnet2ResourceId = "$vnetResourceId/subnets/default2"
    $subnet3ResourceId = "$vnetResourceId/subnets/default3"
    $msi1ResourceId = "$resourceGroupArmId/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$dependentResourcesPrefix-msi1"
    $msi2ResourceId = "$resourceGroupArmId/providers/Microsoft.ManagedIdentity/userAssignedIdentities/$dependentResourcesPrefix-msi2"
    $peName1 = "pe1" + (RandomString -allChars $false -len 6)
    $peName2 = "pe2" + (RandomString -allChars $false -len 6)
    $alias = "alias" + (RandomString -allChars $false -len 6)
    $postMigrationName = "postMigration" + (RandomString -allChars $false -len 6)

    $namespacePrimaryKey = GenerateSASKey
    $namespaceSecondaryKey = GenerateSASKey
    $queuePrimaryKey = GenerateSASKey
    $queueSecondaryKey = GenerateSASKey
    $topicPrimaryKey = GenerateSASKey
    $topicSecondaryKey = GenerateSASKey

    $env.Add("location", $location)
    $env.Add("secondaryLocation", $secondaryLocation)
    $env.Add("useZoneRedundancy", $useZoneRedundancy)
    $env.Add("usePartitionedNamespace", $usePartitionedNamespace)
    $env.Add('resourceGroup', $resourceGroup)
    $env.Add('namespace', $namespaceName)
    $env.Add("namespaceV2", $namespaceV2)
    $env.Add("namespaceV3", $namespaceV3)
    $env.Add("namespaceV4", $namespaceV4)
    $env.Add("namespaceV5", $namespaceV5)
    $env.Add("namespaceV6", $namespaceV6)
    $env.Add("namespaceV7", $namespaceV7)
    $env.Add("namespaceV8", $namespaceV8)
    $env.Add("namespaceV9", $namespaceV9)
    $env.Add('standardNamespace', $standardNamespaceName)
    $env.Add("systemAssignedNamespaceName", $systemAssignedNamespaceName)
    $env.Add("keyVaultUri", $keyVaultUri)
    $env.Add('namespaceResourceId', $namespaceResourceId)
    $env.Add('primaryNamespace', $primaryNamespaceName)
    $env.Add('secondaryNamespace', $secondaryNamespaceName)
    $env.Add('primaryNamespaceResourceId', $primaryNamespaceResourceId)
    $env.Add('secondaryNamespaceResourceId', $secondaryNamespaceResourceId)
    $env.Add('migrationPrimaryNamespace', $migrationPrimaryNamespaceName)
    $env.Add('migrationSecondaryNamespace', $migrationSecondaryNamespaceName)
    $env.Add('migrationPrimaryNamespaceResourceId', $migrationPrimaryNamespaceResourceId)
    $env.Add('migrationSecondaryNamespaceResourceId', $migrationSecondaryNamespaceResourceId)
    $env.Add('postMigrationName', $postMigrationName)
    $env.Add('pe1', $peName1)
    $env.Add('pe2', $peName2)
    $env.Add('alias', $alias)
    $env.Add("subnetId1", $subnet1ResourceId)
    $env.Add("subnetId2", $subnet2ResourceId)
    $env.Add("subnetId3", $subnet3ResourceId)
    $env.Add("msi1", $msi1ResourceId)
    $env.Add("msi2", $msi2ResourceId)

    $env.Add('namespacePrimaryKey', $namespacePrimaryKey)
    $env.Add('namespaceSecondaryKey', $namespaceSecondaryKey)
    $env.Add('queuePrimaryKey', $queuePrimaryKey)
    $env.Add('queueSecondaryKey', $queueSecondaryKey)
    $env.Add('topicPrimaryKey', $topicPrimaryKey)
    $env.Add('topicSecondaryKey', $topicSecondaryKey)

    Write-Host -ForegroundColor Magenta "Creating resource group $resourceGroup in $location"

    New-AzResourceGroup -Name $resourceGroup -Location $location -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deploying dependencies ARM template"

    $dependentResourcesTemplate = Get-Content .\test\deployment-template\DependentResourcesParameters.json | ConvertFrom-Json
    $dependentResourcesTemplate.parameters.resource_name_prefix.value = $dependentResourcesPrefix
    $dependentResourcesTemplate.parameters.useZoneRedundancy.value = $useZoneRedundancy
    Set-Content -Path .\test\deployment-template\DependentResourcesParameters.json -Value (ConvertTo-Json $dependentResourcesTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\DependentResourcesTemplate.json -TemplateParameterFile .\test\deployment-template\DependentResourcesParameters.json -Name dependenciesTemplate -ResourceGroupName $resourceGroup -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deployed dependencies ARM template"

    Write-Host -ForegroundColor Magenta "Deploying Service Bus namespace template"

    $serviceBusTemplate = Get-Content .\test\deployment-template\parameter.json | ConvertFrom-Json
    $serviceBusTemplate.parameters.secondaryLocation.value = $secondaryLocation
    $serviceBusTemplate.parameters.namespace_name.value = $namespaceName
    $serviceBusTemplate.parameters.standard_namespace_name.value = $standardNamespaceName
    $serviceBusTemplate.parameters.system_assigned_namespace_name.value = $systemAssignedNamespaceName
    $serviceBusTemplate.parameters.primarynamespace_name.value = $primaryNamespaceName
    $serviceBusTemplate.parameters.secondarynamespace_name.value = $secondaryNamespaceName
    $serviceBusTemplate.parameters.migrationPrimaryNamespace.value = $migrationPrimaryNamespaceName
    $serviceBusTemplate.parameters.migrationSecondaryNamespace.value = $migrationSecondaryNamespaceName
    $serviceBusTemplate.parameters.subnet1Id.value = $subnet1ResourceId
    $serviceBusTemplate.parameters.peName1.value = $peName1
    $serviceBusTemplate.parameters.peName2.value = $peName2
    $serviceBusTemplate.parameters.useZoneRedundancy.value = $useZoneRedundancy
    Set-Content -Path .\test\deployment-template\parameter.json -Value (ConvertTo-Json $serviceBusTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\template.json -TemplateParameterFile .\test\deployment-template\parameter.json -Name serviceBusTemplate -ResourceGroupName $resourceGroup -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deployed Service Bus namespace template"

    Write-Host -ForegroundColor Magenta "Deploying KeyVault ARM template"

    $keyVaultTemplate = Get-Content .\test\deployment-template\KeyVaultParameters.json | ConvertFrom-Json
    $keyVaultTemplate.parameters.resource_name_prefix.value = $dependentResourcesPrefix
    $keyVaultTemplate.parameters.system_assigned_namespace_name.value = $systemAssignedNamespaceName
    Set-Content -Path .\test\deployment-template\KeyVaultParameters.json -Value (ConvertTo-Json $keyVaultTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\KeyVaultTemplate.json -TemplateParameterFile .\test\deployment-template\KeyVaultParameters.json -Name keyVaultTemplate -ResourceGroupName $resourceGroup -Verbose:$verbose

    Write-Host -ForegroundColor Magenta "Deployed KeyVault ARM template"

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

