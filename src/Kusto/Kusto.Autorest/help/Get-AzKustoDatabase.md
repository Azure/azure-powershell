---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustodatabase
schema: 2.0.0
---

# Get-AzKustoDatabase

## SYNOPSIS
Returns a database.

## SYNTAX

### List (Default)
```
Get-AzKustoDatabase -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Skiptoken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzKustoDatabase -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKustoDatabase -InputObject <IKustoIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a database.

## EXAMPLES

### Example 1: List all Kusto databases in a cluster by name
```powershell
Get-AzKustoDatabase -ResourceGroupName testrg -ClusterName testnewkustocluster
```

```output
Kind      Location Name                                 Type
----      -------- ----                                 ----
ReadWrite East US  testnewkustocluster/mykustodatabase  Microsoft.Kusto/Clusters/Databases
ReadWrite East US  testnewkustocluster/mykustodatabase2 Microsoft.Kusto/Clusters/Databases
```

The above command returns all Kusto databases in the cluster "testnewkustocluster" found in the resource group "testrg".

### Example 2: Get a specific Kusto database by name
```powershell
Get-AzKustoDatabase -ResourceGroupName testrg -ClusterName testnewkustocluster -Name mykustodatabase
```

```output
Kind      Location Name                                Type
----      -------- ----                                ----
ReadWrite East US  testnewkustocluster/mykustodatabase Microsoft.Kusto/Clusters/Databases
```

The above command returns the Kusto database named "mykustodatabase" in the cluster "testnewkustocluster" found in the resource group "testrg".

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the database in the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DatabaseName

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

### -Skiptoken
Skiptoken is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls.

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

### -Top
limit the number of results

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IDatabase

## NOTES

## RELATED LINKS

