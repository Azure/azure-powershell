---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/get-aznewrelicmonitor
schema: 2.0.0
---

# Get-AzNewRelicMonitor

## SYNOPSIS
Get a NewRelicMonitorResource

## SYNTAX

### List (Default)
```
Get-AzNewRelicMonitor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### List1
```
Get-AzNewRelicMonitor [-SubscriptionId <String[]>] -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Get
```
Get-AzNewRelicMonitor [-SubscriptionId <String[]>] -Name <String> -ResourceGroupName <String>
 [-ListLinkedResource] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNewRelicMonitor -InputObject <INewRelicIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get a NewRelicMonitorResource

## EXAMPLES

### Example 1: List monitors by subscription
```powershell
Get-AzNewRelicMonitor
```

```output
Location        Name                                            SystemDataCreatedAt   SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------        ----                                            -------------------   -------------------                  ----------------------- ------------------------ ------------------------         
eastus          user01_test_16_3_sb                             6/16/2023 6:26:11 AM  user01@example.com                   User                    6/16/2023 6:47:28 AM     11111111-2222-3333-4444-123456789101 
eastus          16_06_23_01                                     6/16/2023 7:55:28 AM  usaccount@outlook.com                User                    6/16/2023 7:55:28 AM     usaccount@outlook.com
eastus          test-new-relic                                  6/19/2023 8:44:48 AM  useraccount@outlook.com              User                    6/19/2023 8:44:48 AM     useraccount@outlook.com        
eastus          test-new-relic2                                 6/21/2023 9:18:43 AM  useraccount@outlook.com              User                    6/21/2023 9:18:43 AM     useraccount@outlook.com        
eastus          test-01                                         6/27/2023 8:30:45 AM  user1@outlook.com                    User                    6/27/2023 8:30:45 AM     user1@outlook.com
centraluseuap   testNR-5868                                     6/5/2023 6:22:07 AM   09a13a20-12be-4fda-a11e-a6895d6b321b Application             6/5/2023 6:22:07 AM      09a13a20-12be-4fda-a11e-a6895d6… 
centraluseuap   testNR-6804                                     6/5/2023 6:25:37 AM   09a13a20-12be-4fda-a11e-a6895d6b321b Application             6/5/2023 6:25:37 AM      09a13a20-12be-4fda-a11e-a6895d6… 
Central US EUAP Harsh_PostMan_0706_1                            6/9/2023 11:24:46 AM  harshkumar@outlook.com               User                    6/9/2023 11:24:46 AM     harshkumar@outlook.com
centraluseuap   FromPortal0906                                  6/9/2023 12:44:44 PM  harshkumar@outlook.com               User                    6/9/2023 12:44:44 PM     harshkumar@outlook.com
Central US EUAP Harsh_PostMan_0906_7pm                          6/9/2023 1:26:54 PM   harshkumar@outlook.com               User                    6/9/2023 1:26:54 PM      harshkumar@outlook.com
centraluseuap   0906_7pm_CUSEUAP                                6/9/2023 1:29:55 PM   harshkumar@outlook.com               User                    6/9/2023 1:29:55 PM      harshkumar@outlook.com
centraluseuap   CertificateDoesntHaveCNPrefix_CUSEUAP_0906_10pm 6/9/2023 4:51:53 PM   harshkumar@outlook.com               User                    6/9/2023 4:51:53 PM      harshkumar@outlook.com
centraluseuap   1006_CUS_2am                                    6/9/2023 8:25:23 PM   harshkumar@outlook.com               User                    6/9/2023 8:25:23 PM      harshkumar@outlook.com
centraluseuap   CUS_1106                                        6/11/2023 12:29:58 PM harshkumar@outlook.com               User                    6/11/2023 12:29:58 PM    harshkumar@outlook.com
Central US EUAP Harsh_PostMan_1206                              6/12/2023 11:53:46 AM harshkumar@outlook.com               User                    6/12/2023 11:53:46 AM    harshkumar@outlook.com
centraluseuap   CUS_1206_2                                      6/12/2023 11:58:07 AM harshkumar@outlook.com               User                    6/12/2023 11:58:07 AM    harshkumar@outlook.com
centraluseuap   1406_Develop_CUS                                6/14/2023 8:57:58 AM  harshkumar@outlook.com               User                    6/14/2023 8:57:58 AM     harshkumar@outlook.com
centraluseuap   usaccount_27_06_23_02                           6/27/2023 5:14:26 AM  usaccount@outlook.com                User                    6/27/2023 5:14:26 AM     usaccount@outlook.com
centraluseuap   usaccount_28_03_23_01                           3/28/2023 8:09:47 AM  usaccount@outlook.com                User                    5/26/2023 7:15:21 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   usaccount_28_03_23_02                           3/28/2023 12:04:18 PM usaccount@outlook.com                User                    5/26/2023 7:15:21 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   usaccount_05_04_23_01                           4/5/2023 8:33:53 AM   usaccount@outlook.com                User                    5/26/2023 7:15:22 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   usaccount_21_04_23_03                           4/21/2023 11:29:46 AM usaccount@outlook.com                User                    4/21/2023 11:29:46 AM    usaccount@outlook.com
centraluseuap   usaccount_21_04_23_04                           4/21/2023 11:35:23 AM usaccount@outlook.com                User                    5/26/2023 7:15:23 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   usaccount_24_04_23_01                           4/24/2023 3:33:40 AM  usaccount@outlook.com                User                    5/26/2023 7:15:23 AM     f73fdc11-ed25-4c35-a93a-f525ab3…      
centraluseuap   acctest2985                                     5/2/2023 11:33:12 AM  user01@example.com                   User                    5/2/2023 11:33:12 AM     user01@example.com             
centraluseuap   acctestterraform1                               5/2/2023 11:50:50 AM  user01@example.com                   User                    5/2/2023 11:50:50 AM     user01@example.com             
Central US EUAP Harsh_PostMan_0905_1                            5/9/2023 5:13:23 AM   harshkumar@outlook.com               User                    5/9/2023 5:13:23 AM      harshkumar@outlook.com
centraluseuap   Uxuxuxuxuuxux                                   5/9/2023 7:53:15 AM   harshkumar@outlook.com               User                    5/9/2023 7:53:15 AM      harshkumar@outlook.com
centraluseuap   vip-test-09May23-CEUAP-LinkOrg-1                5/9/2023 9:58:49 AM   viprayjain@outlook.com               User                    5/26/2023 7:15:24 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   user01_test_canary1                             5/19/2023 4:19:33 AM  user01@example.com                   User                    5/19/2023 4:19:33 AM     user01@example.com             
centraluseuap   user01terraformcreate5                          5/23/2023 11:44:18 AM user01@example.com                   User                    5/23/2023 11:44:18 AM    user01@example.com             
centraluseuap   java-sdk-8849                                   5/26/2023 4:55:57 AM  09a13a20-12be-4fda-a11e-a6895d6b321b Application             5/26/2023 4:55:57 AM     09a13a20-12be-4fda-a11e-a6895d6… 
centraluseuap   usaccount_31_05_23_01                           5/31/2023 9:58:47 AM  usaccount@outlook.com                User                    5/31/2023 9:58:47 AM     usaccount@outlook.com
Central US EUAP Harsh_PostMan_0706                                                                                                                 6/7/2023 6:39:55 AM      harshkumar@outlook.com
eastus2euap     usaccount_21_06_23_01                           6/21/2023 9:06:41 AM  usaccount@outlook.com                User                    6/21/2023 9:06:41 AM     usaccount@outlook.com
```

Get list of monitors by subscription

### Example 2: List monitors by specific resource group
```powershell
Get-AzNewRelicMonitor -ResourceGroupName ps-test
```

```output
Location Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
-------- ----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
eastus   test-01 6/27/2023 8:30:45 AM user1@outlook.com   User                    6/27/2023 8:30:45 AM     user1@outlook.com      User                         ps-test
eastus   test-02 6/27/2023 8:44:10 AM user1@outlook.com   User                    6/27/2023 8:44:10 AM     user1@outlook.com      User                         ps-test
```

Get list of monitors by specific resource group

### Example 3: Get specific monitor with specific resource group
```powershell
Get-AzNewRelicMonitor -Name test-01 -ResourceGroupName ps-test
```

```output
Location Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
-------- ----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
eastus   test-01 6/27/2023 8:30:45 AM user1@outlook.com   User                    6/27/2023 8:30:45 AM     user1@outlook.com      User                         ps-test
```

Get specific monitor by name and resource group

### Example 4: List linked Azure resources
```powershell
Get-AzNewRelicMonitor -MonitorName test-01 -ResourceGroupName group-test -ListLinkedResource
```

```output
Id
--
/SUBSCRIPTIONS/11111111-2222-3333-4444-123456789101/RESOURCEGROUPS/group-TEST/PROVIDERS/NEWRELIC.OBSERVABILITY/MONITORS/TEST-01
```

This command lists all Azure resources associated to the same NewRelic organization and account as the target resource.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ListLinkedResource
List Linked Resource

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Monitors resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MonitorName

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
Parameter Sets: List1, Get
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
Parameter Sets: List, List1, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ILinkedResource

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.INewRelicMonitorResource

## NOTES

## RELATED LINKS
