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

    $tag1 = RandomString -allChars $false -len 4
    $tag2 = RandomString -allChars $false -len 4
    $tag3 = RandomString -allChars $false -len 4

    $workSpace = "workspace" + $tag1
    $env.Add("workSpace", $workSpace)

    $envName = "env" + $tag1
    $envName2 = "env" + $tag2
    $env.Add("envName", $envName)
    $env.Add("envName2", $envName2)

    $envCertName = "envcert" + $tag1
    $envCertName2 = "envcert" + $tag2
    $envCertName3 = "envcert" + $tag3
    $env.Add("envCertName", $envCertName)
    $env.Add("envCertName2", $envCertName2)
    $env.Add("envCertName3", $envCertName3)

    $containerAppName = "containerapp" + $tag1
    $containerAppName2 = "containerapp" + $tag2
    $containerAppName3 = "containerapp" + $tag3
    $env.Add("containerAppName", $containerAppName)
    $env.Add("containerAppName2", $containerAppName2)
    $env.Add("containerAppName3", $containerAppName3)

    $envDaprName = "envdapr" + $tag1
    $envDaprName2 = "envdapr" + $tag2
    $env.Add("envDaprName", $envDaprName)
    $env.Add("envDaprName2", $envDaprName2)

    $storageAccount = "storageaccount" + $tag1
    $env.Add("storageAccount", $storageAccount)

    $acrName = "acr" + $tag1
    $env.Add("acrName", $acrName)

    $resourceGroup = "testgroup" + $tag1
    $env.Add("location", "canadacentral")
    $env.Add("resourceGroup", $resourceGroup)
    New-AzResourceGroup -Name $env.resourceGroup -Location $env.location

    New-AzOperationalInsightsWorkspace -ResourceGroupName $env.resourceGroup -Name $env.workSpace -Sku PerGB2018 -Location $env.location -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $customId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $env.resourceGroup -Name $env.workSpace).CustomerId
    $sharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $env.resourceGroup -Name $env.workSpace).PrimarySharedKey
    New-AzContainerAppManagedEnv -EnvName $env.envName -ResourceGroupName $env.resourceGroup -Location $env.location -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $customId -LogAnalyticConfigurationSharedKey $sharedKey -VnetConfigurationInternal:$false

    New-SelfSignedCertificate -DnsName "www.fabrikam.com" -CertStoreLocation "cert:\LocalMachine\My"
    $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
    Get-ChildItem -Path cert:\localMachine\my\4FCA2F8CA8A95F87F7CDC7B69DA441C3E1A178FF | Export-PfxCertificate -FilePath "C:\mypfx.pfx" -Password $mypwd
    New-AzContainerAppManagedEnvCert -EnvName $env.envName -Name $env.envCertName -ResourceGroupName $env.resourceGroup -Location $env.location -InputFile "C:\mypfx.pfx" -Password $mypwd

    $certificateId = (Get-AzContainerAppManagedEnvCert -EnvName $env.EnvName -ResourceGroupName $env.resourceGroup -Name $env.envCertName).Id
    $customDomain = New-AzContainerAppCustomDomainObject -CertificateId $certificateId -Name "www.fabrikam.com" -BindingType SniEnabled
    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label production -LatestRevision:$True -Weight 100
    $secretObject = New-AzContainerAppSecretObject -Name "facebook-secret" -Value "facebook-password"
    $containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
    $probe = New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
    $image = New-AzContainerAppTemplateObject -Name $env.containerAppName -Image "mcr.microsoft.com/azuredocs/containerapps-helloworld:latest" -Probe $probe -ResourceCpu 2.0 -ResourceMemory 4.0Gi
    $envId = (Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroup -EnvName $env.envName).Id
    New-AzContainerApp -Name $env.containerAppName -ResourceGroupName $env.resourceGroup -Location $env.location -ConfigurationActiveRevisionsMode 'Single' -ManagedEnvironmentId $envId -IngressExternal -IngressTransport 'auto' -IngressTargetPort 80 -TemplateContainer $image -ConfigurationSecret $secretObject -IngressTraffic $trafficWeight -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080 -IngressCustomDomain $customDomain

    New-AzStorageAccount -ResourceGroupName $env.resourceGroup -AccountName $env.storageAccount -Location $env.location -SkuName Standard_GRS
    New-AzContainerRegistry -ResourceGroupName $env.resourceGroup -Name $env.acrName -Sku "Premium" -EnableAdminUser

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Remove-AzResourceGroup -Name $env.resourceGroup
}

