---
external help file:
Module Name: Az.DisconnectedOperations
online version: https://learn.microsoft.com/powershell/module/az.disconnectedoperations/get-azdisconnectedoperationsartifact
schema: 2.0.0
---

# Get-AzDisconnectedOperationsArtifact

## SYNOPSIS
Get the resource

## SYNTAX

### List (Default)
```
Get-AzDisconnectedOperationsArtifact -ImageName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDisconnectedOperationsArtifact -ArtifactName <String> -ImageName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDisconnectedOperationsArtifact -InputObject <IDisconnectedOperationsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityDisconnectedOperation
```
Get-AzDisconnectedOperationsArtifact -ArtifactName <String>
 -DisconnectedOperationInputObject <IDisconnectedOperationsIdentity> -ImageName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityImage
```
Get-AzDisconnectedOperationsArtifact -ArtifactName <String>
 -ImageInputObject <IDisconnectedOperationsIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the resource

## EXAMPLES

### Example 1: List all artifacts from a specified image
```powershell
Get-AzDisconnectedOperationsArtifact -ImageName "default" -Name "disconnected-operation-name" -ResourceGroupName "my-resource-group"
```

```output
Name                   SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                   ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
My-artifact-1                                                                                                                                                         my-resource-group
My-artifact-2                                                                                                                                                         my-resource-group                                                                    
```

This command lists all the artifacts from image `default` in resource group `my-resource-group`

### Example 2: Get a specific artifact by name
```powershell
Get-AzDisconnectedOperationsArtifact -ArtifactName "my-artifact" -ImageName "default" -Name "disconnected-operation-name" -ResourceGroupName "my-resource-group"
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group`	

### Example 3: GetViaIdentity for artifact.
```powershell
$disconnectedOperationsArtifact = @{
  "ArtifactName" = "my-artifact";
  "ImageName" = "default";
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsArtifact -InputObject $disconnectedOperationsArtifact
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact.vhdx
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx` via the Artifact Identity input object.

### Example 4: GetViaIdentityImage for artifact.
```powershell
$disconnectedOperationsImage = @{
  "ImageName" = "default";
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsArtifact -ArtifactName "my-artifact" -ImageInputObject $disconnectedOperationsImage
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact.vhdx
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx` via the Image Identity input object.

### Example 5: GetViaIdentityDisconnectedOperation for artifact.
```powershell
$disconnectedOperations = @{
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}
Get-AzDisconnectedOperationsArtifact -ArtifactName "my-artifact" -ImageName "default" -DisconnectedOperationInputObject $disconnectedOperations
```

```output
Description                  : Local data disk
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.Edge/disconnectedOperations/disconnected-operation-name/images/default/artifacts/my-artifact
Name                         : my-artifact
Order                        : 2
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
Size                         : 35068
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Title                        : my-artifact.vhdx
Type                         : Microsoft.Edge/disconnectedOperations/images/artifacts
```

This command gets the artifact `my-artifact` from image `default` in resource group `my-resource-group` from subscription `xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx` via the DisconnectedOperations Identity input object.

## PARAMETERS

### -ArtifactName
The name of the Artifact

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityDisconnectedOperation, GetViaIdentityImage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -ImageInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity
Parameter Sets: GetViaIdentityImage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ImageName
The name of the Image

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityDisconnectedOperation, List
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifact

## NOTES

## RELATED LINKS

