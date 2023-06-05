---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmimage
schema: 2.0.0
---

# Get-AzStackHCIVMImage

## SYNOPSIS


## SYNTAX

### BySubscription (Default)
```
Get-AzStackHCIVMImage [-SubscriptionId <String[]>] [<CommonParameters>]
```

### ByName
```
Get-AzStackHCIVMImage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ByResourceGroup
```
Get-AzStackHCIVMImage -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ByResourceId
```
Get-AzStackHCIVMImage -ResourceId <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListAllSupportedImages
```
Get-AzStackHCIVMImage -ClusterName <String> -ResourceGroupName <String> -SupportedImages
 [-SubscriptionId <String[]>] [<CommonParameters>]
```

### ListImagesByOffer
```
Get-AzStackHCIVMImage -ClusterName <String> -Offer <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [<CommonParameters>]
```

### ListImagesByPublisher
```
Get-AzStackHCIVMImage -ClusterName <String> -Publisher <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [<CommonParameters>]
```

### ListImagesBySku
```
Get-AzStackHCIVMImage -ClusterName <String> -ResourceGroupName <String> -Sku <String>
 [-SubscriptionId <String[]>] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ClusterName


```yaml
Type: System.String
Parameter Sets: ListAllSupportedImages, ListImagesByOffer, ListImagesByPublisher, ListImagesBySku
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile


```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: ByName, ByResourceGroup, ByResourceId
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name


```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offer


```yaml
Type: System.String
Parameter Sets: ListImagesByOffer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher


```yaml
Type: System.String
Parameter Sets: ListImagesByPublisher
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName


```yaml
Type: System.String
Parameter Sets: ByName, ByResourceGroup, ListAllSupportedImages, ListImagesByOffer, ListImagesByPublisher, ListImagesBySku
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId


```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku


```yaml
Type: System.String
Parameter Sets: ListImagesBySku
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportedImages


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListAllSupportedImages
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

### System.Object

## NOTES

ALIASES

## RELATED LINKS

