if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPeeringServicePrefix'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPeeringServicePrefix.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPeeringServicePrefix' {
    It 'List' {
        {
            $prefixes = Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG
            $prefixes.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $prefix = Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG -Name TestPrefix
            $prefix.Name | Should -Be "TestPrefix"
        } | Should -Not -Throw
    }
}
