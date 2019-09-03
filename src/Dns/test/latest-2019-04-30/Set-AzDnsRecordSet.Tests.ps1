$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDnsRecordSet.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzDnsRecordSet' {
    It 'UpdateSoa' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateA' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateAaaa' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateCaa' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateCname' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateMX' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateNS' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdatePtr' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateSrv' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateTxt' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
