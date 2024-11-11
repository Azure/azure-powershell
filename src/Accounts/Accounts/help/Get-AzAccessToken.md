---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://learn.microsoft.com/powershell/module/az.accounts/get-azaccesstoken
schema: 2.0.0
---

# Get-AzAccessToken

## SYNOPSIS
Get secure raw access token. When using -ResourceUrl, please make sure the value does match current Azure environment. You may refer to the value of `(Get-AzContext).Environment`.
> **_NOTE:_**  The current default output token type is going to be changed from plain text `String` to `SecureString` for security. Please use `-AsSecureString` to migrate to the secure behaviour before the breaking change takes effects.

## SYNTAX

### KnownResourceTypeName (Default)
```
Get-AzAccessToken [-ResourceTypeName <String>] [-TenantId <String>] [-AsSecureString]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceUrl
```
Get-AzAccessToken -ResourceUrl <String> [-TenantId <String>] [-AsSecureString]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get access token

## EXAMPLES

### Example 1 Get the access token for ARM endpoint
```powershell
Get-AzAccessToken -AsSecureString
```

Get access token of current account for ResourceManager endpoint

### Example 2 Get the access token for Microsoft Graph endpoint
```powershell
Get-AzAccessToken -AsSecureString -ResourceTypeName MSGraph
```

Get access token of Microsoft Graph endpoint for current account

### Example 3 Get the access token for Microsoft Graph endpoint
```powershell
Get-AzAccessToken -AsSecureString -ResourceUrl "https://graph.microsoft.com/"
```

Get access token of Microsoft Graph endpoint for current account

## PARAMETERS

### -AsSecureString
Specifiy to convert output token as a secure string.
Please always use the parameter for security purpose and to avoid the upcoming breaking chang and refer to [Frequently asked questions about Azure PowerShell](https://learn.microsoft.com/en-us/powershell/azure/faq) for how to convert from `SecureString` to plain text.

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

### -ResourceTypeName
Optional resource type name, supported values: AadGraph, AnalysisServices, AppConfiguration, Arm, Attestation, Batch, CommunicationEmail, DataLake, KeyVault, MSGraph, OperationalInsights, ResourceManager, Storage, Synapse. Default value is Arm if not specified.

```yaml
Type: System.String
Parameter Sets: KnownResourceTypeName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUrl
Resource url for that you're requesting token, e.g. 'https://graph.microsoft.com/'.

```yaml
Type: System.String
Parameter Sets: ResourceUrl
Aliases: Resource, ResourceUri

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
Optional Tenant Id. Use tenant id of default context if not specified.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSAccessToken
The output type is going to be deprecate.

### Microsoft.Azure.Commands.Profile.Models.PSSecureAccessToken
Use `-AsSecureString` to get the token as `SecureString`.

## NOTES

## RELATED LINKS
