if(($null -eq $TestName) -or ($TestName -contains 'New-AzDatabricksAccessConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDatabricksAccessConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDatabricksAccessConnector' {
    It 'CreateExpanded' {
        { New-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorname01 -Location eastus } | Should -Not -Throw
    }
}
