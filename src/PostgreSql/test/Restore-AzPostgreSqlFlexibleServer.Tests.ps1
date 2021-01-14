$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restore-AzPostgreSqlFlexibleServer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restore-AzPostgreSqlFlexibleServer' {
    It 'PointInTimeRestore' {
        {
            $restorePointInTime = (Get-Date).AddMinutes(-10)
            Restore-AzPostgreSqlFlexibleServer -SourceServerName $env.flexibleServerName -Location $env.location -Name $env.restoreName -ResourceGroupName $env.resourceGroup -RestorePointInTime $restorePointInTime
        } | Should -Not -Throw
    }
}
