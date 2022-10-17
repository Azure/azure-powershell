if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDatabricksAccessConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDatabricksAccessConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDatabricksAccessConnector' {
    It 'Delete' {
        { 
            Remove-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorname01 
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $obj = New-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorname01 -Location eastus
            Remove-AzDatabricksAccessConnector -InputObject $obj
        } | Should -Not -Throw
    }
}
