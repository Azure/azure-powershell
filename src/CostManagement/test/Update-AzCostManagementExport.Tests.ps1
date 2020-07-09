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
    It 'UpdateExpanded' -skip {
        # Has issue on server, Parameter ResourceID is not null
        # TODO: When fix issue on server
        $export = Update-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01 -RecurrencePeriodFrom $env.toDate
        $export.RecurrencePeriodFrom | Should -Be $env.toDate
    }

    It 'UpdateViaIdentityExpanded' -skip {
        # Has issue on server, Parameter ResourceID is not null
        # TODO: When fix issue on server
        $oldExport = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01
        $export = Update-AzCostManagementExport -InputObject $oldExport -RecurrencePeriodFrom $env.fromDate
        $export.RecurrencePeriodFrom | Should -Be $env.fromDate
    }
}
