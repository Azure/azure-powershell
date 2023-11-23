if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetworkDataNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetworkDataNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetworkDataNetwork' {
    It 'CreateExpanded' {
        {
            $config = New-AzMobileNetworkDataNetwork -MobileNetworkName $env.testNetwork3 -Name $env.testDataNetwork -ResourceGroupName $env.resourceGroup -Location $env.location
            $config.Name | Should -Be $env.testDataNetwork
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetworkDataNetwork -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetworkDataNetwork -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -Name $env.testDataNetwork
            $config.Name | Should -Be $env.testDataNetwork
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            $config = Update-AzMobileNetworkDataNetwork -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -DataNetworkName $env.testDataNetwork -Tag @{"abc"="`12"}
            $config.Name | Should -Be $env.testDataNetwork
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetworkDataNetwork -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -Name $env.testDataNetwork
        } | Should -Not -Throw
    }
}
