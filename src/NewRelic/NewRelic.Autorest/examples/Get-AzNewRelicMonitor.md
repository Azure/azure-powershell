### Example 1: List monitors by subscription
```powershell
Get-AzNewRelicMonitor
```

```output
Location        Name                                            SystemDataCreatedAt   SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------        ----                                            -------------------   -------------------                  ----------------------- ------------------------ ------------------------         
eastus          dipesh_test_16_3_sb                             6/16/2023 6:26:11 AM  dipeshbhakat@outlook.com             User                    6/16/2023 6:47:28 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
eastus          16_06_23_01                                     6/16/2023 7:55:28 AM  saurgupta@outlook.com                User                    6/16/2023 7:55:28 AM     saurgupta@outlook.com
eastus          test-new-relic                                  6/19/2023 8:44:48 AM  v-taoxuzeng@outlook.com              User                    6/19/2023 8:44:48 AM     v-taoxuzeng@outlook.com        
eastus          test-new-relic2                                 6/21/2023 9:18:43 AM  v-taoxuzeng@outlook.com              User                    6/21/2023 9:18:43 AM     v-taoxuzeng@outlook.com        
eastus          test-01                                         6/27/2023 8:30:45 AM  v-jiaji@outlook.com                  User                    6/27/2023 8:30:45 AM     v-jiaji@outlook.com
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
centraluseuap   saurgupta_27_06_23_02                           6/27/2023 5:14:26 AM  saurgupta@outlook.com                User                    6/27/2023 5:14:26 AM     saurgupta@outlook.com
centraluseuap   saurgupta_28_03_23_01                           3/28/2023 8:09:47 AM  saurgupta@outlook.com                User                    5/26/2023 7:15:21 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   saurgupta_28_03_23_02                           3/28/2023 12:04:18 PM saurgupta@outlook.com                User                    5/26/2023 7:15:21 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   saurgupta_05_04_23_01                           4/5/2023 8:33:53 AM   saurgupta@outlook.com                User                    5/26/2023 7:15:22 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   saurgupta_21_04_23_03                           4/21/2023 11:29:46 AM saurgupta@outlook.com                User                    4/21/2023 11:29:46 AM    saurgupta@outlook.com
centraluseuap   saurgupta_21_04_23_04                           4/21/2023 11:35:23 AM saurgupta@outlook.com                User                    5/26/2023 7:15:23 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   saurgupta_24_04_23_01                           4/24/2023 3:33:40 AM  saurgupta@outlook.com                User                    5/26/2023 7:15:23 AM     f73fdc11-ed25-4c35-a93a-f525ab3…      
centraluseuap   acctest2985                                     5/2/2023 11:33:12 AM  dipeshbhakat@outlook.com             User                    5/2/2023 11:33:12 AM     dipeshbhakat@outlook.com       
centraluseuap   acctestterraform1                               5/2/2023 11:50:50 AM  dipeshbhakat@outlook.com             User                    5/2/2023 11:50:50 AM     dipeshbhakat@outlook.com       
Central US EUAP Harsh_PostMan_0905_1                            5/9/2023 5:13:23 AM   harshkumar@outlook.com               User                    5/9/2023 5:13:23 AM      harshkumar@outlook.com
centraluseuap   Uxuxuxuxuuxux                                   5/9/2023 7:53:15 AM   harshkumar@outlook.com               User                    5/9/2023 7:53:15 AM      harshkumar@outlook.com
centraluseuap   vip-test-09May23-CEUAP-LinkOrg-1                5/9/2023 9:58:49 AM   viprayjain@outlook.com               User                    5/26/2023 7:15:24 AM     f73fdc11-ed25-4c35-a93a-f525ab3… 
centraluseuap   dipesh_test_canary1                             5/19/2023 4:19:33 AM  dipeshbhakat@outlook.com             User                    5/19/2023 4:19:33 AM     dipeshbhakat@outlook.com       
centraluseuap   dipeshterraformcreate5                          5/23/2023 11:44:18 AM dipeshbhakat@outlook.com             User                    5/23/2023 11:44:18 AM    dipeshbhakat@outlook.com       
centraluseuap   java-sdk-8849                                   5/26/2023 4:55:57 AM  09a13a20-12be-4fda-a11e-a6895d6b321b Application             5/26/2023 4:55:57 AM     09a13a20-12be-4fda-a11e-a6895d6… 
centraluseuap   saurgupta_31_05_23_01                           5/31/2023 9:58:47 AM  saurgupta@outlook.com                User                    5/31/2023 9:58:47 AM     saurgupta@outlook.com
Central US EUAP Harsh_PostMan_0706                                                                                                                 6/7/2023 6:39:55 AM      harshkumar@outlook.com
eastus2euap     saurgupta_21_06_23_01                           6/21/2023 9:06:41 AM  saurgupta@outlook.com                User                    6/21/2023 9:06:41 AM     saurgupta@outlook.com
```

Get list of monitors by subscription

### Example 2: List monitors by specific resource group
```powershell
Get-AzNewRelicMonitor -ResourceGroupName ps-test
```

```output
Location Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
-------- ----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
eastus   test-01 6/27/2023 8:30:45 AM v-jiaji@outlook.com   User                    6/27/2023 8:30:45 AM     v-jiaji@outlook.com      User                         ps-test
eastus   test-02 6/27/2023 8:44:10 AM v-jiaji@outlook.com   User                    6/27/2023 8:44:10 AM     v-jiaji@outlook.com      User                         ps-test
```

Get list of monitors by specific resource group

### Example 3: Get specific monitor with specific resource group
```powershell
Get-AzNewRelicMonitor -Name test-01 -ResourceGroupName ps-test
```

```output
Location Name    SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName RetryAfter
-------- ----    -------------------  -------------------   ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- ----------
eastus   test-01 6/27/2023 8:30:45 AM v-jiaji@outlook.com   User                    6/27/2023 8:30:45 AM     v-jiaji@outlook.com      User                         ps-test
```

Get specific monitor by name and resource group