if (($null -eq $TestName) -or ($TestName -contains 'New-AzTrustedSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzTrustedSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzTrustedSigningAccount' {
    It 'CreateExpanded-BasicSku' {
        $accountName = 'azpstestaccountbasic'
        
        $sut = New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        
        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $accountName
        $sut.Location | Should -Be $env.location
        $sut.SkuName | Should -Be 'Basic'
    }
    It 'CreateExpanded-PremiumSku' {
        $accountName = 'azpstestaccountpremium'

        $sut = New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Premium'

        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $accountName
        $sut.Location | Should -Be $env.location
        $sut.SkuName | Should -Be 'Premium'
    }
}
