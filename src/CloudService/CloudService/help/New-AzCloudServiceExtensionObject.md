---
external help file: Az.CloudService-help.xml
Module Name: Az.CloudService
online version: https://learn.microsoft.com/powershell/module/Az.CloudService/new-azcloudserviceextensionobject
schema: 2.0.0
---

# New-AzCloudServiceExtensionObject

## SYNOPSIS
Create an in-memory object for Extension.

## SYNTAX

```
New-AzCloudServiceExtensionObject [-AutoUpgradeMinorVersion <Boolean>] [-ForceUpdateTag <String>]
 [-Name <String>] [-ProtectedSetting <String>] [-ProtectedSettingFromKeyVaultSecretUrl <String>]
 [-Publisher <String>] [-RolesAppliedTo <String[]>] [-Setting <String>] [-SourceVaultId <String>]
 [-Type <String>] [-TypeHandlerVersion <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Extension.

## EXAMPLES

### Example 1: Create Geneva extension object
```powershell
$extension = New-AzCloudServiceExtensionObject -Name "GenevaExtension" -Publisher "Microsoft.Azure.Geneva" -Type "GenevaMonitoringPaaS" -TypeHandlerVersion "2.14.0.2"
```

This command creates Geneva extension object which is used for creating or updating a cloud service.
For more details see New-AzCloudService.

## PARAMETERS

### -AutoUpgradeMinorVersion
Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForceUpdateTag
Tag to force apply the provided public and protected settings.
        Changing the tag value allows for re-running the extension without changing any of the public or protected settings.
        If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.
        If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and
        it is up to handler implementation whether to re-run it or not.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the extension.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectedSetting
Protected settings for the extension which are encrypted before sent to the role instance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectedSettingFromKeyVaultSecretUrl
Secret URL which contains the protected settings of the extension.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
The name of the extension handler publisher.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RolesAppliedTo
Optional list of roles to apply this extension.
If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Setting
Public settings for the extension.
For JSON extensions, this is the JSON settings for the extension.
For XML Extension (like RDP), this is the XML setting for the extension.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceVaultId
Resource Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Specifies the type of the extension.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TypeHandlerVersion
Specifies the version of the extension.
Specifies the version of the extension.
If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used.
If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected.
If a major version number and a minor version number are specified (X.Y), the specific extension version is selected.
If a version is specified, an auto-upgrade is performed on the role instance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Extension

## NOTES

## RELATED LINKS
