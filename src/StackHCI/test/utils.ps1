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
$env | Add-Member -Name 'AddWithCache' -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } }
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $subscriptionId = (Get-AzContext).Subscription.Id
    $env.SubscriptionId = $subscriptionId
    $aadTenantId = (Get-AzContext).Tenant.Id
    $env.Tenant = $aadTenantId
    $resourceGroup = 'azurestackhci-pwsh-rg-' + (RandomString -allChars $false -len 2)
    New-AzResourceGroup -Name $resourceGroup -Location eastus
    Write-Host -ForegroundColor Green "Resource Group Created" $resourceGroup

    $aadClientId = [guid]::NewGuid()
    $resourceLocation = "eastus"
    $clusterName = "pwsh-Cluster" + (RandomString -allChars $false -len 4)
    $arcSettingName = "default"
    $extensionName = "MicrosoftMonitoringAgent"
    $extensionPublisher = "Microsoft.EnterpriseCloud.Monitoring"

    $env.Add("ResourceGroup", $resourceGroup)
    $env.Add("ClusterName", $clusterName)
    $env.Add("AadClientId", $aadClientId)
    $env.Add("AadTenantId", $aadTenantId)
    $env.Add("Location", $resourceLocation)
    $env.Add("ArcSettingName", $arcSettingName)
    $env.Add("ExtensionName", $extensionName)
    $env.Add("ExtensionPublisher", $extensionPublisher)

    $cluster = New-AzStackHciCluster -Name $clusterName -ResourceGroupName $resourceGroup -AadTenantId $aadTenantId -AadClientId $aadClientId -Location $resourceLocation
    Write-Host -ForegroundColor Green "Cluster Created" $cluster.Name

    $clusterremove = New-AzStackHciCluster -Name "$($clusterName)-remove" -ResourceGroupName $resourceGroup -AadTenantId $aadTenantId -AadClientId $aadClientId -Location $resourceLocation
    Write-Host -ForegroundColor Green "Cluster Created" $clusterremove.Name

    $clusterremove2 = New-AzStackHciCluster -Name "$($clusterName)-remove2" -ResourceGroupName $resourceGroup -AadTenantId $aadTenantId -AadClientId $aadClientId -Location $resourceLocation
    Write-Host -ForegroundColor Green "Cluster Created" $clusterremove2.Name

    $arcSetting = New-AzStackHciArcSetting -ResourceGroupName $resourceGroup -ClusterName $clusterName
    Write-Host -ForegroundColor Green "ArcSetting Created" $arcSetting.Name

    $arcSetting2 = New-AzStackHciArcSetting -ResourceGroupName $resourceGroup -ClusterName "$($clusterName)-remove2"
    Write-Host -ForegroundColor Green "ArcSetting Created" $arcSetting2.Name

    $extension = New-AzStackHciExtension -ArcSettingName $arcSetting.Name -ClusterName $cluster.Name -Name $extensionName -ResourceGroupName $resourceGroup -ExtensionParameterPublisher $extensionPublisher
    Write-Host -ForegroundColor Green "Extension Created" $extension.Name

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Write-Host -ForegroundColor Green "Cleaning up " $env.ResourceGroup
    Remove-AzResourceGroup -Name $env.ResourceGroup
}

