if (($null -eq $TestName) -or ($TestName -contains 'Get-AzTrustedSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzTrustedSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzTrustedSigningAccount' {
    It 'Get' {
        $accountName = 'azpstestaccount'
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'

        $sut = Get-AzTrustedSigningAccount -AccountName $accountName -ResourceGroupName $env.rg
		
        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $accountName
        $sut.Location | Should -Be $env.location
    }

    It 'List' {
        $accountName1 = 'azpstestaccount1'
        $accountName2 = 'azpstestaccount2'
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName1 -Location $env.location -SkuName 'Basic'
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName2 -Location $env.location -SkuName 'Basic'

        $sut = Get-AzTrustedSigningAccount -ResourceGroupName $env.rg
		
        $sut | Should -Not -BeNullOrEmpty
        $sut.Count | Should -BeGreaterThan 1
        $sut.Name | Should -Contain $accountName1
        $sut.Name | Should -Contain $accountName2
    }
}
