if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDatabricksAccessConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDatabricksAccessConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDatabricksAccessConnector' {
    It 'UpdateExpanded' {
        { 
            Update-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorname01 -Tag @{'key'='value'}
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $obj = Get-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorname01
            Update-AzDatabricksAccessConnector -InputObject $obj -Tag @{'key'='value'} 
        } | Should -Not -Throw
    }
}
