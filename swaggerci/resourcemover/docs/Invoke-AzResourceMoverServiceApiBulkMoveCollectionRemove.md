---
external help file:
Module Name: Az.ResourceMoverServiceApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.resourcemoverserviceapi/invoke-azresourcemoverserviceapibulkmovecollectionremove
schema: 2.0.0
---

# Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove

## SYNOPSIS
Removes the set of move resources included in the request body from move collection.
The orchestration is done by service.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

## SYNTAX

### BulkExpanded (Default)
```
Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove -MoveCollectionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-MoveResource <String[]>]
 [-MoveResourceInputType <MoveResourceInputType>] [-ValidateOnly] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Bulk
```
Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove -MoveCollectionName <String>
 -ResourceGroupName <String> -Body <IBulkRemoveRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BulkViaIdentity
```
Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove -InputObject <IResourceMoverServiceApiIdentity>
 -Body <IBulkRemoveRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### BulkViaIdentityExpanded
```
Invoke-AzResourceMoverServiceApiBulkMoveCollectionRemove -InputObject <IResourceMoverServiceApiIdentity>
 [-MoveResource <String[]>] [-MoveResourceInputType <MoveResourceInputType>] [-ValidateOnly]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Removes the set of move resources included in the request body from move collection.
The orchestration is done by service.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Body
Defines the request body for bulk remove of move resources operation.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceMoverServiceApi.Models.Api20210801.IBulkRemoveRequest
Parameter Sets: Bulk, BulkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceMoverServiceApi.Models.IResourceMoverServiceApiIdentity
Parameter Sets: BulkViaIdentity, BulkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MoveCollectionName
.

```yaml
Type: System.String
Parameter Sets: Bulk, BulkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveResource
Gets or sets the list of resource Id's, by default it accepts move resource id's unless the input type is switched via moveResourceInputType property.

```yaml
Type: System.String[]
Parameter Sets: BulkExpanded, BulkViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveResourceInputType
Defines the move resource input type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResourceMoverServiceApi.Support.MoveResourceInputType
Parameter Sets: BulkExpanded, BulkViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
.

```yaml
Type: System.String
Parameter Sets: Bulk, BulkExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription ID.

```yaml
Type: System.String
Parameter Sets: Bulk, BulkExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateOnly
Gets or sets a value indicating whether the operation needs to only run pre-requisite.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BulkExpanded, BulkViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResourceMoverServiceApi.Models.Api20210801.IBulkRemoveRequest

### Microsoft.Azure.PowerShell.Cmdlets.ResourceMoverServiceApi.Models.IResourceMoverServiceApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResourceMoverServiceApi.Models.Api20210801.IOperationStatus

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IBulkRemoveRequest>: Defines the request body for bulk remove of move resources operation.
  - `[MoveResource <String[]>]`: Gets or sets the list of resource Id's, by default it accepts move resource id's unless the input type is switched via moveResourceInputType property.
  - `[MoveResourceInputType <MoveResourceInputType?>]`: Defines the move resource input type.
  - `[ValidateOnly <Boolean?>]`: Gets or sets a value indicating whether the operation needs to only run pre-requisite.

INPUTOBJECT <IResourceMoverServiceApiIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MoveCollectionName <String>]`: The Move Collection Name.
  - `[MoveResourceName <String>]`: The Move Resource Name.
  - `[ResourceGroupName <String>]`: The Resource Group Name.
  - `[SubscriptionId <String>]`: The Subscription ID.

## RELATED LINKS

