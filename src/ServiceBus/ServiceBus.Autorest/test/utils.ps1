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
    # For any resources you created for test, you should add it to $env here.
    $resourceGroup = "resourceGroupAutorest" + (RandomString -allChars $false -len 6)
    $namespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $standardNamespaceName = "namespaceName" + (RandomString -allChars $false -len 6)
    $namespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.ServiceBus/namespaces/" + $namespaceName
    $primaryNamespaceName = "primaryNS" + (RandomString -allChars $false -len 6)
    $primaryNamespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.ServiceBus/namespaces/" + $primaryNamespaceName
    $secondaryNamespaceName = "secondaryNS" + (RandomString -allChars $false -len 6)
    $secondaryNamespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.ServiceBus/namespaces/" + $secondaryNamespaceName
    $migrationPrimaryNamespaceName = "primaryNS" + (RandomString -allChars $false -len 6)
    $migrationPrimaryNamespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.ServiceBus/namespaces/" + $migrationPrimaryNamespaceName
    $migrationSecondaryNamespaceName = "secondaryNS" + (RandomString -allChars $false -len 6)
    $migrationSecondaryNamespaceResourceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.ServiceBus/namespaces/" + $migrationSecondaryNamespaceName
    $peName1 = "pe1" + (RandomString -allChars $false -len 6)
    $peName2 = "pe2" + (RandomString -allChars $false -len 6)
    $alias = "alias" + (RandomString -allChars $false -len 6)
    $postMigrationName = "postMigration" + (RandomString -allChars $false -len 6)

    $env.Add('resourceGroup', $resourceGroup)
    $env.Add('namespace', $namespaceName)
    $env.Add('standardNamespace', $standardNamespaceName)
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

    $namespacePrimaryKey = GenerateSASKey
    $namespaceSecondaryKey = GenerateSASKey
    $queuePrimaryKey = GenerateSASKey
    $queueSecondaryKey = GenerateSASKey
    $topicPrimaryKey = GenerateSASKey
    $topicSecondaryKey = GenerateSASKey
    
    $env.Add('namespacePrimaryKey', $namespacePrimaryKey)
    $env.Add('namespaceSecondaryKey', $namespaceSecondaryKey)
    $env.Add('queuePrimaryKey', $queuePrimaryKey)
    $env.Add('queueSecondaryKey', $queueSecondaryKey)
    $env.Add('topicPrimaryKey', $topicPrimaryKey)
    $env.Add('topicSecondaryKey', $topicSecondaryKey)

    New-AzResourceGroup -Name $resourceGroup -Location eastus

    $serviceBusTemplate = Get-Content .\test\deployment-template\parameter.json | ConvertFrom-Json
    $serviceBusTemplate.parameters.namespace_name.value = $namespaceName
    $serviceBusTemplate.parameters.standard_namespace_name.value = $standardNamespaceName
    $serviceBusTemplate.parameters.namespaceResourceId.value = $namespaceResourceId
    $serviceBusTemplate.parameters.peName1.value = $peName1
    $serviceBusTemplate.parameters.peName2.value = $peName2
    Set-Content -Path .\test\deployment-template\parameter.json -Value (ConvertTo-Json $serviceBusTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\template.json -TemplateParameterFile .\test\deployment-template\parameter.json -Name serviceBusTemplate -ResourceGroupName $resourceGroup

    $serviceBusTemplate = Get-Content .\test\deployment-template\DisasterRecoveryParameter.json | ConvertFrom-Json
    $serviceBusTemplate.parameters.primarynamespace_name.value = $primaryNamespaceName
    $serviceBusTemplate.parameters.secondarynamespace_name.value = $secondaryNamespaceName
    $serviceBusTemplate.parameters.migrationPrimaryNamespace.value = $migrationPrimaryNamespaceName
    $serviceBusTemplate.parameters.migrationSecondaryNamespace.value = $migrationSecondaryNamespaceName
    Set-Content -Path .\test\deployment-template\DisasterRecoveryParameter.json -Value (ConvertTo-Json $serviceBusTemplate)
    $rg = New-AzResourceGroupDeployment -TemplateFile .\test\deployment-template\DisasterRecoveryTemplate.json -TemplateParameterFile .\test\deployment-template\DisasterRecoveryParameter.json -Name disasterRecoveryTemplate -ResourceGroupName $resourceGroup

    $resourceNames = Get-Content .\test\deployment-template\pre-created-resources\parameter.json | ConvertFrom-Json
    $env.Add("subnetId1", $resourceNames.parameters.virtualNetworkId.Value)
    $env.Add("subnetId2", $resourceNames.parameters.virtualNetworkId2.Value)
    $env.Add("subnetId3", $resourceNames.parameters.virtualNetworkId3.Value)

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

