### Example 1: Create virtual machine
```powershell
$networkAttachment = @{
    AttachedNetworkId = "attachedNetworkID"
    IpAllocationMethod = "Dynamic"
}
$hint = @{
    HintType = "Affinity"
    SchedulingExecution = "schedulingExecution"
    Scope = "scope"
    ResourceId = "resourceId"
}
$sshPublicKey = @{
    KeyData = "ssh-rsa aaaKyfsdx= fakekey@vm"
}

$securePassword = ConvertTo-SecureString "password" -asplaintext -force

New-AzNetworkCloudVirtualMachine -Name vmName  -ResourceGroupName resourceGroup -AdminUsername adminUsername -CloudServiceNetworkAttachmentAttachedNetworkId csnAttachedNetworkId -CloudServiceNetworkAttachmentIPAllocationMethod ipAllocationMethod -CpuCore cpuCore -ExtendedLocationName extendedLocationName -ExtendedLocationType "Custom" -Location location -SubscriptionId subscriptionId -MemorySizeGb memorySizeGb -OSDiskSizeGb osDiskSizeGb -VMImage vmImage -BootMethod bootMethod -CloudServiceNetworkAttachmentDefaultGateway defaultGateway -CloudServiceNetworkAttachmentName csnAttachmentName -IsolateEmulatorThread isolateEmulatorThread -NetworkAttachment $networkAttachment -NetworkData networkData -OSDiskCreateOption osDiskCreationOption -OSDiskDeleteOption osDiskDeleteOption -PlacementHint $hint -SshPublicKey $sshPublicKey -Tag @{tags = "tags"} -UserData userData -VirtioInterface virtioInterface -VMDeviceModel vmDeviceModel -VMImageRepositoryCredentialsUsername registryUsername -VMImageRepositoryCredentialsPassword $securePassword -VMImageRepositoryCredentialsRegistryUrl registryUrl
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataL
                                                                                                                                                  astModified
                                                                                                                                                  ByType
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             -----------
eastus   default 7/07/2023 21:32:03 <user>                 User                    07/07/2023 21:32:41      <identity>                           Application
```

This command creates a virtual machine.
