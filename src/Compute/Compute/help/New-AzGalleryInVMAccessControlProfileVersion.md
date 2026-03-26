---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azgalleryinvmaccesscontrolprofileversion
schema: 2.0.0
---

# New-AzGalleryInVMAccessControlProfileVersion

## SYNOPSIS
Creates a new version of a gallery inVMAccessControlProfile.

## SYNTAX

```
New-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName <String> -GalleryName <String>
 -GalleryInVMAccessControlProfileName <String>
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzGalleryInVMAccessControlProfileVersion** cmdlet creates a new version of a gallery inVMAccessControlProfile in Azure. <br>
This cmdlet takes in PSGalleryInVMAccessControlProfileVersion object created from [New-AzGalleryInVMAccessControlProfileVersionConfig](https://learn.microsoft.com/powershell/module/az.compute/new-AzGalleryInVMAccessControlProfileVersionConfig) as input. <br>

[Add-AzGalleryInVMAccessControlVersionRulesIdentity](https://learn.microsoft.com/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesIdentity), [Add-AzGalleryInVMAccessControlVersionRulesPrivilege](https://learn.microsoft.com/powershell/module/az.compute/add-AzGalleryInVMAccessControlVersionRulesPrivilege), [Add-AzGalleryInVMAccessControlVersionRulesRole](https://learn.microsoft.com/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesRole), and [Add-AzGalleryInVMAccessControlVersionRulesRoleAssignment](https://learn.microsoft.com/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesRoleAssignment) cmdlets can also be used to add rules to the PSGalleryInVmAccessControlProfileVersion object.

## EXAMPLES

### Example 1
```powershell
New-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName "myResourceGroup" -GalleryName "myGallery" -GalleryInVMAccessControlProfileName "myProfile" -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion
```

Creates a version of a gallery inVMAccessControlProfile.

### Example 2
```powershell
$rgname = "myResourceGroup"
$location = "West US 2"
$galleryName = "myGallery"
$inVMAccessProfileName = "myProfile"
$inVMAccessProfileVersionName = "myProfileVersion"

# Create a gallery 
New-AzGallery -ResourceGroupName $rgname -GalleryName $galleryName -Location $location -Description "My custom image gallery"

# Create a gallery inVMAccessControlProfile 
New-AzGalleryInVMAccessControlProfile -ResourceGroupName  $rgname -GalleryName $galleryName -GalleryInVMAccessControlProfileName $InVMAccessControlProfileName -Location $location -OsType "Windows" -ApplicableHostEndPoint "WireServer" 

# Create a gallery inVMAccessControlProfile version config 
$inVMAccessControlProfileVersion = New-AzGalleryInVMAccessControlProfileVersionConfig -Name $inVMAccessControlProfileVersionName -Location $location -Mode "Audit" -DefaultAccess "Deny" -TargetLocation @("Wesut US2", "West US") -ExcludeFromLatest 

# Add rules to PSGalleryInVMAccessControlProfileVersion
Add-AzGalleryInVMAccessControlProfileVersionRulesPrivilege -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -PrivilegeName "GoalState" -Path "/machine" -QueryParameter @{ comp = "goalstate" } 
Add-AzGalleryInVMAccessControlProfileVersionRulesRole -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -RoleName "Provisioning" -Privilege @("GoalState") 
Add-AzGalleryInVMAccessControlProfileVersionRulesIdentity -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -IdentityName "WinPA" -UserName "SYSTEM" -GroupName "Administrators" -ExePath "C:\Windows\System32\cscript.exe" -ProcessName "cscript" 
Add-AzGalleryInVMAccessControlProfileVersionRulesRoleAssignment -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -Role "Provisioning" -Identity @("WinPA") 

# Create the gallery inVMAccessControlProfile version resource in Azure
New-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName $rgname -GalleryName $galleryName -GalleryInVMAccessControlProfileName $inVMAccessProfileName -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion
```

Creates a complete InVM Access Control Profile setup by first creating a gallery and InVM Access Control Profile, then building a local profile version configuration with rules, and finally deploying it to Azure.

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

### -GalleryInVMAccessControlProfileName
The name of the Gallery In VM Access Control Profile.

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

### -GalleryInVmAccessControlProfileVersion
PSGalleryInVmAccessControlProfileVersion object created from New-AzGalleryInVMAccessControlProfileVersionConfig.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryName
The name of the gallery.

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

### -ResourceGroupName
The name of the resource group.

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
