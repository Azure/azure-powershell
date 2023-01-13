if(($null -eq $TestName) -or ($TestName -contains 'Restart-AzMLWorkspaceCompute'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzMLWorkspaceCompute.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restart-AzMLWorkspaceCompute' {
    It 'AmlCompute' -skip {
        { 
            throw [System.NotImplementedException] 
        } | Should -Not -Throw
    }

    It 'ComputeInstance' {
        { 
            Start-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name v-diya1
            Restart-AzMLWorkspaceCompute -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name v-diya1 
        } | Should -Not -Throw
    }

    It 'Kubernetes' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'VirtualMachine' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'HDInsight' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'DataFactory' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'Databricks' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'DataLakeAnalytics' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'SynapseSpark' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
