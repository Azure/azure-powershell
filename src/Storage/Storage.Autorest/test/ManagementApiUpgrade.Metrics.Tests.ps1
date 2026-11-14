if (($null -eq $TestName) -or ($TestName -contains 'ManagementApiUpgrade.Metrics')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $script:TestRecordingFile = Join-Path $PSScriptRoot 'ManagementApiUpgrade.Metrics.Recording.json'
    $currentPath = $PSScriptRoot
    $mockingPath = $null
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Filter 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
        if (-not $mockingPath -and -not $currentPath) {
            throw 'Cannot find the Storage recording support module.'
        }
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ManagementApiUpgrade.Metrics' {
    It 'Creates, reads, updates, and removes the capacity metrics rule while preserving filters' {
        $scope = @{
            ResourceGroupName = Get-StorageManagementFixture ResourceGroupName
            AccountName = Get-StorageManagementFixture AccountName
            SubscriptionId = Get-StorageManagementFixture SubscriptionId
        }
        $filters = @(Get-StorageManagementFixture MetricsContainers)
        $existing = @(Get-AzStorageAdvancedPlatformMetricsRule @scope -ErrorAction Stop)
        if ($existing.Count -ne 0) {
            throw 'Use a dedicated fixture account without an existing advanced platform metrics rule.'
        }
        $created = $false
        try {
            $rule = New-AzStorageAdvancedPlatformMetricsRule @scope -Enabled `
                -RuleConfigFilterType ContainerListFilter -RuleConfigFilterValue $filters -ErrorAction Stop
            $created = $true
            $rule.Enabled | Should -Be $true
            $rule.RuleType | Should -Be 'ContainerLevelCapacityMetrics'
            $rule = Get-AzStorageAdvancedPlatformMetricsRule -InputObject @{ Id = $rule.Id } -ErrorAction Stop
            $rule.RuleConfigFilterType | Should -Be 'ContainerListFilter'
            ($rule.RuleConfigFilterValue -join ',') | Should -Be ($filters -join ',')
            @(Get-AzStorageAdvancedPlatformMetricsRule @scope -ErrorAction Stop).Count | Should -Be 1

            $rule = Update-AzStorageAdvancedPlatformMetricsRule @scope -Enabled:$false -Confirm:$false -ErrorAction Stop
            $rule.Enabled | Should -Be $false
            $rule.RuleConfigFilterType | Should -Be 'ContainerListFilter'
            ($rule.RuleConfigFilterValue -join ',') | Should -Be ($filters -join ',')
            $rule = Get-AzStorageAdvancedPlatformMetricsRule -InputObject @{ Id = $rule.Id } -ErrorAction Stop
            $rule.Enabled | Should -Be $false
        } finally {
            if ($created) {
                Remove-AzStorageAdvancedPlatformMetricsRule @scope -Confirm:$false -ErrorAction Stop
            }
        }
        @(Get-AzStorageAdvancedPlatformMetricsRule @scope -ErrorAction Stop).Count | Should -Be 0
    }
}
