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
    BeforeAll {
        $subId = "27cafca8-b9a4-4264-b399-45d0c9cca1ab"
        $ResourceGroupName = 'testps-rg-' + (RandomString -allChars $false -len 6)
        Write-Host -ForegroundColor Green "Create test group $($ResourceGroupName)"
        New-AzResourceGroup -Name $ResourceGroupName -Location $env.location -SubscriptionId $subId

        $Name = 'fdp-' + (RandomString -allChars $false -len 6);
        Write-Host -ForegroundColor Green "Use frontDoorName : $($Name)"

        $tags = @{"tag1" = "value1"; "tag2" = "value2"}
        $hostName = "$Name.azurefd.net"
        $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
        $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
        $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
        $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
        $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
        $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
        $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
        
        New-AzFrontDoor -Name $Name -ResourceGroupName $resourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
        $classicResourceReferenceId = "/subscriptions/$subId/resourcegroups/$ResourceGroupName/providers/Microsoft.Network/Frontdoors/$Name"

        $profileSku = "Standard_AzureFrontDoor"
        $migratedProfileName = 'migrated-test'

        Install-Module -Name Az.FrontDoor
        Install-Module -Name Az.KeyVault

        Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName $ResourceGroupName -ClassicResourceReferenceId $classicResourceReferenceId -ProfileName $migratedProfileName -SkuName $profileSku 
    }

    It 'Commit' {
        try
        {
            Enable-AzFrontDoorCdnProfileMigration -ProfileName  $migratedProfileName -ResourceGroupName $ResourceGroupName
        } Finally
        {
            Remove-AzResourceGroup -Name $ResourceGroupName -NoWait
        }
    }
}