---
external help file: Az.NetworkAnalytics-help.xml
Module Name: Az.NetworkAnalytics
online version: https://learn.microsoft.com/powershell/module/az.networkanalytics/get-aznetworkanalyticsdataproduct
schema: 2.0.0
---

# Get-AzNetworkAnalyticsDataProduct

## SYNOPSIS
Retrieve data product resource.

## SYNTAX

### List (Default)
```
Get-AzNetworkAnalyticsDataProduct [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkAnalyticsDataProduct -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzNetworkAnalyticsDataProduct -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkAnalyticsDataProduct -InputObject <INetworkAnalyticsIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve data product resource.

## EXAMPLES

### Example 1: Get data product resource by data product name.
```powershell
Get-AzNetworkAnalyticsDataProduct -DataProductName "pwshdp01" -ResourceGroupName "ResourceGroupName"
```

```output
Location       Name     SystemDataCreatedAt    SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----     -------------------    -------------------    ----------------------- ------------------------ -------------
southcentralus pwshdp01 10/13/2023 11:22:54 AM user1@microsoft.com User                    10/13/2023 11:22:54 AM   user1@microsoft.com
```

Get data product resource by data product name.

### Example 2: List all data product resource for a resoure group.
```powershell
$GetDataProductsForRG = Get-AzNetworkAnalyticsDataProduct -ResourceGroupName "ResourceGroupName"

$GetDataProductsForRG | select Name,ResourceGroupName,Location,ProvisioningState,Product,MajorVersion,Publisher | Format-Table
```

```output
Name         ResourceGroupName Location    ProvisioningState Product MajorVersion Publisher SystemDataCreatedBy
----         ----------------- --------    ----------------- ------- ------------ --------- -------------------
dpinstance1  powershell-test    eastus      Succeeded         MCC     2.0.0        Microsoft user1@microsoft.com
dpinstance2  powershell-test    uksouth     Succeeded         MCC     2.0.0        Microsoft user1@microsoft.com
dpinstance3  powershell-test    westus      Succeeded         MCC     2.0.0        Microsoft user2@microsoft.com
dpinstance4  powershell-test    uksouth     Succeeded         MCC     2.0.0        Microsoft user3@microsoft.com
```

List all data product resource for a resoure group.

### Example 3: List all data product resource for a subscription.
```powershell
$GetDataProductsForSub = Get-AzNetworkAnalyticsDataProduct

$GetDataProductsForRG | select Name,ResourceGroupName,Location,ProvisioningState,Product,MajorVersion,Publisher | Format-Table
```

```output
Name         ResourceGroupName Location    ProvisioningState Product MajorVersion Publisher SystemDataCreatedBy
----         ----------------- --------    ----------------- ------- ------------ --------- -------------------
dpinstance1  powershell-test    eastus      Succeeded         MCC     1.0.0        Microsoft user1@microsoft.com
dpinstance2  powershell-test    uksouth     Succeeded         MCC     1.0.0        Microsoft user1@microsoft.com
dpinstance3  powershell-test    westus      Succeeded         MCC     2.0.0        Microsoft user2@microsoft.com
dpinstance4  powershell-test    uksouth     Succeeded         MCC     2.0.0        Microsoft user3@microsoft.com
```

List all data product resource for a subscription.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.INetworkAnalyticsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The data product resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DataProductName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.INetworkAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkAnalytics.Models.Api20231115.IDataProduct

## NOTES

## RELATED LINKS
