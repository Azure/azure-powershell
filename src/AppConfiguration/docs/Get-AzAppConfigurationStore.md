---
external help file: Az.AppConfiguration-help.xml
Module Name: Az.AppConfiguration
online version: https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/get-azappconfigurationstore
schema: 2.0.0
---

# Get-AzAppConfigurationStore

## SYNOPSIS
Lists the configuration stores for a given subscription.

## SYNTAX

### ListSubscriptionIdViaHost (Default)
```
Get-AzAppConfigurationStore [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetSubscriptionIdViaHost
```
Get-AzAppConfigurationStore -Name <String> -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzAppConfigurationStore -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListSubscriptionIdViaHost1
```
Get-AzAppConfigurationStore -ResourceGroupName <String> [-SkipToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzAppConfigurationStore -ResourceGroupName <String> -SubscriptionId <String> [-SkipToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzAppConfigurationStore -SubscriptionId <String> [-SkipToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists the configuration stores for a given subscription.

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
The name of the configuration store.

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

### -ResourceGroupName
The name of the resource group to which the container registry belongs.

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

### -SkipToken
A skip token is used to continue retrieving items after an operation returns a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls.

```yaml
Type: System.String
Parameter Sets: ListSubscriptionIdViaHost, ListSubscriptionIdViaHost1, List1, List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Microsoft Azure subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStore
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/get-azappconfigurationstore](https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/get-azappconfigurationstore)

