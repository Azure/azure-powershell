---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 63D48BA4-EE80-4740-90B9-0EE05B3F6536
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azvmssvm
schema: 2.0.0
---

# Get-AzVmssVM

## SYNOPSIS
Gets the properties of a VMSS virtual machine.

## SYNTAX

### DefaultParameter (Default)
```
Get-AzVmssVM [[-ResourceGroupName] <String>] [[-VMScaleSetName] <String>] [[-InstanceId] <String>] [-UserData]
 [-ResiliencyView] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### FriendMethod
```
Get-AzVmssVM [[-ResourceGroupName] <String>] [[-VMScaleSetName] <String>] [[-InstanceId] <String>]
 [-InstanceView] [-UserData] [-ResiliencyView] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzVmssVM** cmdlet gets the model view and instance view of a Virtual Machine Scale Set (VMSS) virtual machine.
The model view is the user specified properties of the virtual machine.
The instance view is the instance level status of the virtual machine.
Specify the *Status* parameter to get only the instance view of a virtual machine.

## EXAMPLES

### Example 1: Get the properties of a VMSS virtual machine
```powershell
Get-AzVmssVM -ResourceGroupName "Group001" -VMScaleSetName "VMSS001"
```

This command gets the properties of the VMSS virtual machine named VMSS001 that belongs to the resource group named Group001.
Since the command does not specify the *InstanceView* switch parameter, the cmdlet gets the model view of the virtual machine.

### Example 2: Get the model view properties of a VMSS virtual machine
```powershell
Get-AzVmssVM -ResourceGroupName "Group002" -VMScaleSetName "VMSS004" -InstanceId $ID
```

This command gets the properties of the VMSS virtual machine named VMSS004 that belongs to the resource group named Group002.
The command gets the instance ID stored in the variable $ID for which to get the model view.

### Example 3: Get the instance view properties of a VMSS virtual machine
```powershell
Get-AzVmssVM -InstanceView  -ResourceGroupName $rgname  -VMScaleSetName $vmssName -InstanceId $ID
```

This command gets the properties of the VMSS virtual machine named VMSS004 that belongs to the resource group named Group002.
Since the command specifies the *InstanceView* switch parameter, the cmdlet gets the instance view of the virtual machine.
The command gets the instance ID stored in the variable $ID for which to get the instance view.

### Example 4: Get the resilient VM deletion status of a VMSS virtual machine
```powershell
Get-AzVmssVM -ResiliencyView -ResourceGroupName "Group001" -VMScaleSetName "VMSS001" -InstanceId "0"
```

This command gets the resilient VM deletion status for the VMSS virtual machine with instance ID 0 in the scale set VMSS001.
The ResiliencyView parameter retrieves the ResilientVMDeletionStatus property, which indicates whether automatic delete retries are in progress, failed, or not started.
This is useful for monitoring the Resilient Delete feature status.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -InstanceId
Specifies the instance ID for which to get the model view.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InstanceView
Indicates that this cmdlet gets only the instance view of the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: FriendMethod
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the Resource Group of the VMSS.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserData
UserData for the Vmss, which will be base-64 encoded. Customer should not pass any secrets in here.

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

### -ResiliencyView
Gets the resilient VM deletion status for the VM, which indicates whether retries are in progress, failed, or not started. This parameter is only supported when retrieving a specific VM instance (when InstanceId is provided).

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

### -VMScaleSetName
Specifies the name of the VMSS.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSetVM

## NOTES

## RELATED LINKS

[Set-AzVmssVM](./Set-AzVmssVM.md)

[Get-AzVmss](./Get-AzVmss.md)
