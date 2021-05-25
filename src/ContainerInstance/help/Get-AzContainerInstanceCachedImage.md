---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module/az.containerinstance/get-azcontainerinstancecachedimage
schema: 2.0.0
---

# Get-AzContainerInstanceCachedImage

## SYNOPSIS
Get the list of cached images on specific OS type for a subscription in a region.

## SYNTAX

```
Get-AzContainerInstanceCachedImage -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the list of cached images on specific OS type for a subscription in a region.

## EXAMPLES

### Example 1: Get the list of cached images for the current subscription in a region.
```powershell
PS C:\> Get-AzContainerInstanceCachedImage -Location eastus

Image                                                                                OSType
-----                                                                                ------
microsoft/dotnet-framework:4.7.2-runtime-20181211-windowsservercore-ltsc2016         Windows
microsoft/dotnet-framework:4.7.2-runtime-20190108-windowsservercore-ltsc2016         Windows
microsoft/dotnet-framework:4.7.2-runtime-20190212-windowsservercore-ltsc2016         Windows
...
```

This command gets the list of cached images for the current subscription in the region `eastus`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The identifier for the physical azure location.

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

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImages

## NOTES

ALIASES

## RELATED LINKS

