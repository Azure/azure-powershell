if(($null -eq $TestName) -or ($TestName -contains 'Update-AzCloudHsm'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCloudHsm.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzCloudHsm' {
    It 'UpdateExpanded' {
        $cloudHsm = Update-AzCloudHsm -Name $env.cloudHsmName -ResourceGroupName $env.rgName -Tag @{ UseMockHfc = "true"; MockHfcDelayInMs = "1"; Department = "Accounting"}
        $cloudHsm.name.Contains($env.cloudHsmName) | Should -Be $true
        $cloudHsm.tag.Count | Should -Be 3    
        }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
