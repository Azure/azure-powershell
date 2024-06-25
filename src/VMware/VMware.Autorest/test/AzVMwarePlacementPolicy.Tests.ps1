$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwarePlacementPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwarePlacementPolicy' {
    It 'CreateExpanded' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -ClusterSize 3 -SkuName av20
            $config.Name | Should -Be "cluster1"
            
            $config = New-AzVMwareVMPlacementPolicyPropertyObject -AffinityType 'Affinity' -VMMember @{"abc"="123"}
            $config = New-AzVMwarePlacementPolicy -ClusterName $env.rstr1 -Name $env.policy1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Property $config
            $config.Name | Should -Be "policy1"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzVMwarePlacementPolicy -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwarePlacementPolicy -Name $env.policy1 -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Name | Should -Be "policy1"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzVMwarePlacementPolicy -ClusterName $env.rstr1 -Name $env.policy1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -State 'Enabled'
            $config.Name | Should -Be "policy1"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzVMwarePlacementPolicy -Name $env.policy1 -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config = Update-AzVMwarePlacementPolicy -InputObject $config -State 'Enabled'
            $config.Name | Should -Be "policy1"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzVMwarePlacementPolicy -Name $env.policy1 -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzVMwarePlacementPolicy -Name $env.policy1 -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            Remove-AzVMwarePlacementPolicy -InputObject $config
        } | Should -Not -Throw
    }
}
