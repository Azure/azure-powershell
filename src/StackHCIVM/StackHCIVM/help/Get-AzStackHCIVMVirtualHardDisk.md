---
external help file: Az.StackHCIVM-help.xml
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmvirtualharddisk
schema: 2.0.0
---

# Get-AzStackHCIVMVirtualHardDisk

## SYNOPSIS
Gets a virtual hard disk

## SYNTAX

### List1 (Default)
```
Get-AzStackHCIVMVirtualHardDisk [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzStackHCIVMVirtualHardDisk -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzStackHCIVMVirtualHardDisk -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzStackHCIVMVirtualHardDisk [-ResourceId <String>] [-DefaultProfile <PSObject>] [-NoWait]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a virtual hard disk

## EXAMPLES

### EXAMPLE 1
```
Get-AzStackHCIVMVirtualHardDisk -Name  "testVhd" -ResourceGroupName "test-rg"
```

### EXAMPLE 2
```
Get-AzStackHCIVMVirtualHardDisk -ResourceGroupName "test-rg"
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the virtual hard disk

```yaml
Type: System.String
Parameter Sets: Get
Aliases: VirtualHardDiskName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ByResourceId
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The ARM ID of the virtual hard disk.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable, -ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IVirtualHardDisks
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmvirtualharddisk](https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmvirtualharddisk)
