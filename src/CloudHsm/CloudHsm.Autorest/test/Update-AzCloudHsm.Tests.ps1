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
        $cloudHsm = Update-AzCloudHsm -SubscriptionId $env.SubscriptionId -Name $env.cloudHsmName -ResourceGroupName $env.rgName -Tag @{ Department = "Accounting"; Purpose = "PSTest"}
        $cloudHsm.name | Should -Be $env.cloudHsmName
        $cloudHsm.tag.Count | Should -Be 2
        }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
