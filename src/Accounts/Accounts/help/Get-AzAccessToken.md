---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://learn.microsoft.com/powershell/module/az.accounts/get-azaccesstoken
schema: 2.0.0
---

# Get-AzAccessToken

## SYNOPSIS
Get raw access token. When using -ResourceUrl, please make sure the value does match current Azure environment. You may refer to the value of `(Get-AzContext).Environment`.

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
Get-AzAccessToken
```

Get access token of current account for ResourceManager endpoint

### Example 2 Get the access token for Microsoft Graph endpoint
```powershell
Get-AzAccessToken -ResourceTypeName MSGraph
```

Get access token of Microsoft Graph endpoint for current account

### Example 3 Get the access token for Microsoft Graph endpoint
```powershell
Get-AzAccessToken -ResourceUrl "https://graph.microsoft.com/"
```

Get access token of Microsoft Graph endpoint for current account

## PARAMETERS

### -AsSecureString
Specifiy to convert output token as a secure string.

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
Optional resource type name, supported values: AadGraph, AnalysisServices, AppConfiguration, Arm, Attestation, Batch, DataLake, KeyVault, MSGraph, OperationalInsights, ResourceManager, Storage, Synapse. Default value is Arm if not specified.

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

### Microsoft.Azure.Commands.Profile.Models.PSSecureAccessToken

## NOTES

## RELATED LINKS
