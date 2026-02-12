if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzArtifactSigningCertificateProfile')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzArtifactSigningCertificateProfile.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzArtifactSigningCertificateProfile' {
    It 'Delete' {
        $accountName = $profileName = 'azpstestprofiledelete'
        New-AzArtifactSigningAccount -ResourceGroupName $env.rg -AccountName $accountName -Location $env.location -SkuName 'Basic'
        New-AzArtifactSigningCertificateProfile -AccountName $accountName -ResourceGroupName $env.rg -ProfileName $profileName `
            -IdentityValidationId $env.IdentityValidationId -ProfileType:PublicTrustTest
        { Get-AzArtifactSigningCertificateProfile -ResourceGroupName $env.rg -AccountName $accountName -ProfileName $profileName } | Should -Not -Throw

        Remove-AzArtifactSigningCertificateProfile -ResourceGroupName $env.rg -AccountName $accountName -ProfileName $profileName

        { Get-AzArtifactSigningCertificateProfile -ResourceGroupName $env.rg -AccountName $accountName -ProfileName $profileName } | Should -Throw "ResourceNotFound"
    }
}
