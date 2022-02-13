---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/get-azexpressrouteportslocation
schema: 2.0.0
---

# Get-AzExpressRoutePortsLocation

## SYNOPSIS
Gets the locations at which ExpressRoutePort resources are available.

## SYNTAX

```
Get-AzExpressRoutePortsLocation [-LocationName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzExpressRoutePortsLocation** cmdlet is used to retrieve the locations at which 
ExpressRoutePort resources are available. Given a specific location as input, the cmdlet displays
the details of that location i.e., list of available bandwidths at that location.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzExpressRoutePortsLocation
```

Lists the locations at which ExpressRoutePort resources are available.

### Example 2
```powershell
PS C:\> Get-AzExpressRoutePortsLocation -LocationName $loc
```

Lists the ExpressRoutePort bandwidths available at location $loc.

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

### -LocationName
The name of the location.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSExpressRoutePortsLocation

## NOTES

## RELATED LINKS
