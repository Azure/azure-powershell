---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 556A9F12-DF72-468F-9C3F-A747CC70BD2F
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/test-azdnsavailability
=======
online version: https://docs.microsoft.com/powershell/module/az.network/test-azdnsavailability
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Test-AzDnsAvailability

## SYNOPSIS
Checks whether a domain name in the cloudapp.azure.com zone is available for use.

## SYNTAX

```
Test-AzDnsAvailability -DomainNameLabel <String> -Location <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Checks whether a domain name in the cloudapp.azure.com zone is available for use.

## EXAMPLES

<<<<<<< HEAD
### Example 1: Check if contoso.cloudapp.azure.com is available for use.
=======
### Example 1: Check if contoso.westus.cloudapp.azure.com is available for use.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```
Test-AzDnsAvailability -DomainNameLabel contoso -Location westus
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -DomainNameLabel
```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DomainQualifiedName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
