$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzCloudService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Restart-AzCloudService' {

    It 'Restart cloud service' {
        Restart-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstance $env.RoleInstanceName
    }

    It 'Restart cloud service via identity' {
        $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        Restart-AzCloudService -InputObject $cloudService -RoleInstance $env.RoleInstanceName
    }
}
