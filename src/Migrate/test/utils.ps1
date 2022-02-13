function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    $env.srsSubscriptionId = "7c943c1b-5122-4097-90c8-861411bdd574"
    $env.srsTenant = "72f988bf-86f1-41af-91ab-2d7cd011db47"
    $env.srsResourceGroup = "cbtsignoff2105srcrg"
    $env.srsProjectName = "cbtsignoff2105project"
    $env.srsMachineName = "idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea"
    $env.srsMachineId = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015abd5-5788-6477-c69f-bb53618ac3b8"
    $env.srsTestNetworkId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/fancy(migrate)/providers/Microsoft.Network/virtualNetworks/Cbtsignoff2105targetnetwork"
    $env.srsJobId = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationJobs/92457265-7eb3-4391-837c-b71e6cce9334"
    $env.srsJobName = "54f4d887-e6b4-4424-8a15-42e452343552"
    $env.srsProjectId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.Migrate/migrateprojects/cbtsignoff2105project"
    $env.srsResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/fancy(migrate)"
    $env.srsVaultName = "signoff2105app1452vault"
    $env.srsProtectionContainerName = "signoff2105app1c36replicationcontainer"
    $env.srsFabricName = "signoff2105app1c36replicationfabric"
    $env.srsPolicyName = "migratesignoff2105app1452sitepolicy"
    $env.srsMappingName = "containermapping"
    $env.srsProviderName = "signoff2105app1c36dra"
    $env.srsTestPolicy = "migratesignoff2105app1452sitepolicy"
    $env.srsPolicyId = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationPolicies/migratesignoff2105app1452sitepolicy"
    $env.srsTargetPCId = "Microsoft Azure"
    $env.srsDiskType = "Standard_LRS"
    $env.srsDiskId = "6000C290-ce50-48c1-191b-0529758e8c10"
    $env.srsSDSMachineName = "idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015be48-8229-31df-154c-0df27fccb275"
    $env.srsTargetRGId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/fancy(migrate)"
    $env.srsTgtNId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/fancy(migrate)/providers/Microsoft.Network/virtualNetworks/Cbtsignoff2105targetnetwork"
    $env.srsTgtVMName = "singhabh-TestVM"
    $env.srsLicense = "NoLicenseType"
    $env.srsSDSMachineId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.OffAzure/VMwareSites/signoff2105app1452site/machines/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_50153b6a-81fb-6ab4-d3c4-ef2202e03768"
    $env.srsSDSSite = "signoff2105app1452site"
    $env.srsMachineNametempa = "idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015e56d-c36e-c890-fc90-66df3c744ba6"
    $env.srsMachineIdtempb = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015e56d-c36e-c890-fc90-66df3c744ba6"
    $env.srsMachineIdtempc = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_500244e2-10af-9aa9-213c-784ec31288c8"
    $env.srsMachineIdtempd = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea"
    $env.srsMachineNametempe = "idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea"
    $env.srsMachineIdtempf = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea"
    $env.srsMachineIdtempg = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea"
    $env.srsGetSDSMachineID = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.OffAzure/VMwareSites/signoff2105app1452site/machines/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea"
    $env.srsMachinetempz = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea"   
    $env.srsMachinetempy = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015a79d-1383-b5f6-b434-029793d367ea" 
    $env.srsMachinetmpx = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_50153b6a-81fb-6ab4-d3c4-ef2202e03768"
    $env.srsMachinetmpw = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015036c-2cf6-771f-428d-6d686b0aa8ba"
    $env.srsMachinetmpv = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_501598ae-aa6f-aecb-3d4f-09a29c11df2f"
    $env.srsinitinfraResourceGroupName = "cbtsignoff2105srcrg"
    $env.srsinitinfraProjectName = "cbtsignoff2105project"
    $env.srsinitinfraScenario = "agentlessVMware"
    $env.srsinitinfraTargetRegion = "centraluseuap"
    $env.srsSDSMachineId1 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.OffAzure/VMwareSites/signoff2105app1452site/machines/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015abd5-5788-6477-c69f-bb53618ac3b8"
    $env.srsSDSMachineId2 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.OffAzure/VMwareSites/signoff2105app1452site/machines/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015036c-2cf6-771f-428d-6d686b0aa8ba"
    $env.srsSDSMachineId3 = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.OffAzure/VMwareSites/signoff2105app1452site/machines/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015e56d-c36e-c890-fc90-66df3c744ba6"
    $env.srsDiskId1 = "6000C29a-7c98-c890-0575-d0b05e4a8a43"
    $env.srsDiskId2 = "6000C29b-b830-6417-60a5-de171631692d"
    $env.srsDiskId3 = "6000C29b-ffa5-8351-2d43-2602547dd2b7" 
    $env.srsMachinetmpa = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015e56d-c36e-c890-fc90-66df3c744ba6"

    $env.migSubscriptionId = "7c943c1b-5122-4097-90c8-861411bdd574"
    $env.migResourceGroup = "cbtsignoff2105srcrg"
    $env.migProjectName = "cbtsignoff2105project"
    $env.migSolutionName = "Servers-Migration-ServerMigration"
    $env.migSiteName = "signoff2105app1452site"
    $env.migVMwareMachineName = "idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_501501f9-0009-48ca-3030-a16262ba8e5d"
    $env.migRunAsAccountName = "f53e4f58-d091-536f-948e-51bc0745552e"
    $env.migApplianceName = "signoff2105app"
    
    $envFile = 'localEnv.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

