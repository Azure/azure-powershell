if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMLWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMLWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMLWorkspace' {
    It 'List1' {
        { Get-AzMLWorkspace } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-cli01 } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzMLWorkspace -ResourceGroupName ml-rg-test } | Should -Not -Throw
    }

    # It 'GetViaIdentity' -skip {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }
}
