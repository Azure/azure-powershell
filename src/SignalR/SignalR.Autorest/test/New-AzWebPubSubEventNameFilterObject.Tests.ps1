if(($null -eq $TestName) -or ($TestName -contains 'New-AzWebPubSubEventNameFilterObject'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWebPubSubEventNameFilterObject.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWebPubSubEventNameFilterObject' {
    It '__AllParameterSets' {
        $filter = New-AzWebPubSubEventNameFilterObject -SystemEvent connected -UserEventPattern event1
        $filter.SystemEvent | Should -HaveCount 1
        $filter.UserEventPattern | Should -Be event1
    }
}
