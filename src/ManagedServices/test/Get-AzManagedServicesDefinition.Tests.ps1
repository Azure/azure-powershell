if(($null -eq $TestName) -or ($TestName -contains 'Get-AzManagedServicesDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzManagedServicesDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzManagedServicesDefinition' {
    It 'List' -skip {
        $definitions = Get-AzManagedServicesDefinition | Format-List -Property Id, Name, Type, ProvisioningState
        $definitions.Count | Should -Be 2
    }

    It 'Get' -skip {
        $definition = Get-AzManagedServicesDefinition -Name $env.DefinitionId
        $definition.Name | Should -Be $env.DefinitionId
    }

    It 'GetViaIdentity' -skip {
        $definition = Get-AzManagedServicesDefinition -Name $env.DefinitionId
        $definition = Get-AzManagedServicesDefinition -InputObject $definition
        $definition.Name | Should -Be $env.DefinitionId
    }
}
