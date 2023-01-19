if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetwork' {
    It 'CreateExpanded' {
        {
            $config = New-AzMobileNetwork -Name $env.testNetwork1 -ResourceGroupName $env.resourceGroup -Location $env.location -PublicLandMobileNetworkIdentifierMcc 001 -PublicLandMobileNetworkIdentifierMnc 01
            $config.Name | Should -Be $env.testNetwork1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetwork
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetwork -ResourceGroupName $env.resourceGroup -Name $env.testNetwork1
            $config.Name | Should -Be $env.testNetwork1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzMobileNetwork -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzMobileNetwork -MobileNetworkName $env.testNetwork1 -ResourceGroupName $env.resourceGroup -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.testNetwork1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMobileNetwork -ResourceGroupName $env.resourceGroup -Name $env.testNetwork1
            $config = Update-AzMobileNetwork -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.testNetwork1
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetwork -ResourceGroupName $env.resourceGroup -Name $env.testNetwork1
        } | Should -Not -Throw
    }
}
