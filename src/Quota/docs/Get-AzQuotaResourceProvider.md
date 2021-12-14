---
external help file:
Module Name: Az.Quota
online version: https://docs.microsoft.com/powershell/module/az.quota/get-azquotaresourceprovider
schema: 2.0.0
---

# Get-AzQuotaResourceProvider

## SYNOPSIS
Gets the list of current resource providers supported by the Microsoft.Quota resource provider.\r\nFor each resource provider, the resource templates the resource provider supports are be provided.
\r\nFor each resource template, the resource dimensions are listed.
The resource dimensions are the name-value pairs in the resource URI.\r\nExample: Microsoft.Compute Resource Provider\r\nThe URI template is '/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{locationId}/quotaBucket'.
The actual dimensions vary depending on the resource provider.\r\nThe resource dimensions are {subscriptions},{locations},{quotaBucket}.

## SYNTAX

```
Get-AzQuotaResourceProvider [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of current resource providers supported by the Microsoft.Quota resource provider.\r\nFor each resource provider, the resource templates the resource provider supports are be provided.
\r\nFor each resource template, the resource dimensions are listed.
The resource dimensions are the name-value pairs in the resource URI.\r\nExample: Microsoft.Compute Resource Provider\r\nThe URI template is '/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{locationId}/quotaBucket'.
The actual dimensions vary depending on the resource provider.\r\nThe resource dimensions are {subscriptions},{locations},{quotaBucket}.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Quota.Models.Api20210315.IResourceProviderInformation

## NOTES

ALIASES

## RELATED LINKS

