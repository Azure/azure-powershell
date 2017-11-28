---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
Module Name: AzureRM.DataLakeAnalytics
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datalakeanalytics/get-azurermdatalakeanalyticsfirewallrule
schema: 2.0.0
---

# Get-AzureRmDataLakeAnalyticsFirewallRule

## SYNOPSIS
Retrieves a firewall rule or list of firewall rules from a Data Lake Analytics account.

## SYNTAX

```
Get-AzureRmDataLakeAnalyticsFirewallRule [-Account] <String> [[-Name] <String>] [[-ResourceGroupName] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDataLakeAnalyticsFirewallRule** cmdlet retrieves a firewall rule or list of firewall rules from an Azure Data Lake Analytics account.

## EXAMPLES

### Example 1: Get a firewall rule
```
PS C:\>Get-AzureRmDataLakeAnalyticsFirewallRule -Account "ContosoAdlAcct" -Name "My firewall rule"
```

This command gets the firewall rule named "my firewall rule" from account "ContosoAdlAcct"

### Example 2: List all firewall rules
```
PS C:\>Get-AzureRmDataLakeAnalyticsFirewallRule -Account "ContosoAdlAcct"
```

This command gets all firewall rules from account "ContosoAdlAcct"

## PARAMETERS

### -Account
The Data Lake Analytics account to get the firewall rule from

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the firewall rule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group under which want to retrieve the account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRule
System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRule, Microsoft.Azure.Commands.DataLakeAnalytics, Version=2.5.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

