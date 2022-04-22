---
external help file:
Module Name: Az.ContainerAppsApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.containerappsapi/get-azcontainerappsapicontainerapprevisionreplica
schema: 2.0.0
---

# Get-AzContainerAppsApiContainerAppRevisionReplica

## SYNOPSIS
Get a replica for a Container App Revision.

## SYNTAX

### List (Default)
```
Get-AzContainerAppsApiContainerAppRevisionReplica -ContainerAppName <String> -ResourceGroupName <String>
 -RevisionName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppsApiContainerAppRevisionReplica -ContainerAppName <String> -Name <String>
 -ResourceGroupName <String> -RevisionName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppsApiContainerAppRevisionReplica -InputObject <IContainerAppsApiIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a replica for a Container App Revision.

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

### -ContainerAppName
Name of the Container App.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Container App Revision Replica.

```yaml
Type: System.String
Parameter Sets: Get
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

### -RevisionName
Name of the Container App Revision.

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

### -SubscriptionId
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20220301.IReplica

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IContainerAppsApiIdentity>: Identity Parameter
  - `[ContainerAppName <String>]`: Name of the Container App.
  - `[EnvName <String>]`: Name of the Environment.
  - `[EnvironmentName <String>]`: Name of the Managed Environment.
  - `[Id <String>]`: Resource identity path
  - `[ManagedEnvironmentName <String>]`: Name of the Managed Environment.
  - `[Name <String>]`: Name of the Container App AuthConfig.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RevisionName <String>]`: Name of the Container App Revision.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

