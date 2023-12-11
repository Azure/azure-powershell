function GetEndpoint([string]$project, [string]$resourceGroup) {
        $query = "Resources |where type =~'Microsoft.devcenter/projects' "`
            + "| where name =~ '$project' "`
            + "| where resourceGroup =~ '$resourceGroup' "`
            + "| take 1 "`
            + "| extend devCenterUri = properties.devCenterUri | project devCenterUri"
        $argResponse = Az.ResourceGraph\Search-AzGraph -Query $query
        $devCenterUri = $argResponse.devCenterUri

        return $devCenterUri.Substring(0, $devCenterUri.Length - 1)

}
function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % { [char]$_ })
    }
    else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % { [char]$_ })
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
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
    $projectName = "pwshProj" + (RandomString -allChars $false -len 6)
    $projectName2 = "pwshProj" + (RandomString -allChars $false -len 6)
    $poolName = RandomString -allChars $false -len 6
    $poolName2 = RandomString -allChars $false -len 6
    $location = "canadacentral"
    $catalogName = RandomString -allChars $false -len 6
    $attachedNetworkName = RandomString -allChars $false -len 6
    $networkConnectionName = RandomString -allChars $false -len 6
    $networkConnectionId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/networkConnections/" + $networkConnectionName
    $gitHubBranch = "main"
    $gitHubPath = "/Environments"
    $devBoxDefinitionName = RandomString -allChars $false -len 6
    $osStorageType = "ssd_1024gb"
    $skuName = "general_a_8c32gb1024ssd_v2"
    $imageName = "MicrosoftWindowsDesktop_windows-ent-cpc_win11-22h2-ent-cpc-os"
    $imageReferenceId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $devCenterName + "/galleries/Default/images/" + $imageName
    $imageVersion = "1.0.0"
    $environmentTypeName = RandomString -allChars $false -len 6
    $devCenterId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/" + $resourceGroup + "/providers/Microsoft.DevCenter/devcenters/" + $devCenterName
    $time = "18:30"
    $timeZone = "America/Los_Angeles"
    $subnetId = "/subscriptions/" + $env.SubscriptionId + "/resourceGroups/amlim-test/providers/Microsoft.Network/virtualNetworks/amlim-vnet-canadacentral/subnets/default"

    Connect-AzAccount -Tenant $env.Tenant -AccountId amlim@microsoft.com

    New-AzResourceGroup -Name $resourceGroup -Location "canadacentral"

    #Replace with real values
    $gitHubSecretIdentifier = "https://dummyVault/dummy/00000000"
    $keyVaultName = "amlim-kv"
    $gitHubUri = "https://github.com/fake/fake.git"
    $userObjectId = "c3c951b7-d307-4c40-9495-70bd562d98d5"

    $env.Add("resourceGroup", $resourceGroup)
    $env.Add("userObjectId", $userObjectId)
    $env.Add("managedIdentityName", $managedIdentityName)
    $env.Add("devCenterName", $devCenterName)
    $env.Add("projectName", $projectName)
    $env.Add("projectName2", $projectName2)
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
    $env.Add("osStorageType", $osStorageType)
    $env.Add("skuName", $skuName)
    $env.Add("imageReferenceId", $imageReferenceId)
    $env.Add("environmentTypeName", $environmentTypeName)
    $env.Add("imageName", $imageName)
    $env.Add("imageVersion", $imageVersion)
    $env.Add("devCenterId", $devCenterId)
    $env.Add("poolName", $poolName)
    $env.Add("poolName2", $poolName2)
    $env.Add("time", $time)
    $env.Add("timeZone", $timeZone)
    $env.Add("subnetId", $subnetId)

    $devboxTemplate = Get-Content .\test\deploymentTemplates\parameter.json | ConvertFrom-Json
    $devboxTemplate.parameters.managedIdentityName.value = $managedIdentityName
    $devboxTemplate.parameters.subscriptionId.value = $env.SubscriptionId
    $devboxTemplate.parameters.resourceGroup.value = $resourceGroup
    $devboxTemplate.parameters.devCenterName.value = $devCenterName
    $devboxTemplate.parameters.projectName.value = $projectName
    $devboxTemplate.parameters.projectName2.value = $projectName2
    $devboxTemplate.parameters.location.value = $location
    $devboxTemplate.parameters.subnetId.value = $subnetId
    $devboxTemplate.parameters.keyVaultSecret.value = $gitHubSecretIdentifier
    $devboxTemplate.parameters.networkConnectionName.value = $networkConnectionName
    $devboxTemplate.parameters.catalogName.value = $catalogName
    $devboxTemplate.parameters.gitHubRepo.value = $gitHubUri
    $devboxTemplate.parameters.attachedNetworkName.value = $attachedNetworkName
    $devboxTemplate.parameters.imageReferenceId.value = $imageReferenceId
    $devboxTemplate.parameters.skuName.value = $skuName
    $devboxTemplate.parameters.osStorageType.value = $osStorageType
    $devboxTemplate.parameters.keyVaultName.value = $keyVaultName
    $devboxTemplate.parameters.environmentTypeName.value = $environmentTypeName
    $devboxTemplate.parameters.poolName.value = $poolName
    $devboxTemplate.parameters.poolName2.value = $poolName2
    $devboxTemplate.parameters.devBoxDefinitionName.value = $devBoxDefinitionName
    $devboxTemplate.parameters.userObjectId.value = $userObjectId

    Set-Content -Path .\test\deploymentTemplates\parameter.json -Value (ConvertTo-Json $devboxTemplate)
    Write-Host -ForegroundColor Magenta "Starting deployment of dev box template"
    New-AzResourceGroupDeployment -TemplateFile .\test\deploymentTemplates\template.json -TemplateParameterFile .\test\deploymentTemplates\parameter.json -Name devboxTemplate -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Magenta "Deployed dev box template"

    $msi = Get-AzUserAssignedIdentity -Name $managedIdentityName -ResourceGroupName $resourceGroup
    $principalId = $msi.PrincipalId
    $devboxTemplate2 = Get-Content .\test\deploymentTemplates\parameter2.json | ConvertFrom-Json
    $devboxTemplate2.parameters.managedIdentityPrincipalId.value = $principalId
    Set-Content -Path .\test\deploymentTemplates\parameter2.json -Value (ConvertTo-Json $devboxTemplate2)

    Write-Host -ForegroundColor Magenta "Starting deployment of dev box template2"
    Az.Resources\New-AzDeployment -Location $location -TemplateFile .\test\deploymentTemplates\template2.json -TemplateParameterFile .\test\deploymentTemplates\parameter2.json -Name devboxTemplate2
    Write-Host -ForegroundColor Magenta "Deployed dev box template2"

    #use Az Resource Graph instead
    $endpoint = GetEndpoint -project $projectName -resourceGroup $resourceGroup
    $env.Add("endpoint", $endpoint)

    Connect-AzAccount -Tenant $env.Tenant -AccountId "amlim@fidalgosh010.onmicrosoft.com"
    Write-Host -ForegroundColor Magenta "Switched to non-guest account"

    $devboxName = RandomString -allChars $false -len 6
    $devboxName2 = RandomString -allChars $false -len 6
    $devboxName3 = RandomString -allChars $false -len 6
    $env.Add("devboxName", $devboxName)
    $env.Add("devboxName2", $devboxName2)
    $env.Add("devboxName3", $devboxName3)

    $envName = RandomString -allChars $false -len 6
    $envName2 = RandomString -allChars $false -len 6
    $envNameToDelete = RandomString -allChars $false -len 6
    $envNameToDelete2 = RandomString -allChars $false -len 6
    $envNameToDelete3 = RandomString -allChars $false -len 6
    $envNameToDelete4 = RandomString -allChars $false -len 6
    $env.Add("envName", $envName)
    $env.Add("envName2", $envName2)
    $env.Add("envNameToDelete", $envNameToDelete)
    $env.Add("envNameToDelete2", $envNameToDelete2)
    $env.Add("envNameToDelete3", $envNameToDelete3)
    $env.Add("envNameToDelete4", $envNameToDelete4)
    $sandbox = "Sandbox"
    $functionApp = "FunctionApp"
    $functionAppName1 = RandomString -allChars $false -len 6
    $functionAppParameters = @{"name" = $functionAppName1 }
    $env.Add("sandbox", $sandbox)
    $env.Add("functionApp", $functionApp)
    $env.Add("functionAppName1", $functionAppName1)
    $env.Add("functionAppParameters", $functionAppParameters)

    $functionAppName2 = RandomString -allChars $false -len 6
    $functionAppName3 = RandomString -allChars $false -len 6
    $functionAppName4 = RandomString -allChars $false -len 6
    $functionAppName5 = RandomString -allChars $false -len 6
    $functionAppName6 = RandomString -allChars $false -len 6
    $functionAppName7 = RandomString -allChars $false -len 6
    $functionAppName8 = RandomString -allChars $false -len 6
    $functionAppName9 = RandomString -allChars $false -len 6
    $functionAppName10 = RandomString -allChars $false -len 6
    $functionAppName11 = RandomString -allChars $false -len 6
    $functionAppName12 = RandomString -allChars $false -len 6
    $functionAppName13 = RandomString -allChars $false -len 6
    $env.Add("functionAppName2", $functionAppName2)
    $env.Add("functionAppName3", $functionAppName3)
    $env.Add("functionAppName4", $functionAppName4)
    $env.Add("functionAppName5", $functionAppName5)
    $env.Add("functionAppName6", $functionAppName6)
    $env.Add("functionAppName7", $functionAppName7)
    $env.Add("functionAppName8", $functionAppName8)
    $env.Add("functionAppName9", $functionAppName9)
    $env.Add("functionAppName10", $functionAppName10)
    $env.Add("functionAppName11", $functionAppName11)
    $env.Add("functionAppName12", $functionAppName12)
    $env.Add("functionAppName13", $functionAppName13)



    New-AzDevCenterUserEnvironment -Endpoint $endpoint -Name $envName -ProjectName $projectName -CatalogName $catalogName -EnvironmentDefinitionName $sandbox -EnvironmentType $environmentTypeName
    New-AzDevCenterUserEnvironment -Endpoint $endpoint -Name $envName2 -ProjectName $projectName -CatalogName $catalogName -EnvironmentDefinitionName $functionApp -EnvironmentType $environmentTypeName -Parameter $functionAppParameters
    New-AzDevCenterUserEnvironment -Endpoint $endpoint -Name $envNameToDelete -ProjectName $projectName -CatalogName $catalogName -EnvironmentDefinitionName $sandbox -EnvironmentType $environmentTypeName
    New-AzDevCenterUserEnvironment -Endpoint $endpoint -Name $envNameToDelete2 -ProjectName $projectName -CatalogName $catalogName -EnvironmentDefinitionName $sandbox -EnvironmentType $environmentTypeName
    New-AzDevCenterUserEnvironment -Endpoint $endpoint -Name $envNameToDelete3 -ProjectName $projectName -CatalogName $catalogName -EnvironmentDefinitionName $sandbox -EnvironmentType $environmentTypeName
    New-AzDevCenterUserEnvironment -Endpoint $endpoint -Name $envNameToDelete4 -ProjectName $projectName -CatalogName $catalogName -EnvironmentDefinitionName $sandbox -EnvironmentType $environmentTypeName

    New-AzDevCenterUserDevBox -Endpoint $endpoint -Name $devboxName -ProjectName $projectName -PoolName $poolName
    New-AzDevCenterUserDevBox -Endpoint $endpoint -Name $devboxName2 -ProjectName $projectName2 -PoolName $poolName2
    New-AzDevCenterUserDevBox -Endpoint $endpoint -Name $devboxName3 -ProjectName $projectName -PoolName $poolName

    $skipDevBox1 = RandomString -allChars $false -len 6
    $skipDevBox2 = RandomString -allChars $false -len 6
    $skipDevBox3 = RandomString -allChars $false -len 6
    $skipDevBox4 = RandomString -allChars $false -len 6
    $env.Add("skipDevBox1", $skipDevBox1)
    $env.Add("skipDevBox2", $skipDevBox2)
    $env.Add("skipDevBox3", $skipDevBox3)
    $env.Add("skipDevBox4", $skipDevBox4)


    New-AzDevCenterUserDevBox -Endpoint $endpoint -Name $skipDevBox1 -ProjectName $projectName -PoolName $poolName
    New-AzDevCenterUserDevBox -Endpoint $endpoint -Name $skipDevBox2 -ProjectName $projectName -PoolName $poolName
    New-AzDevCenterUserDevBox -Endpoint $endpoint -Name $skipDevBox3 -ProjectName $projectName -PoolName $poolName
    New-AzDevCenterUserDevBox -Endpoint $endpoint -Name $skipDevBox4 -ProjectName $projectName -PoolName $poolName



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
