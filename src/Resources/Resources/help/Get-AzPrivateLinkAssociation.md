---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Resources.dll-Help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azprivatelinkassociation
schema: 2.0.0
---

# Get-AzPrivateLinkAssociation

## SYNOPSIS
Gets all the Azure Resource Management Private Link Association(s).

## SYNTAX

```
Get-AzPrivateLinkAssociation [-ManagementGroupId] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzPrivateLinkAssociation cmdlet gets all of resource management private link at the scope.

## EXAMPLES

### Example 1
```powershell
Get-AzPrivateLinkAssociation -ManagementGroupId fc096d27-0434-4460-a3ea-110df0422a2d | Format-List
```

```output
Id         : /providers/Microsoft.Management/managementGroups/fc096d27-0434-4460-a3ea-110df0422a2d/providers/Microsoft.
             Authorization/privateLinkAssociations/7afcb623-ff23-591c-8cdd-57f5357711f4
Type       : Microsoft.Authorization/privateLinkAssociations
Name       : 7afcb623-ff23-591c-8cdd-57f5357711f4
Properties : {"privateLink":"/subscriptions/aeb49941-36c3-4e7c-9ffd-16ba89d33ec4/resourceGroups/nrp-validate/providers/
             Microsoft.Authorization/resourceManagementPrivateLinks/DeepDiveRMPL","publicNetworkAccess":"Enabled","tena
             ntID":"fc096d27-0434-4460-a3ea-110df0422a2d","scope":"/providers/Microsoft.Management/managementGroups/24f
             15700-370c-45bc-86a7-aee1b0c4eb8a"}

Id         : /providers/Microsoft.Management/managementGroups/fc096d27-0434-4460-a3ea-110df0422a2d/providers/Microsoft.
             Authorization/privateLinkAssociations/1d7942d1-288b-48de-8d0f-2d2aa8e03ad4
Type       : Microsoft.Authorization/privateLinkAssociations
Name       : 1d7942d1-288b-48de-8d0f-2d2aa8e03ad4
Properties : {"privateLink":"/subscriptions/aeb49941-36c3-4e7c-9ffd-16ba89d33ec4/resourceGroups/nrp-validate/providers/
             Microsoft.Authorization/resourceManagementPrivateLinks/DeepDiveRMPL","publicNetworkAc
             cess":"Enabled","tenantID":"fc096d27-0434-4460-a3ea-110df0422a2d","scope":"/providers/Microsoft.Management
             /managementGroups/fc096d27-0434-4460-a3ea-110df0422a2d"}
```

Get all the private link associations at the managment group scope.

### Example 2
```powershell
Get-AzPrivateLinkAssociation -ManagementGroupId fc096d27-0434-4460-a3ea-110df0422a2d -Name 1d7942d1-288b-48de-8d0f-2d2aa8e03ad4 | Format-List
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

Get the specific private link associations at the managment group scope.

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

Required: False
Position: 1
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Resources.Models.PrivateLinks.PSResourceManagementPrivateLinkAssociation

## NOTES

## RELATED LINKS

[Remove-AzPrivateLinkAssociation](./Remove-AzPrivateLinkAssociation.md)
[New-AzPrivateLinkAssociation](./New-AzPrivateLinkAssociation.md)
