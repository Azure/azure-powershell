if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAttestationProvider'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAttestationProvider.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAttestationProvider' {
    It 'UpdateExpanded' {
        { Update-AzAttestationProvider -Name $env.providername -ResourceGroupName $env.rg -Tag @{"k1" = "v1"}} | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $provider = Get-AzAttestationProvider -Name $env.providername -ResourceGroupName $env.rg
            Update-AzAttestationProvider -InputObject $provider -Tag @{"k1" = "v1"}
        } | Should -Not -Throw
    }
}
