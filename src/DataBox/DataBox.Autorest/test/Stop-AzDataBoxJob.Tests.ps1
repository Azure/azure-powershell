$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDataBoxJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzDataBoxJob' {
    It 'CancelExpanded' {
        Stop-AzDataBoxJob -Name $env.JobNameScheduleOrder -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
        Stop-AzDataBoxJob -Name $env.JobNameImport -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
        Stop-AzDataBoxJob -Name $env.JobNameExport -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
        Stop-AzDataBoxJob -Name $env.JobNameUAI -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
        Stop-AzDataBoxJob -Name $env.JobNameDisk -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
        Stop-AzDataBoxJob -Name $env.JobNameHeavy -ResourceGroupName $env.ResourceGroup -Reason "Test Job" -SubscriptionId $env.SubscriptionId
    }
}
