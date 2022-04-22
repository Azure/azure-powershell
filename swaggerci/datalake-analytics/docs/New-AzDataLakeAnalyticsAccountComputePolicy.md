---
external help file:
Module Name: Az.DataLakeAnalyticsAccount
online version: https://docs.microsoft.com/en-us/powershell/module/az.datalakeanalyticsaccount/new-azdatalakeanalyticsaccountcomputepolicy
schema: 2.0.0
---

# New-AzDataLakeAnalyticsAccountComputePolicy

## SYNOPSIS
Creates or updates the specified compute policy.
During update, the compute policy with the specified name will be replaced with this new compute policy.
An account supports, at most, 50 policies

## SYNTAX

```
New-AzDataLakeAnalyticsAccountComputePolicy -AccountName <String> -Name <String> -ResourceGroupName <String>
 -ObjectId <String> -ObjectType <AadObjectType> [-SubscriptionId <String>]
 [-MaxDegreeOfParallelismPerJob <Int32>] [-MinPriorityPerJob <Int32>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the specified compute policy.
During update, the compute policy with the specified name will be replaced with this new compute policy.
An account supports, at most, 50 policies

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The name of the Data Lake Analytics account.

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

### -MaxDegreeOfParallelismPerJob
The maximum degree of parallelism per job this user can use to submit jobs.
This property, the min priority per job property, or both must be passed.

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

### -MinPriorityPerJob
The minimum priority per job this user can use to submit jobs.
This property, the max degree of parallelism per job property, or both must be passed.

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

### -Name
The name of the compute policy to create or update.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ComputePolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ObjectId
The AAD object identifier for the entity to create a policy for.

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

### -ObjectType
The type of AAD object the object identifier refers to.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Support.AadObjectType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Azure resource group.

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
Get subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Models.Api20191101Preview.IComputePolicy

## NOTES

ALIASES

## RELATED LINKS

