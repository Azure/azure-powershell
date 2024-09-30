---
external help file:
Module Name: Az.StandbyPool
online version: https://learn.microsoft.com/powershell/module/az.standbypool/get-azstandbyvmpoolstatus
schema: 2.0.0
---

# Get-AzStandbyVMPoolStatus

## SYNOPSIS
Get a StandbyVirtualMachinePoolRuntimeViewResource

## SYNTAX

### Get (Default)
```
Get-AzStandbyVMPoolStatus -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStandbyVMPoolStatus -InputObject <IStandbyPoolIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityStandbyVirtualMachinePool
```
Get-AzStandbyVMPoolStatus -StandbyVirtualMachinePoolInputObject <IStandbyPoolIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzStandbyVMPoolStatus -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a StandbyVirtualMachinePoolRuntimeViewResource

## EXAMPLES

### Example 1: Get runtime view of a standby virtual machine pool
```powershell
Get-AzStandbyVMPoolStatus `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-ResourceGroupName test-standbypool `
-Name testPool
```

```output
Id                           : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Standb
                               yPool/standbyVirtualMachinePools/testPool/runtimeViews/latest
InstanceCountSummary         : {{
                                 "instanceCountsByState": [
                                   {
                                     "state": "Creating",
                                     "count": 0
                                   },
                                   {
                                     "state": "Starting",
                                     "count": 0
                                   },
                                   {
                                     "state": "Running",
                                     "count": 1
                                   },
                                   {
                                     "state": "Deallocating",
                                     "count": 0
                                   },
                                   {
                                     "state": "Deallocated",
                                     "count": 0
                                   },
                                   {
                                     "state": "Deleting",
                                     "count": 0
                                   }
                                 ]
                               }}
Name                         : latest
ProvisioningState            : Succeeded
ResourceGroupName            : test-standbypool
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.StandbyPool/standbyVirtualMachinePools/runtimeViews
```

Above command is getting a runtime veiw of standby virtual machine pool.

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
Parameter Sets: Get, List
Aliases:

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StandbyVirtualMachinePoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyPoolIdentity
Parameter Sets: GetViaIdentityStandbyVirtualMachinePool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.StandbyPool.Models.IStandbyVirtualMachinePoolRuntimeViewResource

## NOTES

## RELATED LINKS

