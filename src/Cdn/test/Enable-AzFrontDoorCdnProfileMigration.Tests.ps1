if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzFrontDoorCdnProfileMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzFrontDoorCdnProfileMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzFrontDoorCdnProfileMigration'  {
    It 'Commit' {
        Install-Module -Name Az.FrontDoor
        Install-Module -Name Az.KeyVault
        
        $subId = $env.SubscriptionId
        $Name = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorName : $($Name)"

        $tags = @{"tag1" = "value1"; "tag2" = "value2"}
        $hostName = "$Name.azurefd.net"
        $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
        $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
        $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
        $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
        $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
        $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
        $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
        
        New-AzFrontDoor -Name $Name -ResourceGroupName $env.ResourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
        $classicResourceReferenceId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Network/Frontdoors/$Name"

        $profileSku = "Standard_AzureFrontDoor"
        $migratedProfileName = 'migrated-test'

        Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName $env.ResourceGroupName -ClassicResourceReferenceId $classicResourceReferenceId -ProfileName $migratedProfileName -SkuName $profileSku 
        Enable-AzFrontDoorCdnProfileMigration -ProfileName $migratedProfileName -ResourceGroupName $env.ResourceGroupName
    }
}