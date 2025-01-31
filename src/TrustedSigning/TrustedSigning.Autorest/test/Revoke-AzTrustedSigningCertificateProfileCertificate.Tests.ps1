if (($null -eq $TestName) -or ($TestName -contains 'Revoke-AzTrustedSigningCertificateProfileCertificate')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Revoke-AzTrustedSigningCertificateProfileCertificate.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Revoke-AzTrustedSigningCertificateProfileCertificate' {
    It 'Revoke' {
        $accountName = $profileName = 'azpstestprofilerevoke'

        New-AzTrustedSigningCodeSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        $cp = New-AzTrustedSigningCertificateProfile -AccountName $accountName -ResourceGroupName $env.rg -ProfileName $profileName -IdentityValidationId $env.IdentityValidationId -ProfileType:PublicTrustTest

        { Revoke-AzTrustedSigningCertificateProfileCertificate -AccountName $accountName -ProfileName $profileName -ResourceGroupName $env.rg -EffectiveAt (Get-Date) -Reason 'Unspecified' -Thumbprint $cp.Certificate.Thumbprint -SerialNumber $cp.Certificate.SerialNumber } | Should -Throw "The operation for resource '*' is invalid as certificate revocation can only be triggered from azure portal."
    }
}
