if(($null -eq $TestName) -or ($TestName -contains 'New-AzPeeringService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPeeringService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPeeringService' {
    It 'CreateExpanded' {
        {
            $peeringService = New-AzPeeringService -Name TestPeeringService -ResourceGroupName DemoRG -Location "East US 2" -PeeringServiceLocation Georgia -PeeringServiceProvider MicrosoftEdge -ProviderPrimaryPeeringLocation Atlanta
            $peeringService.Name | Should -Be "TestPeeringService"
        } | Should -Not -Throw
    }
}
