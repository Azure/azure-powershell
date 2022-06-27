---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az.app/get-azcontainerapp
schema: 2.0.0
---

# Get-AzContainerApp

## SYNOPSIS
Get the properties of a Container App.

## SYNTAX

### List (Default)
```
Get-AzContainerApp [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerApp -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### List1
```
Get-AzContainerApp -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the properties of a Container App.

## EXAMPLES

### Example 1: List the properties of a Container App.
```powershell
Get-AzContainerApp
```

```output
Location       Name               ResourceGroupName
--------       ----               -----------------
Canada Central azcli-containerapp azcli_gp
Canada Central azps-containerapp  azpstest_gp
```

List the properties of a Container App.

### Example 2: Get the properties of a Container App by Resource Group.
```powershell
Get-AzContainerApp -ResourceGroupName azpstest_gp
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Get the properties of a Container App by Resource Group.

### Example 3: Get the properties of a Container App by name.
```powershell
Get-AzContainerApp -ResourceGroupName azpstest_gp -Name azps-containerapp
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Get the properties of a Container App by name.

## PARAMETERS

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
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ContainerAppName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
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

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IContainerApp

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAppIdentity>: Identity Parameter
  - `[AuthConfigName <String>]`: Name of the Container App AuthConfig.
  - `[CertificateName <String>]`: Name of the Certificate.
  - `[ComponentName <String>]`: Name of the Dapr Component.
  - `[ContainerAppName <String>]`: Name of the Container App.
  - `[EnvironmentName <String>]`: Name of the Managed Environment.
  - `[Id <String>]`: Resource identity path
  - `[ReplicaName <String>]`: Name of the Container App Revision Replica.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RevisionName <String>]`: Name of the Container App Revision.
  - `[SourceControlName <String>]`: Name of the Container App SourceControl.
  - `[StorageName <String>]`: Name of the storage.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

