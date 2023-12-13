---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/start-azdevcenteradminpoolhealthcheck
schema: 2.0.0
---

# Start-AzDevCenterAdminPoolHealthCheck

## SYNOPSIS
Triggers a refresh of the pool status.

## SYNTAX

### Run (Default)
```
Start-AzDevCenterAdminPoolHealthCheck -PoolName <String> -ProjectName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RunViaIdentity
```
Start-AzDevCenterAdminPoolHealthCheck -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Triggers a refresh of the pool status.

## EXAMPLES

### EXAMPLE 1
```
Start-AzDevCenterAdminPoolHealthCheck -ResourceGroupName testRg -PoolName DevPool -ProjectName DevProject
```

### EXAMPLE 2
```
$pool = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "PoolName" = "DevPool"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Start-AzDevCenterAdminPoolHealthCheck -InputObject $pool
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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
Type: IDevCenterIdentity
Parameter Sets: RunViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PoolName
Name of the pool.

```yaml
Type: String
Parameter Sets: Run
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The name of the project.

```yaml
Type: String
Parameter Sets: Run
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
Type: String
Parameter Sets: Run
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: String
Parameter Sets: Run
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
## OUTPUTS

### System.Boolean
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IDevCenterIdentity\>: Identity Parameter
  \[AttachedNetworkConnectionName \<String\>\]: The name of the attached NetworkConnection.
  \[CatalogName \<String\>\]: The name of the Catalog.
  \[DevBoxDefinitionName \<String\>\]: The name of the Dev Box definition.
  \[DevCenterName \<String\>\]: The name of the devcenter.
  \[EnvironmentDefinitionName \<String\>\]: The name of the Environment Definition.
  \[EnvironmentTypeName \<String\>\]: The name of the environment type.
  \[GalleryName \<String\>\]: The name of the gallery.
  \[Id \<String\>\]: Resource identity path
  \[ImageName \<String\>\]: The name of the image.
  \[Location \<String\>\]: The Azure region
  \[NetworkConnectionName \<String\>\]: Name of the Network Connection that can be applied to a Pool.
  \[OperationId \<String\>\]: The ID of an ongoing async operation
  \[PoolName \<String\>\]: Name of the pool.
  \[ProjectName \<String\>\]: The name of the project.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ScheduleName \<String\>\]: The name of the schedule that uniquely identifies it.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[TaskName \<String\>\]: The name of the Task.
  \[VersionName \<String\>\]: The version of the image.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.devcenter/start-azdevcenteradminpoolhealthcheck](https://learn.microsoft.com/powershell/module/az.devcenter/start-azdevcenteradminpoolhealthcheck)

