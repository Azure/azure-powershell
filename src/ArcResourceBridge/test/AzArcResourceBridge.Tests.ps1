if(($null -eq $TestName) -or ($TestName -contains 'AzArcResourceBridge'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzArcResourceBridge.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzArcResourceBridge' {
    It 'CreateExpanded' {
        {
            $config = New-AzArcResourceBridge -Name $env.resourceBridge1 -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'SystemAssigned' -Distro 'AKSEdge' -InfrastructureConfigProvider 'HCI' -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.resourceBridge1

            $config = New-AzArcResourceBridge -Name $env.resourceBridge2 -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'SystemAssigned' -Distro 'AKSEdge' -InfrastructureConfigProvider 'HCI' -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.resourceBridge2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzArcResourceBridge
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzArcResourceBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1
            $config.Name | Should -Be $env.resourceBridge1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzArcResourceBridge -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzArcResourceBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1 -Tag @{"111"="222";"aaa"="bbb"}
            $config.Name | Should -Be $env.resourceBridge1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzArcResourceBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge2
            $config = Update-AzArcResourceBridge -InputObject $config -Tag @{"111"="222";"aaa"="bbb"}
            $config.Name | Should -Be $env.resourceBridge2
        } | Should -Not -Throw
    }

    It 'ListKey' {
        {
            $config = Get-AzArcResourceBridgeCredential -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetTelemetryConfig' {
        {
            $config = Get-AzArcResourceBridgeTelemetryConfig
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetUpgradeGraph' {
        {
            $config = Get-AzArcResourceBridgeUpgradeGraph -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1 -UpgradeGraph Stable
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzArcResourceBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzArcResourceBridge -ResourceGroupName $env.resourceGroup -Name $env.resourceBridge2
            Remove-AzArcResourceBridge -InputObject $config
        } | Should -Not -Throw
    }
}
