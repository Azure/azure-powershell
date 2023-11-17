---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadsmonitor
schema: 2.0.0
---

# Get-AzWorkloadsMonitor

## SYNOPSIS
Gets properties of a SAP monitor for the specified subscription, resource group, and resource name.

## SYNTAX

### List (Default)
```
Get-AzWorkloadsMonitor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWorkloadsMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadsMonitor -InputObject <IWorkloadsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzWorkloadsMonitor -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a SAP monitor for the specified subscription, resource group, and resource name.

## EXAMPLES

### Example 1: List all AMS Instances
```powershell
Get-AzWorkloadsMonitor
```

```output
Name        ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----        ----------------- ------------------------------------- --------    -----------------
ad-ams-inst ad-ams-rg         ad-ams-mrg                            eastus2euap Deleting
ad-ams-tp   ad-ams-rg         sapmonrg-q2nti3                       eastus2euap Succeeded
ad-ams      ad-ams-rg         sapmonrg-u2mtiw                       eastus      Succeeded
suha-1606-ams2 suha-0802-rg1     mrg-15061                          eastus2euap Failed
```

Lists all AMS Instances in the subscription

### Example 2: List all AMS instances in a Resource Group
```powershell
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg
```

```output
Name        ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----        ----------------- ------------------------------------- --------    -----------------
ad-ams-inst ad-ams-rg         ad-ams-mrg                            eastus2euap Deleting
ad-ams-tp   ad-ams-rg         sapmonrg-q2nti3                       eastus2euap Succeeded
ad-ams      ad-ams-rg         sapmonrg-u2mtiw                       eastus      Succeeded
```

List all AMS instances in a Resource Group

### Example 3: Get Information about an AMS Instance
```powershell
Get-AzWorkloadsMonitor -ResourceGroupName ad-ams-rg -Name ad-ams
```

```output
Name   ResourceGroupName ManagedResourceGroupConfigurationName Location ProvisioningState
----   ----------------- ------------------------------------- -------- -----------------
ad-ams ad-ams-rg         sapmonrg-u2mtiw                       eastus   Succeeded
```

Gets information about a specific AMS instance in a resource group

### Example 4: Get Information about an AMS Instance by Id
```powershell
 Get-AzWorkloadsMonitor -InputObject '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/suha-1606-ams2'
```

```output
Name           ResourceGroupName ManagedResourceGroupConfigurationName Location    ProvisioningState
----           ----------------- ------------------------------------- --------    -----------------
suha-1606-ams2 suha-0802-rg1     mrg-15061                             eastus2euap Failed


```

Get Information about an AMS Instance by ArmId

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the SAP monitor resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MonitorName

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IMonitor

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IWorkloadsIdentity>`: Identity Parameter
  - `[ApplicationInstanceName <String>]`: The name of SAP Application Server instance resource.
  - `[CentralInstanceName <String>]`: Central Services Instance resource name string modeled as parameter for auto generation to work correctly.
  - `[DatabaseInstanceName <String>]`: Database resource name string modeled as parameter for auto generation to work correctly.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[MonitorName <String>]`: Name of the SAP monitor resource.
  - `[ProviderInstanceName <String>]`: Name of the provider instance.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SapVirtualInstanceName <String>]`: The name of the Virtual Instances for SAP solutions resource
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

