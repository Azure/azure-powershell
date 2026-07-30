---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdappattachpackage
Module Name: Az.DesktopVirtualization
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# Get-AzWvdAppAttachPackage

## SYNOPSIS

Get an app attach package.

## SYNTAX

### List (Default)

```
Get-AzWvdAppAttachPackage [-SubscriptionId <String[]>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get

```
Get-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity

```
Get-AzWvdAppAttachPackage -InputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1

```
Get-AzWvdAppAttachPackage -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## ALIASES

## DESCRIPTION

Get an app attach package.

## EXAMPLES

### Example 1: Get an Azure Virtual Desktop App Attach Package by Name

```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName -Name packageName1
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
```

This command gets an Azure Virtual Desktop App Attach Packages by name.

### Example 2: List all Azure Virtual Desktop App Attach Packages in a resource group

```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
eastus     packageName2  Microsoft.DesktopVirtualization/appattachpackages
```

This command lists Azure Virtual Desktop App Attach Packages in a resource group.

### Example 3: List all Azure Virtual Desktop App Attach Packages in a specified subscription

```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
eastus     packageName2  Microsoft.DesktopVirtualization/appattachpackages
```

This command lists Azure Virtual Desktop App Attach Packages in a subscription.

### Example 4: List all Azure Virtual Desktop App Attach Packages in the current subscription

```powershell
Get-AzWvdAppAttachPackage
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
eastus     packageName2  Microsoft.DesktopVirtualization/appattachpackages
```

This command lists Azure Virtual Desktop App Attach Packages in a subscription.

## PARAMETERS

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

### -Filter

OData filter expression.
Valid properties for filtering are package name, host pool, and resource group.

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List1
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: List
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -InputObject

Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
DefaultValue: None
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: GetViaIdentity
  Position: Named
  IsRequired: true
  ValueFromPipeline: true
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
DontShow: false
AcceptedValues: []
HelpMessage: ''
```

### -Name

The name of the App Attach package

```yaml
Type: System.String
DefaultValue: None
SupportsWildcards: false
Aliases:
- AppAttachPackageName
ParameterSets:
- Name: Get
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
- Name: List1
  Position: Named
  IsRequired: true
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
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
Type: System.String[]
DefaultValue: (Get-AzContext).Subscription.Id
SupportsWildcards: false
Aliases: []
ParameterSets:
- Name: List1
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: List
  Position: Named
  IsRequired: false
  ValueFromPipeline: false
  ValueFromPipelineByPropertyName: false
  ValueFromRemainingArguments: false
- Name: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IAppAttachPackage

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

