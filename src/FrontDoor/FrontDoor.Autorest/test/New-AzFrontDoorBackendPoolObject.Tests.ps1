if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorBackendPoolObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorBackendPoolObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorBackendPoolObject' {
    It '__AllParameterSets' -skip {
        $FDName = $env.FrontDoorName
        $resourceGroupName = $env.ResourceGroupName
        $subId = $env.SubscriptionId

        $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
        
        $backendpool1 = New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $FDName -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
        $backendpool1.Name | Should -Be "backendpool1"
        $backendpool1.HealthProbeSettingId | Should -Be "/subscriptions/$subId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/frontDoors/$FDName/HealthProbeSettings/healthProbeSetting1"
        $backendpool1.LoadBalancingSettingId | Should -Be "/subscriptions/$subId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/frontDoors/$FDName/LoadBalancingSettings/loadBalancingSetting1"
    }
}
