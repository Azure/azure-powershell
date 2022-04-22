---
external help file:
Module Name: Az.DataLakeAnalyticsAccount
online version: https://docs.microsoft.com/en-us/powershell/module/az.datalakeanalyticsaccount/add-azdatalakeanalyticsaccountstorageaccount
schema: 2.0.0
---

# Add-AzDataLakeAnalyticsAccountStorageAccount

## SYNOPSIS
Updates the specified Data Lake Analytics account to add an Azure Storage account.

## SYNTAX

### AddExpanded (Default)
```
Add-AzDataLakeAnalyticsAccountStorageAccount -AccountName <String> -Name <String> -ResourceGroupName <String>
 -AccessKey <String> [-SubscriptionId <String>] [-Suffix <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Add
```
Add-AzDataLakeAnalyticsAccountStorageAccount -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Parameter <IAddStorageAccountParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AddViaIdentity
```
Add-AzDataLakeAnalyticsAccountStorageAccount -InputObject <IDataLakeAnalyticsAccountIdentity>
 -Parameter <IAddStorageAccountParameters> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### AddViaIdentityExpanded
```
Add-AzDataLakeAnalyticsAccountStorageAccount -InputObject <IDataLakeAnalyticsAccountIdentity>
 -AccessKey <String> [-Suffix <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the specified Data Lake Analytics account to add an Azure Storage account.

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

### -AccessKey
The access key associated with this Azure Storage account that will be used to connect to it.

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountName
The name of the Data Lake Analytics account.

```yaml
Type: System.String
Parameter Sets: Add, AddExpanded
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
Parameter Sets: AddViaIdentity, AddViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Azure Storage account to add

```yaml
Type: System.String
Parameter Sets: Add, AddExpanded
Aliases: StorageAccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters used to add a new Azure Storage account.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Models.Api20191101Preview.IAddStorageAccountParameters
Parameter Sets: Add, AddViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
The name of the Azure resource group.

```yaml
Type: System.String
Parameter Sets: Add, AddExpanded
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
Parameter Sets: Add, AddExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Suffix
The optional suffix for the storage account.

```yaml
Type: System.String
Parameter Sets: AddExpanded, AddViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Models.Api20191101Preview.IAddStorageAccountParameters

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeAnalyticsAccount.Models.IDataLakeAnalyticsAccountIdentity

## OUTPUTS

### System.Boolean

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

PARAMETER <IAddStorageAccountParameters>: The parameters used to add a new Azure Storage account.
  - `AccessKey <String>`: The access key associated with this Azure Storage account that will be used to connect to it.
  - `[Suffix <String>]`: The optional suffix for the storage account.

## RELATED LINKS

