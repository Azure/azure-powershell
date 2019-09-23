---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
schema: 2.0.0
---

# Set-AzWebAppAccessRestriction

## SYNOPSIS
Sets the inheritance of Main site Access Restiction settings to SCM Site for an Azure Web App.

## SYNTAX

```
Set-AzWebAppAccessRestriction [-ResourceGroupName] <String> [-Name] <String> [-ScmSiteUseMainSiteRestrictionSet]
 [-SlotName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzWebAppAccessRestriction** cmdlet gets Access Restriction settings about an Azure Web App.

## EXAMPLES

### Example 1: Set a Web App SCM Site to use Access Resstrictions from Main Site from a resource group
```
PS C:\>Set-AzWebAppAccessRestriction -ResourceGroupName "Default-Web-WestUS" -Name "ContosoSite" -ScmSiteUseMainSiteRestrictionSet
```

This command set a Web App named ContosoSite that belongs to the resource group Default-Web-WestUS to use access restriction settings of main site on scm site.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Name
WebApp Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ScmSiteUseMainSiteRestrictionSet
Scm site inherits rules set on Main site.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SlotName
Deployment Slot name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.WebApps.Models.PSAccessRestrictionSettings

## NOTES

## RELATED LINKS

[Get-AzWebAppAccessRestriction](./Get-AzWebAppAccessRestriction.md)

[Add-AzWebAppAccessRestriction](./Add-AzWebAppAccessRestriction.md)

[Remove-AzWebAppAccessRestriction](./Remove-AzWebAppAccessRestriction.md)
