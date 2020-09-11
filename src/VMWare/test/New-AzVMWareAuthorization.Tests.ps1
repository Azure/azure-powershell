$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMWareAuthorization.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzVMWareAuthorization' {
    It 'CreateExpanded' {
        $cloud = New-AzVMWarePrivateCloud -Name $env.rstr1 -ResourceGroupName $env.resourceGroup -NetworkBlock 192.168.48.0/22 -SkuName av36 -ManagementClusterSize 3 -Location $env.location

        $auth = New-AzVMWareAuthorization -Name $env.rstr2 -PrivateCloudName $cloud.Name -ResourceGroupName $env.resourceGroup

        $auth_get = Get-AzVMWareAuthorization -Name $env.rstr2 -PrivateCloudName $cloud.Name -ResourceGroupName $env.resourceGroup
    }
}
