---
external help file: Microsoft.Azure.Commands.Insights.dll-Help.xml
Module Name: AzureRM.Insights
ms.assetid: 18D5B95E-4CF1-4C79-AE8B-9F4DA49B46A9
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.insights/add-azurermlogprofile
schema: 2.0.0
---

# Add-AzureRmLogProfile

## SYNOPSIS
Creates a new activity log profile. This profile is used to either archive the activity log to an Azure storage account or stream it to an Azure event hub in the same subscription. 

## SYNTAX

```
Add-AzureRmLogProfile -Name <String> [-StorageAccountId <String>] [-ServiceBusRuleId <String>]
 [-RetentionInDays <Int32>] -Location <System.Collections.Generic.List`1[System.String]>
 [-Category <System.Collections.Generic.List`1[System.String]>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmLogProfile** cmdlet creates a log profile.

- **Storage Account** - Only standard storage account (premium storage account is not supported) is supported. It could either be of type ARM or Classic. If it's logged to a storage account, the cost of storing the activity log is billed at normal standard storage rates. There could be only one log profile per subscription consequentially only one storage account per subscription can be used to export activity log. 

- **Event Hub** - There could be only one log profile per subscription consequentially only one event hub per subscription can be used to export activity log. If activity log is streamed to an event hub, standard event hub pricing will apply. 

In the activity log, events can pertain to a region or could be "Global". Global essentially means these events are region agnostics and are independent of region, in fact majority of events fall into this category. If the activity log profile is set from the portal, it implicitly adds "Global" along with any other region selected in the user interface. When using the cmdlet, the location as "Global" must be explicitly mentioned apart from any other region. 

**Note** :- **Failing to set "Global" in the locations will result in a majority of activity log not getting exported.** 

This cmdlet implements the ShouldProcess pattern, i.e. it might request confirmation from the user before actually creating, modifying, or removing the resource.

## EXAMPLES

### Example 1 : Add a new log profile to export the activity log matching the location condition to a storage account
```
Add-AzureRmLogProfile -Locations "Global","West US" -Name ExportLogProfile -StorageAccountId /subscriptions/40gpe80s-9sb7-4f07-9042-b1b6a92ja9fk/resourceGroups/activitylogRG/providers/Microsoft.Storage/storageAccounts/activitylogstorageaccount
```

## PARAMETERS

### -Category
Specifies the list of categories.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: Categories

Required: False
Position: Named
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

### -Location
Specifies the location of the log profile.
Valid values: Run below cmdlet to get the latest list of locations. 

Get-AzureLocation | Select DisplayName

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: Locations

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the profile.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RetentionInDays
Specifies the retention policy, in days. This is the number of days the logs are preserved in the storage account specified. To retain the data forever set this to **0**. If it's not specified, then it defaults to **0**. Normal standard storage or event hub billing rates will apply for data retention.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceBusRuleId
Specifies the ID of the Service Bus rule.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountId
Specifies the ID of the Storage account. ID is the fully qualified Resource ID of the storage account for example  

/subscriptions/40gpe80s-9sb7-4f07-9042-b1b6a92ja9fk/resourceGroups/activitylogRG/providers/Microsoft.Storage/storageAccounts/activitylogstorageaccount

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSLogProfile

## NOTES

## RELATED LINKS

[Get-AzureRmLogProfile](./Get-AzureRmLogProfile.md)

[Remove-AzureRmLogProfile](./Remove-AzureRmLogProfile.md)


