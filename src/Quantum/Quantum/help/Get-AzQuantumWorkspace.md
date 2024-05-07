---
external help file: Az.Quantum-help.xml
Module Name: Az.Quantum
online version: https://learn.microsoft.com/powershell/module/az.quantum/get-azquantumworkspace
schema: 2.0.0
---

# Get-AzQuantumWorkspace

## SYNOPSIS
Returns the Workspace resource associated with the given name.

## SYNTAX

### List (Default)
```
Get-AzQuantumWorkspace [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzQuantumWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzQuantumWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzQuantumWorkspace -InputObject <IQuantumIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns the Workspace resource associated with the given name.

## EXAMPLES

### Example 1: List the Workspace resource associated by the SubId.
```powershell
Get-AzQuantumWorkspace
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

List the Workspace resource associated by the SubId.

### Example 2: List the Workspace resource associated by the ResourceGroupName.
```powershell
Get-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

List the Workspace resource associated by the ResourceGroupName.

### Example 3: Get the Workspace resource associated by the name.
```powershell
Get-AzQuantumWorkspace -ResourceGroupName azps_test_group_quantum -Name azps-qw
```

```output
Location Name    ResourceGroupName
-------- ----    -----------------
eastus   azps-qw azps_test_group_quantum
```

Get the Workspace resource associated by the name.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IQuantumIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the quantum workspace resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WorkspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

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
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IQuantumIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.Api20220110Preview.IQuantumWorkspace

## NOTES

## RELATED LINKS
