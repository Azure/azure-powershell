if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetworkSite'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetworkSite.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetworkSite' {
    It 'CreateExpanded' {
        {
            $config = New-AzMobileNetworkSite -MobileNetworkName $env.testNetwork2 -Name $env.testSite -ResourceGroupName $env.resourceGroup -Location $env.location -Tag @{"site"="123"}
            $config.Name | Should -Be $env.testSite
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -Name $env.testSite
            $config.Name | Should -Be $env.testSite
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -SiteName $env.testSite -Tag @{"site"="123"}
            $config.Name | Should -Be $env.testSite
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -Name $env.testSite
            $config = Update-AzMobileNetworkSite -InputObject $config -Tag @{"site"="123"}
            $config.Name | Should -Be $env.testSite
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetworkSite -ResourceGroupName $env.resourceGroup -MobileNetworkName $env.testNetwork2 -Name $env.testSite
        } | Should -Not -Throw
    }
}
