---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azproviderfeature
schema: 2.0.0
---

# Get-AzProviderFeature

## SYNOPSIS
Gets the preview feature with the specified name.

## SYNTAX

### ListSubscriptionIdViaHost (Default)
```
Get-AzProviderFeature [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetSubscriptionIdViaHost
```
Get-AzProviderFeature -Name <String> -ResourceProviderNamespace <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzProviderFeature -Name <String> -ResourceProviderNamespace <String> -SubscriptionId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListSubscriptionIdViaHost1
```
Get-AzProviderFeature -ResourceProviderNamespace <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzProviderFeature -ResourceProviderNamespace <String> -SubscriptionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzProviderFeature -SubscriptionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the preview feature with the specified name.

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

### -Name
The name of the feature to get.

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

### -ResourceProviderNamespace
The resource provider namespace for the feature.

```yaml
Type: System.String
Parameter Sets: GetSubscriptionIdViaHost, Get, ListSubscriptionIdViaHost1, List1
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
Parameter Sets: Get, List1, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20151201.IFeatureResult
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azproviderfeature](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azproviderfeature)

