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
        $cloudService.RoleProfile.Role.Count | Should Be 2
    }

    It 'GetViaIdentity' {
        $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cs2 = Get-AzCloudService -InputObject $cloudService.Id
        $cs2.RoleProfile.Role.Count | Should Be 2
    }
}
