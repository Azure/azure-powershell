if (($null -eq $TestName) -or ($TestName -contains 'Get-AzSqlVM')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSqlVM.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSqlVM' {
    It 'List1' {
        $sqlVMs = Get-AzSqlVM

        $sqlVMs.Count | Should -Be 3
        $sqlVMs.Name.Contains($env.SqlVMName_HA1) | Should -Be $true
        $sqlVMs.Name.Contains($env.SqlVMName_HA2) | Should -Be $true
        $sqlVMs.Name.Contains($env.SqlVMName) | Should -Be $true
        $sqlVMs[0].SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs[0].SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs[0].SqlManagement | Should -Be 'Full'
        $sqlVMs[0].SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs[0].GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
        $sqlVMs[1].SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs[1].SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs[1].SqlManagement | Should -Be 'Full'
        $sqlVMs[1].SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs[1].GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
        $sqlVMs[2].SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs[2].SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs[2].SqlManagement | Should -Be 'Full'
        $sqlVMs[2].SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs[2].GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
    }

    It 'Get' {
        $sqlVMs = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMName_HA1

        $sqlVMs.Count | Should -Be 1
        $sqlVMs.Name | Should -Be $env.SqlVMName_HA1
        $sqlVMs.SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs.SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs.SqlManagement | Should -Be 'Full'
        $sqlVMs.SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs.GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
    }

    It 'List2' {
        $sqlVMs = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName

        $sqlVMs.Count | Should -Be 2
        $sqlVMs.Name.Contains($env.SqlVMName_HA1) | Should -Be $true
        $sqlVMs.Name.Contains($env.SqlVMName_HA2) | Should -Be $true
        $sqlVMs[0].SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs[0].SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs[0].SqlManagement | Should -Be 'Full'
        $sqlVMs[0].SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs[0].GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
        $sqlVMs[1].SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs[1].SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs[1].SqlManagement | Should -Be 'Full'
        $sqlVMs[1].SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs[1].GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
    }

    It 'List' {
        $sqlVMs = Get-AzSqlVM -ResourceGroupName $env.ResourceGroupName -GroupName $env.SqlVMGroupName

        $sqlVMs.Count | Should -Be 2
        $sqlVMs.Name.Contains($env.SqlVMName_HA1) | Should -Be $true
        $sqlVMs.Name.Contains($env.SqlVMName_HA2) | Should -Be $true
        $sqlVMs[0].SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs[0].SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs[0].SqlManagement | Should -Be 'Full'
        $sqlVMs[0].SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs[0].GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
        $sqlVMs[1].SqlImageOffer | Should -Be $env.SqlImageOffer
        $sqlVMs[1].SqlImageSku | Should -Be $env.SqlImageSku
        $sqlVMs[1].SqlManagement | Should -Be 'Full'
        $sqlVMs[1].SqlServerLicenseType | Should -Be 'PAYG'
        $sqlVMs[1].GroupResourceId.Split("/")[-1] | Should -Be $env.SqlVMGroupName
    }
}
