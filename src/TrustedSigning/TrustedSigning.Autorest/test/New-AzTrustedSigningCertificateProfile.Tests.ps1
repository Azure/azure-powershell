if (($null -eq $TestName) -or ($TestName -contains 'New-AzTrustedSigningCertificateProfile')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzTrustedSigningCertificateProfile.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzTrustedSigningCertificateProfile' {
    It 'CreateExpanded' {
        $accountName = $profileName = 'azpstestprofile'
        
        New-AzTrustedSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        
        $sut = New-AzTrustedSigningCertificateProfile -AccountName $accountName -ResourceGroupName $env.rg -ProfileName $profileName `
            -IdentityValidationId $env.IdentityValidationId -ProfileType:PublicTrustTest
		
        $sut | Should -Not -BeNullOrEmpty
        $sut.Name | Should -Be $profileName
        $sut.ProfileType | Should -Be 'PublicTrustTest'
        $sut.IdentityValidationId | Should -Be $env.IdentityValidationId
    }
}
