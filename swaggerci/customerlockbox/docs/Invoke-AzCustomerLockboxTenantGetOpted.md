---
external help file:
Module Name: Az.CustomerLockbox
online version: https://docs.microsoft.com/en-us/powershell/module/az.customerlockbox/invoke-azcustomerlockboxtenantgetopted
schema: 2.0.0
---

# Invoke-AzCustomerLockboxTenantGetOpted

## SYNOPSIS
Get Customer Lockbox request

## SYNTAX

### Tenant (Default)
```
Invoke-AzCustomerLockboxTenantGetOpted -TenantId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### TenantViaIdentity
```
Invoke-AzCustomerLockboxTenantGetOpted -InputObject <ICustomerLockboxIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Customer Lockbox request

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerLockbox.Models.ICustomerLockboxIdentity
Parameter Sets: TenantViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TenantId
The Azure tenant ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: Tenant
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomerLockbox.Models.ICustomerLockboxIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICustomerLockboxIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[RequestId <String>]`: The Lockbox request ID.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)
  - `[TenantId <String>]`: The Azure tenant ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)

## RELATED LINKS

