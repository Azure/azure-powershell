---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadssapcentralinstance
schema: 2.0.0
---

# Get-AzWorkloadsSapCentralInstance

## SYNOPSIS
Gets the SAP Central Services Instance resource.

## SYNTAX

### List (Default)
```
Get-AzWorkloadsSapCentralInstance -ResourceGroupName <String> -SapVirtualInstanceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzWorkloadsSapCentralInstance -Name <String> -ResourceGroupName <String> -SapVirtualInstanceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadsSapCentralInstance -InputObject <ISapVirtualInstanceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the SAP Central Services Instance resource.

## EXAMPLES

### Example 1: Get an overview of The Central service Instance(s)
```powershell
Get-AzWorkloadsSapCentralInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT
```

```output
Name ResourceGroupName Health  EnqueueServerPropertyHostname ProvisioningState Status  Location
---- ----------------- ------  ----------------------------- ----------------- ------  --------
cs0  DemoRGVIS         Healthy drtvm                         Succeeded         Running eastus2euap
```

This command will help you get an overview, including health and status of the Central service instance in a Virtual instance for SAP solutions

### Example 2:  Get an overview of The Central service Instance(s)
```powershell
Get-AzWorkloadsSapCentralInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DemoRGVIS/providers/Microsoft.Workloads/sapVirtualInstances/DRT/centralInstances/cs0
```

```output
Name ResourceGroupName Health  EnqueueServerPropertyHostname ProvisioningState Status  Location
---- ----------------- ------  ----------------------------- ----------------- ------  --------
cs0  DemoRGVIS         Healthy drtvm                         Succeeded         Running eastus2euap
```

This command will help you get an overview, including health and status of a Central service instance in the Virtual instance for SAP solutions by using the Azure resource ID of the Central service instance

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Central Services Instance resource name string modeled as parameter for auto generation to work correctly.

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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SapVirtualInstanceName
The name of the Virtual Instances for SAP solutions resource

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api20231001Preview.ISapCentralServerInstance

## NOTES

ALIASES

Get-AzVISCentralInstance

## RELATED LINKS
