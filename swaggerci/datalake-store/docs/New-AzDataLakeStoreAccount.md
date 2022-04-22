---
external help file:
Module Name: Az.DataLakeStoreAccount
online version: https://docs.microsoft.com/en-us/powershell/module/az.datalakestoreaccount/new-azdatalakestoreaccount
schema: 2.0.0
---

# New-AzDataLakeStoreAccount

## SYNOPSIS
Creates the specified Data Lake Store account.

## SYNTAX

```
New-AzDataLakeStoreAccount -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-DefaultGroup <String>] [-EncryptionConfigType <EncryptionConfigType>]
 [-EncryptionState <EncryptionState>] [-FirewallAllowAzureIP <FirewallAllowAzureIpsState>]
 [-FirewallRule <ICreateFirewallRuleWithAccountParameters[]>] [-FirewallState <FirewallState>]
 [-KeyVaultMetaInfoEncryptionKeyName <String>] [-KeyVaultMetaInfoEncryptionKeyVersion <String>]
 [-KeyVaultMetaInfoKeyVaultResourceId <String>] [-NewTier <TierType>] [-Tag <Hashtable>]
 [-TrustedIdProvider <ICreateTrustedIdProviderWithAccountParameters[]>]
 [-TrustedIdProviderState <TrustedIdProviderState>]
 [-VirtualNetworkRule <ICreateVirtualNetworkRuleWithAccountParameters[]>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates the specified Data Lake Store account.

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

### -DefaultGroup
The default owner group for all new folders and files created in the Data Lake Store account.

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

### -EncryptionConfigType
The type of encryption configuration being used.
Currently the only supported types are 'UserManaged' and 'ServiceManaged'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Support.EncryptionConfigType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionState
The current state of encryption for this Data Lake Store account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Support.EncryptionState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirewallAllowAzureIP
The current state of allowing or disallowing IPs originating within Azure through the firewall.
If the firewall is disabled, this is not enforced.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Support.FirewallAllowAzureIpsState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirewallRule
The list of firewall rules associated with this Data Lake Store account.
To construct, see NOTES section for FIREWALLRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Models.Api20161101.ICreateFirewallRuleWithAccountParameters[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirewallState
The current state of the IP address firewall for this Data Lake Store account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Support.FirewallState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultMetaInfoEncryptionKeyName
The name of the user managed encryption key.

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

### -KeyVaultMetaInfoEncryptionKeyVersion
The version of the user managed encryption key.

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

### -KeyVaultMetaInfoKeyVaultResourceId
The resource identifier for the user managed Key Vault being used to encrypt.

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
The resource location.

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

### -Name
The name of the Data Lake Store account.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewTier
The commitment tier to use for next month.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Support.TierType
Parameter Sets: (All)
Aliases:

Required: False
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
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
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

### -Tag
The resource tags.

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

### -TrustedIdProvider
The list of trusted identity providers associated with this Data Lake Store account.
To construct, see NOTES section for TRUSTEDIDPROVIDER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Models.Api20161101.ICreateTrustedIdProviderWithAccountParameters[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustedIdProviderState
The current state of the trusted identity provider feature for this Data Lake Store account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Support.TrustedIdProviderState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkRule
The list of virtual network rules associated with this Data Lake Store account.
To construct, see NOTES section for VIRTUALNETWORKRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Models.Api20161101.ICreateVirtualNetworkRuleWithAccountParameters[]
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

### Microsoft.Azure.PowerShell.Cmdlets.DataLakeStoreAccount.Models.Api20161101.IDataLakeStoreAccount

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FIREWALLRULE <ICreateFirewallRuleWithAccountParameters[]>: The list of firewall rules associated with this Data Lake Store account.
  - `EndIPAddress <String>`: The end IP address for the firewall rule. This can be either ipv4 or ipv6. Start and End should be in the same protocol.
  - `Name <String>`: The unique name of the firewall rule to create.
  - `StartIPAddress <String>`: The start IP address for the firewall rule. This can be either ipv4 or ipv6. Start and End should be in the same protocol.

TRUSTEDIDPROVIDER <ICreateTrustedIdProviderWithAccountParameters[]>: The list of trusted identity providers associated with this Data Lake Store account.
  - `IdProvider <String>`: The URL of this trusted identity provider.
  - `Name <String>`: The unique name of the trusted identity provider to create.

VIRTUALNETWORKRULE <ICreateVirtualNetworkRuleWithAccountParameters[]>: The list of virtual network rules associated with this Data Lake Store account.
  - `Name <String>`: The unique name of the virtual network rule to create.
  - `SubnetId <String>`: The resource identifier for the subnet.

## RELATED LINKS

