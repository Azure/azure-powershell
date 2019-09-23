---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
schema: 2.0.0
---

# Remove-AzWebAppAccessRestriction

## SYNOPSIS
Removes an Access Restriction from an Azure Web App.

## SYNTAX

```
Remove-AzWebAppAccessRestriction [-ResourceGroupName] <String> [-Name] <String> -RuleName <String>
 [-TargetScmSite] [-SlotName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzWebAppAccessRestriction** cmdlet removes an Access Restriction from an Azure Web App

## EXAMPLES

### Example 1: Remove a Web App
```
PS C:\>Remove-AzWebAppAccessRestriction -ResourceGroupName "Default-Web-WestUS" -Name "ContosoSite" -RuleName IpRule
```

This command removes the IpRule access restriction from Azure Web App named ContosoSite that belongs to the resource group named Default-Web-WestUS.

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

### -RuleName
Access Restriction rule name. E.g.: DeveloperWorkstation.

```yaml
Type: System.String
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

### -TargetScmSite
Rule is aimed for Main site or Scm site.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.WebApps.Models.PSAccessRestrictionSettings

## NOTES

## RELATED LINKS

[Get-AzWebAppAccessRestriction](./Get-AzWebAppAccessRestriction.md)

[Set-AzWebAppAccessRestriction](./Set-AzWebAppAccessRestriction.md)

[Add-AzWebAppAccessRestriction](./Add-AzWebAppAccessRestriction.md)
