$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMigrateServerReplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzMigrateServerReplication' {
    It 'ByNameVMwareCbt' {
        $output = Set-AzMigrateServerReplication -MachineName  $env.srsMachineName -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup -TargetVMName $env.srsTgtVMName -SubscriptionId $env.srsSubscriptionId
 	$output.Count | Should -BeGreaterOrEqual 1
    }

    It 'ByIDVMwareCbt' {
        $output = Set-AzMigrateServerReplication -TargetObjectID $env.srsMachineId -TargetVMName $env.srsTgtVMName -SubscriptionId $env.srsSubscriptionId
 	$output.Count | Should -BeGreaterOrEqual 1
    }

    It 'ByInputObjectVMwareCbt' {
	$obj = Get-AzMigrateServerReplication -TargetObjectID $env.srsMachineId -SubscriptionId $env.srsSubscriptionId
        $obj.Count | Should -BeGreaterOrEqual 1
        $output = Set-AzMigrateServerReplication -InputObject $obj -TargetVMName $env.srsTgtVMName -SubscriptionId $env.srsSubscriptionId
 	$output.Count | Should -BeGreaterOrEqual 1
    }
}
