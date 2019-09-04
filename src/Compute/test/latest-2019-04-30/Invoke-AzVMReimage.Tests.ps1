$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzVMReimage.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzVMReimage' {
    It 'Redeploy1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReimageViaIdentityExpanded' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RedeployViaIdentity1' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
