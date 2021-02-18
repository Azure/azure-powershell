$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzImportExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzImportExport' {
    It 'UpdateExpanded' {
        $name = "pwsh"
        $number = "pwsh20200000"
        $job = Update-AzImportExport -Name $env.jobName -ResourceGroupName $env.resourceGroup -DeliveryPackageCarrierName $name -DeliveryPackageTrackingNumber $number
        $job.DeliveryPackageCarrierName | Should -Be $name
        $job.DeliveryPackageTrackingNumber | Should -Be $number
    }

    It 'UpdateViaIdentityExpanded' {
        $Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.ImportExport/jobs/$($env.jobName)"
        $job = Update-AzImportExport -InputObject $Id -CancelRequested
        $job.CancelRequested | Should -Be True
    }
}
