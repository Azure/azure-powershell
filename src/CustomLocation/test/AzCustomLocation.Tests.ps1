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
            $config = New-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName -Location $env.location -ClusterExtensionId $env.ClusterExtensionId -HostResourceId $env.HostResourceId -DisplayName $env.clusterLocationName -Namespace arc
            $config.Type | Should -Be "Microsoft.ExtendedLocation/customLocations"
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
            $config.Type | Should -Be "Microsoft.ExtendedLocation/customLocations"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName
            $config.Name | Should -Be $env.clusterLocationName
        } | Should -Not -Throw
    }

    It 'Get1' {
        {
            $config = Get-AzCustomLocationEnabledResourceType -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName
            $config.Type | Should -Be "Microsoft.ExtendedLocation/customLocations/enabledResourceTypes"
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $config = New-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName -Location $env.location -ClusterExtensionId $env.ClusterExtensionId -HostResourceId $env.HostResourceId -DisplayName $env.clusterLocationName -Namespace arc
            $config.Name | Should -Be $env.clusterLocationName
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzCustomLocation -ResourceGroupName $env.resourceGroup -Name $env.clusterLocationName
        } | Should -Not -Throw
    }
}
