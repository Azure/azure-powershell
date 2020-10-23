$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCloudService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCloudService' {
    It 'List cloud service in subscription' {
        $cloudServices = Get-AzCloudService
        $cloudServices.Count | Should BeGreaterThan 0
    }

    It 'List cloud service in ResourceGroup' {
        $cloudServices = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName
        $cloudServices.Count | Should BeGreaterThan 0
    }

    It 'Get cloud service' {
        $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudService.RoleProfileRole.Count | Should Be 2
    }

    It 'Get cloud service InstanceView' {
        $cloudServiceInstanceView = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -InstanceView
        $cloudServiceInstanceView.RoleInstanceStatusesSummary.Count | Should Be 2
    }

    It 'Get cloud service via identity' {
        $cs = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudService = $cs | Get-AzCloudService
        $cloudService.RoleProfileRole.Count | Should Be 2
    }

    It 'Get cloud service InstanceView via identity' {
        $cs = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudServiceInstanceView = $cs | Get-AzCloudService -InstanceView
        $cloudServiceInstanceView.RoleInstanceStatusesSummary.Count | Should Be 2
    }
}
