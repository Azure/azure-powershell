if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetworkSlice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetworkSlice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetworkSlice' {
    It 'CreateExpanded' {
        {
            $config = New-AzMobileNetworkSlice -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -SliceName $env.testSlice -Location $env.location -SnssaiSst 1 -SnssaiSd "1abcde"
            $config.Name | Should -Be $env.testSlice
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetworkSlice -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetworkSlice -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -SliceName $env.testSlice
            $config.Name | Should -Be $env.testSlice
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            $config = Update-AzMobileNetworkSlice -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -SliceName $env.testSlice -Tag @{"abc"="123"} -SnssaiSst 1
            $config.Name | Should -Be $env.testSlice
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetworkSlice -MobileNetworkName $env.testNetwork3 -ResourceGroupName $env.resourceGroup -SliceName $env.testSlice
        } | Should -Not -Throw
    }
}
