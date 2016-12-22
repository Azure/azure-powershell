---
external help file: Microsoft.AzureStack.Commands.StorageAdmin.dll-Help.xml
online version: 
schema: 2.0.0
ms.assetid: F9988B87-11CA-41AB-90D8-4A0F9C2BA918
---

# Get-ACSEventQuery

## SYNOPSIS
Gets an ACS query object.

## SYNTAX

```
Get-ACSEventQuery [-FarmName] <String> [-StartTime] <DateTime> [-EndTime] <DateTime> [-NodeName <String>]
 [[-ResourceUri] <String>] [[-ProviderGuid] <Guid>] [[-EventId] <Int32[]>] [[-SubscriptionId] <String>]
 [[-Token] <String>] [[-AdminUri] <Uri>] [-ResourceGroupName] <String> [-SkipCertificateValidation]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-ACSEventQuery** cmdlet gets an Azure Consistent Storage system (ACS) query object.
The **ACSEventQuery** object can be used to query events from the ACS system.

## EXAMPLES

### Example 1: Get an ACS query object
```
PS C:\>$EndTime = Get-Date
PS C:\> $StartTime=$EndTime.addminutes(-10)
PS C:\> $Query = Get-ACSEventQuery -FarmId $Farm.Name -Token "Token01" -SubscriptionId $SubscriptID -AdminUri $AdminUri -ResourceGroupName $ResourceGroup -StartTime $StartTime -EndTime $EndTime
```

This command gets an ACS query object and stores the result in the variable named $Query.

## PARAMETERS

### -FarmName
Specifies the name of the ACS farm.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StartTime
Specifies the start time of a time range.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
Specifies the end time of a time range.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: True
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
Specifies the path, as a URI, to the resource file.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderGuid

```yaml
Type: Guid
Parameter Sets: (All)
Aliases: 

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventId

```yaml
Type: Int32[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the service administrator subscription ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Token
Specifies the service administrator token.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AdminUri
Specifies the location of the Resource Manager endpoint.
If you configured your environment by using the Set-AzureRMEnvironment cmdlet, you do not have to specify this parameter.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that this cmdlet gets the ACS event query object from.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipCertificateValidation
Indicates that this cmdlet skips certificate validation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeName
Specifies the name of the node.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.AzureStack.Commands.StorageAdmin.FarmResponse,
Output from Get-ACSFarm can be piped to this cmdlet.

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-ACSEvent](./Get-ACSEvent.md)

[Get-ACSFarm](./Get-ACSFarm.md)


