$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsRecordSet.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzDnsRecordSet' {
    It 'CreateCname' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateA' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateAaaa' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateCaa' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateMX' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateNS' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreatePtr' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateSrv' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateTxt' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
