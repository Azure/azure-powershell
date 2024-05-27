if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSpringBuildServiceAgentPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSpringBuildServiceAgentPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSpringBuildServiceAgentPool' {
    It 'Get' {
        {
            New-AzSpringBuildServiceAgentPool -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01 -PoolSizeName "S1"
            Get-AzSpringBuildServiceAgentPool -ResourceGroupName $env.resourceGroup -ServiceName $env.enterpriseSpringName01
        } | Should -Not -Throw
    } 
}
