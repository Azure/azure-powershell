---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappconnectedenvstorage
schema: 2.0.0
---

# Get-AzContainerAppConnectedEnvStorage

## SYNOPSIS
Get storage for a connectedEnvironment.

## SYNTAX

### List (Default)
```
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppConnectedEnvStorage -InputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityConnectedEnvironment
```
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentInputObject <IAppIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get storage for a connectedEnvironment.

## EXAMPLES

### Example 1: List storage by connected env name.
```powershell
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

List storage by connected env name.

### Example 2: Get storage for a connectedEnvironment by name.
```powershell
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a connectedEnvironment by name.

### Example 3: Get storage for a connectedEnvironment.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
Get-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentInputObject $connectedenv -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a connectedEnvironment.

## PARAMETERS

### -ConnectedEnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: GetViaIdentityConnectedEnvironment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectedEnvironmentName
Name of the Environment.

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
Name of the storage.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityConnectedEnvironment
Aliases: StorageName

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IConnectedEnvironmentStorage

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IConnectedEnvironmentStoragesCollection

## NOTES

## RELATED LINKS

