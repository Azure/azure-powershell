if(($null -eq $TestName) -or ($TestName -contains 'Set-AzFrontDoor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzFrontDoor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzFrontDoor' {
    It 'UpdateExpanded' {
        $FDName = $env.FrontDoorNameForUpdate
        $tags = @{"tag1" = "value1"; "tag2" = "value2"}
        $hostName = "$FDName.azurefd.net"
        $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule1" -FrontDoorName $FDName -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint1" -BackendPoolName "backendPool1"
        $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
        $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" -HealthProbeMethod "Head" -EnabledState "Disabled"
        $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1" 
        $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
        $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $FDName -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
        $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
        New-AzFrontDoor -Name $FDName -ResourceGroupName $env.ResourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
    
        $newTags = @{"tag1" = "value3"; "tag2" = "value4"}
        $healthProbeSetting1.HealthProbeMethod = "Get"
        $healthProbeSetting1.EnabledState = "Enabled"
        $backendPoolsSetting1.SendRecvTimeoutInSeconds = 20
        $updatedFrontDoor = Set-AzFrontDoor -Name $FDName -ResourceGroupName $env.ResourceGroupName -Tag $newTags -HealthProbeSetting $healthProbeSetting1 -BackendPoolsSetting $backendPoolsSetting1
        $updatedFrontDoor.Tag["tag1"] | Should -Be "value3"
        $updatedFrontDoor.Tag["tag2"] | Should -Be "value4"
        $updatedFrontDoor.HealthProbeSetting[0].HealthProbeMethod | Should -Be "Get"
        $updatedFrontDoor.HealthProbeSetting[0].EnabledState | Should -Be "Enabled"
        $updatedFrontDoor.BackendPoolsSetting[0].SendRecvTimeoutInSeconds | Should -Be 20
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
