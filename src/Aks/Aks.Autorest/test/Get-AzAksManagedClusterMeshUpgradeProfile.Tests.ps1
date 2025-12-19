if (($null -eq $TestName) -or ($TestName -contains 'Get-AzAksManagedClusterMeshUpgradeProfile')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksManagedClusterMeshUpgradeProfile.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksManagedClusterMeshUpgradeProfile' {
    It 'List' {
        $profile = Get-AzAksManagedClusterMeshUpgradeProfile -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName
        $profile.Count | Should -Be 1
        $profile.Revision | Should -Be 'asm-1-25'
        $profile.Upgrade.Count | Should -Be 2
        $profile.Upgrade | Should -Contain 'asm-1-26'    
        $profile.Upgrade | Should -Contain 'asm-1-26' 
    }

    It 'GetViaIdentityManagedCluster' {
        $aks = @{Id="/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)"}
        $profile = Get-AzAksManagedClusterMeshUpgradeProfile -ManagedClusterInputObject $aks -Mode asm-1-25
        $profile.Revision | Should -Be 'asm-1-25'
        $profile.Upgrade.Count | Should -Be 2
        $profile.Upgrade | Should -Contain 'asm-1-26'    
        $profile.Upgrade | Should -Contain 'asm-1-26' 
    }

    It 'Get' {
        $profile = Get-AzAksManagedClusterMeshUpgradeProfile -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Mode asm-1-25
        $profile.Count | Should -Be 1
        $profile.Revision | Should -Be 'asm-1-25'
        $profile.Upgrade.Count | Should -Be 2
        $profile.Upgrade | Should -Contain 'asm-1-26'    
        $profile.Upgrade | Should -Contain 'asm-1-26' 
    }

    It 'GetViaIdentity' {
        $profile = @{Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)/meshUpgradeProfiles/asm-1-25"}
        $profile = $profile | Get-AzAksManagedClusterMeshUpgradeProfile
        $profile.Count | Should -Be 1
        $profile.Revision | Should -Be 'asm-1-25'
        $profile.Upgrade.Count | Should -Be 2
        $profile.Upgrade | Should -Contain 'asm-1-26'    
        $profile.Upgrade | Should -Contain 'asm-1-26' 
    }
}
