if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistryScopeMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistryScopeMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistryScopeMap' {
    It 'List' {
        {Get-AzContainerRegistryScopeMap -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup } | Should -Not -Throw
    }

    It 'Get'  {
        {Get-AzContainerRegistryScopeMap -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr1 } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
