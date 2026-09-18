
if (($null -eq $TestName) -or ($TestName -contains 'AzKubernetesRuntimeLoadBalancer')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzKubernetesRuntimeLoadBalancer.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzKubernetesRuntimeLoadBalancer' {

    $resourceUri = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroup)/providers/Microsoft.Kubernetes/connectedClusters/$($env.ArcName)"
    $extensionName = "arcnetworking"

    It 'Enables Networking service' {
        if ($TestMode -eq 'playback') {
            return
        }

        $output = Enable-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId $resourceUri

        $output.Extension.Name | Should -Be $extensionName

        { Get-AzKubernetesExtension -ResourceGroupName $env.ResourceGroup -ClusterName $env.ArcName -ClusterType ConnectedClusters -Name $extensionName } | Should -Not -Throw

    }

    It "Creates, Gets and Deletes a load balancer" {

        $newLoadBalancerName = "test1"
        $address = "192.168.50.1/32"
        $advertiseMode = "ARP"
        Write-Host "Creating a load balancer"

        $output = New-AzKubernetesRuntimeLoadBalancer `
            -ArcConnectedClusterId $resourceUri `
            -Name $newLoadBalancerName `
            -Address $address `
            -AdvertiseMode $advertiseMode -Verbose

        $output.TypeProperty.Type | Should -Be $typeProperty.Type

        Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId $resourceUri -Name $newLoadBalancerName | ConvertTo-Json | Should -Be ($output | ConvertTo-Json)

        Remove-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId $resourceUri -Name $newLoadBalancerName

        { Get-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId $resourceUri -Name $newLoadBalancerName } | Should -Throw

    }

    It 'Disables networking service ' {

        if ($TestMode -eq 'playback') {
            return
        }

        Disable-AzKubernetesRuntimeLoadBalancer -ArcConnectedClusterId $resourceUri

        { Get-AzKubernetesExtension -ResourceGroupName $env.ResourceGroup -ClusterName $env.ArcName -ClusterType ConnectedClusters -Name $extensionName } | Should -Throw
    }
}