---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version:
schema: 2.0.0
---

# New-AzCdnWafAction

## SYNOPSIS
Create a CDN WAF Action for use in a rule.

## SYNTAX

### RedirectActionParameterSet
```
New-AzCdnWafAction [-Redirect] [-RedirectUrl <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BlockActionParameterSet
```
New-AzCdnWafAction [-Block] [-CustomBlockResponseStatusCode <Int32>] [-CustomBlockResponseBody <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### LogActionParameterSet
```
New-AzCdnWafAction [-Log] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AllowActionParameterSet
```
New-AzCdnWafAction [-Allow] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzCdnWafAction** cmdlet creates an Azure Content Delivery Network (CDN) Web Application
Firewall (WAF) action locally, for use in creating rules.

## EXAMPLES

## PARAMETERS

### -Allow
Create an action that allows the request.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AllowActionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Block
Create an action that blocks the request.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BlockActionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomBlockResponseBody
The response body returned for blocked requests.
If not specified, the policy default is used.

```yaml
Type: System.String
Parameter Sets: BlockActionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomBlockResponseStatusCode
The status code returned for blocked requests.
If not specified, the policy default is used.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: BlockActionParameterSet
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Log
Create an action that logs the request.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: LogActionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Redirect
Create an action that performs an HTTP redirect.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RedirectActionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RedirectUrl
The URL the client is redirected to.

```yaml
Type: System.String
Parameter Sets: RedirectActionParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSAction

## NOTES

## RELATED LINKS
