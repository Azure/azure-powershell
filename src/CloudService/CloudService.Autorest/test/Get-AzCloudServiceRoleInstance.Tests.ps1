$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzCloudServiceRoleInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzCloudServiceRoleInstance' {
    It 'List cloud service role instance' {
        $cloudServiceRoleInstances = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudServiceRoleInstances.Count | Should Be 4
    }

    It 'List cloud service role instance InstanceView via Expand' {
        $cloudServiceRoleInstanceInstanceViews = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -Expand instanceView
        $cloudServiceRoleInstanceInstanceViews.Count | Should Be 4
    }

    It 'Get cloud service role instance' {
        $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName
        $cloudServiceRoleInstance.Name | Should Be $env.RoleInstanceName
    }

    It 'Get cloud service role instance InstanceView via Expand' {
        $cloudServiceRoleInstanceInstanceView = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName -Expand instanceView
        $cloudServiceRoleInstanceInstanceView.InstanceViewPlatformFaultDomain | Should Be 0
    }

    It 'Get cloud service role instance via identity' {
        $cloudServiceRoleInstances = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -InputObject $cloudServiceRoleInstances[0].Id
        $cloudServiceRoleInstance.Name | Should Be $cloudServiceRoleInstances[0].Name
    }

    It 'Get cloud service role instance InstanceView via identity and Expand' {
        $cloudServiceRoleInstances = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudServiceRoleInstanceInstanceView = Get-AzCloudServiceRoleInstance -InputObject $cloudServiceRoleInstances[0].Id -Expand instanceView
        $cloudServiceRoleInstanceInstanceView.InstanceViewPlatformFaultDomain | Should Be 0
    }
}
