if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFileShareSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFileShareSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFileShareSnapshot' {
    It 'List' {
        {
            $config = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01
            $config.Count | Should -BeGreaterOrEqual 0
        } | Should -Not -Throw
    }

    It 'GetViaIdentityFileShare' {
        {
            $fileShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01
            $config = Get-AzFileShareSnapshot -FileShareInputObject $fileShare
            $config.Count | Should -BeGreaterOrEqual 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $env.snapshotName01
            $config.Name | Should -Be $env.snapshotName01
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $snapshot = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                                 -ResourceName $env.fileShareName01 `
                                                 -Name $env.snapshotName01
            $config = Get-AzFileShareSnapshot -InputObject $snapshot
            $config.Name | Should -Be $env.snapshotName01
        } | Should -Not -Throw
    }
}
