$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedKubernetes.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzConnectedKubernetes' {
    It 'CreateExpanded' -skip {
        {
            $config = New-AzConnectedKubernetes -ClusterName $env.clusterNameEUS1 -ResourceGroupName $env.resourceGroupEUS -Location $env.locationEUS
            $config.ProvisioningState | Should -Be 'Succeeded'

            # Clear helm azure-arc environment
            helm delete azure-arc -n azure-arc-release --no-hooks
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzConnectedKubernetes
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroupEUS
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzConnectedKubernetes -ResourceGroupName $env.resourceGroupEUS -Name $env.clusterNameEUS1 -Tag @{'key1'= 1; 'key2'= 2}
            $config.Tag.Count | Should -Be 2
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS1
            $config.Tag.Count | Should -Be 2
            $config.Name | Should -Be $env.clusterNameEUS1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroupEUS -Name $env.clusterNameEUS2
            $config = Update-AzConnectedKubernetes -InputObject $config -Tag @{'key1'= 1; 'key2'= 2; 'key3'= 3}
            $config.Tag.Count | Should -Be 3
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $config = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS2
            $config = Get-AzConnectedKubernetes -InputObject $config
            $config.Tag.Count | Should -Be 3
            $config.Name | Should -Be $env.clusterNameEUS2
        } | Should -Not -Throw
    }

    It 'ClusterUserCredential-AAD-True' {
        {
            $config = Get-AzConnectedKubernetesUserCredential -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS1 -AuthenticationMethod AAD -ClientProxy
            $config.Kubeconfig.Name | Should -Be "KubeConfig"
        } | Should -Not -Throw
    }

    It 'ClusterUserCredential-AAD-False' {
        {
            $config = Get-AzConnectedKubernetesUserCredential -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS1 -AuthenticationMethod AAD -ClientProxy:$false
            $config.Kubeconfig.Name | Should -Be "KubeConfig"
        } | Should -Not -Throw
    }

    It 'ClusterUserCredential-Token-True' {
        {
            $config = Get-AzConnectedKubernetesUserCredential -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS2 -AuthenticationMethod Token -ClientProxy
            $config.Kubeconfig.Name | Should -Be "KubeConfig"
        } | Should -Not -Throw
    }

    It 'ClusterUserCredential-Token-False' {
        {
            $config = Get-AzConnectedKubernetesUserCredential -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS2 -AuthenticationMethod Token -ClientProxy:$false
            $config.Kubeconfig.Name | Should -Be "KubeConfig"
        } | Should -Not -Throw
    }

    It 'CreateWorkloadIdentityExpanded' -skip {
        {
            $config = New-AzConnectedKubernetes -ClusterName $env.clusterNameEUS3 -ResourceGroupName $env.resourceGroupEUS -Location $env.locationEUS -OidcIssuerProfileEnabled -WorkloadIdentityEnabled
            $config.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'Delete' -skip {
        {
            Remove-AzConnectedKubernetes -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        {
            $config = Get-AzConnectedKubernetes -ResourceGroupName $env.resourceGroupEUS -ClusterName $env.clusterNameEUS2
            Remove-AzConnectedKubernetes -InputObject $config
        } | Should -Not -Throw
    }
}
