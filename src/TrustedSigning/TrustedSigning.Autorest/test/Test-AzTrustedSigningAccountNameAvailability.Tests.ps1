if (($null -eq $TestName) -or ($TestName -contains 'Test-AzTrustedSigningAccountNameAvailability')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzTrustedSigningAccountNameAvailability.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzTrustedSigningAccountNameAvailability' {
    It "CheckViaJsonString" {
        $accountName = 'nonexistent'
        { Test-AzTrustedSigningAccountNameAvailability -JsonString  "{ `"name`": `"$accountName`",   `"type`": `"microsoft.codesigning/codesigningaccounts`" }" } | Should -Not -Throw
    }
}
