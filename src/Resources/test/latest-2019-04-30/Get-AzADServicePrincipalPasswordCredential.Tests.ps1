$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzADServicePrincipalPasswordCredential.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzADServicePrincipalPasswordCredential' {
    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
