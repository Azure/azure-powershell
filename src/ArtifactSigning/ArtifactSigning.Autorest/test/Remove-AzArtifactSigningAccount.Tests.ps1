if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzArtifactSigningAccount')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzArtifactSigningAccount.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzArtifactSigningAccount' {
    It 'Delete' {
        $accountName = 'azpstestaccountdelete'
        New-AzArtifactSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        { Get-AzArtifactSigningAccount -ResourceGroupName $env.rg -AccountName $accountName } | Should -Not -Throw

        Remove-AzArtifactSigningAccount -ResourceGroupName $env.rg -AccountName $accountName

        { Get-AzArtifactSigningAccount -ResourceGroupName $env.rg -AccountName $accountName } | Should -Throw "ResourceNotFound"
    }
}
