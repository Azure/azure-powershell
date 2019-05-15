---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Blueprint.dll-Help.xml
Module Name: Az.Blueprint
online version:
schema: 2.0.0
---

# Export-AzBlueprintWithArtifacts

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### SubscriptionScope (Default)
```
Export-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ExportToFile
```
Export-AzBlueprintWithArtifacts -Blueprint <PSBlueprintBase> -OutputPath <String> [-Version <String>] [-Force]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CreateBlueprintBySubscription
```
Export-AzBlueprintWithArtifacts -Name <String> [-SubscriptionId <String>] -BlueprintFile <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CreateBlueprintByManagementGroup
```
Export-AzBlueprintWithArtifacts -Name <String> -ManagementGroupId <String> -BlueprintFile <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ImportBlueprint
```
Export-AzBlueprintWithArtifacts -Name <String> [-SubscriptionId <String>] [-ManagementGroupId <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### BySubscriptionAndName
```
Export-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BySubscriptionNameAndVersion
```
Export-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BySubscriptionNameAndLatestPublished
```
Export-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ManagementGroupScope
```
Export-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupAndName
```
Export-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupNameAndVersion
```
Export-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupNameAndLatestPublished
```
Export-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Blueprint
The Blueprint definition object to export.

```yaml
Type: PSBlueprintBase
Parameter Sets: ExportToFile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BlueprintFile
Path to a Blueprint JSON file on disk.

```yaml
Type: String
Parameter Sets: CreateBlueprintBySubscription, CreateBlueprintByManagementGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
When set to true, execution will not ask for a confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: ExportToFile
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupId
Management Group Id where the blueprint definition is or will be saved.

```yaml
Type: String
Parameter Sets: CreateBlueprintByManagementGroup, ManagementGroupScope, ByManagementGroupAndName, ByManagementGroupNameAndVersion, ByManagementGroupNameAndLatestPublished
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ImportBlueprint
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Blueprint definition name.

```yaml
Type: String
Parameter Sets: CreateBlueprintBySubscription, CreateBlueprintByManagementGroup, ImportBlueprint
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OutputPath
Path to a file on disk where to export the Blueprint definition in JSON format.

```yaml
Type: String
Parameter Sets: ExportToFile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id where the blueprint definition is or will be saved.

```yaml
Type: String
Parameter Sets: SubscriptionScope, CreateBlueprintBySubscription, ImportBlueprint, BySubscriptionAndName, BySubscriptionNameAndVersion, BySubscriptionNameAndLatestPublished
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Published blueprint definition version.

```yaml
Type: String
Parameter Sets: ExportToFile
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Blueprint.Models.PSBlueprintBase

### System.String

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
