---
external help file:
Module Name: Az.EdgeOrderPartnerApiS
online version: https://docs.microsoft.com/en-us/powershell/module/az.edgeorderpartnerapis/invoke-azedgeorderpartnerapismanagelink
schema: 2.0.0
---

# Invoke-AzEdgeOrderPartnerApiSManageLink

## SYNOPSIS
API for linking management resource with inventory

## SYNTAX

### ManageExpanded (Default)
```
Invoke-AzEdgeOrderPartnerApiSManageLink -FamilyIdentifier <String> -Location <String> -SerialNumber <String>
 -ManagementResourceArmId <String> -Operation <ManageLinkOperation> -TenantId <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Manage
```
Invoke-AzEdgeOrderPartnerApiSManageLink -FamilyIdentifier <String> -Location <String> -SerialNumber <String>
 -ManageLinkRequest <IManageLinkRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaIdentity
```
Invoke-AzEdgeOrderPartnerApiSManageLink -InputObject <IEdgeOrderPartnerApiSIdentity>
 -ManageLinkRequest <IManageLinkRequest> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ManageViaIdentityExpanded
```
Invoke-AzEdgeOrderPartnerApiSManageLink -InputObject <IEdgeOrderPartnerApiSIdentity>
 -ManagementResourceArmId <String> -Operation <ManageLinkOperation> -TenantId <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API for linking management resource with inventory

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

### -FamilyIdentifier
Unique identifier for the product family

```yaml
Type: System.String
Parameter Sets: Manage, ManageExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.IEdgeOrderPartnerApiSIdentity
Parameter Sets: ManageViaIdentity, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The location of the resource

```yaml
Type: System.String
Parameter Sets: Manage, ManageExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManageLinkRequest
Request body for ManageLink call
To construct, see NOTES section for MANAGELINKREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.Api20201201Preview.IManageLinkRequest
Parameter Sets: Manage, ManageViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementResourceArmId
Arm Id of the management resource to which inventory is to be linkedFor unlink operation, enter empty string

```yaml
Type: System.String
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Operation
Operation to be performed - Link, Unlink, Relink

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Support.ManageLinkOperation
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -SerialNumber
The serial number of the device

```yaml
Type: System.String
Parameter Sets: Manage, ManageExpanded
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
Type: System.String
Parameter Sets: Manage, ManageExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
Tenant ID of management resource associated with inventory

```yaml
Type: System.String
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.Api20201201Preview.IManageLinkRequest

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.IEdgeOrderPartnerApiSIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IEdgeOrderPartnerApiSIdentity>: Identity Parameter
  - `[FamilyIdentifier <String>]`: Unique identifier for the product family
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the resource
  - `[SerialNumber <String>]`: The serial number of the device
  - `[SubscriptionId <String>]`: The ID of the target subscription.

MANAGELINKREQUEST <IManageLinkRequest>: Request body for ManageLink call
  - `ManagementResourceArmId <String>`: Arm Id of the management resource to which inventory is to be linked         For unlink operation, enter empty string
  - `Operation <ManageLinkOperation>`: Operation to be performed - Link, Unlink, Relink
  - `TenantId <String>`: Tenant ID of management resource associated with inventory

## RELATED LINKS

