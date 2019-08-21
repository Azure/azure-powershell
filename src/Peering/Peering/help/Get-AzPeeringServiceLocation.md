---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.dll-Help.xml
Module Name: Az.Peering
online version: https://docs.microsoft.com/en-us/powershell/module/az.peering/get-azpeeringservicelocation
schema: 2.0.0
---

# Get-AzPeeringServiceLocation

## SYNOPSIS
Gets a list of peering service locations offered by Microsoft.

## SYNTAX

```
Get-AzPeeringServiceLocation [-PeeringLocation] <String> [-PeeringCountry <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
List peering locations.

## EXAMPLES

### Example 1
```powershell
PS C:\>Get-AzPeeringServiceLocation -PeeringLocation Washington

Country			:United States
State			:Washington
Azure Region	:US West 2
```

Retrieves the peering locations for washington.

### Example 2
```powershell
PS C:\>Get-AzPeeringServiceLocation -PeeringCountry "United States"

Country			:United States
State			:Alabama
Azure Region	:US Central 

Country			:United States
State			:Alaska
Azure Region	:US West 2

...
```

Retrieves the peering locations for washington.
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

### -PeeringCountry
The country filter

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

### -PeeringLocation
The Physical Location Different from Azure Region.
Use Get-AzPeeringLocation -Kind \<kind\> use City name as key.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSPeering

## NOTES

## RELATED LINKS
