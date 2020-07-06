$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCostManagementExecuteExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzCostManagementExecuteExport' {
    It 'Execute'  {
        Invoke-AzCostManagementExecuteExport -Scope "subscriptions/$($env.SubscriptionId)" -ExportName $env.exportName01 
        $exportHist = Get-AzCostManagementExportExecutionHistory -Scope "subscriptions/$($env.SubscriptionId)" -ExportName $env.exportName01
        $exportHist.Count | Should -Be 2
    }

    It 'ExecuteViaIdentity'  {
        $export = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01
        Invoke-AzCostManagementExecuteExport -InputObject $export
        $exportHist = Get-AzCostManagementExportExecutionHistory -Scope "subscriptions/$($env.SubscriptionId)" -ExportName $env.exportName01
        $exportHist.Count | Should -Be 3
    }
}
