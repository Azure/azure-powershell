if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerConfluentBootstrapServerObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerConfluentBootstrapServerObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerConfluentBootstrapServerObject' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'New' { 
        $target = New-AzServiceLinkerConfluentBootstrapServerObject -Endpoint $env.confluentEndpoint
        $target.Endpoint | Should -Be $env.confluentEndpoint
        $target.Type |  Should -Be "ConfluentBootstrapServer"
    }
}
