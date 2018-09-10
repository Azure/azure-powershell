---
external help file: Microsoft.Azure.Commands.Dns.dll-Help.xml
Module Name: AzureRM.Dns
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.dns/get-azurermdnsresourcereference
schema: 2.0.0
---

# Get-AzureRmDnsResourceReference

## SYNOPSIS
Get the resource alias references

## SYNTAX

```
Get-AzureRmDnsResourceReference -ResourceId <System.Collections.Generic.List`1[System.String]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDnsResourceReference** gets other resources referring to the target resource.
You need to pass the id of the resources queried and it will return all the referred resource ids.

## EXAMPLES

### Example 1
```powershell
PS C:\> $references = Get-AzureRmDnsResourceReference -ResourceId "/subscriptions/mysubscription/resourceGroups/myresourceGroup/providers/Microsoft.Network/dnszones/zone.com/A/www"
```
This example gets the resources referred to dns record www of type A in zone zone.com under resource group myresourceGroup and subscription mysubscription

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Target Resource Id.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Dns.Models.DnsResourceReference, Microsoft.Azure.Commands.Dns, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS
