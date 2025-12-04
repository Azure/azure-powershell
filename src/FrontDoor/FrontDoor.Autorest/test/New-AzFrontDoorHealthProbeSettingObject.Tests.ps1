if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorHealthProbeSettingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorHealthProbeSettingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorHealthProbeSettingObject' {
    It '__AllParameterSets' -skip {
        $healthProbeSetting1 = New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1" 
        $healthProbeSetting1.Name | Should -Be "healthProbeSetting1"
        $healthProbeSetting1.EnabledState | Should -Be "Enabled"
        $healthProbeSetting1.HealthProbeMethod | Should -Be "HEAD"
        $healthProbeSetting1.IntervalInSeconds | Should -Be 30
        $healthProbeSetting1.Path | Should -Be "/"
        $healthProbeSetting1.Protocol | Should -Be "Http"
    }
}
