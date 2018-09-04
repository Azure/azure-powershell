---
external help file: Microsoft.Azure.Commands.DeploymentManager.dll-Help.xml
Module Name: Microsoft.Azure.Commands.DeploymentManager
online version:
schema: 2.0.0
---

# New-AzureRmDeploymentManagerArtifactSource

## SYNOPSIS
Creates an artifact source.

## SYNTAX

```
New-AzureRmDeploymentManagerArtifactSource -ResourceGroupName <String> -Name <String> -Location <String>
 -SasUri <String> [-ArtifactRoot <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmDeploymentManagerArtifactSource** cmdlet creates an artifact source.
Specify the *Name*, *ResourceGroupName* and required properties.

You can modify the returned object locally and then apply the changes to the artifact source by using the Set-AzureRmDeploymentManagerArtifactSource cmdlet.

The cmdlet returns an ArtifactSource object that has a ResourceId which can be referenced in the New-AzureRmDeloymentManagerServiceTopology cmdlet so that artifacts required for a ServiceUnit resource, the Template and Parameters files, can be referenced from this location.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmDeploymentManagerArtifactSource -ResourceGroupName ContosoResourceGroup -Name ContosoArtifactSource -Location "Central US" -SasUri "https://ContosoStorage.blob.core.windows.net/ContosoArtifacts?sasParameters"
```

Creates an artifact source in the ContosoResourceGroup with the name ContosoArtifactSource with Central US as the location of the resource. The SasUri property provides an Azure Storage SAS Uri to the storage container where the artifacts are stored.

## PARAMETERS

### -ArtifactRoot
The optional directory offset under the storage container for the artifacts.

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

### -Location
The location of the resource.

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

### -Name
The name of the artifact source.

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

### -ResourceGroupName
The resource group.

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

### -SasUri
The SAS Uri to the Azure storage container where the artifacts are stored.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.DeploymentManager.Models.PSArtifactSource

## NOTES

## RELATED LINKS

[Get-AzureRmDeploymentManagerArtifactSource](./Get-AzureRmDeploymentManagerArtifactSource.md)

[Remove-AzureRmDeploymentManagerArtifactSource](./Remove-AzureRmDeploymentManagerArtifactSource.md)

[Set-AzureRmDeploymentManagerArtifactSource](./Set-AzureRmDeploymentManagerArtifactSource.md)