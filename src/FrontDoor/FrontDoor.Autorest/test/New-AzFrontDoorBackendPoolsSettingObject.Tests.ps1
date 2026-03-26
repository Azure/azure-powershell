if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorBackendPoolsSettingObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorBackendPoolsSettingObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorBackendPoolsSettingObject' {
    It '__AllParameterSets' -skip {
        $backendPoolsSetting1 = New-AzFrontDoorBackendPoolsSettingObject -SendRecvTimeoutInSeconds 33
        $backendPoolsSetting1.SendRecvTimeoutInSeconds | Should -Be 33
        $backendPoolsSetting1.EnforceCertificateNameCheck | Should -Be "Enabled"
    }
}
