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
    

    $resourceGroup = "pwshRg" + (RandomString -allChars $false -len 6)
    $managedIdentityName = "pwshMsi" + (RandomString -allChars $false -len 6)
    $devCenterName = "pwshDc" + (RandomString -allChars $false -len 6)
    $devCenterName2 = "pwshDc2" + (RandomString -allChars $false -len 6)
    $projectName = "pwshProj" + (RandomString -allChars $false -len 6)
    $projectName2 = "pwshPro2" + (RandomString -allChars $false -len 6)
    $poolName = RandomString -allChars $false -len 6
    $poolName2 = RandomString -allChars $false -len 6
    $location = "canadacentral"
    $catalogName = RandomString -allChars $false -len 6
    $catalogName2 = RandomString -allChars $false -len 6
    $attachedNetworkName  = RandomString -allChars $false -len 6
    $attachedNetworkName2  = RandomString -allChars $false -len 6
    $networkConnectionName  = RandomString -allChars $false -len 6
    $networkConnectionName2  = RandomString -allChars $false -len 6
    $galleryName  = RandomString -allChars $false -len 6
    $galleryName2  = RandomString -allChars $false -len 6
    $networkConnectionId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/networkConnections/" + $networkConnectionName
    $gitHubBranch = "main"
    $gitHubPath = "/Environments"
    $gitHubSecretIdentifier = "https://dummyVault/dummy/00000000"
    $keyVaultName = "dummy"
    $gitHubUri = "https://github.com/fake/fake.git"
    $devBoxDefinitionName  = RandomString -allChars $false -len 6
    $devBoxDefinitionName2  = RandomString -allChars $false -len 6
    $osStorageType = "ssd_1024gb"
    $skuName = "general_a_8c32gb_v1"
    $imageName = "MicrosoftWindowsDesktop_windows-ent-cpc_win11-22h2-ent-cpc-os"
    $imageReferenceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $devCenterName + "/galleries/Default/images/" + $imageName
    $imageVersion = "1.0.0"
    $environmentTypeName =  RandomString -allChars $false -len 6
    $environmentTypeName2 =  RandomString -allChars $false -len 6
    $devCenterId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $devCenterName
    $time = "18:30"
    $timeZone = "America/Los_Angeles"
    $subnetId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/amlim-test/providers/Microsoft.Network/virtualNetworks/amlim-vnet-canadacentral/subnets/default"
    $sigId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/amlim-test/providers/Microsoft.Compute/galleries/amlim_pwsh_sig"
    New-AzResourceGroup -Name $resourceGroup -Location "canadacentral"

    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("managedIdentityName", $managedIdentityName)
    $env.Add("devCenterName", $devCenterName)
    $env.Add("devCenterName2", $devCenterName2)
    $env.Add("projectName", $projectName)
    $env.Add("location", $location)
    $env.Add("catalogName", $catalogName)
    $env.Add("attachedNetworkName", $attachedNetworkName)
    $env.Add("attachedNetworkName2", $attachedNetworkName2)
    $env.Add("networkConnectionName", $networkConnectionName)
    $env.Add("networkConnectionName2", $networkConnectionName2)
    $env.Add("networkConnectionId", $networkConnectionId)
    $env.Add("gitHubBranch", $gitHubBranch)
    $env.Add("gitHubPath", $gitHubPath)
    $env.Add("gitHubSecretIdentifier", $gitHubSecretIdentifier)
    $env.Add("gitHubUri", $gitHubUri)
    $env.Add("devBoxDefinitionName", $devBoxDefinitionName)
    $env.Add("devBoxDefinitionName2", $devBoxDefinitionName2)
    $env.Add("osStorageType", $osStorageType)
    $env.Add("skuName", $skuName)
    $env.Add("imageReferenceId", $imageReferenceId)
    $env.Add("environmentTypeName", $environmentTypeName)
    $env.Add("imageName", $imageName)
    $env.Add("imageVersion", $imageVersion)
    $env.Add("devCenterId", $devCenterId)
    $env.Add("poolName", $poolName)
    $env.Add("time", $time)
    $env.Add("timeZone", $timeZone)
    $env.Add("subnetId", $subnetId)
    $env.Add("sigId", $sigId)
    $env.Add("projectName2", $projectName2)
    $env.Add("catalogName2", $catalogName2)
    $env.Add("environmentTypeName2", $environmentTypeName2)
    $env.Add("galleryName", $galleryName)
    $env.Add("galleryName2", $galleryName2)
    $env.Add("poolName2", $poolName2)

    $devboxTemplate = Get-Content .\test\deploymentTemplates\parameter.json | ConvertFrom-Json
    $devboxTemplate.parameters.managedIdentityName.value = $managedIdentityName
    $devboxTemplate.parameters.subscriptionId.value =  $env.SubscriptionId
    $devboxTemplate.parameters.resourceGroup.value = $resourceGroup
    $devboxTemplate.parameters.devCenterName.value = $devCenterName
    $devboxTemplate.parameters.devCenterName2.value = $devCenterName2
    $devboxTemplate.parameters.projectName.value = $projectName
    $devboxTemplate.parameters.location.value = $location
    $devboxTemplate.parameters.subnetId.value = $subnetId
    $devboxTemplate.parameters.keyVaultSecret.value = $gitHubSecretIdentifier
    $devboxTemplate.parameters.networkConnectionName.value = $networkConnectionName
    $devboxTemplate.parameters.networkConnectionName2.value = $networkConnectionName2
    $devboxTemplate.parameters.catalogName.value = $catalogName
    $devboxTemplate.parameters.gitHubRepo.value = $gitHubUri
    $devboxTemplate.parameters.attachedNetworkName.value = $attachedNetworkName
    $devboxTemplate.parameters.imageReferenceId.value = $imageReferenceId
    $devboxTemplate.parameters.skuName.value = $skuName
    $devboxTemplate.parameters.osStorageType.value = $osStorageType
    $devboxTemplate.parameters.keyVaultName.value = $keyVaultName
    $devboxTemplate.parameters.tenantId.value = $env.Tenant
    $devboxTemplate.parameters.environmentTypeName.value = $environmentTypeName
    $devboxTemplate.parameters.poolName.value = $poolName
    $devboxTemplate.parameters.sigId.value = $sigId
    $devboxTemplate.parameters.projectName2.value = $projectName2
    $devboxTemplate.parameters.catalogName2.value = $catalogName2
    $devboxTemplate.parameters.attachedNetworkName2.value = $attachedNetworkName2
    $devboxTemplate.parameters.devBoxDefinitionName2.value = $devBoxDefinitionName2
    $devboxTemplate.parameters.devBoxDefinitionName.value = $devBoxDefinitionName
    $devboxTemplate.parameters.environmentTypeName2.value = $environmentTypeName2
    $devboxTemplate.parameters.galleryName.value = $galleryName
    $devboxTemplate.parameters.galleryName2.value = $galleryName2
    $devboxTemplate.parameters.poolName2.value = $poolName2

    Set-Content -Path .\test\deploymentTemplates\parameter.json -Value (ConvertTo-Json $devboxTemplate)

    New-AzResourceGroupDeployment -TemplateFile .\test\deploymentTemplates\template.json -TemplateParameterFile .\test\deploymentTemplates\parameter.json -Name devboxTemplate -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Magenta "Deployed dev box template"


    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

