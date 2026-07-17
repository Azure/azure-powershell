---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azpacketcapturesettingsconfig
schema: 2.0.0
---

# New-AzPacketCaptureSettingsConfig

## SYNOPSIS
Creates a new capture setting object.

## SYNTAX

```
New-AzPacketCaptureSettingsConfig [-FileCount <Int32>] [-FileSizeInBytes <Int64>]
 [-SessionTimeLimitInSeconds <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The New-AzPacketCaptureSettingsConfig cmdlet creates a new packet capture settings object. 
This object is being used as a parameter for creating a packet capture, in case, we want to utilize 
the continuous capture capabilities and pass 'Continuous Capture' as true/false.

This New-AzPacketCaptureSettingsConfig cmdlet creates an object of PSPacketCaptureSettings, which contains file count, file size in bytes and session time limit (in second) with default values.

## EXAMPLES

### Example 1
```powershell
New-AzPacketCaptureSettingsConfig -FileCount 2 -FileSizeInBytes 102400 -SessionTimeLimitInSeconds 60
```

In the above example, passing file count with file size and session time (in seconds). It will create an object.

### Example 2
```powershell
New-AzPacketCaptureSettingsConfig
```

In the above example, without passing any parameters. It will create an object with default values,

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

### -FileCount
Number of file count. Default value is 1.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 1
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FileSizeInBytes
Number of bytes captured per packet. Default value is 1073741824.

```yaml
Type: System.Nullable`1[System.Int64]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 1073741824
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SessionTimeLimitInSeconds
Capture session in seconds. Default value is 18000.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 18000
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Nullable`1[[System.Int64, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPacketCaptureSettings

## NOTES

## RELATED LINKS
