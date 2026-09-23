if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFileShareSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFileShareSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFileShareSnapshot' {
    It 'Delete' {
        {
            $snapshotName = "snapshot-todelete"
            New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                     -ResourceName $env.fileShareName01 `
                                     -Name $snapshotName `
                                     -Metadata @{"purpose" = "testing"; "environment" = "test"}
            Remove-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                        -ResourceName $env.fileShareName01 `
                                        -Name $snapshotName `
                                        -PassThru
            $config = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $snapshotName `
                                               -ErrorAction SilentlyContinue
            $config | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
