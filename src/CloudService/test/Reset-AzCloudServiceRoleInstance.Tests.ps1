$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzCloudServiceRoleInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

# Restart/Reimage/Rebuild are async operation and it is not possible to determine the state of role just after the operation.
# Hence in this test we only verify the execution of command is succesful.

Describe 'Reset-AzCloudServiceRoleInstance' {
    It 'Restart cloud service role instance' {
        Reset-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName -Restart
    }

    It 'Rebuild cloud service role instance' {
		Reset-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName -Rebuild
    }

    It 'Reimage cloud service role instance' {
        Reset-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstanceName $env.RoleInstanceName -Reimage
    }

    # It 'Restart cloud service role instance via identity' {
	#     $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
	# 	$cloudServiceRoleInstance[0] | Reset-AzCloudServiceRoleInstance -Restart
    # }

    # It 'Rebuild cloud service role instance via identity' {
	#     $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
	# 	$cloudServiceRoleInstance[0] | Reset-AzCloudServiceRoleInstance -Rebuild
    # }

    # It 'Reimage cloud service role instance via identity' {
	#     $cloudServiceRoleInstance = Get-AzCloudServiceRoleInstance -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
	# 	$cloudServiceRoleInstance[0] | Reset-AzCloudServiceRoleInstance -Reimage
    # }
}
