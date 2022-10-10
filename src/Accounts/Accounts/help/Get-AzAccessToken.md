---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://docs.microsoft.com/powershell/module/az.accounts/get-azaccesstoken
schema: 2.0.0
---

# Get-AzAccessToken

## SYNOPSIS
Get raw access token. The format of `-ResourceUrl` concatenates a desired resource identifier with an 
optional desired OAuth2 permission for that resource. Please make sure resource identifier matches current 
Azure environment. You may refer to the value of `(Get-AzContext).Environment`. If permission is not 
provided, `/.default` is appended automatically for all app-level permission.

## SYNTAX

### KnownResourceTypeName (Default)
```
Get-AzAccessToken [-ResourceTypeName <String>] [-TenantId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceUrl
```
Get-AzAccessToken -ResourceUrl <String> [-TenantId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
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
Type: String
Parameter Sets: KnownResourceTypeName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUrl
Resource url for that you're requesting token, e.g. 'https://graph.microsoft.com/'. Permission can be appended.

```yaml
Type: String
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
Type: String
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

## NOTES

## RELATED LINKS
