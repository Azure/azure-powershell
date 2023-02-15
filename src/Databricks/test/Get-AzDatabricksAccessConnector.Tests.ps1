if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDatabricksAccessConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDatabricksAccessConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDatabricksAccessConnector' {
    It 'List1' {
        { Get-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorname01 } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzDatabricksAccessConnector } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $obj = Get-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorname01
            Get-AzDatabricksAccessConnector -InputObject $obj 
        } | Should -Not -Throw
    }
}
