---
external help file: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.dll-Help.xml
Module Name: Az.FrontDoor
online version:
schema: 2.0.0
---

# New-AzFrontDoorBackendPoolsSettingsObject

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

```
New-AzFrontDoorBackendPoolsSettingsObject -EnforceCertificateNameCheck <PSEnforceCertificateNameCheck>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Create a PSBackendPoolsSettings object for Front Door creation that apply to all backend pools

## EXAMPLES

### Example 1 : Create backend pools settings
```powershell
PS C:> New-AzFrontDoorBackendPoolsSettingsObject -EnforceCertificateNameCheck Enabled

EnforceCertificateNameCheck
---------------------------
                    Enabled
```

Create backend pools settings object with certificate name check enforced

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

### -EnforceCertificateNameCheck
Whether to enforce certificate name check on HTTPS requests to all backend pools.
No effect on non-HTTPS requests.

```yaml
Type: Microsoft.Azure.Commands.FrontDoor.Models.PSEnforceCertificateNameCheck
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled

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

### Microsoft.Azure.Commands.FrontDoor.Models.PSBackendPoolsSettings

## NOTES

## RELATED LINKS
