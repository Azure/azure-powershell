---
external help file:
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
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReissueExpanded
```
Invoke-AzReissueAppServiceCertificateOrder -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-PassThru] [-Csr <String>] [-DelayExistingRevokeInHour <Int32>]
 [-IsPrivateKeyExternal] [-KeySize <Int32>] [-Kind <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ReissueViaIdentityExpanded
```
Invoke-AzReissueAppServiceCertificateOrder -InputObject <IWebSiteIdentity> [-PassThru] [-Csr <String>]
 [-DelayExistingRevokeInHour <Int32>] [-IsPrivateKeyExternal] [-KeySize <Int32>] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReissueViaIdentity
```
Invoke-AzReissueAppServiceCertificateOrder -InputObject <IWebSiteIdentity> [-PassThru]
 [-ReissueCertificateOrderRequest <IReissueCertificateOrderRequest1>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reissue an existing certificate order.

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

### -CertificateOrderName
Name of the certificate order.

```yaml
Type: System.String
Parameter Sets: Reissue, ReissueExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Csr
Csr to be used for re-key operation.

```yaml
Type: System.String
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DelayExistingRevokeInHour
Delay in hours to revoke existing certificate after the new certificate is issued.

```yaml
Type: System.Int32
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: ReissueViaIdentityExpanded, ReissueViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IsPrivateKeyExternal
Should we change the ASC type (from managed private key to external private key and vice versa).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeySize
Certificate Key Size.

```yaml
Type: System.Int32
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ReissueCertificateOrderRequest
Class representing certificate reissue request.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IReissueCertificateOrderRequest1
Parameter Sets: Reissue, ReissueViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Reissue, ReissueExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Reissue, ReissueExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IReissueCertificateOrderRequest1

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### System.Boolean

## ALIASES

## RELATED LINKS

