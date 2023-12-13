if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetworkSimGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetworkSimGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetworkSimGroup' {
    It 'CreateExpanded' {
        {
            $config = New-AzMobileNetworkSimGroup -Name $env.testSimGroup -ResourceGroupName $env.resourceGroup -Location $env.location -MobileNetworkId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.MobileNetwork/mobileNetworks/$($env.testNetwork2)"
            $config.Name | Should -Be $env.testSimGroup
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetworkSimGroup
            $config.Count | Should -BeGreaterThan 0
        }
         | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetworkSimGroup -ResourceGroupName $env.resourceGroup -Name $env.testSimGroup
            $config.Name | Should -Be $env.testSimGroup
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzMobileNetworkSimGroup -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            $config = Update-AzMobileNetworkSimGroup -SimGroupName $env.testSimGroup -ResourceGroupName $env.resourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.testSimGroup
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetworkSimGroup -ResourceGroupName $env.resourceGroup -Name $env.testSimGroup
        } | Should -Not -Throw
    }
}
