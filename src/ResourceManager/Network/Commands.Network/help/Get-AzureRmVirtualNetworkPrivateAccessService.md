---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmVirtualNetworkPrivateAccessService

## SYNOPSIS
Lists private access services for location

## SYNTAX

```
Get-AzureRmVirtualNetworkPrivateAccessService -Location <String>
```

## DESCRIPTION
Get-AzureRmVirtualNetworkPrivateAccessService lists private access service values available in the specified location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmVirtualNetworkPrivateAccessService -Location westus

Name              Id                                                                                                                      Type
----              --                                                                                                                      ----
Microsoft.Storage /subscriptions/2c224e7e-3ef5-431d-a57b-e71f4662e3a6/providers/Microsoft.Network/privateAccessServices/Microsoft.Storage Microsoft.Network/privateAccessServices
```

Gets available private access services in westus region.

## PARAMETERS

### -Location
The location to retrieve the private access services from.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.PSPrivateAccessServiceResult, Microsoft.Azure.Commands.Network, Version=4.1.0.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS

