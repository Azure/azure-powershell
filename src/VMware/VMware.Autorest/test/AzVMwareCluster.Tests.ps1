$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareCluster.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzVMwareCluster' {
    It 'List' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -ClusterSize 3 -SkuName av20
            $config.Name | Should -Be "cluster1"

            $config = Get-AzVMwareCluster -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    
    It 'Get' {
        {
            $config = Get-AzVMwareCluster -Name $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.SkuName | Should -Be "av20"
        } | Should -Not -Throw
    }

    It 'CreateExpanded' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 3 -SkuName av36
            $config.SkuName | Should -Be "av20"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = New-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 3 -SkuName av36
            $config.SkuName | Should -Be "av20"

            $config = Update-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2 -ClusterSize 4
            $config.SkuName | Should -Be "av20"

            Remove-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzVMwareCluster -Name $env.rstr2 -PrivateCloudName $env.privateCloudName2 -ResourceGroupName $env.resourceGroup2
        } | Should -Not -Throw
    }
}
