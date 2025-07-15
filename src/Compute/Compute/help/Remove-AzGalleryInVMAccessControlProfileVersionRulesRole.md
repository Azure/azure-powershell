---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/remove-azgalleryinvmaccesscontrolprofileversionrulesrole
schema: 2.0.0
---

# Remove-AzGalleryInVMAccessControlProfileVersionRulesRole

## SYNOPSIS
Removes a Rules Role from a PSGalleryInVmAccessControlProfileVersion object.

## SYNTAX

```
Remove-AzGalleryInVMAccessControlProfileVersionRulesRole
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion> -RoleName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzGalleryInVMAccessControlProfileVersionRulesRole** cmdlet removes a Rules Role from the provided PSGalleryInVmAccessControlProfileVersion object based on the role name.

## EXAMPLES

### Example 1
```powershell
$inVMAccessControlProfileVersion  = New-AzGalleryInVMAccessControlProfileVersionConfig -Name "myProfileVersion" -Location "West US 2" -Mode "Audit" -DefaultAccess "Deny" -TargetLocation @("West US 2")

Add-AzGalleryInVMAccessControlProfileVersionRulesRole -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -RoleName "Provisioning" -Privilege @("GoalState") 
Add-AzGalleryInVMAccessControlProfileVersionRulesRole -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -RoleName "Provisioning2" -Privilege @("GoalState") 

Remove-AzGalleryInVMAccessControlProfileVersionRulesRole -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -RoleName "Provisioning2"
```

Creates a local PSGalleryInVMAccessControlProfileVersion object, add two rule roles, then remove the role with name "Provisioning2". 

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

### -RoleName
The name of the role.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

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

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
