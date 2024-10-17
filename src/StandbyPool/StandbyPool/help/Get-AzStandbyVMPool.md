---
external help file: Az.StandbyPool-help.xml
Module Name: Az.StandbyPool
online version: https://learn.microsoft.com/powershell/module/az.standbypool/get-azstandbyvmpool
schema: 2.0.0
---

# Get-AzStandbyVMPool

## SYNOPSIS
Get a StandbyVirtualMachinePoolResource

## SYNTAX

### List (Default)
```
Get-AzStandbyVMPool [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzStandbyVMPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzStandbyVMPool -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStandbyVMPool -InputObject <IStandbyPoolIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a StandbyVirtualMachinePoolResource

## EXAMPLES

### Example 1: get a standby virutal machine pool
```powershell
Get-AzStandbyVMPool  `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-ResourceGroupName test-standbypool `
-Name testPool
```

```output
AttachedVirtualMachineScaleSetId  : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss
ElasticityProfileMaxReadyCapacity : 1
ElasticityProfileMinReadyCapacity : 1
Id                                : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.StandbyPool/standbyVirtualMachinePools/testPool
Location                          : eastus
Name                              : testPool
ProvisioningState                 : Succeeded
ResourceGroupName                 : test-standbypool
SystemDataCreatedAt               : 4/10/2024 7:15:23 PM
SystemDataCreatedBy               : dev@microsoft.com
SystemDataCreatedByType           : User
SystemDataLastModifiedAt          : 4/10/2024 7:15:23 PM
SystemDataLastModifiedBy          : dev@microsoft.com
SystemDataLastModifiedByType      : User
Tag                               : {
                                    }
Type                              : microsoft.standbypool/standbyvirtualmachinepools
VirtualMachineState               : Running
```

Above command is getting a standby virtual machine pool with given subscription id, and given resource group.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyPoolIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the standby virtual machine pool

```yaml
Type: System.String
Parameter Sets: Get
Aliases: StandbyVirtualMachinePoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyPoolIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyVirtualMachinePoolResource

## NOTES

## RELATED LINKS
