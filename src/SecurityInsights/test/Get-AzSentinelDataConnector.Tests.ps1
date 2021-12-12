if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelDataConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelDataConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelDataConnector' {
    It 'List' {
        $dataConnectors = Get-AzSentineldataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $dataConnectors.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $dataConnector = Get-AzSentineldataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.dataConnectorId
        $dataConnector.Name | Should -Be $env.dataConnectorId
    }

    It 'GetViaIdentity'  {
        $dataConnector = Get-AzSentineldataConnector -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.dataConnectorId
        $dataConnectorViaIdentity = Get-AzSentineldataConnector -InputObject $dataConnector
        $dataConnectorViaIdentity.Name | Should -Be $env.dataConnectorId
    }
}
