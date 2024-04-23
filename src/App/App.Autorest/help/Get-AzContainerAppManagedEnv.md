---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappmanagedenv
schema: 2.0.0
---

# Get-AzContainerAppManagedEnv

## SYNOPSIS
Get the properties of a Managed Environment used to host container apps.

## SYNTAX

### List (Default)
```
Get-AzContainerAppManagedEnv [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppManagedEnv -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppManagedEnv -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzContainerAppManagedEnv -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the properties of a Managed Environment used to host container apps.

## EXAMPLES

### Example 1: List the properties of Managed Environment used to host container apps by sub.
```powershell
Get-AzContainerAppManagedEnv
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

List the properties of Managed Environment used to host container apps by sub.

### Example 2: List the properties of Managed Environment used to host container apps by resource group name.
```powershell
Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

List the properties of Managed Environment used to host container apps by resource group name.

### Example 3: Get the properties of a Managed Environment used to host container apps by name.
```powershell
Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app -Name azps-env
```

```output
Location Name     ResourceGroupName
-------- ----     -----------------
East US  azps-env azps_test_group_app
```

Get the properties of a Managed Environment used to host container apps by name.

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
Name of the Environment.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EnvName

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IManagedEnvironment

## NOTES

## RELATED LINKS

