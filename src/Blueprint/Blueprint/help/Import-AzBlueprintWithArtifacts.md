---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Blueprint.dll-Help.xml
Module Name: Az.Blueprint
online version:
schema: 2.0.0
---

# Import-AzBlueprintWithArtifacts

## SYNOPSIS
Import a blueprint file in JSON format to a blueprint object and save it within the specified subscription or management group.

## SYNTAX

### SubscriptionScope (Default)
```
Import-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ImportBlueprint
```
Import-AzBlueprintWithArtifacts -InputPath <String> [-Force] -Name <String> [-SubscriptionId <String>]
 [-ManagementGroupId <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CreateBlueprintBySubscription
```
Import-AzBlueprintWithArtifacts -Name <String> [-SubscriptionId <String>] -BlueprintFile <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CreateBlueprintByManagementGroup
```
Import-AzBlueprintWithArtifacts -Name <String> -ManagementGroupId <String> -BlueprintFile <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### BySubscriptionAndName
```
Import-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BySubscriptionNameAndVersion
```
Import-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### BySubscriptionNameAndLatestPublished
```
Import-AzBlueprintWithArtifacts [-SubscriptionId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ManagementGroupScope
```
Import-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupAndName
```
Import-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupNameAndVersion
```
Import-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByManagementGroupNameAndLatestPublished
```
Import-AzBlueprintWithArtifacts -ManagementGroupId <String> [-DefaultProfile <IAzureContextContainer>]
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
Parameter Sets: ImportBlueprint
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputPath
Path to a Blueprint JSON file on disk.

```yaml
Type: String
Parameter Sets: ImportBlueprint
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagementGroupId
Management Group Id where the blueprint definition is or will be saved.

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

### -Name
Blueprint definition name.

```yaml
Type: String
Parameter Sets: ImportBlueprint, CreateBlueprintBySubscription, CreateBlueprintByManagementGroup
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
Parameter Sets: SubscriptionScope, ImportBlueprint, CreateBlueprintBySubscription, BySubscriptionAndName, BySubscriptionNameAndVersion, BySubscriptionNameAndLatestPublished
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

### System.String

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
