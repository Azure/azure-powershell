---
external help file:
Module Name: Az.AceProvisioningPartnerApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.aceprovisioningpartnerapi/get-azaceprovisioningpartnerapipartner
schema: 2.0.0
---

# Get-AzAceProvisioningPartnerApiPartner

## SYNOPSIS
Get the management partner using the partnerId, objectId and tenantId.

## SYNTAX

### Get1 (Default)
```
Get-AzAceProvisioningPartnerApiPartner [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAceProvisioningPartnerApiPartner -Id <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAceProvisioningPartnerApiPartner -InputObject <IAceProvisioningPartnerApiIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the management partner using the partnerId, objectId and tenantId.

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

### -Id
Id of the Partner

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PartnerId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AceProvisioningPartnerApi.Models.IAceProvisioningPartnerApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AceProvisioningPartnerApi.Models.IAceProvisioningPartnerApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AceProvisioningPartnerApi.Models.Api20180201.IPartnerResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAceProvisioningPartnerApiIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[PartnerId <String>]`: Id of the Partner

## RELATED LINKS

