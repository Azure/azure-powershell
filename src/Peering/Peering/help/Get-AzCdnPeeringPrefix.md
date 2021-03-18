---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Peering.dll-Help.xml
Module Name: Az.Peering
online version: https://docs.microsoft.com/en-us/powershell/module/az.peering/get-azcdnpeeringprefix
schema: 2.0.0
---

# Get-AzCdnPeeringPrefix

## SYNOPSIS
Lists all of the advertised prefixes for the specified peering location

## SYNTAX

```
Get-AzCdnPeeringPrefix [-PeeringLocation] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all of the advertised prefixes for the specified peering location

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzCdnPeeringPrefix -PeeringLocation "Seattle"
```

Lists all of the advertised prefixes in the specified physical peering location

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

### -PeeringLocation
The Physical Location Different from Azure Region.
Use Get-AzPeeringLocation -Kind \<kind\> use City name as key to check if the peering location exists or Use Get-AzPeeringLocation -Kind \<kind\> to get all the peering locations to select.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.PSCdnPeeringPrefix

## NOTES

## RELATED LINKS
