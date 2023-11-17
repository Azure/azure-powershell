---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerapprevision
schema: 2.0.0
---

# Get-AzContainerAppRevision

## SYNOPSIS
Get a revision of a Container App.

## SYNTAX

### List (Default)
```
Get-AzContainerAppRevision -ContainerAppName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppRevision -ContainerAppName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppRevision -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityContainerApp
```
Get-AzContainerAppRevision -ContainerAppInputObject <IAppIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a revision of a Container App.

## EXAMPLES

### Example 1: List revision of a Container App.
```powershell
Get-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

```output
Name                         Active TrafficWeight ProvisioningState ResourceGroupName
----                         ------ ------------- ----------------- -----------------
azps-containerapp-1--6a9svx2 True   100           Provisioned       azps_test_group_app
```

List revision of a Container App.

### Example 2: Get a revision by name.
```powershell
Get-AzContainerAppRevision -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name azps-containerapp-1--6a9svx2
```

```output
Name                         Active TrafficWeight ProvisioningState ResourceGroupName
----                         ------ ------------- ----------------- -----------------
azps-containerapp-1--6a9svx2 True   100           Provisioned       azps_test_group_app
```

Get a revision by name.

### Example 3: Get a revision by Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Get-AzContainerAppRevision -ContainerAppInputObject $containerapp -Name azps-containerapp-1--6a9svx2
```

```output
Name                         Active TrafficWeight ProvisioningState ResourceGroupName
----                         ------ ------------- ----------------- -----------------
azps-containerapp-1--6a9svx2 True   100           Provisioned       azps_test_group_app
```

Get a revision by Container App.

## PARAMETERS

### -ContainerAppInputObject
Identity Parameter
To construct, see NOTES section for CONTAINERAPPINPUTOBJECT properties and create a hash table.

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

### -Filter
The filter to apply on the operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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
Name of the Container App Revision.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityContainerApp
Aliases: RevisionName

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRevision

## NOTES

## RELATED LINKS

