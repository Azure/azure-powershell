---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/new-azsynapseworkspacepackage
schema: 2.0.0
---

# New-AzSynapseWorkspacePackage

## SYNOPSIS
Uploads a local workspace package file to an Azure Synapse workspace.

## SYNTAX

### CreateByNameParameterSet (Default)
```
New-AzSynapseWorkspacePackage -WorkspaceName <String> -Package <String> [-ConcurrentTaskCount <Int32>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateByObjectParameterSet
```
New-AzSynapseWorkspacePackage -WorkspaceObject <PSSynapseWorkspace> -Package <String>
 [-ConcurrentTaskCount <Int32>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSynapseWorkspacePackage** uploads a local workspace package file to an Azure Synapse workspace.

## EXAMPLES

### Example 1: Upload a named workspace package
```powershell
New-AzSynapseWorkspacePackage -WorkspaceName ContosoWorkspace -Package ".\ContosoPackage.whl"
```

This command uploads the workspace package whose location is ".\ContosoPackage.whl" to an Azure Synapse workspace named ContosoWorkspace. The workspace pacakge can be either wheel or jar files.

### Example 2: Upload all workspace packages under the current folder
```powershell
Get-ChildItem -File | New-AzSynapseWorkspacePackage -WorkspaceName ContosoWorkspace
```

This command uses the core Windows PowerShell cmdlet Get-ChildItem to get all the workspace packages in the current folder and in subfolders, and then passes them to the current cmdlet by using the pipeline operator. The New-AzSynapseWorkspacePackage cmdlet uploads the workspace package files to the Azure Synapse workspace named ContosoWorkspace.

### Example 3: Upload a named workspace package and add it to Apache Spark pool
```powershell
$package = New-AzSynapseWorkspacePackage -WorkspaceName ContosoWorkspace -Package ".\ContosoPackage.whl"
Update-AzSynapseSparkPool -WorkspaceName ContosoWorkspace -Name ContosoSparkPool -PackageAction Add -Package $package
```

This first command uploads the workspace package whose location is ".\ContosoPackage.whl" to an Azure Synapse workspace named ContosoWorkspace. The workspace pacakge can be either wheel or jar files. Then the second command addes the package to a given Apache Spark pool named ContotoSparkPool.

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

### -ConcurrentTaskCount
The total amount of concurrent async tasks.
The default value is 10.

```yaml
Type: System.Nullable`1[System.Int32]
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

### -Package
Specifies a local file path for a file to upload as workspace package.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FullName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
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
Parameter Sets: CreateByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.WorkspacePackages.PSSynapseWorkspacePackage

## NOTES

## RELATED LINKS
