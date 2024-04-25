---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/export-azsynapsesparkconfiguration
schema: 2.0.0
---

# Export-AzSynapseSparkConfiguration

## SYNOPSIS
Exports a Synapse spark configuration to an output folder.

## SYNTAX

### ExportByName (Default)
```
Export-AzSynapseSparkConfiguration -WorkspaceName <String> [-Name <String>] -OutputFolder <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ExportByObject
```
Export-AzSynapseSparkConfiguration -WorkspaceObject <PSSynapseWorkspace> [-Name <String>]
 -OutputFolder <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ExportByInputObject
```
Export-AzSynapseSparkConfiguration -InputObject <PSSparkConfigurationResource> -OutputFolder <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Export-AzSynapseSparkConfiguration** cmdlet exports a Synapse spark configuration to a configuration(.json) file.
The name of the spark configuration becomes the name of the exported file. If you specify the name of a spark configuration, the cmdlet exports that spark configuration. If you do not specify a name, the cmdlet export all spark configurations in the workspace.

## EXAMPLES

### Example 1
```powershell
Export-AzSynapseSparkConfiguration -WorkspaceName ContosoWorkspace -OutputFolder "C:\SparkConfiguration"
```

Exports all spark configurations in the workspace ContosoWorkspace to the folder "C:\SparkConfiguration".

### Example 2
```powershell
Export-AzSynapseSparkConfiguration -WorkspaceName ContosoWorkspace -Name ContoSparkConfiguration -OutputFolder "C:\SparkConfiguration"
```

Exports a single spark configuration named ContoSparkConfiguration in the workspace ContosoWorkspace to the folder "C:\SparkConfiguration".

### Example 3
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Export-AzSynapseSparkConfiguration -Name ContoSparkConfiguration -OutputFolder "C:\SparkConfiguration"
```

Exports a single spark configuration named ContoSparkConfiguration in the workspace ContosoWorkspace to the folder "C:\SparkConfiguration" through pipeline.

### Example 4
```powershell
$sparkConfiguration = Get-AzSynapseSparkConfiguration -WorkspaceName ContosoWorkspace -Name ContoSparkConfiguration
$sparkConfiguration | Export-AzSynapseSparkConfiguration -OutputFolder "C:\SparkConfiguration"
```

Exports a single spark configuration called ContoSparkConfiguration in the workspace ContosoWorkspace to the folder "C:\SparkConfiguration" through pipeline.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Spark configuration object.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSparkConfigurationResource
Parameter Sets: ExportByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Spark Configuration name.

```yaml
Type: System.String
Parameter Sets: ExportByName, ExportByObject
Aliases: SparkConfigurationName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputFolder
The folder where the spark configuration should be placed.

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

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: ExportByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceObject
workspace input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace
Parameter Sets: ExportByObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

### Microsoft.Azure.Commands.Synapse.Models.PSSparkConfigurationResource

## OUTPUTS

### System.IO.FileInfo

## NOTES

## RELATED LINKS
