---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/enable-azsqlserveradvancedthreatprotection
schema: 2.0.0
---

# Enable-AzSqlServerAdvancedThreatProtection

## SYNOPSIS
Enables Advanced Threat Protection on a server.

## SYNTAX

## DESCRIPTION
The **Enable-AzSqlServerAdvancedThreatProtection** cmdlet is being replaced by **Enable-AzSqlServerAdvancedDataSecurity** cmdlet

## EXAMPLES

### Example 1 - Enable server Advanced Threat Protection
```powershell
PS C:\>  Enable-AzSqlServerAdvancedThreatProtection `
            -ResourceGroupName "ResourceGroup01" `
            -ServerName "Server01" 

ResourceGroupName	         : ResourceGroup01
ServerName		             : Server01
IsEnabled		             : True
```

### Example 2 - Enable server Advanced Threat Protection from server resource
```powershell
PS C:\>  Get-AzSqlServer `
           -ResourceGroupName "ResourceGroup01" `
           -ServerName "Server01" `
           | Enable-AzSqlServerAdvancedThreatProtection

ResourceGroupName	         : ResourceGroup01
ServerName		             : Server01
IsEnabled		             : True
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
