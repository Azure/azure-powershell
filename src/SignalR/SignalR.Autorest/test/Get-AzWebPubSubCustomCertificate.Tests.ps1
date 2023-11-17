if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebPubSubCustomCertificate'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebPubSubCustomCertificate.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

# Tested in New-AzWebPubSubCustomDomain.Tests.ps1
Describe 'Get-AzWebPubSubCustomCertificate' {
    It 'List' {
        Set-ItResult -Skipped -Because "Tested in New-AzWebPubSubCustomDomain.Tests.ps1"

    }

    It 'Get' {
        Set-ItResult -Skipped -Because "Tested in New-AzWebPubSubCustomDomain.Tests.ps1"
    }

    It 'GetViaIdentity' {
        Set-ItResult -Skipped -Because "Tested in New-AzWebPubSubCustomDomain.Tests.ps1"
    }
}
