---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadssapapplicationinstance
schema: 2.0.0
---

# Get-AzWorkloadsSapApplicationInstance

## SYNOPSIS
Gets the SAP Application Server Instance corresponding to the Virtual Instance for SAP solutions resource.

## SYNTAX

### List (Default)
```
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName <String> -SapVirtualInstanceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWorkloadsSapApplicationInstance -Name <String> -ResourceGroupName <String>
 -SapVirtualInstanceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadsSapApplicationInstance -InputObject <ISapVirtualInstanceIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the SAP Application Server Instance corresponding to the Virtual Instance for SAP solutions resource.

## EXAMPLES

### Example 1: Get an overview of The App Server Instance(s) 
```powershell
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

This command will help you get an overview, including health and status of all the App Server instances in the Virtual instance for SAP solutions

### Example 2: Get an overview of The App Server Instance
```powershell
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT -Name app0
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

This command will help you get an overview, including health and status of a specific App Server instance in the Virtual instance for SAP solutions

### Example 3: Get an overview of The App Server Instance
```powershell
Get-AzWorkloadsSapApplicationInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DemoRGVIS/providers/Microsoft.Workloads/sapVirtualInstances/DRT/applicationInstances/app0
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

This command will help you get an overview, including health and status of a specific App Server instance in the Virtual instance for SAP solutions by using the Azure resource ID of the App server instance

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
The name of SAP Application Server instance resource.

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

### -SapVirtualInstanceName
The name of the Virtual Instances for SAP solutions resource

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api20231001Preview.ISapApplicationServerInstance

## NOTES

ALIASES

Get-AzVISApplicationInstance

## RELATED LINKS

