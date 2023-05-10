if(($null -eq $TestName) -or ($TestName -contains 'Set-AzAdvisorConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzAdvisorConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzAdvisorConfiguration' {
    It 'CreateByLCT' {
        $Advisor = Set-AzAdvisorConfiguration -LowCpuThreshold 15
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }

    It 'CreateByRG' {
        $Advisor = Set-AzAdvisorConfiguration -ResourceGroupName $env.resourceGroup
        $Advisor.Count | Should -BeGreaterOrEqual 1
    }

    It 'CreateByInputObject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
