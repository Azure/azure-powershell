$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzCloudServiceRoleInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restart-AzCloudServiceRoleInstance' {

    It 'Restart cloud service role instance' {
        Restart-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName
    }

    It 'Restart cloud service role instance via identity' {
        $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        Restart-AzCloudServiceRoleInstance -InputObject $cloudServiceRoleInstance[0]
    }
}
