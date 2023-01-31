if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistryReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistryReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistryReplication' {
    It 'List' {
        { get-AzContainerRegistryReplication -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup  } | Should -Not -Throw
    }

    It 'Get' {
        { get-AzContainerRegistryReplication -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.replication } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
