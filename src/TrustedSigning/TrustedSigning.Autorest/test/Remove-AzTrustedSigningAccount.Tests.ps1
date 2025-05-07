if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzTrustedSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTrustedSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzTrustedSigningAccount' {
    It 'Delete' {
        $accountName = 'azpstestaccountdelete'
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        { Get-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName } | Should -Not -Throw

        Remove-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName

        { Get-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName } | Should -Throw "ResourceNotFound"
    }
}
