---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azgalleryinvmaccesscontrolprofileversionconfig
schema: 2.0.0
---

# New-AzGalleryInVMAccessControlProfileVersionConfig

## SYNOPSIS
Creates a local PSGalleryInVmAccessControlProfileVersion object.

## SYNTAX

```
New-AzGalleryInVMAccessControlProfileVersionConfig -Name <String> -Location <String> -Mode <String>
 -DefaultAccess <String> -TargetLocation <String[]> [-ExcludeFromLatest]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzGalleryInVMAccessControlProfileVersionConfig** cmdlet creates a local PSGalleryInVmAccessControlProfileVersion object, 
which then can be used with the **[New-AzGalleryInVMAccessControlProfileVersion](https://learn.microsoft.com/powershell/module/az.compute/new-AzGalleryInVMAccessControlProfileVersion)** cmdlet to create a new Gallery In VM Access Control Profile Version in Azure.
<br>
[Add-AzGalleryInVMAccessControlVersionRulesIdentity](https://learn.microsoft.com/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesIdentity), [Add-AzGalleryInVMAccessControlVersionRulesPrivilege](https://learn.microsoft.com/powershell/module/az.compute/add-AzGalleryInVMAccessControlVersionRulesPrivilege), [Add-AzGalleryInVMAccessControlVersionRulesRole](https://learn.microsoft.com/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesRole), and [Add-AzGalleryInVMAccessControlVersionRulesRoleAssignment](https://learn.microsoft.com/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesRoleAssignment) cmdlets can be used to add rules to the PSGalleryInVmAccessControlProfileVersion object.

## EXAMPLES

### Example 1
```powershell
New-AzGalleryInVMAccessControlProfileVersionConfig -Name "myProfileVersion" -Location "West US 2" -Mode "Audit" -DefaultAccess "Deny" -TargetLocation @("West US", "West US 2") -ExcludeFromLatest
```

Creates a local PSGalleryInVmAccessControlProfileVersion object with the specified parameters.

### Example 2
```powershell
$CPVersionConfig = New-AzGalleryInVMAccessControlProfileVersionConfig -Name "myProfileVersion" -Location "West US 2" -Mode "Audit" -DefaultAccess "Deny" -TargetLocation @("West US", "West US 2") ` 
| Add-AzGalleryInVMAccessControlProfileVersionRulesPrivilege -PrivilegeName "GoalState" -Path "/machine" -QueryParameter @{ comp = "goalstate" } `
| Add-AzGalleryInVMAccessControlProfileVersionRulesRole -RoleName "Provisioning" -Privilege @("GoalState") `
| Add-AzGalleryInVMAccessControlProfileVersionRulesIdentity -IdentityName "WinPA" -UserName "SYSTEM" -GroupName "Administrators" -ExePath "C:\Windows\System32\cscript.exe" -ProcessName "cscript" `
| Add-AzGalleryInVMAccessControlProfileVersionRulesRoleAssignment -Role "Provisioning" -Identity @("WinPA")
```

Creates a local PSGalleryInVmAccessControlProfileVersion object then add rules.

## PARAMETERS

### -DefaultAccess
This property allows you to specify if the requests will be allowed to access the host endpoints.

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

### -ExcludeFromLatest
If set to true, Virtual Machines deployed from the latest version of the Resource Profile won't use this Profile version.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The location of the Gallery In VM Access Control Profile Version.

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

### -Mode
This property allows you to specify whether the access control rules are in Audit mode, in Enforce mode or Disabled.

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

### -Name
The name of the Gallery In VM Access Control Profile Version.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GalleryInVMAccessControlProfileVersionName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetLocation
The names of the target regions where the Resource Profile version is going to be replicated to. This property is updatable.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String[]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
