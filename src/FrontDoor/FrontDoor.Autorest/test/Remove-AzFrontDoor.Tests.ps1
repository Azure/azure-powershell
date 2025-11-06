if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFrontDoor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFrontDoor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFrontDoor' {
    It 'Delete'  {
        {
            $frontDoorName = $env.FrontDoorNameForDelete
            $tags = @{"tag1" = "value1"; "tag2" = "value2"}
            $hostName = "$frontDoorName.azurefd.net"
            $routingrule1 = New-AzFrontDoorRoutingRuleObject -Name "routingrule2" -FrontDoorName $frontDoorName -ResourceGroupName $env.ResourceGroupName -FrontendEndpointName "frontendEndpoint2" -BackendPoolName "backendPool2"
            $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
            $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting2" -HealthProbeMethod "Head" -EnabledState "Disabled"
            $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting2" 
            $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint2" -HostName $hostName
            $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool2" -FrontDoorName $frontDoorName -ResourceGroupName $env.ResourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting2" -LoadBalancingSettingsName "loadBalancingSetting2"
            $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33 -EnforceCertificateNameCheck "Enabled"
            New-AzFrontDoor -Name $frontDoorName -ResourceGroupName $env.ResourceGroupName -RoutingRule $routingrule1 -BackendPool $backendpool1 -BackendPoolsSetting $backendPoolsSetting1 -FrontendEndpoint $frontendEndpoint1 -LoadBalancingSetting $loadBalancingSetting1 -HealthProbeSetting $healthProbeSetting1 -Tag $tags
            Start-Sleep 20
            Remove-AzFrontDoor -Name $frontDoorName -ResourceGroupName $env.ResourceGroupName -PassThru
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
