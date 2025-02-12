---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappsourcecontrol
schema: 2.0.0
---

# Get-AzContainerAppSourceControl

## SYNOPSIS
Get a SourceControl of a Container App.

## SYNTAX

### List (Default)
```
Get-AzContainerAppSourceControl -ContainerAppName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppSourceControl -ContainerAppName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppSourceControl -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityContainerApp
```
Get-AzContainerAppSourceControl -ContainerAppInputObject <IAppIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a SourceControl of a Container App.

## EXAMPLES

### Example 1: List SourceControl of a Container App.
```powershell
Get-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

List SourceControl of a Container App.

### Example 2: Get a SourceControl of a Container App by name.
```powershell
Get-AzContainerAppSourceControl -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app -Name current
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Get a SourceControl of a Container App by name.

### Example 3: Get a SourceControl of a Container App.
```powershell
$containerapp = Get-AzContainerApp -ResourceGroupName azps_test_group_app -Name azps-containerapp-1
Get-AzContainerAppSourceControl -ContainerAppInputObject $containerapp -Name current
```

```output
Branch Name    RepoUrl                                 RegistryInfoRegistryUserName ResourceGroupName
------ ----    -------                                 ---------------------------- -----------------
main   current https://github.com/lijinpei2008/ghatest azpscontainerregistry        azps_test_group_app
```

Get a SourceControl of a Container App.

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
Name of the Container App SourceControl.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityContainerApp
Aliases: SourceControlName

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.ISourceControl

## NOTES

## RELATED LINKS

