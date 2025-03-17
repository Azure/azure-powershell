if (($null -eq $TestName) -or ($TestName -contains 'Get-AzTrustedSigningCertificateProfile')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzTrustedSigningCertificateProfile.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzTrustedSigningCertificateProfile' {
    BeforeAll {
        $accountName = 'azpstestprofileget0'
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Premium'
    }
    It 'Get' {
        $profileName = 'azpstestprofile1'
        New-AzTrustedSigningCertificateProfile -AccountName $accountName -ResourceGroupName $env.rg -ProfileName $profileName `
            -IdentityValidationId $env.IdentityValidationId -ProfileType:PublicTrustTest

        $sut = Get-AzTrustedSigningCertificateProfile  -AccountName $accountName -ResourceGroupName $env.rg

        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $profileName
        $sut.ProfileType | Should -Be 'PublicTrustTest'
        $sut.IdentityValidationId | Should -Be $env.IdentityValidationId
    }
    It 'List' {
        $profileName1 = 'azpstestprofile2'
        $profileName2 = 'azpstestprofile3'

        New-AzTrustedSigningCertificateProfile -AccountName $accountName -ResourceGroupName $env.rg -ProfileName $profileName1 `
            -IdentityValidationId $env.IdentityValidationId -ProfileType:PublicTrustTest
        New-AzTrustedSigningCertificateProfile -AccountName $accountName -ResourceGroupName $env.rg -ProfileName $profileName2 `
            -IdentityValidationId $env.IdentityValidationId -ProfileType:PublicTrustTest

        $sut = Get-AzTrustedSigningCertificateProfile  -AccountName $accountName -ResourceGroupName $env.rg

        $sut | Should -Not -BeNullOrEmpty
        $sut.Count | Should -BeGreaterThan 1
        $sut.Name | Should -Contain $profileName1
        $sut.Name | Should -Contain $profileName2
    }
}
