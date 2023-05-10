if(($null -eq $TestName) -or ($TestName -contains 'AzDigitalTwinsPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzDigitalTwinsPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDigitalTwinsPrivateEndpointConnection' {
    It 'CreateExpanded' {
        {
            $config = New-AzDigitalTwinsPrivateEndpointConnection -Name "ef697005-0df3-47aa-b704-c14d71ddabf3" -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT -PrivateLinkServiceConnectionStateStatus 'Approved' -PrivateLinkServiceConnectionStateDescription "Approved by johndoe@company.com."
            $config.Name | Should -Be "ef697005-0df3-47aa-b704-c14d71ddabf3"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT -Name "ef697005-0df3-47aa-b704-c14d71ddabf3"
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -ResourceName $env.testEvnDT -Name "ef697005-0df3-47aa-b704-c14d71ddabf3"
        } | Should -Not -Throw
    }
}
