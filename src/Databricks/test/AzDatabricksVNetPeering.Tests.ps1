if (($null -eq $TestName) -or ($TestName -contains 'AzDatabricksVNetPeering')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzDatabricksVNetPeering.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDatabricksVNetPeering' {
    It 'CreateExpanded' -Skip {
        {
            $config = New-AzDatabricksVNetPeering -Name $env.vNetName1 -WorkspaceName $env.workSpaceName3 -ResourceGroupName $env.resourceGroup -RemoteVirtualNetworkId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.vNetName)"
            $config.Name | Should -Be $env.vNetName1
        } | Should -Not -Throw
    }

    It 'List' -Skip {
        {
            $config = Get-AzDatabricksVNetPeering -WorkspaceName $env.workSpaceName3 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' -Skip {
        {
            $config = Get-AzDatabricksVNetPeering -WorkspaceName $env.workSpaceName3 -ResourceGroupName $env.resourceGroup -Name $env.vNetName1
            $config.Name | Should -Be $env.vNetName1
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -Skip {
        { 
            $config = Update-AzDatabricksVNetPeering -WorkspaceName $env.workSpaceName3 -ResourceGroupName $env.resourceGroup -Name $env.vNetName1 -AllowForwardedTraffic $True
            $config.Name | Should -Be $env.vNetName1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -Skip {
        {
            $config = Get-AzDatabricksVNetPeering -WorkspaceName $env.workSpaceName3 -ResourceGroupName $env.resourceGroup -Name $env.vNetName1
            $config = Update-AzDatabricksVNetPeering -InputObject $config -AllowForwardedTraffic $True
            $config.Name | Should -Be $env.vNetName1
        } | Should -Not -Throw
    }

    It 'Delete' -Skip {
        { 
            Remove-AzDatabricksVNetPeering -WorkspaceName $env.workSpaceName3 -ResourceGroupName $env.resourceGroup -Name $env.vNetName1
        } | Should -Not -Throw
    }
}