if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringReceivedRoute'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringReceivedRoute.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringReceivedRoute' {
    It 'List' {
        {
            $routes = Get-AzPeeringReceivedRoute -PeeringName DemoPeering -ResourceGroupName DemoRG
            $routes.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
