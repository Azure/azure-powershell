---
external help file:
Module Name: Az.DataLakeAnalyticsAccount
online version: https://docs.microsoft.com/en-us/powershell/module/az.datalakeanalyticsaccount/get-azdatalakeanalyticsaccountcomputepolicy
schema: 2.0.0
---

# Get-AzDataLakeAnalyticsAccountComputePolicy

## SYNOPSIS
Gets the specified Data Lake Analytics compute policy.

## SYNTAX

### List (Default)
```
Get-AzDataLakeAnalyticsAccountComputePolicy -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataLakeAnalyticsAccountComputePolicy -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataLakeAnalyticsAccountComputePolicy -InputObject <IDataLakeAnalyticsAccountIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified Data Lake Analytics compute policy.

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
Parameter Sets: Get, List
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Models.IDataLakeAnalyticsAccountIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the compute policy to retrieve.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ComputePolicyName

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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Models.IDataLakeAnalyticsAccountIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Models.Api20191101Preview.IComputePolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataLakeAnalyticsAccountIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the Data Lake Analytics account.
  - `[ComputePolicyName <String>]`: The name of the compute policy to create or update.
  - `[ContainerName <String>]`: The name of the Azure storage container to retrieve
  - `[DataLakeStoreAccountName <String>]`: The name of the Data Lake Store account to add.
  - `[FirewallRuleName <String>]`: The name of the firewall rule to create or update.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The resource location without whitespace.
  - `[ResourceGroupName <String>]`: The name of the Azure resource group.
  - `[StorageAccountName <String>]`: The name of the Azure Storage account to add
  - `[SubscriptionId <String>]`: Get subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

