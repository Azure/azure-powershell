$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCloudServiceInstanceView.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCloudServiceInstanceView' {
    It 'Get cloud service InstanceView' {
        $cloudServiceInstanceView = Get-AzCloudServiceInstanceView -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudServiceInstanceView.RoleInstanceStatusesSummary.Count | Should -Not -Be 0
    }
}
