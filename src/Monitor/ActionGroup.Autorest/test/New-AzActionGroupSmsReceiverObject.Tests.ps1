if(($null -eq $TestName) -or ($TestName -contains 'New-AzActionGroupSmsReceiverObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzActionGroupSmsReceiverObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzActionGroupSmsReceiverObject' {
    It '__AllParameterSets' {
        {
            New-AzActionGroupSmsReceiverObject -CountryCode 86 -Name user1 -PhoneNumber '01234567890'
        } | Should -Not -Throw
    }
}
