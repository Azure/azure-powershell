$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzStreamAnalyticsFunction.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzStreamAnalyticsFunction' {
    It 'TestExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Test' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TestViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'TestViaIdentity' {
      $func = Get-AzStreamAnalyticsFunction -ResourceGroupName lucas-rg-test -JobName sajob-01-cli -Name score
      Test-AzStreamAnalyticsFunction -InputObject '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/Microsoft.StreamAnalytics/streamingjobs/sajob-01-cli/functions/score/test' -Function $func
    }
}
