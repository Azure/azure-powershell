if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzActionGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzActionGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzActionGroup' {
    It 'Delete' {
        {
            Remove-AzActionGroup -Name $env.actiongroup1 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $ag = Get-AzActionGroup -Name $env.actiongroup3 -ResourceGroupName $env.resourceGroup
            Remove-AzActionGroup -InputObject $ag
        } | Should -Not -Throw
    }
}
