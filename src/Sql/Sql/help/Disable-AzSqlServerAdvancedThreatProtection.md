---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/disable-azsqlserveradvancedthreatprotection
schema: 2.0.0
---

# Disable-AzSqlServerAdvancedThreatProtection

## SYNOPSIS
Disables Advanced Threat Protection on a server.

## SYNTAX

## DESCRIPTION
The **Disable-AzSqlServerAdvancedThreatProtection** cmdlet is being replaced by **Disable-AzSqlServerAdvancedDataSecurity**

## EXAMPLES

### Example 1 - Disable server Advanced Threat Protection
```powershell
PS C:\>  Disable-AzSqlServerAdvancedThreatProtection `
            -ResourceGroupName "ResourceGroup01" `
            -ServerName "Server01" 

ResourceGroupName	         : ResourceGroup01
ServerName		             : Server01
IsEnabled		             : False
```

### Example 2 - Disable server Advanced Threat Protection from server resource
```powershell
PS C:\>  Get-AzSqlServer `
           -ResourceGroupName "ResourceGroup01" `
           -ServerName "Server01" `
           | Disable-AzSqlServerAdvancedThreatProtection

ResourceGroupName	         : ResourceGroup01
ServerName		             : Server01
IsEnabled		             : False
```

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model.ServerAdvancedThreatProtectionPolicyModel

## NOTES

## RELATED LINKS
