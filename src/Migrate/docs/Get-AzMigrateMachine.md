---
external help file:
Module Name: Az.Migrate
online version: https://docs.microsoft.com/en-us/powershell/module/az.migrate/get-azmigratemachine
schema: 2.0.0
---

# Get-AzMigrateMachine

## SYNOPSIS
Method to get machine.

## SYNTAX

### List (Default)
```
Get-AzMigrateMachine -ResourceGroupName <String> -SiteName <String> [-SubscriptionId <String[]>]
 [-ContinuationToken <String>] [-Filter <String>] [-Top <Int32>] [-TotalRecordCount <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMigrateMachine -Name <String> -ResourceGroupName <String> -SiteName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Method to get machine.

## EXAMPLES

### Example 1: List (Default)
```powershell
PS C:\> Get-AzMigrateMachine  -SubscriptionId 31be0ff4-c932-4cb3-8efc-efa411d79280 -ResourceGroupName BugBashAVSVMware -SiteName BBVMwareAVScbbcsite

Name                                                                                  Type
----                                                                                  ----
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098b08-5701-4c58-f6ad-1daf127a8ed9 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_500994c6-c0d1-312c-06dd-ab2a925b6a48 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50093d34-6ee0-4345-5c9c-5ea3970fad1f Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098f99-f949-22ca-642b-724ec6595210 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5009c2ce-ced0-f761-317a-f3ae764596f8 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_500975f3-de2f-b09f-3afe-6217ef7bb6ae Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5008290d-9ce8-5c05-9ba0-e7c8274dd33b Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5009959a-3ae5-03f5-b412-145bdc93ff96 Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_502b221c-7ba0-55dc-ea4d-27816b5e809f Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_5009ac6d-c410-2762-d4d3-927d3e3343ef Microsoft.OffAzure/VMwareSites/machines
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50094477-e603-d4d3-4512-4289fc502423 Microsoft.OffAzure/VMwareSites/machines
```

List machines in a site.

### Example 2: Get
```powershell
PS C:\> Get-AzMigrateMachine  -SubscriptionId 31be0ff4-c932-4cb3-8efc-efa411d79280 -ResourceGroupName BugBashAVSVMware -SiteName BBVMwareAVScbbcsite -Name 10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098b08-5701-4c58-f6ad-1daf127a8ed9

Name                                                                                  Type
----                                                                                  ----
10-150-8-52-b090bef3-b733-5e34-bc8f-eb6f2701432a_50098b08-5701-4c58-f6ad-1daf127a8ed9 Microsoft.OffAzure/VMwareSites/machines
```

Get machine by name.

## PARAMETERS

### -ContinuationToken
Optional parameter for continuation token.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Filter
.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Machine ARM name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MachineName

Required: True
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteName
Site name.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TotalRecordCount
Total count of machines in the given site.

```yaml
Type: System.Int32
Parameter Sets: List
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine

## NOTES

ALIASES

## RELATED LINKS

