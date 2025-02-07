if (($null -eq $TestName) -or ($TestName -contains 'Update-AzTrustedSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzTrustedSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzTrustedSigningAccount' {
    It 'UpdateExpanded' {
        $accountName = 'azpstestaccountupdate'
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'

        # update doesn't return the new account object
        Update-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -SkuName 'Premium' 
        $sut = Get-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName
        
        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $accountName
        $sut.Location | Should -Be $env.location
        $sut.SkuName | Should -Not -Be 'Basic'
        $sut.SkuName | Should -Be 'Premium'
    }
}
