---
external help file:
Module Name: Az.StreamAnalytics
online version: https://docs.microsoft.com/powershell/module/az.streamanalytics/new-azstreamanalyticscluster
schema: 2.0.0
---

# New-AzStreamAnalyticsCluster

## SYNOPSIS
Creates a Stream Analytics Cluster or replaces an already existing cluster.

## SYNTAX

```
New-AzStreamAnalyticsCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-Location <String>] [-SkuCapacity <Int32>]
 [-SkuName <ClusterSkuName>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a Stream Analytics Cluster or replaces an already existing cluster.

## EXAMPLES

### Example 1: Create a new stream analytics cluster
```powershell
PS C:\> New-AzStreamAnalyticsCluster -ResourceGroupName pwshaz-rg-test -Name sac-ps-test01 -Location "West Central US" -SkuName "Default" -SkuCapacity 36

Location        Name          Type                               Etag
--------        ----          ----                               ----
West Central US sac-ps-test01 Microsoft.StreamAnalytics/clusters
```

This command creates a new stream analytics cluster.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -IfMatch
The ETag of the resource.
Omit this value to always overwrite the current record set.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfNoneMatch
Set to '*' to allow a new resource to be created, but to prevent updating an existing record set.
Other values will result in a 412 Pre-condition Failed response.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Denotes the number of streaming units the cluster can support.
Valid values for this property are multiples of 36 with a minimum value of 36 and maximum value of 216.
Required on PUT (CreateOrUpdate) requests.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Specifies the SKU name of the cluster.
Required on PUT (CreateOrUpdate) requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ClusterSkuName
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20200301Preview.ICluster

## NOTES

ALIASES

## RELATED LINKS

