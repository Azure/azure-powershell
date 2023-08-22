if(($null -eq $TestName) -or ($TestName -contains 'Add-AzKeyVaultManagedHsmRegion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzKeyVaultManagedHsmRegion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzKeyVaultManagedHsmRegion' {
    It '__AllParameterSets' {
        $regions = Add-AzKeyVaultManagedHsmRegion -HsmName $env.hsmName -ResourceGroupName $env.rgName -Region uksouth
        $regions.Name -contains "uksouth" | Should -Be $true
    }
}
