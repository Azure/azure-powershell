---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/add-azgalleryinvmaccesscontrolprofileversionrulesprivilege
schema: 2.0.0
---

# Add-AzGalleryInVMAccessControlProfileVersionRulesPrivilege

## SYNOPSIS
Adds a Rules Privilege to a PSGalleryInVmAccessControlProfileVersion object.

## SYNTAX

```
Add-AzGalleryInVMAccessControlProfileVersionRulesPrivilege
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion> -PrivilegeName <String>
 -Path <String> [-QueryParameter <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzGalleryInVMAccessControlProfileVersionRulesPrivilege** cmdlet adds a Rules Privilege to the provided PSGalleryInVmAccessControlProfileVersion object.

## EXAMPLES

### Example 1
```powershell
$inVMAccessControlProfileVersion  = New-AzGalleryInVMAccessControlProfileVersionConfig -Name "myProfileVersion" -Location "West US 2" -Mode "Audit" -DefaultAccess "Deny" -TargetLocation @("West US 2")

Add-AzGalleryInVMAccessControlProfileVersionRulesPrivilege -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -PrivilegeName "GoalState" -Path "/machine" -QueryParameter @{ comp = "goalstate" } 
Add-AzGalleryInVMAccessControlProfileVersionRulesPrivilege -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -PrivilegeName "GoalState2" -Path "/machine" -QueryParameter @{ comp = "goalstate" }
```

Creates a local PSGalleryInVMAccessControlProfileVersion object, then add two rule privileges.

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

### -Path
The HTTP path corresponding to the privilege.

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

### -PrivilegeName
The name of the privilege.

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

### -QueryParameter
The query parameters to match in the path.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
