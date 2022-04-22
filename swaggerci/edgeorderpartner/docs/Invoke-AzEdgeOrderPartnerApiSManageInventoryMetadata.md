---
external help file:
Module Name: Az.EdgeOrderPartnerApiS
online version: https://docs.microsoft.com/en-us/powershell/module/az.edgeorderpartnerapis/invoke-azedgeorderpartnerapismanageinventorymetadata
schema: 2.0.0
---

# Invoke-AzEdgeOrderPartnerApiSManageInventoryMetadata

## SYNOPSIS
API for updating inventory metadata and inventory configuration

## SYNTAX

### ManageExpanded (Default)
```
Invoke-AzEdgeOrderPartnerApiSManageInventoryMetadata -FamilyIdentifier <String> -Location <String>
 -SerialNumber <String> -InventoryMetadata <String> [-SubscriptionId <String>]
 [-ConfigurationOnDeviceConfigurationIdentifier <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Manage
```
Invoke-AzEdgeOrderPartnerApiSManageInventoryMetadata -FamilyIdentifier <String> -Location <String>
 -SerialNumber <String> -ManageInventoryMetadataRequest <IManageInventoryMetadataRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ManageViaIdentity
```
Invoke-AzEdgeOrderPartnerApiSManageInventoryMetadata -InputObject <IEdgeOrderPartnerApiSIdentity>
 -ManageInventoryMetadataRequest <IManageInventoryMetadataRequest> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ManageViaIdentityExpanded
```
Invoke-AzEdgeOrderPartnerApiSManageInventoryMetadata -InputObject <IEdgeOrderPartnerApiSIdentity>
 -InventoryMetadata <String> [-ConfigurationOnDeviceConfigurationIdentifier <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
API for updating inventory metadata and inventory configuration

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

### -AsJob
Run the command as a job

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

### -ConfigurationOnDeviceConfigurationIdentifier
Configuration identifier on device

```yaml
Type: System.String
Parameter Sets: ManageExpanded, ManageViaIdentityExpanded
Aliases:

Required: False
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

### -InventoryMetadata
Inventory metadata to be updated

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

### -ManageInventoryMetadataRequest
Request body for ManageInventoryMetadata call
To construct, see NOTES section for MANAGEINVENTORYMETADATAREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.Api20201201Preview.IManageInventoryMetadataRequest
Parameter Sets: Manage, ManageViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeOrderPartnerApiS.Models.Api20201201Preview.IManageInventoryMetadataRequest

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

MANAGEINVENTORYMETADATAREQUEST <IManageInventoryMetadataRequest>: Request body for ManageInventoryMetadata call
  - `InventoryMetadata <String>`: Inventory metadata to be updated
  - `[ConfigurationOnDeviceConfigurationIdentifier <String>]`: Configuration identifier on device

## RELATED LINKS

