$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Resume-AzMigrateServerReplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Resume-AzMigrateServerReplication' {
    It 'ByIDVMwareCbt' {
       {Resume-AzMigrateServerReplication -TargetObjectID $env.srsMachinetmpa} | Should -Not -Throw
    }

    It 'ByInputObjectVMwareCbt' {
        $obj = Get-AzMigrateServerReplication -TargetObjectID  $env.srsMachinetmpx
        $obj.Count | Should -BeGreaterOrEqual 1
        {Resume-AzMigrateServerReplication -InputObject $obj} | Should -Not -Throw
        }
}
