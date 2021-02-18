---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-aztemplatespec
schema: 2.0.0
---

# Get-AzTemplateSpec

## SYNOPSIS
Gets or lists Template Specs

## SYNTAX

### ListTemplateSpecsParameterSet (Default)
```
Get-AzTemplateSpec [[-ResourceGroupName] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetTemplateSpecByNameParameterSet
```
Get-AzTemplateSpec [-ResourceGroupName] <String> [-Name] <String> [[-Version] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetTemplateSpecByIdParameterSet
```
Get-AzTemplateSpec [[-Version] <String>] [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet can be used to list Template Specs in a subscription/resource group or get a specific Template Spec 
by name or id. When getting a specific Template Spec by name/id a specific version can optionally be retrieved
by specifying a version name through the **-Version** parameter. When **-Version** is used, only the specific version 
details will be present within **.Versions* on the returned Template Spec object. If no specific version 
is specified when retrieving a Template Spec by name/id, all versions will be present within the  **.Versions*
property of the returned object.

**Note**: When listing all Template Specs within a subscription or resource group, each returned Template Spec's
 *".Versions"* property will be *null*. Version information is only included when -Name or -ResourceId parameters
are provided (eg: you are requesting a specific template spec/version).

## EXAMPLES

### Example 1: List Template Specs in current subscription
```powershell
PS C:\> Get-AzTemplateSpec
```

Lists all Template Specs in the current subscription.

### Example 2: List Template Specs in a resource group
```powershell
PS C:\> Get-AzTemplateSpec -ResourceGroupName 'myRG'
```

Lists all Template Specs in the resource group 'myRG' of the current subscription.

### Example 3: Get Template Spec (with all versions) by name
```powershell
PS C:\> Get-AzTemplateSpec -ResourceGroupName 'myRG' -Name 'MyTemplateSpec'
```

Gets information about the Template Spec named 'MyTemplateSpec' within the resource group 'myRG'.

**Note**: All of the Template Spec's versions will be present within the "*.Versions*" property 
of the return object.

### Example 4: Get Template Spec (specific version) by name
```powershell
PS C:\> Get-AzTemplateSpec -ResourceGroupName 'myRG' -Name 'MyTemplateSpec' -Version 'v1.0'
```

Gets information about version 'v1.0' of the Template Spec named 'MyTemplateSpec' within the resource group 'myRG'.

**Note**: The *".Versions"* property of the returned object will contain only the specific version requested.

### Example 5: Get Template Spec (with all versions) by resource id
```powershell
PS C:\> Get-AzTemplateSpec -ResourceId '/subscriptions/{subId}/resourceGroups/myRG/providers/Microsoft.Resources/templateSpecs/MyTemplateSpec'
```

Gets information about the Template Spec named 'MyTemplateSpec' within the resource group 'myRG' of subscription \{subId\}.

**Note**: All of the Template Spec's versions will be present within the "*.Versions*" property 
of the return object.

### Example 6: Get Template Spec (specific version) by resource id
```powershell
PS C:\> Get-AzTemplateSpec -ResourceId '/subscriptions/{subId}/resourceGroups/myRG/providers/Microsoft.Resources/templateSpecs/MyTemplateSpec' -Version 'v1.0'
```

Gets information about version 'v1.0' of the Template Spec named 'MyTemplateSpec' within the resource group 'myRG' of subscription \{subId\}.

**Note**: The *".Versions"* property of the returned object will contain only the specific version requested.

## PARAMETERS

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

### -Name
The name of the template spec.

```yaml
Type: System.String
Parameter Sets: GetTemplateSpecByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: ListTemplateSpecsParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetTemplateSpecByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The fully qualified resource Id of the template spec.
Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/templateSpecs/{templateSpecName}

```yaml
Type: System.String
Parameter Sets: GetTemplateSpecByIdParameterSet
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
The version of the template spec.

```yaml
Type: System.String
Parameter Sets: GetTemplateSpecByNameParameterSet, GetTemplateSpecByIdParameterSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSTemplateSpec

## NOTES

## RELATED LINKS
