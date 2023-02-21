if(($null -eq $TestName) -or ($TestName -contains 'AzResourceConnectorBridge'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzResourceConnectorBridge.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzResourceConnectorBridge' {
    It 'CreateExpanded' {
        {
            $config = New-AzResourceConnectorBridge -Name $env.resourceBridge1 -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'SystemAssigned' -Distro 'AKSEdge' -InfrastructureConfigProvider 'HCI' -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.resourceBridge1

            $config = New-AzResourceConnectorBridge -Name $env.resourceBridge2 -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'SystemAssigned' -Distro 'AKSEdge' -InfrastructureConfigProvider 'HCI' -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.resourceBridge2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzResourceConnectorBridge
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzResourceConnectorBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1
            $config.Name | Should -Be $env.resourceBridge1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzResourceConnectorBridge -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzResourceConnectorBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1 -Tag @{"111"="222";"aaa"="bbb"}
            $config.Name | Should -Be $env.resourceBridge1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzResourceConnectorBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge2
            $config = Update-AzResourceConnectorBridge -InputObject $config -Tag @{"111"="222";"aaa"="bbb"}
            $config.Name | Should -Be $env.resourceBridge2
        } | Should -Not -Throw
    }

    It 'ListKey' {
        {
            $config = Get-AzResourceConnectorBridgeKey -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetTelemetryConfig' {
        {
            $config = Get-AzResourceConnectorBridgeTelemetryConfig
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetUpgradeGraph' {
        {
            $config = Get-AzResourceConnectorBridgeUpgradeGraph -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1 -UpgradeGraph Stable
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzResourceConnectorBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzResourceConnectorBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge2
            Remove-AzResourceConnectorBridge -InputObject $config
        } | Should -Not -Throw
    }
}
