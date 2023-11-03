if(($null -eq $TestName) -or ($TestName -contains 'AzDigitalTwinsPrivateLinkResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDigitalTwinsPrivateLinkResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDigitalTwinsPrivateLinkResource' {
    It 'List' {
        {
            $config = Get-AzDigitalTwinsPrivateLinkResource -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDigitalTwinsPrivateLinkResource -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT -ResourceId API
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
