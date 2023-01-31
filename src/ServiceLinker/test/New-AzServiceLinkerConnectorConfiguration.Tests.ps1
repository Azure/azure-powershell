if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerConnectorConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerConnectorConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerConnectorConfiguration' {
    It 'Generate' -skip {
        $configs = New-AzServiceLinkerConnectorConfiguration -ResourceGroupName $env.resourceGroup -Location $env.location -ConnectorName $env.preparedLinker
        $configs.Count | Should -BeGreaterOrEqual 1
    }
}
