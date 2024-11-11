---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappconnectedenvdapr
schema: 2.0.0
---

# Get-AzContainerAppConnectedEnvDapr

## SYNOPSIS
Get a dapr component.

## SYNTAX

### List (Default)
```
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityConnectedEnvironment
```
Get-AzContainerAppConnectedEnvDapr -Name <String> -ConnectedEnvironmentInputObject <IAppIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppConnectedEnvDapr -InputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a dapr component.

## EXAMPLES

### Example 1: List dapr component by connected env name.
```powershell
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

List dapr component by connected env name.

### Example 2: Get a dapr component by name.
```powershell
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Name azps-connectedenvdapr
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Get a dapr component by name.

### Example 3: Get a dapr component.
```powershell
$connectedenv = Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv
Get-AzContainerAppConnectedEnvDapr -ConnectedEnvironmentInputObject $connectedenv -Name azps-connectedenvdapr
```

```output
Name                  ComponentType        IgnoreError InitTimeout ResourceGroupName   Version
----                  -------------        ----------- ----------- -----------------   -------
azps-connectedenvdapr state.azure.cosmosdb False       50s         azps_test_group_app v1
```

Get a dapr component.

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
Name of the connected environment.

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
Name of the Dapr Component.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityConnectedEnvironment
Aliases: DaprName

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IDaprComponent

## NOTES

## RELATED LINKS
