$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCostManagementExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCostManagementExport' {
    It 'List' {
        $exportList = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)"
        $exportList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $export = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01
        $export.Name | Should -Be $env.exportName01
    }

    It 'GetViaIdentity'  {
        $export = Get-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName01
        $export = Get-AzCostManagementExport -InputObject $export 
        $export.Name | Should -Be $env.exportName01
    }
}
