$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzCloudService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Stop-AzCloudService' {

    It 'PowerOff/Stop cloud service' {
        Stop-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
    }

    It 'PowerOff/Stop cloud service via identity' {
        $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        Stop-AzCloudService -InputObject $cloudService
    }
}
