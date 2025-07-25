if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerRegistryToken'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerRegistryToken.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzContainerRegistryToken' {
    It 'CreateExpanded' {
        $map = Get-AzContainerRegistryScopeMap -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr1
        {New-AzContainerRegistryToken -RegistryName $env.rstr1 -ResourceGroupName  $env.resourceGroup -Name $env.rstr2 -ScopeMapId $map.Id} | Should -Not -Throw
    }
}
