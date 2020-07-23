$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzImportExportBitLockerKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzImportExportBitLockerKey' {
    It 'List' {
        $key = Get-AzImportExportBitLockerKey -JobName $env.jobName -ResourceGroupName $env.resourceGroup
        $key.DriveId | Should -Be 9CA995BB
        $key.BitLockerKey | Should -Be 238810-662376-448998-450120-652806-203390-606320-483076
    }
}
