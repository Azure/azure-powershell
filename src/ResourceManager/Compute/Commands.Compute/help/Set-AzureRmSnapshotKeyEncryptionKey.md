---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmSnapshotKeyEncryptionKey

## SYNOPSIS
Sets the key encryption key properties on a snapshot object.

## SYNTAX

```
Set-AzureRmSnapshotKeyEncryptionKey [-Snapshot] <Snapshot> [[-KeyUrl] <String>] [-SourceVaultId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmSnapshotKeyEncryptionKey** cmdlet sets the key encryption key properties on a snapshot object.

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -KeyUrl
Specifes the key Url.

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

### -Snapshot
Specifies a local snapshot object.

```yaml
Type: Snapshot
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -SourceVaultId
Specifies the source vault ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Management.Compute.Models.Snapshot
System.String

## OUTPUTS

### Microsoft.Azure.Management.Compute.Models.Snapshot

## NOTES

## RELATED LINKS

