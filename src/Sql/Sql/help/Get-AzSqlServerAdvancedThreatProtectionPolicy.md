---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/get-azsqlserveradvancedthreatprotectionpolicy
schema: 2.0.0
---

# Get-AzSqlServerAdvancedThreatProtectionPolicy

## SYNOPSIS
Gets Advanced Threat Protection policy of a server.

## SYNTAX

## DESCRIPTION
The **Get-AzSqlServerAdvancedThreatProtectionPolicy** cmdlet is being replaced by **Get-AzSqlServerAdvancedDataSecurityPolicy**

## EXAMPLES

### Example 1 - Gets server Advanced Threat Protection
```powershell
PS C:\>  Get-AzSqlServerAdvancedThreatProtectionPolicy `
            -ResourceGroupName "ResourceGroup01" `
            -ServerName "Server01" 

ResourceGroupName	         : ResourceGroup01
ServerName		             : Server01
IsEnabled		             : True
```

### Example 2 - Gets server Advanced Threat Protection from server resource
```powershell
PS C:\>  Get-AzSqlServer `
           -ResourceGroupName "ResourceGroup01" `
           -ServerName "Server01" `
           | Get-AzSqlServerAdvancedThreatProtectionPolicy

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
