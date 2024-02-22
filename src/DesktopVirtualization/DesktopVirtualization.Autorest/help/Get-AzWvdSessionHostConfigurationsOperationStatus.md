---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdsessionhostconfigurationsoperationstatus
schema: 2.0.0
---

# Get-AzWvdSessionHostConfigurationsOperationStatus

## SYNOPSIS
Get Operation status for SessionHostManagement

## SYNTAX

### List (Default)
```
Get-AzWvdSessionHostConfigurationsOperationStatus -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-IsLatest] [-IsNonTerminal] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWvdSessionHostConfigurationsOperationStatus -HostPoolName <String> -OperationId <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWvdSessionHostConfigurationsOperationStatus -InputObject <IDesktopVirtualizationIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get Operation status for SessionHostManagement

## EXAMPLES

### Example 1: Get a Azure Virtual Desktop SessionHostConfigurationOperationStatus by HostPoolName and operationId
```powershell
Get-AzWvdSessionHostConfigurationsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -OperationId operationId
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     operationId Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
```

This command gets a Azure Virtual Desktop SessionHostConfigurationOperationStatus in a Resource Group.

### Example 2: List Azure Virtual Desktop SessionHostConfigurationOperationStatuses
```powershell
Get-AzWvdSessionHostConfigurationsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostConfigurationOperationStatuses in a Resource Group.

### Example 3: List Azure Virtual Desktop SessionHostConfigurationOperationStatuses with filters
```powershell
Get-AzWvdSessionHostConfigurationsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -isLatest:$false -isNonTerminal
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostconfigurations/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostConfigurationOperationStatuses in a Resource Group.

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

### -HostPoolName
The name of the host pool within the specified resource group

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsLatest
Returns the most recent sessionHostConfiguration operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsNonTerminal
Returns currently running operations.
Ignored if 'isLatest' is true

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationId
The Guid of the operation.

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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.ISessionHostConfigurationOperationStatus

## NOTES

## RELATED LINKS

