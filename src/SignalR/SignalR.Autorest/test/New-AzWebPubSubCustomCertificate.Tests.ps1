if(($null -eq $TestName) -or ($TestName -contains 'New-AzWebPubSubCustomCertificate'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWebPubSubCustomCertificate.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

# Tested in New-AzWebPubSubCustomDomain.Tests.ps1
Describe 'New-AzWebPubSubCustomCertificate' {
    It 'CreateExpanded' {
        Set-ItResult -Skipped -Because "Tested in New-AzWebPubSubCustomDomain.Tests.ps1"
    }
}
