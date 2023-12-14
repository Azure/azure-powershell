$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzCustomLocation.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzCustomLocation' {
    It 'Create' {
        {
            $config = New-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName1 -Location $env.location -ClusterExtensionId $env.ClusterExtensionId -HostResourceId $env.HostResourceId -DisplayName $env.clusterLocationName1 -Namespace azps2
            $config.Name | Should -Be $env.clusterLocationName1

            $config = New-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName2 -Location $env.location -ClusterExtensionId $env.ClusterExtensionId -HostResourceId $env.HostResourceId -DisplayName $env.clusterLocationName2 -Namespace azps3
            $config.Name | Should -Be $env.clusterLocationName2
        } | Should -Not -Throw
    }

    It 'List' {
        { 
            $config = Get-AzCustomLocation
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        { 
            $config = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName1
            $config.Name | Should -Be $env.clusterLocationName1
        } | Should -Not -Throw
    }

    It 'Get1' {
        {
            $config = Get-AzCustomLocationEnabledResourceType -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $config = Update-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName1 -ClusterExtensionId $env.ClusterExtensionId -HostResourceId $env.HostResourceId -DisplayName $env.clusterLocationName1 -Namespace azps2
            $config.Name | Should -Be $env.clusterLocationName1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName2
            $config = Update-AzCustomLocation -InputObject $config
            $config.Name | Should -Be $env.clusterLocationName2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName2 
            Remove-AzCustomLocation -InputObject $config
        } | Should -Not -Throw
    }
}
