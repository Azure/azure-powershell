$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzVMwarePrivateCloud' {
    It 'UpdateExpanded' {
        {
            $job_cloud_new = New-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location -AcceptEULA -AsJob
            $job_cloud_new | Wait-Job
            $job_cloud_new | Receive-Job

            $job_cloud_update = Update-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup -ManagementClusterSize 4 -AsJob
            $job_cloud_update | Wait-Job
            $job_cloud_update | Receive-Job

            $job_cloud_Remove = Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup -Name $env.rstr2 -AsJob
            $job_cloud_Remove | Wait-Job
            $job_cloud_Remove | Receive-Job
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        {
            $job_cloud_new = New-AzVMwarePrivateCloud -Name $env.rstr2 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location -AcceptEULA -AsJob
            $job_cloud_new | Wait-Job
            $job_cloud_new | Receive-Job
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.rstr2)"
            
            $job_cloud_update = Update-AzVMwarePrivateCloud -InputObject $ID -ManagementClusterSize 4 -AsJob
            $job_cloud_update | Wait-Job
            $job_cloud_update | Receive-Job

            $job_cloud_Remove = Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup -Name $env.rstr2 -AsJob
            $job_cloud_Remove | Wait-Job
            $job_cloud_Remove | Receive-Job
        } | Should -Not -Thorw
    }
}