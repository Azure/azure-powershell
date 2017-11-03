---
external help file: Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml
Module Name: AzureRM.Resources
online version: 
schema: 2.0.0
---

# Get-AzureRmManagedApplicationDefinition

## SYNOPSIS
Gets managed application definitions

## SYNTAX

### The managed application definition name parameter set. (Default)
```
Get-AzureRmManagedApplicationDefinition [-Name <String>] -ResourceGroupName <String> [-ApiVersion <String>]
 [-Pre] [-DefaultProfile <IAzureContextContainer>]
```

### The managed application definition Id parameter set.
```
Get-AzureRmManagedApplicationDefinition -Id <String> [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Get-AzureRmManagedApplicationDefinition** cmdlet gets managed application definitions

## EXAMPLES

### Example 1: Get all managed application definitions under a resource group
```
PS C:\>Get-AzureRmManagedApplicationDefinition -ResourceGroupName "MyRG"
```

This command gets the managed application definitions under resource group "MyRG"

### Example 2: Get a managed application definition
```
PS C:\>Get-AzureRmManagedApplicationDefinition -ResourceGroupName "MyRG" -Name "myManagedAppDef"
```

This command gets the managed application definition "myManagedAppDef" under resource group "MyRG"

## PARAMETERS

### -ApiVersion
When set, indicates the version of the resource provider API to use.
If not specified, the API version is automatically determined as the latest available.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The fully qualified managed application definition Id, including the subscription.
e.g.
/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}

```yaml
Type: String
Parameter Sets: The managed application definition Id parameter set.
Aliases: ResourceId, ManagedApplicationDefinitionId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The managed application definition name.

```yaml
Type: String
Parameter Sets: The managed application definition name parameter set.
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: The managed application definition name parameter set.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Management.Automation.PSObject


## NOTES

## RELATED LINKS

