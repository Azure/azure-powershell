if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzKeyVaultManagedHsmRegion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKeyVaultManagedHsmRegion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzKeyVaultManagedHsmRegion' {
    It '__AllParameterSets' {
        $regions = Remove-AzKeyVaultManagedHsmRegion -Name $env.hsmName -ResourceGroupName $env.rg -Region eastus2
        $regions.Name -notcontains "eastus2" | Should -Be $true
    }
}
