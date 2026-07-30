---
document type: cmdlet
external help file: 
HelpUri: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdregistrationinfo
Module Name: Az.DesktopVirtualization
ms.date: 07/29/2026
PlatyPS schema version: 2024-05-01
---

# Get-AzWvdRegistrationInfo

## SYNOPSIS

Get the Azure Virtual Desktop registration info.

## SYNTAX

### Default (Default)

```
Get-AzWvdRegistrationInfo -HostPoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### __AllParameterSets

```
Get-AzWvdRegistrationInfo -ResourceGroupName <string> -HostPoolName <string>
 [-SubscriptionId <string>] [-DefaultProfile <psobject>]
```

## ALIASES

## DESCRIPTION

Get the Azure Virtual Desktop registration info.

## EXAMPLES

### Example 1: Get Existing Registration Info from Hostpool

```powershell
Get-AzWvdRegistrationInfo -ResourceGroupName rgName -HostPoolName hpName
```

```output
ExpirationTime        RegistrationTokenOperation Token
--------------        -------------------------- -----
5/10/2023 12:00:00 PM None                       <base64 encoded string>

```

Retrieves Registration Info for the chosen hostpool.

### Example 2: Get Empty Registration Info from HostPool

```powershell
Get-AzWvdRegistrationInfo -ResourceGroupName rgName -HostPoolname hpName
```

```output
ExpirationTime RegistrationTokenOperation Token
-------------- -------------------------- -----
               None
```

Returns an empty Registration Info for the chosen Hostpool if the Hostpool doesn't have any Registration Info.

## PARAMETERS

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with Azure.

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

### -HostPoolName

Host Pool Name

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

### -ResourceGroupName

Resource Group Name

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

Subscription Id

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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable,
-InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable,
-ProgressAction, -Verbose, -WarningAction, and -WarningVariable. For more information, see
[about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.RegistrationInfo

## NOTES

## RELATED LINKS

{{ Fill in the related links here }}

