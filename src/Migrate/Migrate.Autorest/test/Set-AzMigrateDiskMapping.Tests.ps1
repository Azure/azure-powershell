$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMigrateDiskMapping.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzMigrateDiskMapping' {
    It 'VMwareCbt' {
        $output = Set-AzMigrateDiskMapping -DiskID abc -DiskName "Diskname"
        $output.Count | Should -BeGreaterOrEqual 1 
        $output.TargetDiskName | Should -Be "DiskName"
    }
}
