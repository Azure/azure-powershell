---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version:
schema: 2.0.0
---

# Set-AzSecurityAutomation

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### ResourceGroupLevelResource (Default)
```
Set-AzSecurityAutomation -ResourceGroupName <String> -Name <String> -Location <String> [-Etag <String>]
 [-Tags <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-Description <String>]
 [-IsEnabled <Boolean>] -Scopes <PSSecurityAutomationScope[]> -Sources <PSSecurityAutomationSource[]>
 -Actions <PSSecurityAutomationAction[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResourceId
```
Set-AzSecurityAutomation -ResourceId <String> -Location <String> [-Etag <String>]
 [-Tags <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-Description <String>]
 [-IsEnabled <Boolean>] -Scopes <PSSecurityAutomationScope[]> -Sources <PSSecurityAutomationSource[]>
 -Actions <PSSecurityAutomationAction[]> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObject
```
Set-AzSecurityAutomation [-Location <String>] [-Etag <String>]
 [-Tags <System.Collections.Generic.IDictionary`2[System.String,System.String]>] [-Description <String>]
 [-IsEnabled <Boolean>] [-Scopes <PSSecurityAutomationScope[]>] [-Sources <PSSecurityAutomationSource[]>]
 -Actions <PSSecurityAutomationAction[]> -InputObject <PSSecurityAutomation>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Actions
A collection of the actions which are triggered if all the configured rules evaluations, within at least one rule set, are true

```yaml
Type: PSSecurityAutomationAction[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -Description
The security automation description

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

### -Etag
Entity tag is used for comparing two or more entities from the same requested resource

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

### -InputObject
Input Object.

```yaml
Type: PSSecurityAutomation
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsEnabled
Is rule enabled.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location.

```yaml
Type: String
Parameter Sets: ResourceGroupLevelResource, ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: InputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name.

```yaml
Type: String
Parameter Sets: ResourceGroupLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: String
Parameter Sets: ResourceGroupLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the security resource that you want to invoke the command on.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scopes
A collection of scopes on which the security automations logic is applied.
Supported scopes are the subscription itself or a resource group under that subscription.
The automation will only apply on defined scopes

```yaml
Type: PSSecurityAutomationScope[]
Parameter Sets: ResourceGroupLevelResource, ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: PSSecurityAutomationScope[]
Parameter Sets: InputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sources
A collection of the source event types which evaluate the security automation set of rules

```yaml
Type: PSSecurityAutomationSource[]
Parameter Sets: ResourceGroupLevelResource, ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: PSSecurityAutomationSource[]
Parameter Sets: InputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tags
Tags.

```yaml
Type: System.Collections.Generic.IDictionary`2[System.String,System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomation

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomation

## NOTES

## RELATED LINKS
