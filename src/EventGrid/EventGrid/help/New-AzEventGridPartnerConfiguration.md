---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# New-AzEventGridPartnerConfiguration

## SYNOPSIS
Creates a new Event Grid partner configuration.

## SYNTAX

```
New-AzEventGridPartnerConfiguration [-ResourceGroupName] <String> [-Tag <Hashtable>]
 [-MaxExpirationTimeInDays <Int32>] [-AuthorizedPartner <Hashtable[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new partner configuration.

## EXAMPLES

### Example 1
```powershell
New-AzEventGridPartnerConfiguration -ResourceGroupName MyResourceGroupName -MaxExpirationTimeInDays 14
```

Creates a new partner configuration under the resource group \`MyResourceGroupName\`.

## PARAMETERS

### -AuthorizedPartner
Array of HashTables where each HashTable is the details of an authorized partner.
Each HashTable has the following key-value info: partnerName, partnerRegistrationImmutableId, and authorizationExpirationTimeInUtc.
At least one key is required.
The partnerName is a String, partnerRegistrationImmutableId  is a Guid, and authorizationExpirationTimeInUtc is a DateTime.

```yaml
Type: Hashtable[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -MaxExpirationTimeInDays
Expiration time in days used to validate the authorization expiration time for each authorized partner.
If this parameter is not specified, the default is 7 days.
Otherwise, allowed values are between 1 and 365 days.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtable which represents resource Tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Hashtable

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Collections.Hashtable[]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration

## NOTES

## RELATED LINKS
