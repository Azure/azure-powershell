---
external help file: Microsoft.Azure.Commands.SiteRecovery.dll-Help.xml
ms.assetid: 4CC5E6A8-B51A-49ED-BB93-FE63F1500780
online version: 
schema: 2.0.0
---

# Get-AzureRmSiteRecoveryNetwork

## SYNOPSIS
Gets information about the networks managed by Site Recovery for the current vault.

## SYNTAX

### Default (Default)
```
Get-AzureRmSiteRecoveryNetwork [<CommonParameters>]
```

### ByFriendlyNameLegacy
```
Get-AzureRmSiteRecoveryNetwork -Server <ASRServer> -FriendlyName <String> [<CommonParameters>]
```

### ByNameLegacy
```
Get-AzureRmSiteRecoveryNetwork -Server <ASRServer> -Name <String> [<CommonParameters>]
```

### ByServerObject
```
Get-AzureRmSiteRecoveryNetwork -Server <ASRServer> [<CommonParameters>]
```

### ByFriendlyName
```
Get-AzureRmSiteRecoveryNetwork -Fabric <ASRFabric> -FriendlyName <String> [<CommonParameters>]
```

### ByName
```
Get-AzureRmSiteRecoveryNetwork -Fabric <ASRFabric> -Name <String> [<CommonParameters>]
```

### ByFabricObject
```
Get-AzureRmSiteRecoveryNetwork -Fabric <ASRFabric> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSiteRecoveryNetwork** cmdlet gets information about Azure Site Recovery networks for the current Azure Site Recovery vault.

## EXAMPLES

## PARAMETERS

### -Server
```yaml
Type: ASRServer
Parameter Sets: ByFriendlyNameLegacy, ByNameLegacy, ByServerObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of the virtual machine network.

```yaml
Type: String
Parameter Sets: ByNameLegacy
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FriendlyName
Specifies the friendly name of the virtual machine network.

```yaml
Type: String
Parameter Sets: ByFriendlyNameLegacy
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByFriendlyName
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Fabric
```yaml
Type: ASRFabric
Parameter Sets: ByFriendlyName, ByName, ByFabricObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

