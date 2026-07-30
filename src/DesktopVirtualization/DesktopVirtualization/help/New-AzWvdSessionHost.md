---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdsessionhost
Module Name: Az.DesktopVirtualization
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# New-AzWvdSessionHost

## SYNOPSIS

Create a sessionHost.

## SYNTAX

### CreateExpanded (Default)

```
New-AzWvdSessionHost -HostPoolName <string> -Name <string> -ResourceGroupName <string>
 [-SubscriptionId <string>] [-AllowNewSession] [-AssignedUser <string>] [-FriendlyName <string>]
 [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

### CreateViaJsonFilePath

```
New-AzWvdSessionHost -HostPoolName <string> -Name <string> -ResourceGroupName <string>
 -JsonFilePath <string> [-SubscriptionId <string>] [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

### CreateViaJsonString

```
New-AzWvdSessionHost -HostPoolName <string> -Name <string> -ResourceGroupName <string>
 -JsonString <string> [-SubscriptionId <string>] [-DefaultProfile <psobject>] [-WhatIf] [-Confirm]
```

## ALIASES

## DESCRIPTION

Create a sessionHost.

## EXAMPLES

### Example 1: Create an Azure Virtual Desktop SessionHost

```powershell
New-AzWvdSessionHost -ResourceGroupName resourceGroup1 -HostPoolName hostPool1 -Name sessionHost1.microsoft.com
```

```output
Name                                          Type
----                                          ----
hostPool1/sessionHost1.microsoft.com          Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command creates a new Azure Virtual Desktop SessionHost in a Host Pool.

### Example 2: Create an Azure Virtual Desktop SessionHost with friendly name

```powershell
New-AzWvdSessionHost -ResourceGroupName resourceGroup1 `
                     -HostPoolName hostPool1 `
                     -Name sessionHost1.microsoft.com `
                     -FriendlyName 'Friendly Name' `
                     -AllowNewSession
```

```output
Name                                          Type
----                                          ----
hostPool1/sessionHost1.microsoft.com          Microsoft.DesktopVirtualization/hostpools/sessionhosts
```

This command creates a new Azure Virtual Desktop SessionHost in a Host Pool with a friendly name and allows new sessions.

## PARAMETERS

### -AllowNewSession

Allow a new session.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CreateExpanded
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -AssignedUser

User assigned to SessionHost.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CreateExpanded
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Confirm

Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- cf
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -DefaultProfile

The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
DefaultValue: None
SupportsWildcards: false
Aliases:
- AzureRMContext
- AzureCredential
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -FriendlyName

Friendly name of SessionHost

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CreateExpanded
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -HostPoolName

The name of the host pool within the specified resource group

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -JsonFilePath

Path of Json file supplied to the Create operation

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CreateViaJsonFilePath
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -JsonString

Json string supplied to the Create operation

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: CreateViaJsonString
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

The name of the session host within the specified host pool

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases:
- SessionHostName
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -ResourceGroupName

The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -SubscriptionId

The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -WhatIf

Shows what would happen if the cmdlet runs.
The cmdlet is not run.
Runs the command in a mode that only reports what would happen without performing the actions.

```yaml
Type: System.Management.Automation.SwitchParameter
DefaultValue: None
SupportsWildcards: false
Aliases:
- wi
ParameterSets:
- Name: (All)
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.ISessionHost

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

