if (($null -eq $TestName) -or ($TestName -contains 'Update-AzSqlVM')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSqlVM.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSqlVM' {
    It 'UpdateExpanded' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location -SqlManagementType 'LightWeight'

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'LightWeight'
        $sqlVM.SqlServerLicenseType | Should -Be 'PAYG'

        $sqlVM = Update-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -SqlManagementType 'Full' -Sku 'Standard' -LicenseType 'AHUB' -Tag @{'IT' = '8888' }

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'Full'
        $sqlVM.SqlServerLicenseType | Should -Be 'AHUB'
        $sqlVM.tag.Count | Should -Be 1
        $sqlVM.tag["IT"] | Should -Be '8888'

        Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }

    It 'UpdateViaIdentityExpanded' {
        $sqlVM = New-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName -Location $env.Location -SqlManagementType 'LightWeight'

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'LightWeight'
        $sqlVM.SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVM.tag.Count | Should -Be 0

        $sqlVM = Update-AzSqlVM -InputObject $sqlVM -SqlManagementType 'Full' -Sku 'Standard' -LicenseType 'AHUB' -Tag @{'IT' = '8888' }

        $sqlVM.Name | Should -Be $env.SqlVMName
        $sqlVM.SqlImageOffer | Should -Be 'SQL2019-WS2019'
        $sqlVM.SqlImageSku | Should -Be 'Standard'
        $sqlVM.SqlManagement | Should -Be 'Full'
        $sqlVM.SqlServerLicenseType | Should -Be 'AHUB'
        $sqlVM.tag.Count | Should -Be 1
        $sqlVM.tag["IT"] | Should -Be '8888'

        Remove-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName
    }
}
