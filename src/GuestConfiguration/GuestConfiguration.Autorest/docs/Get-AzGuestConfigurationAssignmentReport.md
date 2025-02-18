---
external help file:
Module Name: Az.GuestConfiguration
online version: https://learn.microsoft.com/powershell/module/az.guestconfiguration/get-azguestconfigurationassignmentreport
schema: 2.0.0
---

# Get-AzGuestConfigurationAssignmentReport

## SYNOPSIS
Get a report for the guest configuration assignment, by reportId.

## SYNTAX

### List (Default)
```
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName <String>
 -ResourceGroupName <String> -VMName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName <String> -ReportId <String>
 -ResourceGroupName <String> -VMName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get1
```
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName <String> -MachineName <String>
 -ReportId <String> -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get2
```
Get-AzGuestConfigurationAssignmentReport -Name <String> -ReportId <String> -ResourceGroupName <String>
 -VmssName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName <String> -MachineName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List2
```
Get-AzGuestConfigurationAssignmentReport -Name <String> -ResourceGroupName <String> -VmssName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a report for the guest configuration assignment, by reportId.

## EXAMPLES

### Example 1: Get a report by ReportId for a guest configuration assignment
```powershell
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -VMName test-vm -ReportId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/test-assignment/reports/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

Get a report by ReportId for a guest configuration assignment

### Example 2: List reports for a guest configuration assignment
```powershell
Get-AzGuestConfigurationAssignmentReport -GuestConfigurationAssignmentName test-assignment -ResourceGroupName test-rg -VMName test-vm
```

List reports for a guest configuration assignment

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

### -GuestConfigurationAssignmentName
The guest configuration assignment name.

```yaml
Type: System.String
Parameter Sets: Get, Get1, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineName
The name of the ARC machine.

```yaml
Type: System.String
Parameter Sets: Get1, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The guest configuration assignment name.

```yaml
Type: System.String
Parameter Sets: Get2, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReportId
The GUID for the guest configuration assignment report.

```yaml
Type: System.String
Parameter Sets: Get, Get1, Get2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMName
The name of the virtual machine.

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

### -VmssName
The name of the virtual machine scale set.

```yaml
Type: System.String
Parameter Sets: Get2, List2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IGuestConfigurationAssignmentReport

## NOTES

## RELATED LINKS

