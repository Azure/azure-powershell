function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % { [char]$_ })
    }
    else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % { [char]$_ })
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
    $devCenterNameDelete = "pwshDc2" + (RandomString -allChars $false -len 6)
    $projectName = "pwshProj" + (RandomString -allChars $false -len 6)
    $projectNameDelete = "pwshPro2" + (RandomString -allChars $false -len 6)
    $poolName = RandomString -allChars $false -len 6
    $poolNameDelete = RandomString -allChars $false -len 6
    $location = "canadacentral"
    $catalogName = RandomString -allChars $false -len 6
    $catalogNameDelete = RandomString -allChars $false -len 6
    $attachedNetworkName = RandomString -allChars $false -len 6
    $attachedNetworkNameDelete = RandomString -allChars $false -len 6
    $networkConnectionName = RandomString -allChars $false -len 6
    $networkConnectionNameDelete = RandomString -allChars $false -len 6
    $galleryName = RandomString -allChars $false -len 6
    $galleryNameDelete = RandomString -allChars $false -len 6
    $networkConnectionId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/networkConnections/" + $networkConnectionName
    $gitHubBranch = "main"
    $gitHubPath = "/Environments"
    $devBoxDefinitionName = RandomString -allChars $false -len 6
    $devBoxDefinitionNameDelete = RandomString -allChars $false -len 6
    $osStorageType = "ssd_1024gb"
    $skuName = "general_a_8c32gb_v1"
    $imageName = "MicrosoftWindowsDesktop_windows-ent-cpc_win11-22h2-ent-cpc-os"
    $imageReferenceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $devCenterName + "/galleries/Default/images/" + $imageName
    $imageVersion = "1.0.0"
    $environmentTypeName = RandomString -allChars $false -len 6
    $environmentTypeNameDelete = RandomString -allChars $false -len 6
    $devCenterId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $devCenterName
    $time = "18:30"
    $timeZone = "America/Los_Angeles"
    $subnetId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/amlim-test/providers/Microsoft.Network/virtualNetworks/amlim-vnet-canadacentral/subnets/default"
    $sigId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/amlim-test/providers/Microsoft.Compute/galleries/amlim_pwsh_sig"

    # Replace with real values when running test recordings
    $gitHubSecretIdentifier = "https://dummyVault/dummy/00000000"
    $keyVaultName = "dummy"
    $gitHubUri = "https://github.com/fake/fake.git"

    New-AzResourceGroup -Name $resourceGroup -Location "canadacentral"

    $attachedNetworkNew = RandomString -allChars $false -len 4
    $attachedNetworkNew2 = RandomString -allChars $false -len 5
    $catalogNew = RandomString -allChars $false -len 4
    $catalogNew2 = RandomString -allChars $false -len 5
    $devBoxDefinitionNew = RandomString -allChars $false -len 4
    $devBoxDefinitionNew2 = RandomString -allChars $false -len 5
    $devCenterNew = RandomString -allChars $false -len 4
    $devCenterNew2 = RandomString -allChars $false -len 5
    $envTypeNew = RandomString -allChars $false -len 5
    $envTypeNew2 = RandomString -allChars $false -len 4
    $galleryNew = RandomString -allChars $false -len 5
    $galleryNew2 = RandomString -allChars $false -len 4
    $networkConnectionNew = RandomString -allChars $false -len 5
    $networkConnectionNew2 = RandomString -allChars $false -len 4
    $networkConnectionHybridNew = RandomString -allChars $false -len 5
    $networkConnectionHybridNew2 = RandomString -allChars $false -len 4
    $poolNew = RandomString -allChars $false -len 4
    $poolNew2 = RandomString -allChars $false -len 5
    $projectNew = RandomString -allChars $false -len 4
    $projectNew2 = RandomString -allChars $false -len 5
    $envForProjEnvTypeNew = RandomString -allChars $false -len 4
    $envForProjEnvTypeNew2 = RandomString -allChars $false -len 4
    $poolForScheduleNew = RandomString -allChars $false -len 5
    $poolForScheduleNew2 = RandomString -allChars $false -len 4
    $networkingRgName1 = "1" + (RandomString -allChars $false -len 4)
    $networkingRgName2 = "2" + (RandomString -allChars $false -len 4)
    $networkingRgName3 = "3" + (RandomString -allChars $false -len 4)
    $networkingRgName4 = "4" + (RandomString -allChars $false -len 4)
    $aadJoinType = "AzureADJoin"
    $hybridDomainJoinType = "HybridAzureADJoin"
    $domainName = "fidalgoppe010.local"
    $domainPassword = "fakePassword"
    $domainUsername = "domainjoin@fidalgoppe010.local"

    $env.Add("aadJoinType", $aadJoinType)
    $env.Add("hybridDomainJoinType", $hybridDomainJoinType)
    $env.Add("domainName", $domainName)
    $env.Add("domainPassword", $domainPassword)
    $env.Add("domainUsername", $domainUsername)
    $env.Add("networkingRgName1", $networkingRgName1)
    $env.Add("networkingRgName2", $networkingRgName2)
    $env.Add("networkingRgName3", $networkingRgName3)
    $env.Add("networkingRgName4", $networkingRgName4)
    $env.Add("attachedNetworkNew", $attachedNetworkNew)
    $env.Add("attachedNetworkNew2", $attachedNetworkNew2)
    $env.Add("catalogNew", $catalogNew)
    $env.Add("catalogNew2", $catalogNew2)
    $env.Add("devBoxDefinitionNew", $devBoxDefinitionNew)
    $env.Add("devBoxDefinitionNew2", $devBoxDefinitionNew2)
    $env.Add("devCenterNew", $devCenterNew)
    $env.Add("devCenterNew2", $devCenterNew2)
    $env.Add("envTypeNew", $envTypeNew)
    $env.Add("envTypeNew2", $envTypeNew2)
    $env.Add("galleryNew", $galleryNew)
    $env.Add("galleryNew2", $galleryNew2)
    $env.Add("networkConnectionNew", $networkConnectionNew)
    $env.Add("networkConnectionNew2", $networkConnectionNew2)
    $env.Add("poolNew", $poolNew)
    $env.Add("poolNew2", $poolNew2)
    $env.Add("networkConnectionHybridNew", $networkConnectionHybridNew)
    $env.Add("networkConnectionHybridNew2", $networkConnectionHybridNew2)
    $env.Add("projectNew", $projectNew)
    $env.Add("projectNew2", $projectNew2)
    $env.Add("envForProjEnvTypeNew", $envForProjEnvTypeNew)
    $env.Add("envForProjEnvTypeNew2", $envForProjEnvTypeNew2)
    $env.Add("poolForScheduleNew", $poolForScheduleNew)
    $env.Add("poolForScheduleNew2", $poolForScheduleNew2)

    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("managedIdentityName", $managedIdentityName)
    $env.Add("devCenterName", $devCenterName)
    $env.Add("devCenterNameDelete", $devCenterNameDelete)
    $env.Add("projectName", $projectName)
    $env.Add("location", $location)
    $env.Add("catalogName", $catalogName)
    $env.Add("attachedNetworkName", $attachedNetworkName)
    $env.Add("networkConnectionName", $networkConnectionName)
    $env.Add("networkConnectionId", $networkConnectionId)
    $env.Add("gitHubBranch", $gitHubBranch)
    $env.Add("gitHubPath", $gitHubPath)
    $env.Add("gitHubSecretIdentifier", $gitHubSecretIdentifier)
    $env.Add("gitHubUri", $gitHubUri)
    $env.Add("devBoxDefinitionName", $devBoxDefinitionName)
    $env.Add("galleryName", $galleryName)
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

    $env.Add("projectNameDelete", $projectNameDelete)
    $env.Add("catalogNameDelete", $catalogNameDelete)
    $env.Add("environmentTypeNameDelete", $environmentTypeNameDelete)
    $env.Add("devBoxDefinitionNameDelete", $devBoxDefinitionNameDelete)
    $env.Add("galleryNameDelete", $galleryNameDelete)
    $env.Add("poolNameDelete", $poolNameDelete)
    $env.Add("networkConnectionNameDelete", $networkConnectionNameDelete)
    $env.Add("attachedNetworkNameDelete", $attachedNetworkNameDelete)
    $env.Add("devCenterNameDelete", $devCenterNameDelete)

    $devboxTemplate = Get-Content .\test\deploymentTemplates\parameter.json | ConvertFrom-Json
    $devboxTemplate.parameters.managedIdentityName.value = $managedIdentityName
    $devboxTemplate.parameters.subscriptionId.value = $env.SubscriptionId
    $devboxTemplate.parameters.resourceGroup.value = $resourceGroup
    $devboxTemplate.parameters.devCenterName.value = $devCenterName
    $devboxTemplate.parameters.devCenterNameDelete.value = $devCenterNameDelete
    $devboxTemplate.parameters.projectName.value = $projectName
    $devboxTemplate.parameters.location.value = $location
    $devboxTemplate.parameters.subnetId.value = $subnetId
    $devboxTemplate.parameters.keyVaultSecret.value = $gitHubSecretIdentifier
    $devboxTemplate.parameters.networkConnectionName.value = $networkConnectionName
    $devboxTemplate.parameters.networkConnectionNameDelete.value = $networkConnectionNameDelete
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
    $devboxTemplate.parameters.projectNameDelete.value = $projectNameDelete
    $devboxTemplate.parameters.catalogNameDelete.value = $catalogNameDelete
    $devboxTemplate.parameters.attachedNetworkNameDelete.value = $attachedNetworkNameDelete
    $devboxTemplate.parameters.devBoxDefinitionNameDelete.value = $devBoxDefinitionNameDelete
    $devboxTemplate.parameters.devBoxDefinitionName.value = $devBoxDefinitionName
    $devboxTemplate.parameters.environmentTypeNameDelete.value = $environmentTypeNameDelete
    $devboxTemplate.parameters.galleryName.value = $galleryName
    $devboxTemplate.parameters.galleryNameDelete.value = $galleryNameDelete
    $devboxTemplate.parameters.poolNameDelete.value = $poolNameDelete
    $devboxTemplate.parameters.envForProjEnvTypeNew.value = $envForProjEnvTypeNew
    $devboxTemplate.parameters.envForProjEnvTypeNew2.value = $envForProjEnvTypeNew2
    $devboxTemplate.parameters.poolForScheduleNew.value = $poolForScheduleNew
    $devboxTemplate.parameters.poolForScheduleNew2.value = $poolForScheduleNew2

    Set-Content -Path .\test\deploymentTemplates\parameter.json -Value (ConvertTo-Json $devboxTemplate)

    New-AzResourceGroupDeployment -TemplateFile .\test\deploymentTemplates\template.json -TemplateParameterFile .\test\deploymentTemplates\parameter.json -Name devboxTemplate -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Magenta "Deployed dev box template"

    $identity = Get-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.managedIdentityName
    $identityId = $identity.Id
    $env.Add("identityId", $identityId)



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
    Remove-AzResourceGroup -Name $env.networkingRgName1
    Remove-AzResourceGroup -Name $env.networkingRgName2
    Remove-AzResourceGroup -Name $env.networkingRgName3
    Remove-AzResourceGroup -Name $env.networkingRgName4
}

