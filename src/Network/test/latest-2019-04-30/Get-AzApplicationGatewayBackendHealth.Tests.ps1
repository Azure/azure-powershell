$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzApplicationGatewayBackendHealth.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzApplicationGatewayBackendHealth' {
    It 'Backend' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DemandExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DemandViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BackendViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
