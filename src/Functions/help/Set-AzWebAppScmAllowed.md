---
external help file:
Module Name: Az.Functions
online version: https://docs.microsoft.com/powershell/module/az.functions/set-azwebappscmallowed
schema: 2.0.0
---

# Set-AzWebAppScmAllowed

## SYNOPSIS
Updates whether user publishing credentials are allowed on the site or not.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzWebAppScmAllowed -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Allow]
 [-Kind <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzWebAppScmAllowed -Name <String> -ResourceGroupName <String>
 -CsmPublishingAccessPoliciesEntity <ICsmPublishingCredentialsPoliciesEntity> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates whether user publishing credentials are allowed on the site or not.

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

### -Allow
\<code\>true\</code\> to allow access to a publishing method; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CsmPublishingAccessPoliciesEntity
Publishing Credentials Policies parameters.
To construct, see NOTES section for CSMPUBLISHINGACCESSPOLICIESENTITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntity
Parameter Sets: Update
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

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntity

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CSMPUBLISHINGACCESSPOLICIESENTITY <ICsmPublishingCredentialsPoliciesEntity>`: Publishing Credentials Policies parameters.
  - `[Kind <String>]`: Kind of resource.
  - `[Allow <Boolean?>]`: <code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.

## RELATED LINKS

