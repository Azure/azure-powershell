---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/get-azwebapppublishingprofile
schema: 2.0.0
---

# Get-AzWebAppPublishingProfile

## SYNOPSIS
Gets the publishing profile for an app (or deployment slot, if specified).

## SYNTAX

### ListExpanded (Default)
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -OutFile <String>
 [-SubscriptionId <String[]>] [-Format <PublishingProfileFormat>] [-IncludeDisasterRecoveryEndpoints]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -OutFile <String>
 -PublishingProfileOption <ICsmPublishingProfileOptions> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### List1
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -Slot <String> -OutFile <String>
 -PublishingProfileOption <ICsmPublishingProfileOptions> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListExpanded1
```
Get-AzWebAppPublishingProfile -Name <String> -ResourceGroupName <String> -Slot <String> -OutFile <String>
 [-SubscriptionId <String[]>] [-Format <PublishingProfileFormat>] [-IncludeDisasterRecoveryEndpoints]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets the publishing profile for an app (or deployment slot, if specified).

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Format
Name of the format.
Valid values are: FileZilla3WebDeploy -- defaultFtp

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.PublishingProfileFormat
Parameter Sets: ListExpanded, ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IncludeDisasterRecoveryEndpoints
Include the DisasterRecover endpoint if true

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListExpanded, ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OutFile
Path to write output file to

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublishingProfileOption
Publishing options for requested profile.
To construct, see NOTES section for PUBLISHINGPROFILEOPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICsmPublishingProfileOptions
Parameter Sets: List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of the deployment slot.
If a slot is not specified, the API will get the publishing profile for the production slot.

```yaml
Type: System.String
Parameter Sets: List1, ListExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICsmPublishingProfileOptions

## OUTPUTS

### System.Boolean

## ALIASES

### Get-AzWebAppPublishingProfile

### Get-AzWebAppSlotPublishingProfile

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### PUBLISHINGPROFILEOPTION <ICsmPublishingProfileOptions>: Publishing options for requested profile.
  - `[Format <PublishingProfileFormat?>]`: Name of the format. Valid values are:         FileZilla3         WebDeploy -- default         Ftp
  - `[IncludeDisasterRecoveryEndpoint <Boolean?>]`: Include the DisasterRecover endpoint if true

## RELATED LINKS

