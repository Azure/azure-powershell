if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorBackendObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorBackendObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorBackendObject' {
    It '__AllParameterSets' -skip {
        $backend1 = New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net" 
        $backend1.Address | Should -Be "contoso1.azurewebsites.net"
        $backend1.BackendHostHeader | Should -Be "contoso1.azurewebsites.net"
        $backend1.EnabledState | Should -Be "Enabled"
        $backend1.HttpPort | Should -Be 80
        $backend1.HttpsPort | Should -Be 443
        $backend1.Priority | Should -Be 1
        $backend1.PrivateLinkAlias | Should -Be $null
        $backend1.PrivateLinkApprovalMessage | Should -Be $null
        $backend1.PrivateLinkLocation | Should -Be $null
        $backend1.PrivateLinkResourceId | Should -Be $null
        $backend1.Weight | Should -Be 50
    }
}
