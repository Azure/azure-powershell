$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCloudService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzCloudService' {
    It 'Create new cloud service' {
        # Create Network Profile
        $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name "cscmdlettestLBFE" -PublicIPAddressId $env.NewCSPublicIPId
        $networkProfile = New-AzCloudServiceLoadBalancerConfigurationObject -Name "cscmdlettestLB" -FrontendIPConfiguration $feIpConfig
	    
        # Create Role Profile
        $role1 = New-AzCloudServiceRoleProfilePropertiesObject -Name "WebRole" -SkuName "Standard_D1_v2" -SkuTier "Standard" -SkuCapacity 2
        $role2 = New-AzCloudServiceRoleProfilePropertiesObject -Name "WorkerRole" -SkuName "Standard_D1_v2" -SkuTier "Standard" -SkuCapacity 2
        $roles = @($role1, $role2)

        # Create Extension Profile
		$extension = New-AzCloudServiceExtensionObject -Name GenevaExtension -Publisher Microsoft.Azure.Geneva -Type GenevaMonitoringPaaS -TypeHandlerVersion "2.14.0.2"
		
        # Read Configuration File
	    $cscfgFilePath = Join-Path $PSScriptRoot $env.CscfgFile
        $cscfgText = [IO.File]::ReadAllText($cscfgFilePath)
	    
        # Create Cloud Service
        $cloudService = New-AzCloudService                                            `
                          -Name $env.CloudServiceName                                 `
                          -ResourceGroupName $env.ResourceGroupName                   `
                          -Location $env.Location                                     `
                          -PackageUrl $env.CspkgUrl                                   `
                          -Configuration $cscfgText                                   `
                          -RoleProfileRole $roles                                     `
                          -NetworkProfileLoadBalancerConfiguration $networkProfile    `
                          -ExtensionProfileExtension $extension
        $cloudService.ResourceGroupName -eq $env.ResourceGroupName | Should be $true
    }

    It 'Create new cloud service via identity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
