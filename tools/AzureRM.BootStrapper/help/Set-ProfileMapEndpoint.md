---
external help file: AzureRM.Bootstrapper-help.xml
Module Name: AzureRM.BootStrapper
online version:
schema: 2.0.0
---

# Set-ProfileMapEndpoint

## SYNOPSIS
Set the profile map endpoint from where the users of disconnected soverign clouds can download the updated profile map and use it with AzureRm.Bootstrapper module to work with API version profiles.

## SYNTAX

```
Set-ProfileMapEndpoint [-Endpoint] <String> [-force] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
ProfileMap is a JSON file which contains supported API version profiles and corresponding modules. By default, it points to a storage blob in Azure and is updated regularly to reflect the latest changes. In case of disconnected soverign clouds, it's not possible to download this profile map if there are any updates. This cmdlet helps the users of disconnected soverign clouds to configure the endpoint from where they can download the updated profile map and use with Bootstrapper module to work with API version profiles.

## EXAMPLES

### Example 1
```powershell
PS C:\> Set-ProfileMapEndpoint -Endpoint "<Location of profilemap endpoint>"
```

This sets the ProfileMap Endpoint to the given location and downloads the ProfileMap from the given location in case updates are required.

## PARAMETERS

### -Endpoint
Location of profilemap endpoint

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -force
Automatically set the given endpoint as ProfileMapEndpoint without asking for confirmation.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
