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
    It 'UpdateExpanded: Create new cloud service' {
        # Create Network Profile
        $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name "cscmdlettestLBFE" -PublicIPAddressId $env.NewCSPublicIPId
        $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name "cscmdlettestLB" -FrontendIPConfiguration $feIpConfig
        $networkProfile = @{loadBalancerConfiguration = $loadBalancerConfig}

        # Create Role Profile
        $role1 = New-AzCloudServiceRoleProfilePropertiesObject -Name "WebRole" -SkuName "Standard_D1_v2" -SkuTier "Standard" -SkuCapacity 2
        $role2 = New-AzCloudServiceRoleProfilePropertiesObject -Name "WorkerRole" -SkuName "Standard_D1_v2" -SkuTier "Standard" -SkuCapacity 2
        $roleProfile = @{role = @($role1, $role2)}

        # Create Extension Profile
        $genevaExtension = New-AzCloudServiceExtensionObject -Name GenevaExtension -Publisher Microsoft.Azure.Geneva -Type GenevaMonitoringPaaS -TypeHandlerVersion "2.14.0.2"
        $extensionProfile = @{extension = @($genevaExtension)}

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
                          -RoleProfile $roleProfile                                     `
                          -NetworkProfile $networkProfile    `
                          -ExtensionProfile $extensionProfile
        $cloudService.ResourceGroupName -eq $env.ResourceGroupName | Should be $true
    }
    It 'quickCreateParameterSetWithoutStorage' {
        $CloudServiceName2 = $env.CloudServiceName + "2"
        $cscfgFilePath = Join-Path $PSScriptRoot $env.CscfgFile
        $cspkgFilePath = Join-Path $PSScriptRoot $env.CspkgFile
        $csdefFilePath = Join-Path $PSScriptRoot $env.csdefFile
        $cloudService2 = new-azcloudservice `
                            -resourcegroupname $env.ResourceGroupName `
                            -location $env.Location `
                            -configurationFile $cscfgFilePath `
                            -definitionFile $csdefFilePath `
                            -packagefile $cspkgFilePath `
                            -name $CloudServiceName2 `
                            -StorageAccount $env.StorageName 
        $cloudService2.ResourceGroupName -eq $env.ResourceGroupName | Should be $true
    }
    It 'quickCreateParameterSetWithStorage' {
        # getting Package URL

        $tokenStartTime = Get-Date 
        $tokenEndTime = $tokenStartTime.AddYears(1) 
        $storacc = Get-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $env.StorageName
        $cspkgblob = get-azstorageblob -Container $env.ContainerName -Blob $env.BlobName -Context $storacc.Context
        $cspkgToken = New-AzStorageBlobSASToken -Container $env.ContainerName -Blob $env.BlobName -Permission rwd -StartTime $tokenStartTime -ExpiryTime $tokenEndTime -Context $storacc.Context
        $cspkgUrl = $cspkgBlob.ICloudBlob.Uri.AbsoluteUri + $cspkgToken 

        $CloudServiceName3 = $env.CloudServiceName + "3"
        $cscfgFilePath = Join-Path $PSScriptRoot $env.CscfgFile
        $csdefFilePath = Join-Path $PSScriptRoot $env.csdefFile

        # calling New-AzCloudService
        $CloudServiceName3 = new-azcloudservice`
                                 -resourcegroupname theo_cses `
                                 -location eastus `
                                 -configurationFile $cscfgFilePath `
                                 -definitionFile $csdefFilePath `
                                 -packageUrl $cspkgurl `
                                 -name $CloudServiceName3

        $cloudService3.ResourceGroupName -eq $env.ResourceGroupName | Should be $true
    }
}
