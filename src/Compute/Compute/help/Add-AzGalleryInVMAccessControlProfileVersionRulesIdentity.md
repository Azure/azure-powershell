---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/add-azgalleryinvmaccesscontrolprofileversionrulesidentity
schema: 2.0.0
---

# Add-AzGalleryInVMAccessControlProfileVersionRulesIdentity

## SYNOPSIS
Adds a Rules Identity to a PSGalleryInVmAccessControlProfileVersion object.

## SYNTAX

```
Add-AzGalleryInVMAccessControlProfileVersionRulesIdentity
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion> -IdentityName <String>
 [-UserName <String>] [-GroupName <String>] [-ExePath <String>] [-ProcessName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzGalleryInVMAccessControlProfileVersionRulesIdentity** cmdlet adds a Rules Identity to the provided PSGalleryInVmAccessControlProfileVersion object.

## EXAMPLES

### Example 1
```powershell
$inVMAccessControlProfileVersion  = New-AzGalleryInVMAccessControlProfileVersionConfig -Name "myProfileVersion" -Location "West US 2" -Mode "Audit" -DefaultAccess "Deny" -TargetLocation @("West US 2")

Add-AzGalleryInVMAccessControlProfileVersionRulesIdentity -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -IdentityName "WinPA" -UserName "SYSTEM" -GroupName "Administrators" -ExePath "C:\Windows\System32\cscript.exe" -ProcessName "cscript" 
Add-AzGalleryInVMAccessControlProfileVersionRulesIdentity -GalleryInVmAccessControlProfileVersion $inVMAccessControlProfileVersion -IdentityName "WinPA2" -UserName "SYSTEM" -GroupName "Administrators" -ExePath "C:\Windows\System32\cscript.exe" -ProcessName "cscript"
```

Creates a local PSGalleryInVMAccessControlProfileVersion object, then add two rule identities.

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

### -ExePath
The path to the executable.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GroupName
The groupName corresponding to this identity.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityName
The name of the identity.

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

### -ProcessName
The process name of the executable.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserName
The username corresponding to this identity.

```yaml
Type: System.String
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

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
