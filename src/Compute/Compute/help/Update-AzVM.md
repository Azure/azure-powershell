---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 38917534-49C6-47EA-B815-240F794EE655
online version: https://learn.microsoft.com/powershell/module/az.compute/update-azvm
schema: 2.0.0
---

# Update-AzVM

## SYNOPSIS
Updates the state of an Azure virtual machine.

## SYNTAX

### ResourceGroupNameParameterSetName (Default)
```
Update-AzVM [-ResourceGroupName] <String> -VM <PSVirtualMachine> [-Tag <Hashtable>]
 [-OsDiskWriteAccelerator <Boolean>] [-UltraSSDEnabled <Boolean>] [-MaxPrice <Double>]
 [-EncryptionAtHost <Boolean>] [-ProximityPlacementGroupId <String>] [-VirtualMachineScaleSetId <String>]
 [-HostId <String>] [-CapacityReservationGroupId <String>] [-AsJob] [-NoWait] [-UserData <String>]
 [-HibernationEnabled] [-vCPUCountAvailable <Int32>] [-vCPUCountPerCore <Int32>] [-SecurityType <String>]
 [-EnableVtpm <Boolean>] [-EnableSecureBoot <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ExplicitIdentityParameterSet
```
Update-AzVM [-ResourceGroupName] <String> -VM <PSVirtualMachine> [-Tag <Hashtable>]
 -IdentityType <ResourceIdentityType> [-IdentityId <String[]>] [-OsDiskWriteAccelerator <Boolean>]
 [-UltraSSDEnabled <Boolean>] [-MaxPrice <Double>] [-EncryptionAtHost <Boolean>]
 [-ProximityPlacementGroupId <String>] [-VirtualMachineScaleSetId <String>] [-HostId <String>]
 [-CapacityReservationGroupId <String>] [-AsJob] [-NoWait] [-UserData <String>] [-HibernationEnabled]
 [-vCPUCountAvailable <Int32>] [-vCPUCountPerCore <Int32>] [-SecurityType <String>] [-EnableVtpm <Boolean>]
 [-EnableSecureBoot <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### IdParameterSetName
```
Update-AzVM [-Id] <String> -VM <PSVirtualMachine> [-Tag <Hashtable>] [-OsDiskWriteAccelerator <Boolean>]
 [-UltraSSDEnabled <Boolean>] [-MaxPrice <Double>] [-EncryptionAtHost <Boolean>]
 [-ProximityPlacementGroupId <String>] [-VirtualMachineScaleSetId <String>] [-HostId <String>]
 [-CapacityReservationGroupId <String>] [-AsJob] [-NoWait] [-UserData <String>] [-HibernationEnabled]
 [-vCPUCountAvailable <Int32>] [-vCPUCountPerCore <Int32>] [-SecurityType <String>] [-EnableVtpm <Boolean>]
 [-EnableSecureBoot <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzVM** cmdlet updates the state of an Azure virtual machine to the state of a virtual machine object.

## EXAMPLES

### Example 1: Update a virtual machine
```powershell
Update-AzVM -ResourceGroupName "ResourceGroup11" -VM $VirtualMachine
```

This command updates the virtual machine, $VirtualMachine, in ResourceGroup11.
The command updates it by using the virtual machine object stored in the $VirtualMachine variable.
To obtain a virtual machine object, use the **Get-AzVM** cmdlet.

### Example 2: Update a virtual machine to disable hyperthreading.
```powershell
$resourceGroupName = 'Resource Group Name>'
$vmname = 'Virtual Machine Name';
$domainNameLabel = "d1" + $rgname;
$vCPUsCoreInitial = 2;
$vCPUsAvailableInitial = 4;
$vCPUsCore1 = 1;
$vCPUsAvailable1 = 1;
$vmSize = 'Standard_D4s_v4';

$securePassword = 'Password' | ConvertTo-SecureString -AsPlainText -Force;  
$user = "user";
$cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
$vm = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -Size $vmSize -vCPUCountPerCore $vCPUsCoreInitial -vCPUCountAvailable $vCPUsAvailableInitial;
# The $vm.HardwareProfile.VmSizeProperties.VCPUsPerCore property is 2, and the $vm.HardwareProfile.VmSizeProperties.VCPUsAvailable property is 4.

Update-AzVM -ResourceGroupName $rgname -VM $vm -vCPUCountAvailable $vCPUsAvailable1 -vCPUCountPerCore $vCPUsCore1;
# The $vm.HardwareProfile.VmSizeProperties.VCPUsPerCore property is 1, and the $vm.HardwareProfile.VmSizeProperties.VCPUsAvailable property is 1. 
# Hyperthreading is now disabled for this VM.
```

## PARAMETERS

### -AsJob
Run cmdlet in the background and return a Job to track progress.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CapacityReservationGroupId
Id of the capacity reservation Group that is used to allocate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSecureBoot
Specifies whether secure boot should be enabled on the virtual machine.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableVtpm
Specifies whether vTPM should be enabled on the virtual machine.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EncryptionAtHost
EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine or virtual machine scale set. 
This will enable the encryption for all the disks including Resource/Temp disk at host itself. 

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -HibernationEnabled
The flag that enables or disables hibernation capability on the VM.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -HostId
The Id of Host

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Id
Specifies the resource ID of the virtual machine.

```yaml
Type: System.String
Parameter Sets: IdParameterSetName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityId
Specifies the list of user identities associated with the virtual machine.
The user identity references will be ARM resource IDs in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'

```yaml
Type: System.String[]
Parameter Sets: ExplicitIdentityParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the virtual machine. Valid values are SystemAssigned, UserAssigned, SystemAssignedUserAssigned, and None.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Management.Compute.Models.ResourceIdentityType]
Parameter Sets: ExplicitIdentityParameterSet
Aliases:
Accepted values: SystemAssigned, UserAssigned, SystemAssignedUserAssigned, None

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPrice
Specifies the maximum price you are willing to pay for a low priority VM/VMSS. This price is in US Dollars. This price will be compared with the current low priority price for the VM size. Also, the prices are compared at the time of create/update of low priority VM/VMSS and the operation will only succeed if the maxPrice is greater than the current low priority price. The maxPrice will also be used for evicting a low priority VM/VMSS if the current low priority price goes beyond the maxPrice after creation of VM/VMSS. Possible values are: any decimal value greater than zero. Example: 0.01538.  -1 indicates that the low priority VM/VMSS should not be evicted for price reasons. Also, the default max price is -1 if it is not provided by you.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NoWait
Starts the operation and returns immediately, before the operation is completed. In order to determine if the operation has successfully been completed, use some other mechanism.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OsDiskWriteAccelerator
Specifies whether WriteAccelerator should be enabled or disabled on the OS disk.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProximityPlacementGroupId
The resource id of the Proximity Placement Group to use with this virtual machine.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group of the virtual machine.

```yaml
Type: System.String
Parameter Sets: ResourceGroupNameParameterSetName, ExplicitIdentityParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecurityType
Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. By default, UefiSettings will not be enabled unless this property is set.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Specifies the resources and resource groups can be tagged with a set of name-value pairs.
Adding tags to resources enables you to group resources together across resource groups and to create your own views.
Each resource or resource group can have a maximum of 15 tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UltraSSDEnabled
The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM.
Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine only if this property is enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserData
UserData for the VM, which will be base-64 encoded. Customer should not pass any secrets in here.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -vCPUCountAvailable
Specifies the number of vCPUs available for the VM. When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -vCPUCountPerCore
Specifies the vCPU to physical core ratio. When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list). Setting this property to 1 also means that hyper-threading is disabled.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachineScaleSetId
Id for the Virtual Machine ScaleSet that the virtual machine should be updated to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VM
Specifies a local virtual machine object.
To obtain a virtual machine object, use the Get-AzVM cmdlet.
This virtual machine object contains the updated state for the virtual machine.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases: VMProfile

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### System.Boolean

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSAzureOperationResponse

## NOTES

## RELATED LINKS

[Get-AzVM](./Get-AzVM.md)

[New-AzVM](./New-AzVM.md)

[Remove-AzVM](./Remove-AzVM.md)

[Restart-AzVM](./Restart-AzVM.md)

[Start-AzVM](./Start-AzVM.md)

[Stop-AzVM](./Stop-AzVM.md)

[New-AzVMConfig](./New-AzVMConfig.md)


