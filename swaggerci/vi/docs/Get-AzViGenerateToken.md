---
external help file:
Module Name: Az.Vi
online version: https://docs.microsoft.com/en-us/powershell/module/az.vi/get-azvigeneratetoken
schema: 2.0.0
---

# Get-AzViGenerateToken

## SYNOPSIS
Generate an Azure Video Indexer access token.

## SYNTAX

### AccessExpanded (Default)
```
Get-AzViGenerateToken -AccountName <String> -ResourceGroupName <String> -PermissionType <PermissionType>
 -Scope <Scope> [-SubscriptionId <String[]>] [-ProjectId <String>] [-VideoId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Access
```
Get-AzViGenerateToken -AccountName <String> -ResourceGroupName <String>
 -Parameter <IGenerateAccessTokenParameters> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AccessViaIdentity
```
Get-AzViGenerateToken -InputObject <IViIdentity> -Parameter <IGenerateAccessTokenParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AccessViaIdentityExpanded
```
Get-AzViGenerateToken -InputObject <IViIdentity> -PermissionType <PermissionType> -Scope <Scope>
 [-ProjectId <String>] [-VideoId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Generate an Azure Video Indexer access token.

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

### -AccountName
The name of the Azure Video Indexer account.

```yaml
Type: System.String
Parameter Sets: Access, AccessExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Vi.Models.IViIdentity
Parameter Sets: AccessViaIdentity, AccessViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
Access token generation request's parameters
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Vi.Models.Api20220413Preview.IGenerateAccessTokenParameters
Parameter Sets: Access, AccessViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PermissionType
The requested permission

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Vi.Support.PermissionType
Parameter Sets: AccessExpanded, AccessViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectId
The project ID

```yaml
Type: System.String
Parameter Sets: AccessExpanded, AccessViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Access, AccessExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The requested media type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Vi.Support.Scope
Parameter Sets: AccessExpanded, AccessViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Access, AccessExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VideoId
The video ID

```yaml
Type: System.String
Parameter Sets: AccessExpanded, AccessViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Vi.Models.Api20220413Preview.IGenerateAccessTokenParameters

### Microsoft.Azure.PowerShell.Cmdlets.Vi.Models.IViIdentity

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IViIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the Azure Video Indexer account.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

PARAMETER <IGenerateAccessTokenParameters>: Access token generation request's parameters
  - `PermissionType <PermissionType>`: The requested permission
  - `Scope <Scope>`: The requested media type
  - `[ProjectId <String>]`: The project ID
  - `[VideoId <String>]`: The video ID

## RELATED LINKS

