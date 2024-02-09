if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSphereCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSphereCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSphereCatalog' {
    It 'Delete' {
        {
            Remove-AzSphereCatalog -Name $env.anotherCatalog -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            Get-AzSphereCatalog -Name $env.secondCatalog -ResourceGroupName $env.resourceGroup | Remove-AzSphereCatalog
        } | Should -Not -Throw
    }
}
