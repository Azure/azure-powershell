$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCostManagementExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzCostManagementExport' {
    It 'UpdateExpanded' {
        $export = Update-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01 -ScheduleRecurrence 'Weekly'
        $export.property.ScheduleRecurrence | Should -Be 'Weekly'
    }

    It 'UpdateViaIdentityExpanded' {
        $oldExport = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01
        $export = Update-AzCostManagementExport -InputObject $oldExport -ScheduleRecurrence 'Weekly'
        $export.property.ScheduleRecurrence | Should -Be 'Weekly'
    }
}
