---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Reservations.dll-Help.xml
Module Name: Az.Reservations
online version: https://docs.microsoft.com/en-us/powershell/module/az.reservations/calculate-azcalculateprice
schema: 2.0.0
---

# Calculate-AzCalculatePrice

## SYNOPSIS
Calculate price for reservation order

## SYNTAX

```
Calculate-AzCalculatePrice -ReservedResourceType <String> [-Sku <String>] -Location <String>
 -BillingScopeId <String> -Term <String> [-BillingPlan <String>] -Quantity <Int32> [-DisplayName <String>]
 -AppliedScopeType <String> [-AppliedScopes <System.Collections.Generic.IList`1[System.String]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Calculate the price of a reservationOrder with specific sku, region, quantuty and location

## EXAMPLES

### Example 1
```powershell
PS C:\> Calculate-AzCalculatePrice -ReservedResourceType VirtualMachines [-Sku VirtualMachines] -Location centralus
 -BillingScopeId /subscriptions/79c182d9-9af7-4fd5-b136-b71f0a69a1d0 -Term P1Y [-BillingPlan Monthly] -Quantity 2 [-DisplayName demo]
 -AppliedScopeType <String> [-AppliedScopes <System.Collections.Generic.IList`1[System.String]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

After get catalog, customer can get the differe product based on location. By using those infomation, check the price properly

## PARAMETERS

### -AppliedScopes
If AppliedScopeType is "Shared", it will be all subscriptions under the CAID/EA. If "Single" it will only give benefit to that specific subscription

```yaml
Type: System.Collections.Generic.IList`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliedScopeType
"Single" "Shared"

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

### -BillingPlan
"Mothly" "Upfront"

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

### -BillingScopeId
The subscription who will be charge for the RI

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

### -DisplayName
Custom name

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

### -Location
Pick a location

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

### -Quantity
choose quantity to get the price

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReservedResourceType
Reservation Instance type, ex: VirtualMachines, Sql, CosmosDB

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
Pick specific product under the resourceType

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

### -Term
"P1Y"  1 year
"P3y"  3 years
3 years will get more discount 

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.Reservations.Models.CalculatePriceResponse

## NOTES

## RELATED LINKS
