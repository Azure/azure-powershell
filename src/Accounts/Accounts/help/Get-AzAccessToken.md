---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version:
schema: 2.0.0
---

# Get-AzAccessToken

## SYNOPSIS
Get raw access token

## SYNTAX

### KnownResourceTypeName
```
Get-AzAccessToken -ResourceTypeName <String> [-TenantId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get access token

## EXAMPLES

### Example 1 Get raw access token for ARM endpoint
```powershell
PS C:\> Get-AzAccessToken
```

Get access token of ResourceManager endpoint for current account

### Example 2 Get raw access token for AAD graph endpoint
```powershell
PS C:\> Get-AzAccessToken -ResourceTypeName AadGraph
```

Get access token of AAD graph endpoint for current account

## PARAMETERS

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
Optional resouce type name, supported values: AadGraph, Analysis, Arm, Attest, DataLake, KeyVault, OperationInsights, Synapse. Default value is Arm if not specified.

```yaml
Type: System.String
Parameter Sets: KnownResourceTypeName
Aliases:

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

### System.String

## NOTES

## RELATED LINKS
