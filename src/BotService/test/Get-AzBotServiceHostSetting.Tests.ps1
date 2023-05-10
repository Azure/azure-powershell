if(($null -eq $TestName) -or ($TestName -contains 'Get-AzBotServiceHostSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBotServiceHostSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzBotServiceHostSetting' {
    It 'Get' {
        $AzBotServiceHostSetting = Get-AzBotServiceHostSetting
        $AzBotServiceHostSetting -eq $null | Should -Be $False
    }

    It 'GetViaIdentity' -skip {
        #This variable is hidden.
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
