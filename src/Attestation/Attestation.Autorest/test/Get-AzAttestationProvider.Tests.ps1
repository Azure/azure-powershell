if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAttestationProvider'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAttestationProvider.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAttestationProvider' {
    It 'List' {
        { Get-AzAttestationProvider } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzAttestationProvider -Name $env.providername1 -ResourceGroupName $env.rg } | Should -Not -Throw
    }

    It 'List1' {
        { Get-AzAttestationProvider -ResourceGroupName $env.rg } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
