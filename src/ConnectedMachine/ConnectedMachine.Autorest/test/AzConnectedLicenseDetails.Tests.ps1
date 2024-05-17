if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedLicenseDetails'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedLicenseDetails.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedLicenseDetails' {
    It '__AllParameterSets' {
        $all = @(AzConnectedLicenseDetails -State 'Activated' -Target 'Windows Server 2012' -Edition 'Datacenter' -Type 'pCore' -Processor 16)
        $all | Should -Not -BeNullOrEmpty
    }
}
