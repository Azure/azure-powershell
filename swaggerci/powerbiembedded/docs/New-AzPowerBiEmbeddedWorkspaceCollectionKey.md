---
external help file:
Module Name: Az.PowerBiEmbedded
online version: https://docs.microsoft.com/en-us/powershell/module/az.powerbiembedded/new-azpowerbiembeddedworkspacecollectionkey
schema: 2.0.0
---

# New-AzPowerBiEmbeddedWorkspaceCollectionKey

## SYNOPSIS
Regenerates the primary or secondary access key for the specified Power BI Workspace Collection.

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzPowerBiEmbeddedWorkspaceCollectionKey -ResourceGroupName <String> -WorkspaceCollectionName <String>
 [-SubscriptionId <String>] [-KeyName <AccessKeyName>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Regenerate
```
New-AzPowerBiEmbeddedWorkspaceCollectionKey -ResourceGroupName <String> -WorkspaceCollectionName <String>
 -Body <IWorkspaceCollectionAccessKey> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentity
```
New-AzPowerBiEmbeddedWorkspaceCollectionKey -InputObject <IPowerBiEmbeddedIdentity>
 -Body <IWorkspaceCollectionAccessKey> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentityExpanded
```
New-AzPowerBiEmbeddedWorkspaceCollectionKey -InputObject <IPowerBiEmbeddedIdentity> [-KeyName <AccessKeyName>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Regenerates the primary or secondary access key for the specified Power BI Workspace Collection.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Body
.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiEmbedded.Models.Api20160129.IWorkspaceCollectionAccessKey
Parameter Sets: Regenerate, RegenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiEmbedded.Models.IPowerBiEmbeddedIdentity
Parameter Sets: RegenerateViaIdentity, RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyName
Key name

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerBiEmbedded.Support.AccessKeyName
Parameter Sets: RegenerateExpanded, RegenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Azure resource group

```yaml
Type: System.String
Parameter Sets: Regenerate, RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Regenerate, RegenerateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceCollectionName
Power BI Embedded Workspace Collection name

```yaml
Type: System.String
Parameter Sets: Regenerate, RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiEmbedded.Models.Api20160129.IWorkspaceCollectionAccessKey

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiEmbedded.Models.IPowerBiEmbeddedIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PowerBiEmbedded.Models.Api20160129.IWorkspaceCollectionAccessKeys

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IWorkspaceCollectionAccessKey>: .
  - `[KeyName <AccessKeyName?>]`: Key name

INPUTOBJECT <IPowerBiEmbeddedIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Azure location
  - `[ResourceGroupName <String>]`: Azure resource group
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[WorkspaceCollectionName <String>]`: Power BI Embedded Workspace Collection name

## RELATED LINKS

