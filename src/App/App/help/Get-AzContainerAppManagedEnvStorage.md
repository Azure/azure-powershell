---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappmanagedenvstorage
schema: 2.0.0
---

# Get-AzContainerAppManagedEnvStorage

## SYNOPSIS
Get storage for a managedEnvironment.

## SYNTAX

### List (Default)
```
Get-AzContainerAppManagedEnvStorage -EnvName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppManagedEnvStorage -EnvName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentityManagedEnvironment
```
Get-AzContainerAppManagedEnvStorage -Name <String> -ManagedEnvironmentInputObject <IAppIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppManagedEnvStorage -InputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get storage for a managedEnvironment.

## EXAMPLES

### Example 1: List storage for a managedEnvironment.
```powershell
Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

List storage for a managedEnvironment.

### Example 2: Get storage for a managedEnvironment by name.
```powershell
Get-AzContainerAppManagedEnvStorage -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a managedEnvironment by name.

### Example 3: Get storage for a managedEnvironment.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app
Get-AzContainerAppManagedEnvStorage -ManagedEnvironmentInputObject $managedenv -Name azpstestsa
```

```output
Name       AzureFileAccessMode AzureFileAccountName AzureFileShareName ResourceGroupName
----       ------------------- -------------------- ------------------ -----------------
azpstestsa ReadWrite           azpstestsa           azps-rw-sharename  azps_test_group_app
```

Get storage for a managedEnvironment.

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

### -EnvName
Name of the Environment.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
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

### -ManagedEnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: GetViaIdentityManagedEnvironment
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
Parameter Sets: Get, GetViaIdentityManagedEnvironment
Aliases: StorageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IManagedEnvironmentStorage

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IManagedEnvironmentStoragesCollection

## NOTES

## RELATED LINKS
