if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerRegistryScopeMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerRegistryScopeMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzContainerRegistryScopeMap' {
    It 'CreateExpanded' {
        { New-AzContainerRegistryScopeMap -Name $env.rstr2 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -Action "repositories/busybox/content/read" } | Should -Not -Throw
    }
}
