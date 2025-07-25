if(($null -eq $TestName) -or ($TestName -contains 'Update-AzContainerRegistryScopeMap'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzContainerRegistryScopeMap.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzContainerRegistryScopeMap' {
    It 'UpdateExpanded' {
        {Update-AzContainerRegistryScopeMap  -Name $env.rstr1 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -Action "repositories/busybox/content/write"} | Should -Not -Throw

    }
    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
