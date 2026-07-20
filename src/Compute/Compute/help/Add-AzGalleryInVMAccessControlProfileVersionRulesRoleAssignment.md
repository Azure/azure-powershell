---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/add-azgalleryinvmaccesscontrolprofileversionrulesroleassignment
schema: 2.0.0
---

# Add-AzGalleryInVMAccessControlProfileVersionRulesRoleAssignment

## SYNOPSIS
Adds a Rules Role Assignment to a PSGalleryInVmAccessControlProfileVersion object.

## SYNTAX

```
Add-AzGalleryInVMAccessControlProfileVersionRulesRoleAssignment
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion> -Role <String>
 -Identity <String[]> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzGalleryInVMAccessControlProfileVersionRulesRoleAssignment** cmdlet adds a Rules Role Assignment to the provided PSGalleryInVmAccessControlProfileVersion object.

## EXAMPLES

### Example 1
```powershell
$inVMAccessControlProfileVersion  = New-AzGalleryInVMAccessControlProfileVersionConfig -Name "myProfileVersion" -Location "West US 2" -Mode "Audit" -DefaultAccess "Deny" -TargetLocation @("West US 2")

Add-AzGalleryInVMAccessControlProfileVersionRulesRoleAssignment -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -Role "Provisioning" -Identity @("WinPA") 
Add-AzGalleryInVMAccessControlProfileVersionRulesRoleAssignment -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -Role "Provisioning2" -Identity @("WinPA")
```

Creates a local PSGalleryInVMAccessControlProfileVersion object, then add two rule role assignments.

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

### -GalleryInVmAccessControlProfileVersion
PSGalleryInVmAccessControlProfileVersion object created from New-AzGalleryInVMAccessControlProfileVersionConfig.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Identity
A list of identities that can access the privileges defined by the role.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Role
The name of the role.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
