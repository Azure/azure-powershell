if (($null -eq $TestName) -or ($TestName -contains 'New-AzTrustedSigningCodeSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzTrustedSigningCodeSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzTrustedSigningCodeSigningAccount' {
    It 'CreateExpanded-BasicSku' {
        $accountName = 'azpstestaccountbasic'
        
        $sut = New-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        
        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $accountName
        $sut.Location | Should -Be $env.location
        $sut.SkuName | Should -Be 'Basic'
    }
    It 'CreateExpanded-PremiumSku' {
        $accountName = 'azpstestaccountpremium'

        $sut = New-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Premium'

        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $accountName
        $sut.Location | Should -Be $env.location
        $sut.SkuName | Should -Be 'Premium'
    }
}
