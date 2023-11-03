if(($null -eq $TestName) -or ($TestName -contains 'AzDigitalTwinsEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDigitalTwinsEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDigitalTwinsEndpoint' {
    It 'List' {
        {
            $config = Get-AzDigitalTwinsEndpoint -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDigitalTwinsEndpoint -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT -EndpointName $env.testEvnEH
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzDigitalTwinsEndpoint -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT -EndpointName $env.testEvnEG
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzDigitalTwinsEndpoint -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT -EndpointName $env.testEvnSB
            Remove-AzDigitalTwinsEndpoint -InputObject $config
        } | Should -Not -Throw
    }
}
