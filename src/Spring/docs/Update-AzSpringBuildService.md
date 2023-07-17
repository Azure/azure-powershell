---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.spring/update-azspringbuildservice
schema: 2.0.0
---

# Update-AzSpringBuildService

## SYNOPSIS
Create a KPack build.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSpringBuildService -BuildName <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-AgentPool <String>] [-Builder <String>] [-Env <Hashtable>]
 [-RelativePath <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityBuildService
```
Update-AzSpringBuildService -BuildName <String> -BuildServiceInputObject <ISpringIdentity> -Build <IBuild>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityBuildServiceExpanded
```
Update-AzSpringBuildService -BuildName <String> -BuildServiceInputObject <ISpringIdentity>
 [-AgentPool <String>] [-Builder <String>] [-Env <Hashtable>] [-RelativePath <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSpringBuildService -InputObject <ISpringIdentity> [-AgentPool <String>] [-Builder <String>]
 [-Env <Hashtable>] [-RelativePath <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentitySpring
```
Update-AzSpringBuildService -BuildName <String> -SpringInputObject <ISpringIdentity> -Build <IBuild>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentitySpringExpanded
```
Update-AzSpringBuildService -BuildName <String> -SpringInputObject <ISpringIdentity> [-AgentPool <String>]
 [-Builder <String>] [-Env <Hashtable>] [-RelativePath <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a KPack build.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AgentPool
The resource id of agent pool

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityBuildServiceExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Build
Build resource payload
To construct, see NOTES section for BUILD properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuild
Parameter Sets: UpdateViaIdentityBuildService, UpdateViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Builder
The resource id of builder to build the source code

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityBuildServiceExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildName
The name of the build resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityBuildService, UpdateViaIdentityBuildServiceExpanded, UpdateViaIdentitySpring, UpdateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BuildServiceInputObject
Identity Parameter
To construct, see NOTES section for BUILDSERVICEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: UpdateViaIdentityBuildService, UpdateViaIdentityBuildServiceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Env
The environment variables for this build

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityBuildServiceExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RelativePath
The relative path of source code

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityBuildServiceExpanded, UpdateViaIdentityExpanded, UpdateViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter
To construct, see NOTES section for SPRINGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity
Parameter Sets: UpdateViaIdentitySpring, UpdateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuild

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.ISpringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.IBuild

## NOTES

## RELATED LINKS

