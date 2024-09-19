---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/get-azworkloadsproviderinstance
schema: 2.0.0
---

# Get-AzWorkloadsProviderInstance

## SYNOPSIS
Gets properties of a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## SYNTAX

### List (Default)
```
Get-AzWorkloadsProviderInstance -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzWorkloadsProviderInstance -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWorkloadsProviderInstance -InputObject <IWorkloadsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets properties of a provider instance for the specified subscription, resource group, SAP monitor name, and resource name.

## EXAMPLES

### Example 1: List all providers in an AMS Instance
```powershell
Get-AzWorkloadsProviderInstance -ResourceGroupName ad-ams-rg -MonitorName ad-ams
```

```output
Name              ResourceGroupName ProvisioningState IdentityType
----              ----------------- ----------------- ------------
Hana-1-test       ad-ams-rg         Failed            
hana-test-2       ad-ams-rg         Succeeded         
prov-1            ad-ams-rg         Failed            
hana-test         ad-ams-rg         Failed            
SAP-NETWEAVER     ad-ams-rg         Failed            
HA3-HANA-HighAvl  ad-ams-rg         Succeeded         
lh-28022023-host  ad-ams-rg         Failed            
as1-sysdb         ad-ams-rg         Succeeded         
h2-test           ad-ams-rg         Failed            
```

List all the providers created for an AMS Instance

### Example 2: Get information about an AMS Provider
```powershell
Get-AzWorkloadsProviderInstance -ResourceGroupName ad-ams-rg -MonitorName ad-ams -Name hana-test-2
```

```output
Name        ResourceGroupName ProvisioningState IdentityType
----        ----------------- -----------------  ------------
hana-test-2 ad-ams-rg         Succeeded         
```

Gets information about a specific AMS Provider

### Example 3: Get information about an AMS Provider by Id
```powershell
Get-AzWorkloadsProviderInstance -InputObject "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/suha-0802-rg1/providers/Microsoft.Workloads/monitors/ams_mon/providerInstances/suha-db2-1"
```

```output

Name       ResourceGroupName ProvisioningState IdentityType
----       ----------------- ----------------- ------------
suha-db2-1 suha-0802-rg1     Succeeded
```

Get information about an AMS Provider by ArmId

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

### -MonitorName
Name of the SAP monitor resource.

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

### -Name
Name of the provider instance.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ProviderInstanceName

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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IProviderInstance

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

