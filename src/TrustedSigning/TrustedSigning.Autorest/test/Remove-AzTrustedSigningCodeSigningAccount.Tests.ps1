if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzTrustedSigningCodeSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTrustedSigningCodeSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzTrustedSigningCodeSigningAccount' {
    It 'Delete' {
        $accountName = 'azpstestaccountdelete'
        New-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        { Get-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName } | Should -Not -Throw

        Remove-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName

        { Get-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName } | Should -Throw "ResourceNotFound"
    }
}
