$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzVnetGatewayConnectionSharedKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzVnetGatewayConnectionSharedKey' {
    It 'SetExpanded1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Set1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
