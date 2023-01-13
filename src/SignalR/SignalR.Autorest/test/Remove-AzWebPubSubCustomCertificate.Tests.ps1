if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWebPubSubCustomCertificate'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebPubSubCustomCertificate.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

# Tested in New-AzWebPubSubCustomDomain.Tests.ps1
Describe 'Remove-AzWebPubSubCustomCertificate' {
    It 'Delete' {
        Set-ItResult -Skipped -Because "Tested in New-AzWebPubSubCustomDomain.Tests.ps1"
    }

    It 'DeleteViaIdentity' {
        Set-ItResult -Skipped -Because "Tested in New-AzWebPubSubCustomDomain.Tests.ps1"
    }
}
