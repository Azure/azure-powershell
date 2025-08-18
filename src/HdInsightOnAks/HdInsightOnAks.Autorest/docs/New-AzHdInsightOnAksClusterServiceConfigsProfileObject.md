---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksclusterserviceconfigsprofileobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterServiceConfigsProfileObject

## SYNOPSIS
Create an in-memory object for ClusterServiceConfigsProfile.

## SYNTAX

```
New-AzHdInsightOnAksClusterServiceConfigsProfileObject -Config <IClusterServiceConfig[]> -ServiceName <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ClusterServiceConfigsProfile.

## EXAMPLES

### Example 1: Create a service config profile
```powershell
$coreSiteConfigFile=New-AzHdInsightOnAksClusterConfigFileObject -FileName "core-site.xml" -Value @{"fs.defaultFS"="abfs://testcontainer@$teststorage.dfs.core.windows.net"}
$yarnComponentConfig= New-AzHdInsightOnAksClusterServiceConfigObject -ComponentName "yarn-config" -File $coreSiteConfigFile
$yarnServiceConfigProfile=New-AzHdInsightOnAksClusterServiceConfigsProfileObject -ServiceName "yarn-service" -Config $yarnComponentConfig
```

This cmdlet creates the service config profile of "yarn-service" with the ComponentName service config.

## PARAMETERS

### -Config
List of service configs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterServiceConfig[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
Name of the service the configurations should apply to.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ClusterServiceConfigsProfile

## NOTES

## RELATED LINKS

