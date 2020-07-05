$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCostManagementExportExecutionHistory.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCostManagementExportExecutionHistory' {
    It 'Get' {
        { Get-AzCostManagementExportExecutionHistory -Scope "subscriptions/$($env.SubscriptionId)" -ExportName $env.exportName01 } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        # An exception "Invalid identity for URI '/{scope}/providers/Microsoft.CostManagement/exports/{exportName}/runHistory'" was thrown
        # TODO: The issue fix
        $export = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01
        { Get-AzCostManagementExportExecutionHistory -InputObject  $export} | Should -Not -Throw
    }
}
