$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCostManagementExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzCostManagementExport' {
    It 'Delete' {
        Remove-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName04
        $exportList = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)"
        $exportList.Name| Should -Not -Contain $env.exportName04
    }

    It 'DeleteViaIdentity' {
        $export = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)" -Name $env.exportName03
        Remove-AzCostManagementExport -InputObject $export
        $exportList = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)"
        $exportList.Name| Should -Not -Contain $env.exportName03
    }
}
