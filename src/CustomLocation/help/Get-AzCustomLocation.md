---
external help file:
Module Name: Az.CustomLocation
online version: https://docs.microsoft.com/powershell/module/az.customlocation/get-azcustomlocation
schema: 2.0.0
---

# Get-AzCustomLocation

## SYNOPSIS
Gets the details of the customLocation with a specified resource group and name.

## SYNTAX

### List (Default)
```
Get-AzCustomLocation [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzCustomLocation -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCustomLocation -InputObject <ICustomLocationIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzCustomLocation -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the details of the customLocation with a specified resource group and name.

## EXAMPLES

### Example 1: List the details of the customLocation.
```powershell
Get-AzCustomLocation
```

```output
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

List the details of the customLocation.

### Example 2: List the details of the customLocation with a specified resource group.
```powershell
Get-AzCustomLocation -ResourceGroupName azps_test_group
```

```output
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

List the details of the customLocation with a specified resource group.

### Example 3: Gets the details of the customLocation with a specified resource group and name.
```powershell
Get-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster
```

```output
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

Gets the details of the customLocation with a specified resource group and name.

### Example 4: Gets the details of the customLocation.
```powershell
New-AzCustomLocation -ResourceGroupName azps_test_group -Name azps_test_cluster -Location eastus -ClusterExtensionId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster/providers/Microsoft.KubernetesConfiguration/extensions/azps_test_extension" -HostResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azps_test_group/providers/Microsoft.Kubernetes/connectedClusters/azps_test_cluster" -Namespace arc | Get-AzCustomLocation
```

```output
Location Name              Namespace
-------- ----              ----
eastus   azps_test_cluster arc
```

Gets the details of the customLocation.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Custom Locations name.

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

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.Api20210815.ICustomLocation

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<ICustomLocationIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: Custom Locations name.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

