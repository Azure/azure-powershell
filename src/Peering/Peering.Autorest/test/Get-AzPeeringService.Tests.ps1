if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringService' {
    It 'List1' {
        {
            $allPeeringServices = Get-AzPeeringService
            $allPeeringServices.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $peeringService = Get-AzPeeringService -ResourceGroupName DemoRG -Name TestExtension
            $peeringService.Name | Should -Be "TestExtension"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $rgPeeringServices = Get-AzPeeringService -ResourceGroupName DemoRG
            $rgPeeringServices.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

}
