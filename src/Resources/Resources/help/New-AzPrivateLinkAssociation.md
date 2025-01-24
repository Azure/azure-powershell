---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azprivatelinkassociation
schema: 2.0.0
---

# New-AzPrivateLinkAssociation

## SYNOPSIS
Creates the Azure Resource Management Private Link Association.

## SYNTAX

```
New-AzPrivateLinkAssociation [-ManagementGroupId] <String> [-Name] <String> [-PrivateLink] <String>
 [-PublicNetworkAccess] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzPrivateLinkAssociation cmdlet creates the private link assocaition at the scope.

## EXAMPLES

### Example 1
```powershell
New-AzPrivateLinkAssociation -ManagementGroupId fc096d27-0434-4460-a3ea-110df0422a2d -Name 1d7942d1-288b-48de-8d0f-2d2aa8e03ad4 | Format-List
```

```output
Id         : /providers/Microsoft.Management/managementGroups/fc096d27-0434-4460-a3ea-110df0422a2d/providers/Microsoft.
             Authorization/privateLinkAssociations/1d7942d1-288b-48de-8d0f-2d2aa8e03ad4
Type       : Microsoft.Authorization/privateLinkAssociations
Name       : 1d7942d1-288b-48de-8d0f-2d2aa8e03ad4
Properties : {"privateLink":"/subscriptions/aeb49941-36c3-4e7c-9ffd-16ba89d33ec4/resourceGroups/nrp-validate/providers/
             Microsoft.Authorization/resourceManagementPrivateLinks/DeepDiveRMPL","publicNetworkAc
             cess":"Enabled","tenantID":"fc096d27-0434-4460-a3ea-110df0422a2d","scope":"/providers/Microsoft.Management
             /managementGroups/fc096d27-0434-4460-a3ea-110df0422a2d"}
```

Creates the specific private link associations at the managment group scope.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupId
The management group Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The private link association Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PrivateLinkAssociationId

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLink
The name of the private link.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
The public network access is enabled/disabled.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.PrivateLinks.PSResourceManagementPrivateLinkAssociation

## NOTES

## RELATED LINKS

[Remove-AzPrivateLinkAssociation](./Remove-AzPrivateLinkAssociation.md)
[Get-AzPrivateLinkAssociation](./Get-AzPrivateLinkAssociation.md)
