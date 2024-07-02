---
external help file:
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azgalleryapplicationversion
schema: 2.0.0
---

# Get-AzGalleryApplicationVersion

## SYNOPSIS
Retrieves information about a gallery Application Version.

## SYNTAX

### List (Default)
```
Get-AzGalleryApplicationVersion -GalleryApplicationName <String> -GalleryName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzGalleryApplicationVersion -GalleryApplicationName <String> -GalleryName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Expand <ReplicationStatusTypes>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzGalleryApplicationVersion -InputObject <IComputeIdentity> [-Expand <ReplicationStatusTypes>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves information about a gallery Application Version.

## EXAMPLES

### Example 1: Get a Gallery Application Version
```powershell
Get-AzGalleryApplicationVersion -ResourceGroupName $rgName -GalleryName $galleryName -GalleryApplicationName $galleryAppName -Name $versionName
```

Retrieve a Gallery Application Version resource with the provided Resource Group, Gallery, Gallery Application name, and version name.

### Example 2: Get all the Gallery Application Versions in a GalleryApplication
```powershell
Get-AzGalleryApplicationVersion -GalleryName $GalleryName -ResourceGroupName $rgName -GalleryApplicationName $galleryAppName
```

Retrieve all the Gallery Application Version resources in the provided Resource Group, Gallery, and Gallery Application Name.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Expand
The expand expression to apply on the operation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ReplicationStatusTypes
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GalleryApplicationName
The name of the gallery Application Definition in which the Application Version resides.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GalleryName
The name of the Shared Application Gallery in which the Application Definition resides.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the gallery Application Version to be retrieved.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: GalleryApplicationVersionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.IComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20220103.IGalleryApplicationVersion

## NOTES

## RELATED LINKS

