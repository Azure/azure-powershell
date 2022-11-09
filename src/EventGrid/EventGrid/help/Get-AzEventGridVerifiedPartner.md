---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridVerifiedPartner

## SYNOPSIS
Gets the details of a specific Event Grid verified partner or gets the details of all verified partners in the current azure subscription.

## SYNTAX

### VerifiedPartnerNameParameterSet (Default)
```
Get-AzEventGridVerifiedPartner [-Name <String>] [-ODataQuery <String>] [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NextLinkParameterSet
```
Get-AzEventGridVerifiedPartner [-NextLink <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzEventGridVerifiedPartners will get the detail of a specific verified partner or gets the details of all verified partners in the current Azure subscription.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridVerifiedPartner -Name VerifiedPartner1
```

Gets the details of verified partner \`VerifiedPartner1\`.

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

### -Name
EventGrid Verified Partner Name.

```yaml
Type: String
Parameter Sets: VerifiedPartnerNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NextLink
The link for the next page of resources to be obtained.
This value is obtained with the first Get-AzEventGrid cmdlet call when more resources are still available to be queried.

```yaml
Type: String
Parameter Sets: NextLinkParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ODataQuery
The OData query used for filtering the list results.
Filtering is currently allowed on the Name property only.The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.

```yaml
Type: String
Parameter Sets: VerifiedPartnerNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Top
The maximum number of resources to be obtained.
Valid value is between 1 and 100.
If top value is specified and more results are still available, the result will contain a link to the next page to be queried in NextLink.
If the Top value is not specified, the full list of resources will be returned at once.

```yaml
Type: Int32
Parameter Sets: VerifiedPartnerNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSVerifiedPartnerListInstance

### Microsoft.Azure.Commands.EventGrid.Models.PSVerifiedPartner

## NOTES

## RELATED LINKS
