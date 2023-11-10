if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminOperationStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminOperationStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminOperationStatus' {
    It 'Get' {
        $operationStatus = Get-AzDevCenterAdminOperationStatus -Location $env.location  -OperationId "7e9e1394-dad0-4414-8160-21c592e880ef*4699EE32265F9FA5BF00FA169E7D9CF51755378796E32F2D1A198E080CC84614"
        $operationStatus.Name | Should -Be "7e9e1394-dad0-4414-8160-21c592e880ef*4699EE32265F9FA5BF00FA169E7D9CF51755378796E32F2D1A198E080CC84614"
        $operationStatus.Status | Should -Be "Succeeded"
    }
}
