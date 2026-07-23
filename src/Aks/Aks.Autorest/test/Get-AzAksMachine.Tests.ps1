if (($null -eq $TestName) -or ($TestName -contains 'Get-AzAksMachine')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksMachine.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksMachine' {
    It 'List' {
        $machines = Get-AzAksMachine -AgentPoolName 'default' -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName
        $machines.Count | Should -Be 1
        $machines.Name.StartsWith('aks-default') | Should -Be $true
    }

    It 'GetViaIdentityManagedCluster' {
        $aks = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)" }
        $machine = Get-AzAksMachine -AgentPoolName 'default' -ManagedClusterInputObject $aks -Name 'aks-default-12988240-vmss000000'
        $machine.Name | Should -Be 'aks-default-12988240-vmss000000'
    }

    It 'Get' {
        $machine = Get-AzAksMachine -AgentPoolName 'default' -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Name 'aks-default-12988240-vmss000000'
        $machine.Name | Should -Be 'aks-default-12988240-vmss000000'
    }

    It 'GetViaIdentityAgentPool' {
        $pool = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/agentPools/default" }
        $machine = Get-AzAksMachine -AgentPoolInputObject $pool -Name 'aks-default-12988240-vmss000000'
        $machine.Name | Should -Be 'aks-default-12988240-vmss000000'
    }

    It 'GetViaIdentity' {
        $machine1 = @{Id = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/agentPools/default/machines/aks-default-12988240-vmss000000" }
        $machine = Get-AzAksMachine -InputObject $machine1
        $machine.Name | Should -Be 'aks-default-12988240-vmss000000'
    }
}
