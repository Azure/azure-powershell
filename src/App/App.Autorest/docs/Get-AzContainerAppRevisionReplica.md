---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerapprevisionreplica
schema: 2.0.0
---

# Get-AzContainerAppRevisionReplica

## SYNOPSIS
Get a replica for a Container App Revision.

## SYNTAX

### List (Default)
```
Get-AzContainerAppRevisionReplica -ContainerAppName <String> -ResourceGroupName <String>
 -RevisionName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppRevisionReplica -ContainerAppName <String> -Name <String> -ResourceGroupName <String>
 -RevisionName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppRevisionReplica -InputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityContainerApp
```
Get-AzContainerAppRevisionReplica -ContainerAppInputObject <IAppIdentity> -Name <String>
 -RevisionName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityRevision
```
Get-AzContainerAppRevisionReplica -Name <String> -RevisionInputObject <IAppIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a replica for a Container App Revision.

## EXAMPLES

### Example 1: List replica for a Container App Revision.
```powershell
Get-AzContainerAppRevisionReplica -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -RevisionName azps-containerapp-1--xdmhk31
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

List replica for a Container App Revision.

### Example 2: Get a replica for a Container App Revision.
```powershell
Get-AzContainerAppRevisionReplica -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -RevisionName azps-containerapp-1--xdmhk31 -Name azps
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

Get a replica for a Container App Revision.

### Example 3: Get a replica for a Container App Revision.
```powershell
$obj = Get-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app

Get-AzContainerAppRevisionReplica -RevisionInputObject $obj -Name azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

Get a replica for a Container App Revision.

### Example 4: Get a replica for a Container App Revision.
```powershell
$obj = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1

Get-AzContainerAppRevisionReplica -ContainerAppInputObject $obj -RevisionName azps-containerapp-1--xdmhk31 -Name azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t
```

```output
Name                                        ResourceGroupName
----                                        -----------------
azps-containerapp-1--xdmhk31-7fdbf895c6-rh65t azps_test_group_app
```

Get a replica for a Container App Revision.

## PARAMETERS

### -ContainerAppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: GetViaIdentityContainerApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
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
Parameter Sets: Get, GetViaIdentityContainerApp, GetViaIdentityRevision
Aliases: ReplicaName

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

### -RevisionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: GetViaIdentityRevision
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RevisionName
Name of the Container App Revision.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityContainerApp, List
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IReplica

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IReplicaCollection

## NOTES

## RELATED LINKS

