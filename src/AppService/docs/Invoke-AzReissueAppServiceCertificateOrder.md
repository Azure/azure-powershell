---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/invoke-azreissueappservicecertificateorder
schema: 2.0.0
---

# Invoke-AzReissueAppServiceCertificateOrder

## SYNOPSIS
Reissue an existing certificate order.

## SYNTAX

### Reissue (Default)
```
Invoke-AzReissueAppServiceCertificateOrder -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-PassThru] [-ReissueCertificateOrderRequest <IReissueCertificateOrderRequest1>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ReissueExpanded
```
Invoke-AzReissueAppServiceCertificateOrder -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-PassThru] [-Csr <String>] [-DelayExistingRevokeInHour <Int32>]
 [-IsPrivateKeyExternal <Boolean>] [-KeySize <Int32>] [-Kind <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ReissueViaIdentityExpanded
```
Invoke-AzReissueAppServiceCertificateOrder -InputObject <IWebSiteIdentity> [-PassThru] [-Csr <String>]
 [-DelayExistingRevokeInHour <Int32>] [-IsPrivateKeyExternal <Boolean>] [-KeySize <Int32>] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ReissueViaIdentity
```
Invoke-AzReissueAppServiceCertificateOrder -InputObject <IWebSiteIdentity> [-PassThru]
 [-ReissueCertificateOrderRequest <IReissueCertificateOrderRequest1>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Reissue an existing certificate order.

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
Parameter Sets: Reissue, ReissueExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Csr
Csr to be used for re-key operation.

```yaml
Type: String
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
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
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DelayExistingRevokeInHour
Delay in hours to revoke existing certificate after the new certificate is issued.

```yaml
Type: Int32
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: IWebSiteIdentity
Parameter Sets: ReissueViaIdentityExpanded, ReissueViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsPrivateKeyExternal
Should we change the ASC type (from managed private key to external private key and vice versa).

```yaml
Type: Boolean
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeySize
Certificate Key Size.

```yaml
Type: Int32
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Kind of resource.

```yaml
Type: String
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReissueCertificateOrderRequest
Class representing certificate reissue request.

```yaml
Type: IReissueCertificateOrderRequest1
Parameter Sets: Reissue, ReissueViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: String
Parameter Sets: Reissue, ReissueExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: String
Parameter Sets: Reissue, ReissueExpanded
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

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/invoke-azreissueappservicecertificateorder](https://docs.microsoft.com/en-us/powershell/module/az.website/invoke-azreissueappservicecertificateorder)

