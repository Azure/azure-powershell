if (($null -eq $TestName) -or ($TestName -contains 'ManagementApiUpgrade.NetworkSecurityPerimeter')) {
    . (Join-Path $PSScriptRoot 'loadEnv.ps1')
    $script:TestRecordingFile = Join-Path $PSScriptRoot 'ManagementApiUpgrade.NetworkSecurityPerimeter.Recording.json'
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

Describe 'ManagementApiUpgrade.NetworkSecurityPerimeter' {
    It 'Projects inbound service tags from the configured NSP profile' {
        $fixture = Get-StorageManagementFixture NetworkSecurityPerimeter
        $configurations = @(Get-AzStorageNetworkSecurityPerimeterConfiguration `
            -ResourceGroupName $fixture.ResourceGroupName -AccountName $fixture.AccountName `
            -SubscriptionId (Get-StorageManagementFixture SubscriptionId) -ErrorAction Stop)
        $rules = @($configurations.ProfileAccessRule | Where-Object Direction -EQ 'Inbound' | Where-Object { $_.ServiceTag.Count -gt 0 })
        $rules.Count | Should -BeGreaterThan 0
        foreach ($rule in $rules) {
            $rule.ServiceTag | Should -Not -BeNullOrEmpty
        }
    }
}
