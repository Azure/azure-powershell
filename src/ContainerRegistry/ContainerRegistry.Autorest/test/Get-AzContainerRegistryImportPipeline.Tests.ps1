if(($null -eq $TestName) -or ($TestName -contains 'Get-AzContainerRegistryImportPipeline'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzContainerRegistryImportPipeline.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzContainerRegistryImportPipeline' {
    It 'List'  {
        {Get-AzContainerRegistryImportPipeline -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup} | Should -Not -Throw
    }

    It 'Get' {
        {Get-AzContainerRegistryImportPipeline -name $env.rstr1 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup} | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
