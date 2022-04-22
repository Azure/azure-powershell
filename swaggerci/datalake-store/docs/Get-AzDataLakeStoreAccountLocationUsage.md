---
external help file:
Module Name: Az.DataLakeStoreAccount
online version: https://docs.microsoft.com/en-us/powershell/module/az.datalakestoreaccount/get-azdatalakestoreaccountlocationusage
schema: 2.0.0
---

# Get-AzDataLakeStoreAccountLocationUsage

## SYNOPSIS
Gets the current usage count and the limit for the resources of the location under the subscription.

## SYNTAX

### Get (Default)
```
Get-AzDataLakeStoreAccountLocationUsage -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataLakeStoreAccountLocationUsage -InputObject <IDataLakeStoreAccountIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the current usage count and the limit for the resources of the location under the subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Models.IDataLakeStoreAccountIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The resource location without whitespace.

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

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Models.IDataLakeStoreAccountIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Models.Api20161101.IUsage

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataLakeStoreAccountIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the Data Lake Store account.
  - `[FirewallRuleName <String>]`: The name of the firewall rule to create or update.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The resource location without whitespace.
  - `[ResourceGroupName <String>]`: The name of the Azure resource group.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[TrustedIdProviderName <String>]`: The name of the trusted identity provider. This is used for differentiation of providers in the account.
  - `[VirtualNetworkRuleName <String>]`: The name of the virtual network rule to create or update.

## RELATED LINKS

