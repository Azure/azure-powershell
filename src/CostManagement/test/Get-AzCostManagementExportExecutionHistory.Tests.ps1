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
        $exportHist = Get-AzCostManagementExportExecutionHistory -Scope "subscriptions/$($env.SubscriptionId)" -ExportName $env.exportName01
        $exportHist.Count | Should -Be 1
    }

    It 'GetViaIdentity' {
        $export = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01
        $exportHist = Get-AzCostManagementExportExecutionHistory -InputObject $export
        $exportHist.Count | Should -Be 1
    }
}
