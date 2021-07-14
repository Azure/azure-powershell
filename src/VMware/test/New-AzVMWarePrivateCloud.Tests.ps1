$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwarePrivateCloud.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMwarePrivateCloud' {
    It 'CreateExpanded' {
        { 
            $job_cloud_new = New-AzVMwarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -Sku av36 -ManagementClusterSize 3 -Location $env.location -AcceptEULA -AsJob
            $job_cloud_new | Wait-Job
            $job_cloud_new | Receive-Job
        } | Should -Not -Throw
    }
}