if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerRegistryAgentPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerRegistryAgentPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzContainerRegistryAgentPool' {
    It 'CreateExpanded' {
        {New-AzContainerRegistryAgentPool -name  $env.rstr2 -RegistryName  $env.rstr1 -ResourceGroupName $env.ResourceGroup -Location 'eastus' -Count 1 -Tier S1 -os 'Linux'} | Should -Not -Throw
    }
}

