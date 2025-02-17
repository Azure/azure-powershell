function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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

    $containerApp1 = "a" + (RandomString -allChars $false -len 4)
    $containerApp2 = "a" + (RandomString -allChars $false -len 4)
    $containerApp3 = "a" + (RandomString -allChars $false -len 4)
    $env.Add("containerApp1", $containerApp1)
    $env.Add("containerApp2", $containerApp2)
    $env.Add("containerApp3", $containerApp3)

    $containerAppJob1 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("containerAppJob1", $containerAppJob1)

    $containerRegistry1 = "a" + (RandomString -allChars $false -len 5)
    $containerRegistry2 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("containerRegistry1", $containerRegistry1)
    $env.Add("containerRegistry2", $containerRegistry2)

    $storageAccount1 = "a" + (RandomString -allChars $false -len 5)
    $storageAccount2 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("storageAccount1", $storageAccount1)
    $env.Add("storageAccount2", $storageAccount2)

    $authConfig = "a" + (RandomString -allChars $false -len 5)
    $env.Add("authConfig", $authConfig)

    $connectedEnv1 = "a" + (RandomString -allChars $false -len 5)
    $connectedEnv2 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("connectedEnv1", $connectedEnv1)
    $env.Add("connectedEnv2", $connectedEnv2)

    $connectedEnvCert1 = "a" + (RandomString -allChars $false -len 5)
    $connectedEnvCert2 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("connectedEnvCert1", $connectedEnvCert1)
    $env.Add("connectedEnvCert2", $connectedEnvCert2)

    $connectedEnvDapr = "a" + (RandomString -allChars $false -len 5)
    $env.Add("connectedEnvDapr", $connectedEnvDapr)

    $connectedEnvStorage = "a" + (RandomString -allChars $false -len 5)
    $env.Add("connectedEnvStorage", $connectedEnvStorage)

    $managedCert1 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("managedCert1", $managedCert1)

    $managedEnv1 = "a" + (RandomString -allChars $false -len 5)
    $managedEnv2 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("managedEnv1", $managedEnv1)
    $env.Add("managedEnv2", $managedEnv2)

    $managedEnvCert1 = "a" + (RandomString -allChars $false -len 5)
    $managedEnvCert2 = "a" + (RandomString -allChars $false -len 5)
    $env.Add("managedEnvCert1", $managedEnvCert1)
    $env.Add("managedEnvCert2", $managedEnvCert2)

    $managedEnvDapr = "a" + (RandomString -allChars $false -len 5)
    $env.Add("managedEnvDapr", $managedEnvDapr)

    $managedEnvStorage = "a" + (RandomString -allChars $false -len 5)
    $env.Add("managedEnvStorage", $managedEnvStorage)

    $sourceControl = "a" + (RandomString -allChars $false -len 5)
    $env.Add("sourceControl", $sourceControl)

    $managedWorkSpace = "a" + (RandomString -allChars $false -len 5)
    $env.Add("managedWorkSpace", $managedWorkSpace)

    $location = "eastus"
    $env.Add("location", $location)

    $customLocation = "my-custom-location"
    $env.Add("customLocation", $customLocation)

    $resourceGroupManaged = "a" + (RandomString -allChars $false -len 6)
    $resourceGroupConnected = "azps_test_group_app" #"a" + (RandomString -allChars $false -len 6)
    $env.Add("resourceGroupManaged", $resourceGroupManaged)
    $env.Add("resourceGroupConnected", $resourceGroupConnected)

    write-host "Create ResourceGroup for managed env"
    New-AzResourceGroup -Name $env.resourceGroupManaged -Location $env.location

    write-host "Create storage account"
    New-AzStorageAccount -ResourceGroupName $env.resourceGroupManaged -AccountName $env.storageAccount1 -Location $env.location -SkuName Standard_GRS

    write-host "Create container registry"
    New-AzContainerRegistry -ResourceGroupName $env.resourceGroupManaged -Name $env.containerRegistry1 -Sku "Premium" -EnableAdminUser

    write-host "Create workspace"
    New-AzOperationalInsightsWorkspace -ResourceGroupName $env.resourceGroupManaged -Name $env.managedWorkSpace -Sku PerGB2018 -Location $env.location -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"
    $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $env.resourceGroupManaged -Name $env.managedWorkSpace).CustomerId
    $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $env.resourceGroupManaged -Name $env.managedWorkSpace).PrimarySharedKey
    $workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"

    write-host "Create managed env"
    New-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv1 -Location $env.location -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false -WorkloadProfile $workloadProfile
    $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv1).Id

    $selfSignedCert = New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
    Get-ChildItem -Path cert:\LocalMachine\My
    $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
    Get-ChildItem -Path cert:\localMachine\my\$($selfSignedCert.Thumbprint) | Export-PfxCertificate -FilePath ".\test\mypfx.pfx" -Password $mypwd

    write-host "Create managed env cert"
    New-AzContainerAppManagedEnvCert -EnvName $env.managedEnv1 -Name $env.managedEnvCert1 -ResourceGroupName $env.resourceGroupManaged -Location $env.location -InputFile ".\test\mypfx.pfx" -Password $mypwd

    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
    $iPSecurityRestrictionRule = New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"
    $secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
    $configuration = New-AzContainerAppConfigurationObject -IngressIPSecurityRestriction $iPSecurityRestrictionRule -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -IngressClientCertificateMode "accept" -CorPolicyAllowedOrigin "https://a.test.com","https://b.test.com" -CorPolicyAllowedMethod "GET","POST" -CorPolicyAllowedHeader "HEADER1","HEADER2" -CorPolicyExposeHeader "HEADER3","HEADER4" -CorPolicyMaxAge 1234 -CorPolicyAllowCredentials:$True -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $secretObject
    $serviceBind = New-AzContainerAppServiceBindObject -Name "redisService" -ServiceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroupManaged)/providers/Microsoft.App/containerApps/$($env.containerApp1)"

    $probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
    $probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
    $temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
    $temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"

    write-host "Create container app for managed env"
    New-AzContainerApp -ResourceGroupName $env.resourceGroupManaged -Name $env.containerApp1 -Location $env.location -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -TemplateServiceBind $serviceBind -EnvironmentId $EnvId

    write-host "Create ResourceGroup for connected env"
    New-AzResourceGroup -Name $env.resourceGroupConnected -Location $env.location

    write-host "Create storage account"
    New-AzStorageAccount -ResourceGroupName $env.resourceGroupConnected -AccountName $env.storageAccount2 -Location $env.location -SkuName Standard_GRS

    write-host "Create container registry"
    New-AzContainerRegistry -ResourceGroupName $env.resourceGroupConnected -Name $env.containerRegistry2 -Sku "Premium" -EnableAdminUser

    write-host "Here you need to provide the resource 'CustomLocation', for more information on how to create a resource CustomLocation, please refer to the help file: https://learn.microsoft.com/en-us/azure/container-apps/azure-arc-enable-cluster?tabs=azure-powershell"
    write-host "Create connected env"
    New-AzContainerAppConnectedEnv -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnv1 -Location $env.location -ExtendedLocationName "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroupConnected)/providers/Microsoft.ExtendedLocation/customLocations/$($env.customLocation)" -ExtendedLocationType CustomLocation
    $EnvId = (Get-AzContainerAppConnectedEnv -ResourceGroupName $env.resourceGroupConnected -Name $env.connectedEnv1).Id

    $selfSignedCert = New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
    Get-ChildItem -Path cert:\LocalMachine\My
    $mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
    Get-ChildItem -Path cert:\localMachine\my\$($selfSignedCert.Thumbprint) | Export-PfxCertificate -FilePath ".\test\mypfx.pfx" -Password $mypwd

    write-host "Create connected env cert"
    New-AzContainerAppConnectedEnvCert -Name $env.connectedEnvCert1 -ConnectedEnvironmentName $env.connectedEnv1 -ResourceGroupName $env.resourceGroupConnected -Location $env.location -InputFile ".\test\mypfx.pfx" -Password $mypwd

    $trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
    $configuration = New-AzContainerAppConfigurationObject -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80
    $temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
    $temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"

    write-host "Create container app for connected env"
    New-AzContainerApp -ResourceGroupName $env.resourceGroupConnected -Name $env.containerApp2 -Location $env.location -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -EnvironmentId $EnvId -ExtendedLocationName "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroupConnected)/providers/Microsoft.ExtendedLocation/customLocations/$($env.customLocation)" -ExtendedLocationType CustomLocation

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}

function cleanupEnv() {
    # Remove-AzResourceGroup -Name $env.resourceGroupManaged
    # Remove-AzResourceGroup -Name $env.resourceGroupConnected
}

