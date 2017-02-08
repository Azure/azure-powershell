---
external help file: Microsoft.Azure.Commands.ApiManagement.dll-Help.xml
ms.assetid: 9D4A68A8-0A39-4C9A-8EA6-391A5E7A0E25
online version: 
schema: 2.0.0
---

# Add-AzureRmApiManagementRegion

## SYNOPSIS
Adds new deployment regions to a PsApiManagement instance.

## SYNTAX

```
Add-AzureRmApiManagementRegion -ApiManagement <PsApiManagement> -Location <String> [-Sku <PsApiManagementSku>]
 [-Capacity <Int32>] [-VirtualNetwork <PsApiManagementVirtualNetwork>] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmApiManagementRegion** cmdlet adds new instance of type **PsApiManagementRegion** to the collection of **AdditionalRegions** of provided instance of type **Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement**.
This cmdlet does not deploy anything by itself but updates instance of **PsApiManagement** in-memory.
To update a deployment of an API Management pass the modified **PsApiManagement** Instance to Update-AzureRmApiManagementDeployment.

## EXAMPLES

### Example 1: Add new deployment regions to a PsApiManagement instance
```
PS C:\>Add-AzureRmApiManagementRegion -ApiManagement $ApiManagement -Location "East US" -Sku "Premium" -Capacity 2
```

This command adds two premium SKU units and the region named East US to the **PsApiManagement** instance.

### Example 2: Add new deployment regions to a PsApiManagement instance and then update deployment
```
PS C:\>Get-AzureRmApiManagement -ResourceGroupName "Contoso" -Name "ContosoApi" | Add-AzureRmApiManagementRegion -Location "East US" -Sku "Premium" -Capacity 2 | Update-AzureRmApiManagementDeployments
```

This command gets a **PsApiManagement** object, adds two premium SKU units for the region named East US, and then updates deployment.

## PARAMETERS

### -ApiManagement
Specifies the **PsApiManagement** instance that this cmdlet adds additional deployment regions to.

```yaml
Type: PsApiManagement
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Specifies the location of the new deployment region.

Valid values are: 

- North Central US
- South Central US
- Central US
- West Europe
- North Europe
- West US
- East US
- East US 2
- Japan East
- Japan West
- Brazil South
- Southeast Asia
- East Asia
- Australia East
- Australia Southeast

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
Specifies the tier of the deployment region.
Valid values are: 

- Developer
- Standard
- Premium

```yaml
Type: PsApiManagementSku
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Capacity
Specifies the SKU capacity of the deployment region.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetwork
Specifies a virtual network configuration.

```yaml
Type: PsApiManagementVirtualNetwork
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES
* The cmdlet writes updated **PsApiManagement** instance to pipeline.

## RELATED LINKS

[Remove-AzureRmApiManagementRegion](./Remove-AzureRmApiManagementRegion.md)

[Update-AzureRmApiManagementRegion](./Update-AzureRmApiManagementRegion.md)

[Update-AzureRmApiManagementDeployment](./Update-AzureRmApiManagementDeployment.md)


