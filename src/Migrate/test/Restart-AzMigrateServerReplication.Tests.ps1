$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzMigrateServerReplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restart-AzMigrateServerReplication' {
    It 'ByNameVMwareCbt' {
        $output = Restart-AzMigrateServerReplication -MachineName  $env.srsMachineName -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
 	$output.Count | Should -BeGreaterOrEqual 1
    }

    It 'ByIDVMwareCbt' {
        $output = Restart-AzMigrateServerReplication -TargetObjectID $env.srsMachineId -SubscriptionId $env.srsSubscriptionId
 	$output.Count | Should -BeGreaterOrEqual 1
    }

    It 'ByInputObjectVMwareCbt' {
        $obj = Get-AzMigrateServerReplication -TargetObjectID $env.srsMachineId -SubscriptionId $env.srsSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        $output = Restart-AzMigrateServerReplication -InputObject $obj -SubscriptionId $env.srsSubscriptionId
 	$output.Count | Should -BeGreaterOrEqual 1
	
    }
}
