---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdeployment
schema: 2.0.0
---

# Get-AzDeployment

## SYNOPSIS
Gets a deployment.

## SYNTAX

### ListSubscriptionIdViaHost (Default)
```
Get-AzDeployment [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetSubscriptionIdViaHost1
```
Get-AzDeployment -Name <String> -ResourceGroupName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetSubscriptionIdViaHost
```
Get-AzDeployment -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzDeployment -Name <String> -SubscriptionId <String> -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDeployment -Name <String> -SubscriptionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDeployment -SubscriptionId <String> -ResourceGroupName <String> [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDeployment -SubscriptionId <String> [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListSubscriptionIdViaHost1
```
Get-AzDeployment -ResourceGroupName <String> [-Filter <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a deployment.

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

### -Filter
The filter to apply on the operation.
For example, you can use $filter=provisioningState eq '{state}'.

```yaml
Type: System.String
Parameter Sets: ListSubscriptionIdViaHost, List1, List, ListSubscriptionIdViaHost1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the deployment to get.

```yaml
Type: System.String
Parameter Sets: GetSubscriptionIdViaHost1, GetSubscriptionIdViaHost, Get1, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: GetSubscriptionIdViaHost1, Get1, List1, ListSubscriptionIdViaHost1
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
Parameter Sets: Get1, Get, List1, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of results to get.
If null is passed, returns all deployments.

```yaml
Type: System.Int32
Parameter Sets: ListSubscriptionIdViaHost, List1, List, ListSubscriptionIdViaHost1
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentExtended
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdeployment](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azdeployment)

