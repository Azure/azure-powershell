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
            $computerackdefinition = @(@{"networkRackId" = "/subscriptions/a3eeb848-665a-4dbf-80a4-eb460930fb23/resourceGroups/cli-ps-test-automation/providers/Microsoft.Network/virtualNetworks/vNet/subnets/Subnet"; "rackSkuId" = "/subscriptions/a3eeb848-665a-4dbf-80a4-eb460930fb23/providers/Microsoft.NetworkCloud/rackSkus/VLab1_4_Compute_DellR750_1C2M_sim"; "rackSerialNumber" = "aa5678"; "rackLocation" = "Foo Datacenter, Floor 3, Aisle 9, Rack 2"; "availabilityZone" = 1; "storageApplianceConfigurationData" = $storageapplianceconfigurationdata; "bareMetalMachineConfigurationData" = @(@{"bmcCredentials" = @{"password" = "bmcPassword"; "username" = "root" }; "bmcMacAddress" = "AA:BB:CC:DD:E7:08"; "bootMacAddress" = "AA:BB:CC:F8:71:2E"; "machineName" = "lab00r750wkr1"; "rackSlot" = 1; "serialNumber" = "5HS7PK3" }; @{"bmcCredentials" = @{"password" = "bmcPassword"; "username" = "root" }; "bmcMacAddress" = "B0:7B:25:EF:5E:B8"; "bootMacAddress" = "B0:7B:25:DE:7F:F4"; "machineName" = "lab00r750mgr1"; "rackSlot" = 2; "serialNumber" = "6P56PK3" }; @{"bmcCredentials" = @{"password" = "bmcPassword"; "username" = "root" }; "bmcMacAddress" = "B0:7B:25:EF:60:20"; "bootMacAddress" = "B0:7B:25:DE:79:FC"; "machineName" = "lab00r750mgr2"; "rackSlot" = 3; "serialNumber" = "7P56PK3" }) })
            $storageapplianceconfigurationdata = @()
            $baremetalmachineconfigurationdata = @()

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
