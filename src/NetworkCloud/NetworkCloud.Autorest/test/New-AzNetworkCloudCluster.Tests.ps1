if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudCluster')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudCluster.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudCluster' {
    It 'Create' {
        { $clusterconfig = $global:config.AzNetworkCloudCluster
            $common = $global:config.common
            $tagHash = @{
                tag1 = $clusterconfig.tags
            }
            $password = ConvertTo-SecureString "bmcPassword" -AsPlainText
            $bmmConfigurationData1 = New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername $clusterconfig.bmcCredsUsername -BmcMacAddress $clusterconfig.bmcMacAddress1 -BootMacAddress $clusterconfig.bootMacAddress1 -RackSlot 1 -SerialNumber $clusterconfig.serialNumber1 -MachineDetail "machineDetail" -MachineName "lab00r750wkr1"
            $bmmConfigurationData2 = New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername $clusterconfig.bmcCredsUsername -BmcMacAddress $clusterconfig.bmcMacAddress2 -BootMacAddress $clusterconfig.bootMacAddress2 -RackSlot 2 -SerialNumber $clusterconfig.serialNumber2 -MachineDetail "machineDetailmgr" -MachineName "lab00r750mgr1"
            $bmmConfigurationData3 = New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername $clusterconfig.bmcCredsUsername -BmcMacAddress $clusterconfig.bmcMacAddress3 -BootMacAddress $clusterconfig.bootMacAddress3 -RackSlot 3 -SerialNumber $clusterconfig.serialNumber3 -MachineDetail "machineDetailmgr" -MachineName "lab00r750mgr2"
            $bareMetalMachineConfigurationData = @($bmmConfigurationData1, $bmmConfigurationData2, $bmmConfigurationData3)
            $saConfigurationData = New-AzNetworkCloudStorageApplianceConfigurationDataObject -AdminCredentialsPassword $password -AdminCredentialsUsername username -RackSlot 1 -SerialNumber $clusterconfig.serialNumber1 -StorageApplianceName "storageApplianceName"

            $computerackdefinition = New-AzNetworkCloudRackDefinitionObject -NetworkRackId $clusterconfig.networkRackId -RackSerialNumber $clusterconfig.rackSerialNumber -RackSkuId $clusterconfig.rackSkuId -AvailabilityZone "1" -RackLocation $clusterconfig.rackDefinitionRackLocation  -StorageApplianceConfigurationData $saConfigurationData -BareMetalMachineConfigurationData $bareMetalMachineConfigurationData
            $storageapplianceconfigurationdata = @($saConfigurationData)
            $baremetalmachineconfigurationdata = @($bmmconfigurationdata1)

            $securePassword = ConvertTo-SecureString $clusterconfig.clusterServicePrincipalPassword -asplaintext -force

            New-AzNetworkCloudCluster -ResourceGroupName $clusterconfig.clusterRg -Name $clusterconfig.clusterName `
                -AggregatorOrSingleRackDefinitionNetworkRackId $clusterconfig.networkRackId `
                -AggregatorOrSingleRackDefinitionRackSerialNumber $clusterconfig.rackSerialNumber `
                -AggregatorOrSingleRackDefinitionRackSkuId $clusterconfig.rackSkuId `
                -AggregatorOrSingleRackDefinitionAvailabilityZone $clusterconfig.rackDefinitionAvailabilityZone `
                -AggregatorOrSingleRackDefinitionBareMetalMachineConfiguration $baremetalmachineconfigurationdata `
                -AggregatorOrSingleRackDefinitionRackLocation $clusterconfig.rackDefinitionRackLocation `
                -AggregatorOrSingleRackDefinitionStorageApplianceConfiguration $storageapplianceconfigurationdata `
                -ClusterType $clusterconfig.clusterType -ClusterVersion $clusterconfig.clusterVersion `
                -ExtendedLocationName $clusterconfig.extendedLocation -ExtendedLocationType $common.customLocationType `
                -Location $common.location `
                -SubscriptionId $clusterconfig.subscriptionId `
                -NetworkFabricId $clusterconfig.networkFabricId `
                -ClusterServicePrincipalApplicationId $clusterconfig.clusterServicePrincipalApplicationId `
                -ClusterServicePrincipalId $clusterconfig.clusterServicePrincipalId `
                -ClusterServicePrincipalPassword $securePassword `
                -ClusterServicePrincipalTenantId $clusterconfig.clusterServicePrincipalTenantId `
                -AnalyticsWorkspaceId $clusterconfig.analyticsWorkspaceId `
                -ComputeRackDefinition $computerackdefinition `
                -Tag $tagHash `
        } | Should -Not -Throw
    }
}
