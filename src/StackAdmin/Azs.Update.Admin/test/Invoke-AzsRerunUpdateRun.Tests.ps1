$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzsRerunUpdateRun.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzsRerunUpdateRun' {
    It 'Rerun' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RerunViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
