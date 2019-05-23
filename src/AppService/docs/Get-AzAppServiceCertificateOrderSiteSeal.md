---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/get-azappservicecertificateordersiteseal
schema: 2.0.0
---

# Get-AzAppServiceCertificateOrderSiteSeal

## SYNOPSIS
Verify domain ownership for this certificate order.

## SYNTAX

### Retrieve (Default)
```
Get-AzAppServiceCertificateOrderSiteSeal -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> [-SiteSealRequest <ISiteSealRequest>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RetrieveExpanded
```
Get-AzAppServiceCertificateOrderSiteSeal -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> [-LightTheme <Boolean>] [-Locale <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RetrieveViaIdentityExpanded
```
Get-AzAppServiceCertificateOrderSiteSeal -InputObject <IWebSiteIdentity> [-LightTheme <Boolean>]
 [-Locale <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RetrieveViaIdentity
```
Get-AzAppServiceCertificateOrderSiteSeal -InputObject <IWebSiteIdentity> [-SiteSealRequest <ISiteSealRequest>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Verify domain ownership for this certificate order.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -CertificateOrderName
Name of the certificate order.

```yaml
Type: String
Parameter Sets: Retrieve, RetrieveExpanded
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
Type: PSObject
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

```yaml
Type: IWebSiteIdentity
Parameter Sets: RetrieveViaIdentityExpanded, RetrieveViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LightTheme
If \<code\>true\</code\> use the light color theme for site seal; otherwise, use the default color theme.

```yaml
Type: Boolean
Parameter Sets: RetrieveExpanded, RetrieveViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Locale
Locale of site seal.

```yaml
Type: String
Parameter Sets: RetrieveExpanded, RetrieveViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: String
Parameter Sets: Retrieve, RetrieveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteSealRequest
Site seal request.

```yaml
Type: ISiteSealRequest
Parameter Sets: Retrieve, RetrieveViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: String[]
Parameter Sets: Retrieve, RetrieveExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/get-azappservicecertificateordersiteseal](https://docs.microsoft.com/en-us/powershell/module/az.website/get-azappservicecertificateordersiteseal)

