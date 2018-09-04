---
external help file: Microsoft.Azure.Commands.DeploymentManager.dll-Help.xml
Module Name: Microsoft.Azure.Commands.DeploymentManager
online version:
schema: 2.0.0
---

# Get-AzureRmDeploymentManagerArtifactSource

## SYNOPSIS
Gets an artifact source.

## SYNTAX

### Interactive (Default)
```
Get-AzureRmDeploymentManagerArtifactSource [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Get-AzureRmDeploymentManagerArtifactSource [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### InputObject
```
Get-AzureRmDeploymentManagerArtifactSource [-ArtifactSource] <PSArtifactSource>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDeploymentManagerArtifactSource** cmdlet gets an artifact source, and returns an object that represents that artifact source.
Specify the artifact source by its name and resource group name. Alternately, you can provide the ArtifactSource object or the ResourceId.

You can modify this object locally, and then apply changes to the artifact source by using the Set-AzureRmDeploymentManagerArtifactSource cmdlet.

## EXAMPLES

### Example 1: Get an artifact source
```powershell
PS C:\> Get-AzureRmDeploymentManagerArtifactSource -ResourceGroupName "ContosoResourceGroup" -Name "ContosoArtifactSource"
```
This command gets an artifact source named ContosoArtifactSource in ContosoResourceGroup.

### Example 2: Get an artifact source using the resource identifier
```powershell
PS C:\> Get-AzureRmDeploymentManagerArtifactSource -ResourceId "/subscriptions/subscriptionId/resourcegroups/ContosoResourceGroup/providers/Microsoft.DeploymentManager/artifactSources/ContosoArtifactSource"
```
This command gets an artifact source named ContosoArtifactSource in ContosoResourceGroup.

### Example 3: Get an artifact source using an object returned by New-AzureRmDeploymentManagerArtifactSource
```powershell
PS C:\> Get-AzureRmDeploymentManagerArtifactSource -ArtifactSource $artifactSourceObject
```

This command gets an artifact source whose name and ResourceGroup match the Name and ResourceGroupName properties of the $artifactSourceObject, respectively.

## PARAMETERS

### -ArtifactSource
Artifact Source object.

```yaml
Type: Microsoft.Azure.Commands.DeploymentManager.Models.PSArtifactSource
Parameter Sets: InputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the artifact source.

```yaml
Type: System.String
Parameter Sets: Interactive
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group.

```yaml
Type: System.String
Parameter Sets: Interactive
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource identifier.

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.DeploymentManager.Models.PSArtifactSource

## NOTES

## RELATED LINKS

[New-AzureRmDeploymentManagerArtifactSource](./New-AzureRmDeploymentManagerArtifactSource.md)

[Remove-AzureRmDeploymentManagerArtifactSource](./Remove-AzureRmDeploymentManagerArtifactSource.md)

[Set-AzureRmDeploymentManagerArtifactSource](./Set-AzureRmDeploymentManagerArtifactSource.md)