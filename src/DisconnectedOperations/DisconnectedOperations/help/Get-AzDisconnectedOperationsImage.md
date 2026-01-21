---
external help file: Az.DisconnectedOperations-help.xml
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/get-azdisconnectedoperationsimage
schema: 2.0.0
---

# Get-AzDisconnectedOperationsImage

## SYNOPSIS
Get the resource.

## SYNTAX

### List (Default)
```
Get-AzDisconnectedOperationsImage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityDisconnectedOperation
```
Get-AzDisconnectedOperationsImage -ImageName <String>
 -DisconnectedOperationInputObject <IDisconnectedOperationsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDisconnectedOperationsImage -ImageName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDisconnectedOperationsImage -InputObject <IDisconnectedOperationsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the resource.

## EXAMPLES

### Example 1: List all images from a specified DisconnectedOperation
```powershell
Get-AzDisconnectedOperationsImage -Name "Resource-1" -ResourceGroupName "ResourceGroup-1"
```

```output
Name              SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----              ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
release-v2509                                                                                                                                                    ResourceGroup-1
release-v2508                                                                                                                                                    ResourceGroup-1
release0811                                                                                                                                                      ResourceGroup-1
june-2025-release                                                                                                                                                ResourceGroup-1
```

This command lists all the images from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1`.

### Example 2: Get a specific image from a DisconnectedOperation
```powershell
Get-AzDisconnectedOperationsImage -ImageName "release-v2509" -Name "Resource-1" -ResourceGroupName "ResourceGroup-1"
```

```output
CompatibleVersion            : {}
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedOperations/Resource-1/images/release-v2509
Name                         : release-v2509
ProvisioningState            : Succeeded
ReleaseDate                  : 10/17/2025 00:00:00
ReleaseDisplayName           : release-v2509
ReleaseNote                  : https://aka.ms/aldo-publicdocs
ReleaseType                  : Install
ReleaseVersion               : 1.0.1
ResourceGroupName            : ResourceGroup-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Edge/disconnectedOperations/images
```

This command gets the image `release-v2509` from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1`.

### Example 3: GetViaIdentity for image.
```powershell
$disconnectedOperationsImage = @{
  "ImageName" = "default";
  "Name" = "Resource-1";
  "ResourceGroupName" = "ResourceGroup-1";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsImage -InputObject $disconnectedOperationsImage
```

```output
CompatibleVersion            : {}
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedOperations/Resource-1/images/release-v2509
Name                         : release-v2509
ProvisioningState            : Succeeded
ReleaseDate                  : 10/17/2025 00:00:00
ReleaseDisplayName           : release-v2509
ReleaseNote                  : https://aka.ms/aldo-publicdocs
ReleaseType                  : Install
ReleaseVersion               : 1.0.1
ResourceGroupName            : ResourceGroup-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Edge/disconnectedOperations/images
```

This command gets the default or latest image from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1` using InputObject for image.

### Example 4: GetViaIdentityDisconnectedOperations for image.
```powershell
$disconnectedOperations = @{
  "Name" = "Resource-1";
  "ResourceGroupName" = "ResourceGroup-1";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsImage -ImageName "default" -DisconnectedOperationInputObject $disconnectedOperations
```

```output
CompatibleVersion            : {}
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/ResourceGroup-1/providers/Microsoft.Edge/disconnectedOperations/Resource-1/images/release-v2509
Name                         : release-v2509
ProvisioningState            : Succeeded
ReleaseDate                  : 10/17/2025 00:00:00
ReleaseDisplayName           : release-v2509
ReleaseNote                  : https://aka.ms/aldo-publicdocs
ReleaseType                  : Install
ReleaseVersion               : 1.0.1
ResourceGroupName            : ResourceGroup-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Edge/disconnectedOperations/images
```

This command gets the default or latest image from the DisconnectedOperation `Resource-1` in resource group `ResourceGroup-1` using DisconnectedOperationsObject and ImageName.

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

### -DisconnectedOperationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: GetViaIdentityDisconnectedOperation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Filter
Filter the result list using the given expression.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageName
The name of the Image

```yaml
Type: System.String
Parameter Sets: GetViaIdentityDisconnectedOperation, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the resource

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImage

## NOTES

## RELATED LINKS
