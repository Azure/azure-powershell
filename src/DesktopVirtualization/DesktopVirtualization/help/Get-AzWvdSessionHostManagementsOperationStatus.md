---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdsessionhostmanagementsoperationstatus
schema: 2.0.0
---

# Get-AzWvdSessionHostManagementsOperationStatus

## SYNOPSIS
Get Operation status for SessionHostManagement

## SYNTAX

### List (Default)
```
Get-AzWvdSessionHostManagementsOperationStatus -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Action <String>] [-CorrelationId <String>] [-IsInitiatingOperation] [-IsLatest]
 [-IsNonTerminal] [-Type <String>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzWvdSessionHostManagementsOperationStatus -HostPoolName <String> -OperationId <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWvdSessionHostManagementsOperationStatus -InputObject <IDesktopVirtualizationIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get Operation status for SessionHostManagement

## EXAMPLES

### Example 1: Get a Azure Virtual Desktop SessionHostManagementOperationStatus by HostPoolName and operationId
```powershell
Get-AzWvdSessionHostManagementsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -OperationId operationId
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     operationId Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
```

This command gets a Azure Virtual Desktop SessionHostManagementOperationStatus in a Resource Group.

### Example 2: List Azure Virtual Desktop SessionHostManagementOperationStatuses
```powershell
Get-AzWvdSessionHostManagementsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostManagementOperationStatuses in a Resource Group.

### Example 3: List Azure Virtual Desktop SessionHostManagementOperationStatuses with filters
```powershell
Get-AzWvdSessionHostManagementsOperationStatus -ResourceGroupName ResourceGroupName -HostPoolName HostPoolName -isLatest:$false -isNonTerminal -type Control -action start -isInitiatingOperation:$false
```

```output
Location   Name          Type
--------   ----          ----
eastus     operationId1 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
eastus     operationId2 Microsoft.DesktopVirtualization/hostpools/sessionhostmanagements/operationstatuses
```

This command lists a Azure Virtual Desktop SessionHostManagementOperationStatuses in a Resource Group.

## PARAMETERS

### -Action
Action type for the Operation Status list to be filtered on.
Valid actions are: start | retry | pause | resume | cancel).

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

### -CorrelationId
CorrelationId of the sessionHostManagement operations to be returned.

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

### -IsInitiatingOperation
Filter option to only return operations that initiated a sessionHostManagement operation.

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

### -IsLatest
Returns the most recent sessionHostManagement operation.

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

### -Type
Filter based on the type of sessionHostManagement operation.
Valid values are 'InitiateSessionHostUpdate' and 'ValidateSessionHostUpdate'

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20240116Preview.ISessionHostManagementOperationStatus

## NOTES

## RELATED LINKS
