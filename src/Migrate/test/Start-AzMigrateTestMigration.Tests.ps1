$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzMigrateTestMigration.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Start-AzMigrateTestMigration' {
    It 'ByMachineName'  {
        $output = Start-AzMigrateTestMigration -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup  -MachineName $env.srsMachineName -TestNetworkId $env.srsTestNetworkId
        $output.Name | Should -Be $env.srsMachineName
        $cleanupOutput = Start-AzMigrateTestMigrationCleanup -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup  -MachineName $env.srsMachineName 
	    $cleanupOutput.Name | Should -Be $env.srsMachineName
    }

    It 'ByMachineId' {
        $output = Start-AzMigrateTestMigration -MachineId $env.srsMachineId -TestNetworkId $env.srsTestNetworkId
        $output.Name | Should -Be $env.srsMachineName
	    $cleanupOutput = Start-AzMigrateTestMigrationCleanup -MachineId $env.srsMachineId
	    $cleanupOutput.Name | Should -Be $env.srsMachineName
    }
}
