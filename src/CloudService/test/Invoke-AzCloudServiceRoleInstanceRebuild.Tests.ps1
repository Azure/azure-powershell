$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCloudServiceRoleInstanceRebuild.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzCloudServiceRoleInstanceRebuild' {

    It 'Rebuild cloud service role instance' {
        Invoke-AzCloudServiceRoleInstanceRebuild -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName
    }

    It 'Rebuild cloud service role instance via identity' {
        $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        Invoke-AzCloudServiceRoleInstanceRebuild -InputObject $cloudServiceRoleInstance[0]
    }
}
