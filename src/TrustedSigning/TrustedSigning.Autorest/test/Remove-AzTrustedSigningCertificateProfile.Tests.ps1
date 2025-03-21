if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzTrustedSigningCertificateProfile')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTrustedSigningCertificateProfile.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzTrustedSigningCertificateProfile' {
    It 'Delete' {
        $accountName = $profileName = 'azpstestprofiledelete'
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        New-AzTrustedSigningCertificateProfile -AccountName $accountName -ResourceGroupName $env.rg -ProfileName $profileName `
            -IdentityValidationId $env.IdentityValidationId -ProfileType:PublicTrustTest
        { Get-AzTrustedSigningCertificateProfile -ResourceGroupName $env.rg -AccountName $accountName -ProfileName $profileName } | Should -Not -Throw

        Remove-AzTrustedSigningCertificateProfile -ResourceGroupName $env.rg -AccountName $accountName -ProfileName $profileName

        { Get-AzTrustedSigningCertificateProfile -ResourceGroupName $env.rg -AccountName $accountName -ProfileName $profileName } | Should -Throw "ResourceNotFound"
    }
}
