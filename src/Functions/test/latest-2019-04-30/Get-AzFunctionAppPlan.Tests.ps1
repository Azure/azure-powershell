$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFunctionAppPlan.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzFunctionAppPlan' {
    It 'GetAll' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'BySubscriptionId' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByResourceGroupName' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ByLocation' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
