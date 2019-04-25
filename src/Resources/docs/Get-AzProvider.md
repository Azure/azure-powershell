---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azprovider
schema: 2.0.0
---

# Get-AzProvider

## SYNOPSIS
Gets the specified resource provider.

## SYNTAX

### ListSubscriptionIdViaHost (Default)
```
Get-AzProvider [-Expand <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetSubscriptionIdViaHost
```
Get-AzProvider -ResourceProviderNamespace <String> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzProvider -ResourceProviderNamespace <String> -SubscriptionId <String> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzProvider -SubscriptionId <String> [-Expand <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the specified resource provider.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -Expand
The $expand query parameter.
For example, to include property aliases in response, use $expand=resourceTypes/aliases.

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

### -ResourceProviderNamespace
The namespace of the resource provider.

```yaml
Type: System.String
Parameter Sets: GetSubscriptionIdViaHost, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of results to return.
If null is passed returns all deployments.

```yaml
Type: System.Int32
Parameter Sets: ListSubscriptionIdViaHost, List
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IProvider
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azprovider](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azprovider)

