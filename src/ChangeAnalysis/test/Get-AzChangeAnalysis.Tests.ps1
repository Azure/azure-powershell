$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzChangeAnalysis.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzChangeAnalysis' {
    BeforeAll {
        $start = Get-Date -Date "2021-07-16T12:09:03.141Z" -AsUTC
        $end = Get-Date -Date "2021-07-18T12:09:03.141Z" -AsUTC
    }
    It 'List' {
        { Get-AzChangeAnalysis -StartTime $start -EndTime $end } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzChangeAnalysis -StartTime $start -EndTime $end -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzChangeAnalysis -StartTime $start -EndTime $end -ResourceId $env.keyvaultId } | Should -Not -Throw
    }
    
}
