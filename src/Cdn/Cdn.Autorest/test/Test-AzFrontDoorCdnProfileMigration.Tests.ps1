if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnProfileMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnProfileMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnProfileMigration' -Tag 'LiveOnly' {
    # Covers: Test-AzFrontDoorCdnProfileMigration, Start-AzFrontDoorCdnProfilePrepareMigration,
    #         Enable-AzFrontDoorCdnProfileMigration, Stop-AzFrontDoorCdnProfileMigration,
    #         Invoke-AzCdnAbortProfileToAFDMigration, Invoke-AzCdnCommitProfileToAFDMigration,
    #         Move-AzCdnProfileToAFD, Test-AzCdnProfileMigrationCompatibility
    It 'CanExpanded' {
        $subId = $env.SubscriptionId

        # Create classic FrontDoor resources for migration tests
        Import-Module -Name Az.FrontDoor

        $classicFDName = 'fdp-mig-' + (Get-Random -Minimum 1000 -Maximum 9999)
        Write-Host -ForegroundColor Green "Create classic FrontDoor: $classicFDName"
        $hostName = "$classicFDName.azurefd.net"
        $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $classicFDName -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
        $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net"
        $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
        $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1"
        $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
        $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $classicFDName -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
        $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
        New-AzFrontDoor -Name $classicFDName -ResourceGroupName $env.ResourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 | Out-Null
        $classicResourceId = "/subscriptions/$subId/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.Network/Frontdoors/$classicFDName"

        # Test - CanMigrate
        Write-Host -ForegroundColor Green "Test-AzFrontDoorCdnProfileMigration: CanMigrate"
        $canMigrate = Test-AzFrontDoorCdnProfileMigration -SubscriptionId $subId -ResourceGroupName $env.ResourceGroupName -ClassicResourceReferenceId $classicResourceId
        $canMigrate.CanMigrate | Should -Be $true

        # Start migration
        Write-Host -ForegroundColor Green "Start-AzFrontDoorCdnProfilePrepareMigration"
        $migratedProfileName = 'migrated-' + (Get-Random -Minimum 1000 -Maximum 9999)
        $migrateResult = Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName $env.ResourceGroupName -ClassicResourceReferenceId $classicResourceId -ProfileName $migratedProfileName -SkuName "Standard_AzureFrontDoor"
        $migrateResult.PropertiesMigratedProfileResourceIdId | Should -Not -BeNullOrEmpty

        # Commit migration
        Write-Host -ForegroundColor Green "Enable-AzFrontDoorCdnProfileMigration (commit)"
        Enable-AzFrontDoorCdnProfileMigration -ProfileName $migratedProfileName -ResourceGroupName $env.ResourceGroupName

        # Cleanup migrated profile
        Write-Host -ForegroundColor Green "Remove migrated profile: $migratedProfileName"
        Remove-AzFrontDoorCdnProfile -Name $migratedProfileName -ResourceGroupName $env.ResourceGroupName
    }
}
