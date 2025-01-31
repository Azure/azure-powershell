if (($null -eq $TestName) -or ($TestName -contains 'Update-AzTrustedSigningCodeSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzTrustedSigningCodeSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzTrustedSigningCodeSigningAccount' {
    It 'UpdateExpanded' {
        $accountName = 'azpstestaccountupdate'
        New-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'

        # update doesn't return the new account object
        Update-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -SkuName 'Premium' 
        $sut = Get-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName
        
        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $accountName
        $sut.Location | Should -Be $env.location
        $sut.SkuName | Should -Not -Be 'Basic'
        $sut.SkuName | Should -Be 'Premium'
    }
}
