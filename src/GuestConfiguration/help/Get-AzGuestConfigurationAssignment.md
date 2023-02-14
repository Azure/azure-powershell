---
external help file:
Module Name: Az.GuestConfiguration
online version: https://learn.microsoft.com/powershell/module/az.guestconfiguration/get-azguestconfigurationassignment
schema: 2.0.0
---

# Get-AzGuestConfigurationAssignment

## SYNOPSIS
Get information about a guest configuration assignment

## SYNTAX

### List (Default)
```
Get-AzGuestConfigurationAssignment [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### Get
```
Get-AzGuestConfigurationAssignment -Name <String> -ResourceGroupName <String> -VMName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzGuestConfigurationAssignment -MachineName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get2
```
Get-AzGuestConfigurationAssignment -Name <String> -ResourceGroupName <String> -VmssName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzGuestConfigurationAssignment -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### List2
```
Get-AzGuestConfigurationAssignment -ResourceGroupName <String> -VMName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List3
```
Get-AzGuestConfigurationAssignment -MachineName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List4
```
Get-AzGuestConfigurationAssignment -ResourceGroupName <String> -VmssName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get information about a guest configuration assignment

## EXAMPLES

### Example 1: Get a specific guest configuration assignment
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VMName test-vm  -GuestConfigurationAssignmentName test-assignment
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

Get a specific guest configuration assignment

### Example 2: List guest configuration assignments for a VM
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VMName test-vm
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

List guest configuration assignments for a VM

### Example 3: List guest configuration assignments for a VMSS
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VmssName test-vmss
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

List guest configuration assignments for a VMSS

### Example 4: List guest configuration assignments for a ARC machine
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -MachineName test-machine
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

List guest configuration assignments for a ARC machine

### Example 5: List guest configuration assignments for a resource group
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment1 test-rg
westcentralus test-assignment2 test-rg
```

List guest configuration assignments for a resource group

### Example 6: List guest configuration assignments for a subscription
```powershell
Get-AzGuestConfigurationAssignment -SubscriptionId xxxxx-xxxx-xxxxx-xxx
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment1 test-rg
westcentralus test-assignment2 test-rg
```

List guest configuration assignments for a subscription

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

### -MachineName
The name of the ARC machine.

```yaml
Type: System.String
Parameter Sets: Get1, List3
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
Parameter Sets: Get, Get1, Get2
Aliases: GuestConfigurationAssignmentName

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
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: Get, Get1, Get2, List1, List2, List3, List4
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
Parameter Sets: Get, List2
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
Parameter Sets: Get2, List4
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

### Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IGuestConfigurationAssignment

## NOTES

ALIASES

## RELATED LINKS

