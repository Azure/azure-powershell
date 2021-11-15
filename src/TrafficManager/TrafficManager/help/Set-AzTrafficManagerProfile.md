---
external help file: Microsoft.Azure.PowerShell.Cmdlets.TrafficManager.dll-Help.xml
Module Name: Az.TrafficManager
ms.assetid: 975DD42E-61B6-437B-884D-C15A8DB7A667
online version: https://docs.microsoft.com/powershell/module/az.trafficmanager/set-aztrafficmanagerprofile
schema: 2.0.0
---

# Set-AzTrafficManagerProfile

## SYNOPSIS
Updates a Traffic Manager profile.

## SYNTAX

```
Set-AzTrafficManagerProfile -TrafficManagerProfile <TrafficManagerProfile>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzTrafficManagerProfile** cmdlet updates an Azure Traffic Manager profile.
This cmdlet updates the settings of the profile from a local profile object.
You can specify the profile object either by using the *TrafficManagerProfile* parameter or by using the pipeline.

You can obtain a local object that represents a profile by using the Get-AzTrafficManagerProfile cmdlet.
Modify the object locally and then use **Set-AzTrafficManagerProfile** to commit your changes.

## EXAMPLES

### Example 1: Update a profile
```
PS C:\>$TrafficManagerProfile = Get-AzTrafficManagerProfile -Name "ContosoProfile" -ResourceGroupName "ResourceGroup11" 
PS C:\> $TrafficManagerProfile.ProfileStatus = Disabled
PS C:\> Set-AzTrafficManagerProfile -TrafficManagerProfile $TrafficManagerProfile
```

The first command gets an Azure Traffic Manager profile by using the Get-AzTrafficManagerProfile cmdlet.
The command stores the profile locally in the $TrafficManagerProfile variable.

The second command changes that profile locally.
This command disables the profile.

The third command updates the Traffic Manager profile named ContosoProfile to match the local value in $TrafficManagerProfile.

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

### -TrafficManagerProfile
Specifies a local **TrafficManagerProfile** object.
This cmdlet updates Traffic Manager to match this local object.

```yaml
Type: Microsoft.Azure.Commands.TrafficManager.Models.TrafficManagerProfile
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.TrafficManager.Models.TrafficManagerProfile

## OUTPUTS

### Microsoft.Azure.Commands.TrafficManager.Models.TrafficManagerProfile

## NOTES

## RELATED LINKS

[Add-AzTrafficManagerEndpointConfig](./Add-AzTrafficManagerEndpointConfig.md)

[Get-AzTrafficManagerProfile](./Get-AzTrafficManagerProfile.md)

[New-AzTrafficManagerProfile](./New-AzTrafficManagerProfile.md)

[Remove-AzTrafficManagerEndpointConfig](./Remove-AzTrafficManagerEndpointConfig.md)

[Remove-AzTrafficManagerProfile](./Remove-AzTrafficManagerProfile.md)


