$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCloudServiceRoleInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzCloudServiceRoleInstance' {

    It 'Delete role instance' -skip {
        Remove-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstance $env.RoleInstanceName
    }

    It 'Delete role instance via identity' -skip {
        $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
		Remove-AzCloudServiceRoleInstance -InputObject $cloudService -RoleInstance $env.RoleInstanceName
    }
}
