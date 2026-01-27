if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksManagedClusterKuberneteVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksManagedClusterKuberneteVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksManagedClusterKuberneteVersion' {
    It 'List' {
        $result = Get-AzAksManagedClusterKuberneteVersion -Location eastus
        $result.Count | Should -Be 7
        ($result | Where-Object IsDefault -eq $true).Version | Should -Be '1.32'
        ($result | Where-Object IsPreview -eq $true).Version | Should -Be '1.34'
    }
}
