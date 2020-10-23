$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Reset-AzCloudService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

# Restart/Reimage/Rebuild are async operation and it is not possible to determine the state of role just after the operation.
# Hence in this test we only verify the execution of command is succesful.

Describe 'Reset-AzCloudService' {
    It 'Reimage cloud service' {
        Reset-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstance $env.RoleInstanceName -Reimage
    }

    It 'Rebuild cloud service' {
        Reset-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstance $env.RoleInstanceName -Rebuild
    }

    It 'Restart cloud service' {
	    Reset-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName -RoleInstance $env.RoleInstanceName -Restart
    }

    It 'Reimage cloud service via identity' {
        $cloudServices = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName
		$cloudServices[0] | Reset-AzCloudService -RoleInstance $env.RoleInstanceName -Reimage
    }

    It 'Rebuild cloud service via identity' {
        $cloudServices = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName
		$cloudServices[0] | Reset-AzCloudService -RoleInstance $env.RoleInstanceName -Rebuild
    }

    It 'Restart cloud service via identity' {
        $cloudServices = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName
		$cloudServices[0] | Reset-AzCloudService -RoleInstance $env.RoleInstanceName -Restart
    }
}
