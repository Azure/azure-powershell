if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistryToken'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistryToken.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistryToken' {
    It 'List' {
        {Get-AzContainerRegistryToken -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup } | Should -Not -Throw
    }

    It 'Get' {
        {Get-AzContainerRegistryToken -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr4} | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
