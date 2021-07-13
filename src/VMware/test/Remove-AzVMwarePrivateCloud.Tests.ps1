$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwarePrivateCloud' {
    It 'Delete' -skip {
        {
            $job_cloud_new = New-AzVMwarePrivateCloud -Name $env.rstr4 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location -AcceptEULA -AsJob
            $job_cloud_new | Wait-Job
            $job_cloud_new | Receive-Job

            $job_cloud_Remove = Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup -Name $env.rstr4 -AsJob
            $job_cloud_Remove | Wait-Job
            $job_cloud_Remove | Receive-Job
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        {
            $job_cloud_new = New-AzVMwarePrivateCloud -Name $env.rstr3 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location -AcceptEULA -AsJob
            $job_cloud_new | Wait-Job
            $job_cloud_new | Receive-Job

            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.rstr3)"
            $job_cloud_Remove = Remove-AzVMwarePrivateCloud -InputObject $ID
            $job_cloud_Remove | Wait-Job
            $job_cloud_Remove | Receive-Job
          } | Should -Not -Throw
    }
}
