### Example 1: Create a Container App.
```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp -Sku PerGB2018 -Location canadacentral -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"

$CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).CustomerId
$SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).PrimarySharedKey
New-AzContainerAppManagedEnv -EnvName azps-env -ResourceGroupName azps_test_group_app -Location canadacentral -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false
$EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app -EnvName azps-env).Id

New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
Get-ChildItem -Path cert:\LocalMachine\My
$mypwd = ConvertTo-SecureString -String "1234" -Force -AsPlainText
Get-ChildItem -Path cert:\localMachine\my\F61C9A8C53D0500F819463A66C5921AA09E1B787 | Export-PfxCertificate -FilePath C:\mypfx.pfx -Password $mypwd
New-AzContainerAppManagedEnvCert -EnvName azps-env -Name azps-env-cert -ResourceGroupName azps_test_group_app -Location canadacentral -InputFile "C:\mypfx.pfx" -Password $mypwd
$EnvCertId = (Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-env-cert).Id

$trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -RevisionName "testcontainerApp0-ab1234" -Weight 100
$iPSecurityRestrictionRule = New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"
$secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
$configuration = New-AzContainerAppConfigurationObject -IngressIPSecurityRestriction $iPSecurityRestrictionRule -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -IngressClientCertificateMode "accept" -CorPolicyAllowedOrigin "https://a.test.com","https://b.test.com" -CorPolicyAllowedMethod "GET","POST" -CorPolicyAllowedHeader "HEADER1","HEADER2" -CorPolicyExposeHeader "HEADER3","HEADER4" -CorPolicyMaxAge 1234 -CorPolicyAllowCredentials:$True -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $secretObject

$serviceBind = New-AzContainerAppServiceBindObject -Name "redisService" -ServiceId "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/containerApps/azps-containerapp-1"

$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
$probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
$temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
$temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","while true; do echo hello; sleep 10;done"

New-AzContainerApp -Name "azps-containerapp-1" -ResourceGroupName "azps_test_group_app" -Location "canadacentral" -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -TemplateServiceBind $serviceBind -EnvironmentId $EnvId -WorkloadProfileName "My-GP-01"
```

```output
Location       Name                ResourceGroupName
--------       ----                -----------------
Canada Central azps-containerapp-1 azps_test_group_app
```

Create a Container App.