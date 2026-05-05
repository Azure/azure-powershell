if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorFrontendEndpointObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorFrontendEndpointObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorFrontendEndpointObject' {
    It '__AllParameterSets' -skip {
        $FDName = $env.FrontDoorName
        $hostName = "$FDName.azurefd.net"

        $frontendEndpoint1 = New-AzFrontDoorFrontendEndpointObject -Name "frontendendpoint1" -HostName $hostName
        $frontendEndpoint1.Name | Should -Be "frontendendpoint1"
        $frontendEndpoint1.HostName | Should -Be $hostName
        $frontendEndpoint1.SessionAffinityEnabledState | Should -Be "Enabled"
        $frontendEndpoint1.SessionAffinityTtlInSeconds | Should -Be 0
    }
}
