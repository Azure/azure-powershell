$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateNicMapping.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzMigrateNicMapping' {
    It 'VMwareCbt' {
        $output = New-AzMigrateNicMapping -NicID abcd -TargetNicSelectionType primary -TargetNicIP "172.17.1.17"
        $output.Count | Should -BeGreaterOrEqual 1 
        $output.NicID | Should -Be abcd
    }
}
