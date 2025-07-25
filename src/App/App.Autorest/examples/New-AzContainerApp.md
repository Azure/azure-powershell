### Example 1: Create a Container App for Managed Environment.
```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp -Sku PerGB2018 -Location eastus -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"

$CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).CustomerId
$SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).PrimarySharedKey
$workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"
New-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app -Location eastus -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false -WorkloadProfile $workloadProfile
$EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app -Name azps-env).Id

New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
Get-ChildItem -Path cert:\LocalMachine\My
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
Get-ChildItem -Path cert:\localMachine\my\F61C9A8C53D0500F819463A66C5921AA09E1B787 | Export-PfxCertificate -FilePath C:\mypfx.pfx -Password $mypwd
New-AzContainerAppManagedEnvCert -EnvName azps-env -Name azps-env-cert -ResourceGroupName azps_test_group_app -Location eastus -InputFile "C:\mypfx.pfx" -Password $mypwd

$trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
$iPSecurityRestrictionRule = New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"
$secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
$customDomain = New-AzContainerAppCustomDomainObject -Name "mycertweb.com" -BindingType Disabled

$configuration = New-AzContainerAppConfigurationObject -IngressCustomDomain $customDomain -IngressIPSecurityRestriction $iPSecurityRestrictionRule -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -IngressClientCertificateMode "accept" -CorPolicyAllowedOrigin "https://a.test.com","https://b.test.com" -CorPolicyAllowedMethod "GET","POST" -CorPolicyAllowedHeader "HEADER1","HEADER2" -CorPolicyExposeHeader "HEADER3","HEADER4" -CorPolicyMaxAge 1234 -CorPolicyAllowCredentials:$True -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $secretObject

$serviceBind = New-AzContainerAppServiceBindObject -Name "redisService" -ServiceId "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/containerApps/azps-containerapp-1"

$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
$probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
$temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
$temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"

New-AzContainerApp -Name "azps-containerapp-1" -ResourceGroupName "azps_test_group_app" -Location "eastus" -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -TemplateServiceBind $serviceBind -EnvironmentId $EnvId
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Create a Container App for Managed Environment.

### Example 2: Create a Container App for Connected Environment.
```powershell
# Here you need to provide the resource "CustomLocation", for more information on how to create a resource CustomLocation, please refer to the help file: https://learn.microsoft.com/en-us/azure/container-apps/azure-arc-enable-cluster?tabs=azure-powershell
New-AzContainerAppConnectedEnv -Name azps-connectedenv -ResourceGroupName azps_test_group_app -Location eastus -ExtendedLocationName "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.ExtendedLocation/customLocations/my-custom-location" -ExtendedLocationType CustomLocation
$EnvId = (Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv).Id

New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
Get-ChildItem -Path cert:\LocalMachine\My
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
Get-ChildItem -Path cert:\localMachine\my\F61C9A8C53D0500F819463A66C5921AA09E1B787 | Export-PfxCertificate -FilePath C:\mypfx.pfx -Password $mypwd
New-AzContainerAppConnectedEnvCert -Name azps-connectedenvcert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Location eastus -InputFile "C:\mypfx.pfx" -Password $mypwd

$trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
$secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
$configuration = New-AzContainerAppConfigurationObject -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -Secret $secretObject

$temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
$temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"

New-AzContainerApp -Name "azps-containerapp-2" -ResourceGroupName "azps_test_group_app" -Location "eastus" -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -EnvironmentId $EnvId -ExtendedLocationName "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.ExtendedLocation/customLocations/my-custom-location" -ExtendedLocationType CustomLocation
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-2 azps_test_group_app
```

Create a Container App for Connected Environment.