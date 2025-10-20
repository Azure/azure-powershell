if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorLoadBalancingSettingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorLoadBalancingSettingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorLoadBalancingSettingObject' {
    It '__AllParameterSets' -skip {
        $loadBalancingSetting1 = New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1"
        $loadBalancingSetting1.Name | Should -Be "loadbalancingsetting1"
        $loadBalancingSetting1.SampleSize | Should -Be 4
        $loadBalancingSetting1.SuccessfulSamplesRequired | Should -Be 2
        $loadBalancingSetting1.AdditionalLatencyInMilliseconds | Should -Be 0
    }
}
