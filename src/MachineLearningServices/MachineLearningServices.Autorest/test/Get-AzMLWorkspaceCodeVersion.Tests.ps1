if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspaceCodeVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspaceCodeVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspaceCodeVersion' {
    It 'Get' {
        { 
            Get-AzMLWorkspaceCodeVersion -ResourceGroupName $env.DataGroupName -WorkspaceName $env.computeworkspace -Name $env.codename -Version 1
        } | Should -Not -Throw
    }
}
