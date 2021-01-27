$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwareAuthorization' {
    It 'CreateExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
        # $job_cloud_new = New-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -SkuName av36 -ManagementClusterSize 3 -Location $env.location -AsJob
        # $job_cloud_new | Wait-Job
        # $cloud = ($job_cloud_new | Receive-Job)

        # $auth = New-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup
        # $auth_get = Get-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup
        # $auth_remove = Remove-AzVMwareAuthorization -Name $env.rstr3 -PrivateCloudName $env.rstr1 -ResourceGroupName $env.resourceGroup

        # $job_cloud_remove = Remove-AzVMwarePrivateCloud -ResourceGroupName $env.resourceGroup -Name $env.rstr1 -AsJob
        # $job_cloud_remove | Wait-Job
        # $cloud_remove = ($job_cloud_remove | Receive-Job)
    }
}
