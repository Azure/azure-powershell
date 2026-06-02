function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
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
    $env.migMachineId = "/Subscriptions/6b72781d-4550-419b-a56e-44055341a88e/resourceGroups/cbtgqlsrcrg/providers/Microsoft.RecoveryServices/vaults/ecygqlapp4055vault/replicationFabrics/ecygqlapp2fd6replicationfabric/replicationProtectionContainers/ecygqlapp2fd6replicationcontainer/replicationMigrationItems/idclab-vcen8-fareast-corp-micro-d2408603-48eb-434f-8cd5-f34828328495_5037d276-0d72-7b96-7f6d-2ce50a4c05e5"
    $env.migMachineId2 = "/Subscriptions/6b72781d-4550-419b-a56e-44055341a88e/resourceGroups/cbtgqlsrcrg/providers/Microsoft.RecoveryServices/vaults/ecygqlapp4055vault/replicationFabrics/ecygqlapp2fd6replicationfabric/replicationProtectionContainers/ecygqlapp2fd6replicationcontainer/replicationMigrationItems/idclab-vcen8-fareast-corp-micro-d2408603-48eb-434f-8cd5-f34828328495_5037a8fa-3594-21fd-5221-ca92924a7912"
    $env.migTestNetworkId = "/subscriptions/6b72781d-4550-419b-a56e-44055341a88e/resourceGroups/targetrg-ecy/providers/Microsoft.Network/virtualNetworks/vnet-ecy"
    $env.srsJobId = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationJobs/92457265-7eb3-4391-837c-b71e6cce9334"
    $env.srsJobName = "54f4d887-e6b4-4424-8a15-42e452343552"
    $env.migProjectId = "/subscriptions/6b72781d-4550-419b-a56e-44055341a88e/resourceGroups/cbtgqlsrcrg/providers/Microsoft.Migrate/migrateprojects/cbtecygqlproj"
    $env.srsResourceGroupId = "/subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/fancy(migrate)"
    $env.srsVaultName = "signoff2105app1452vault"
    $env.migVaultName = "ecygqlapp4055vault"
    $env.migFabricName = "ecygqlapp4048replicationfabric"
    $env.migPolicyName= "migrateecygqlapp4055sitepolicy"
    $env.migProtectionContainerName= "ecygqlapp2fd6replicationcontainer"
    $env.srsProtectionContainerName = "signoff2105app1c36replicationcontainer"
    $env.srsFabricName = "signoff2105app1c36replicationfabric"
    $env.srsPolicyName = "migratesignoff2105app1452sitepolicy"
    $env.srsMappingName = "containermapping"
    $env.migProviderName = "ecygqlapp2fd6dra"
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
    $env.migGetSDSMachineID = "/subscriptions/6b72781d-4550-419b-a56e-44055341a88e/resourceGroups/cbtgqlsrcrg/providers/Microsoft.OffAzure/VMwareSites/ecygqlapp4055site/machines/idclab-vcen8-fareast-corp-micro-d2408603-48eb-434f-8cd5-f34828328495_5037d276-0d72-7b96-7f6d-2ce50a4c05e5"
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
    $env.srsDiskId1 = "6000C298-484c-efb1-c52b-7d782a6e492c"
    $env.srsDiskId2 = "6000C29b-b830-6417-60a5-de171631692d"
    $env.srsDiskId3 = "6000C29b-ffa5-8351-2d43-2602547dd2b7"
    $env.srsMachinetmpa = "/Subscriptions/7c943c1b-5122-4097-90c8-861411bdd574/resourceGroups/cbtsignoff2105srcrg/providers/Microsoft.RecoveryServices/vaults/signoff2105app1452vault/replicationFabrics/signoff2105app1c36replicationfabric/replicationProtectionContainers/signoff2105app1c36replicationcontainer/replicationMigrationItems/idclab-vcen67-fareast-corp-micr-6f5e3b29-29ad-4e62-abbd-6cd33c4183ef_5015e56d-c36e-c890-fc90-66df3c744ba6"

    $env.migSubscriptionId = "6b72781d-4550-419b-a56e-44055341a88e"
    $env.migResourceGroup = "cbtgqlsrcrg"
    $env.migResourceGroup2= "cbtsignoff2105srcrg"
    $env.migProjectName = "cbtecygqlproj"
    $env.migSolutionName = "Servers-Migration-ServerMigration"
    $env.migSiteName = "ecygqlapp4055site"
    $env.migVMwareMachineName = "idclab-vcen8-fareast-corp-micro-d2408603-48eb-434f-8cd5-f34828328495_5037d276-0d72-7b96-7f6d-2ce50a4c05e5"
    $env.migRunAsAccountName = "9dd70654-9f18-5dcc-993a-c950ac540221"
    $env.migApplianceName = "ecygqlapp"

    $env.hciSubscriptionId = "0daa57b3-f823-4921-a09a-33c048e64022"
    $env.hciMigResourceGroup = "aszmige2etestCIRG01"
    $env.hciTargetRgSubId = "586c20df-c465-4f10-8673-65aa4859e7ca"
    $env.hciProjectName = "aszmigtest1c100b4"
    $env.hciSourceApplianceName = "HyperV-1c100b4"
    $env.hciTargetApplianceName = "asz-1c100b4"
    $env.hciSourceReplicationFabricName = "HyperV-1c100b4409breplicationfabric"
    $env.hciReplicationVaultName = "aszmigtest1c100b4replicationvault"
    $env.hciTgtVirtualSwitchId = "/subscriptions/0daa57b3-f823-4921-a09a-33c048e64022/resourceGroups/EDGECI-REGISTRATION-rr1s46r1706-LtmqC7DF/providers/Microsoft.AzureStackHCI/logicalnetworks/lnet-s46r1706-cl"
    $env.hciTgtStoragePathId = "/subscriptions/0daa57b3-f823-4921-a09a-33c048e64022/resourceGroups/EDGECI-REGISTRATION-rr1s46r1706-LtmqC7DF/providers/Microsoft.AzureStackHCI/storageContainers/UserStorage1-724e432974de4c6180b3a90ecf0f34e3"
    $env.hciSDSMachineId1 = "/subscriptions/0daa57b3-f823-4921-a09a-33c048e64022/resourceGroups/aszmige2etestCIRG01/providers/Microsoft.OffAzure/HyperVSites/HyperV-1c100b4site/machines/b180ad03-00eb-45a8-ad8a-33a44825180f"
    $env.hciTgtVMName1 =  "hciVm1"
    $env.hciDiskId1 = "Microsoft:B180AD03-00EB-45A8-AD8A-33A44825180F\\0BB0F245-C881-46F0-B18E-887820003078\\0\\0\\L"
    $env.hciProtectedItem1 = "/subscriptions/0daa57b3-f823-4921-a09a-33c048e64022/resourceGroups/aszmige2etestCIRG01/providers/Microsoft.DataReplication/replicationVaults/aszmigtest1c100b4replicationvault/protectedItems/b180ad03-00eb-45a8-ad8a-33a44825180f"
    $env.hciSDSMachineId2 = "/subscriptions/0daa57b3-f823-4921-a09a-33c048e64022/resourceGroups/aszmige2etestCIRG01/providers/Microsoft.OffAzure/HyperVSites/HyperV-1c100b4site/machines/0fa67f11-3c1e-491b-a459-372141fb3b7f"
    $env.hciTgtVMName2 = "hciVm2"
    $env.hciDiskId2 = "Microsoft:0FA67F11-3C1E-491B-A459-372141FB3B7F\\C595A4E2-0334-4CC9-BFC9-61F9D56F75FF\\0\\0\\L"
    $env.hciProtectedItem2 = "/subscriptions/0daa57b3-f823-4921-a09a-33c048e64022/resourceGroups/aszmige2etestCIRG01/providers/Microsoft.DataReplication/replicationVaults/aszmigtest1c100b4replicationvault/protectedItems/0fa67f11-3c1e-491b-a459-372141fb3b7f"
    $env.hciNicId2 = "Microsoft:0FA67F11-3C1E-491B-A459-372141FB3B7F\\C284C44D-B38B-4C7A-9B95-69AB6E275F4F"
    $env.hciJobName = "5348d490-92d0-424b-9fe1-6d126cbcee0e"
    $env.hciJobId = "/subscriptions/0daa57b3-f823-4921-a09a-33c048e64022/resourceGroups/aszmige2etestCIRG01/providers/Microsoft.DataReplication/replicationVaults/aszmigtest1c100b4replicationvault/jobs/5348d490-92d0-424b-9fe1-6d126cbcee0e"
    
    $envFile = 'localEnv.json'
    $env.srsMachineId5 = "/Subscriptions/6b72781d-4550-419b-a56e-44055341a88e/resourceGroups/cbtgqlsrcrg/providers/Microsoft.RecoveryServices/vaults/ecygqlapp4055vault/replicationFabrics/ecygqlapp2fd6replicationfabric/replicationProtectionContainers/ecygqlapp2fd6replicationcontainer/replicationMigrationItems/idclab-vcen8-fareast-corp-micro-d2408603-48eb-434f-8cd5-f34828328495_50375aa1-275f-5306-3ded-6214508d3d6a"
    $env.srsSubscriptionId5 = "6b72781d-4550-419b-a56e-44055341a88e"
    $env.sqlServerLicenseType = "PAYG"
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

