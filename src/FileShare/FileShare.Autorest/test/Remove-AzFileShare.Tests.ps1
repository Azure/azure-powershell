if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzFileShare'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzFileShare.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzFileShare' {
    It 'Delete' {
        {
            Remove-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName03 -PassThru
            $config = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName03 -ErrorAction SilentlyContinue
            $config | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $fileShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName02
            Remove-AzFileShare -InputObject $fileShare -PassThru
            $config = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName02 -ErrorAction SilentlyContinue
            $config | Should -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
