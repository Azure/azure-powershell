if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzAttestationProvider'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzAttestationProvider.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzAttestationProvider' {
    It 'Delete' {
        { Remove-AzAttestationProvider -Name $env.providername1 -ResourceGroupName $env.rg -PassThru } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $provider = Get-AzAttestationProvider -Name $env.providername2 -ResourceGroupName $env.rg
            Remove-AzAttestationProvider -InputObject $provider -PassThru 
        } | Should -Not -Throw
    }
}
