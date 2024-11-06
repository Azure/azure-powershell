---
external help file:
Module Name: Az.NeonPostgres
online version: https://learn.microsoft.com/powershell/module/az.neonpostgres/get-azneonpostgresorganization
schema: 2.0.0
---

# Get-AzNeonPostgresOrganization

## SYNOPSIS
Get a OrganizationResource

## SYNTAX

### List (Default)
```
Get-AzNeonPostgresOrganization [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNeonPostgresOrganization -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNeonPostgresOrganization -InputObject <INeonPostgresIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzNeonPostgresOrganization -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a OrganizationResource

## EXAMPLES

### Example 1: Get Neon Organization Details
```powershell
Get-AzNeonPostgresOrganization -SubscriptionId 5d9a6cc3-4e60-4b41-be79-d28f0a01074e
```

```output
Location      Name                       SystemDataCreatedAt   SystemDataCreatedBy           SystemDataCreatedByType Sy
                                                                                                                     st
                                                                                                                     em
                                                                                                                     Da
                                                                                                                     ta
                                                                                                                     La
                                                                                                                     st
                                                                                                                     Mo
                                                                                                                     di
                                                                                                                     fi
                                                                                                                     ed
                                                                                                                     At
--------      ----                       -------------------   -------------------           ----------------------- --
eastus2       org123                     25-Oct-24 5:59:50 AM  deepikan@microsoft.com        User                    25
eastus2       Sr-Neon-Org-Prod           25-Oct-24 10:04:14 AM srinivas.alluri@microsoft.com User                    25
eastus2       Sr-Neon-Org-Prod-2         25-Oct-24 10:16:08 AM srinivas.alluri@microsoft.com User                    25
eastus2       ProdNeonOrg-1              29-Oct-24 5:02:55 AM  srinivas.alluri@microsoft.com User                    29
eastus2       rj-prod-1                                                                                              29
eastus2       rj-prod-2                  29-Oct-24 7:29:12 AM  rajasinghal@microsoft.com     User                    29
eastus2       My-new-neon-org            29-Oct-24 12:33:47 PM priyverma@microsoft.com       User                    29
eastus2       ProdOrgTest                29-Oct-24 3:42:54 PM  srinivas.alluri@microsoft.com User                    29
eastus2       My-new-Neon-Org            04-Nov-24 11:17:17 AM priyverma@microsoft.com       User                    04
eastus2       rj-db-test-1               05-Nov-24 11:19:43 AM rajasinghal@microsoft.com     User                    05
eastus2euap   TestEUS21                  16-Oct-24 9:45:05 AM  srinivas.alluri@microsoft.com User                    16
eastus2euap   test_20                                                                                                16
eastus2euap   test_21                    16-Oct-24 12:17:29 PM guptashash@microsoft.com      User                    16
eastus2euap   test_22                    16-Oct-24 12:19:06 PM guptashash@microsoft.com      User                    16
eastus2euap   testrg-88888               16-Oct-24 12:44:45 PM rajasinghal@microsoft.com     User                    16
eastus2euap   test_24                    16-Oct-24 1:43:58 PM  guptashash@microsoft.com      User                    16
eastus2euap   test_25                    16-Oct-24 1:44:41 PM  guptashash@microsoft.com      User                    16
eastus2euap   TestOperationState                                                                                     17
eastus2euap   eus2euap-nt29              17-Oct-24 2:17:44 AM  srinivas.alluri@microsoft.com User                    17
eastus2euap   eus2euap-nt31              17-Oct-24 5:12:21 AM  srinivas.alluri@microsoft.com User                    17
eastus2euap   test433                    17-Oct-24 5:25:21 AM  srinivas.alluri@microsoft.com User                    17
eastus2euap   testrg-123456              17-Oct-24 7:15:17 AM  rajasinghal@microsoft.com     User                    17
eastus2euap   testrg-11112               17-Oct-24 7:20:00 AM  rajasinghal@microsoft.com     User                    17
eastus2euap   testrg-111                 17-Oct-24 7:34:34 AM  rajasinghal@microsoft.com     User                    17
eastus2euap   testrg-11                  17-Oct-24 7:39:51 AM  rajasinghal@microsoft.com     User                    17
eastus2euap   testrg-2626                17-Oct-24 8:09:47 AM  rajasinghal@microsoft.com     User                    17
eastus2euap   TestOperationStatus2       17-Oct-24 8:12:14 AM  srinivas.alluri@microsoft.com User                    17
eastus2euap   eus2euap-nt32              17-Oct-24 8:18:49 AM  srinivas.alluri@microsoft.com User                    17
eastus2euap   testrg-2627                17-Oct-24 8:21:38 AM  rajasinghal@microsoft.com     User                    17
eastus2euap   testrg-2630                                                                                            17
eastus2euap   eus2euap-nt33              17-Oct-24 10:06:20 AM srinivas.alluri@microsoft.com User                    17
eastus2euap   eus2euap-nt34              17-Oct-24 10:16:20 AM srinivas.alluri@microsoft.com User                    17
eastus2euap   test_26                    17-Oct-24 11:50:38 AM guptashash@microsoft.com      User                    17
eastus2euap   test_27                    17-Oct-24 11:51:42 AM guptashash@microsoft.com      User                    17
eastus2euap   test_28                    17-Oct-24 11:52:29 AM guptashash@microsoft.com      User                    17
eastus2euap   test_29                    17-Oct-24 2:32:38 PM  guptashash@microsoft.com      User                    17
eastus2euap   test_30                    17-Oct-24 2:33:46 PM  guptashash@microsoft.com      User                    17
eastus2euap   test_31                                                                                                17
eastus2euap   test_32                    17-Oct-24 3:07:31 PM  guptashash@microsoft.com      User                    17
eastus2euap   test_33                                                                                                18
eastus2euap   test_34                    18-Oct-24 7:38:33 AM  guptashash@microsoft.com      User                    18
eastus2euap   test_35                                                                                                18
eastus2euap   test_36                    18-Oct-24 8:47:56 AM  guptashash@microsoft.com      User                    18
eastus2euap   test_37                                                                                                18
eastus2euap   test_38                    18-Oct-24 11:08:44 AM guptashash@microsoft.com      User                    18
eastus2euap   test_40                    18-Oct-24 1:34:56 PM  guptashash@microsoft.com      User                    18
eastus2euap   test_41                                                                                                18
eastus2euap   test_42                    18-Oct-24 3:27:37 PM  guptashash@microsoft.com      User                    18
eastus2euap   test_44                    20-Oct-24 10:45:14 AM guptashash@microsoft.com      User                    20
eastus2euap   eus2euap-nt37              20-Oct-24 12:00:30 PM srinivas.alluri@microsoft.com User                    20
eastus2euap   deepika-neon-org-2110      21-Oct-24 5:43:27 AM  deepikan@microsoft.com        User                    21
eastus2euap   testOrgAAK                 21-Oct-24 7:12:25 AM  khanalmas@microsoft.com       User                    21
eastus2euap   almasTestNeonCLI           21-Oct-24 3:40:16 PM  khanalmas@microsoft.com       User                    22
eastus2euap   NeonTestResource           21-Oct-24 4:34:49 PM  khanalmas@microsoft.com       User                    21
eastus2euap   testCLI3                   21-Oct-24 6:03:52 PM  khanalmas@microsoft.com       User                    21
eastus2euap   almasTestNeonCLI1          21-Oct-24 6:13:21 PM  khanalmas@microsoft.com       User                    21
eastus2euap   NeonTestResourceForCLI1    21-Oct-24 6:45:42 PM  khanalmas@microsoft.com       User                    21
eastus2euap   NeonTestResourceForCLI2    21-Oct-24 6:49:26 PM  khanalmas@microsoft.com       User                    21
eastus2euap   NeonTestResourceForCLI3    21-Oct-24 6:53:07 PM  khanalmas@microsoft.com       User                    21
eastus2euap   NeonCLITestResource1       21-Oct-24 6:56:12 PM  khanalmas@microsoft.com       User                    21
eastus2euap   NeonCLITestOrg1            21-Oct-24 7:03:11 PM  khanalmas@microsoft.com       User                    21
eastus2euap   deepika-abc                22-Oct-24 7:38:10 AM  deepikan@microsoft.com        User                    22
eastus2euap   abcd                       22-Oct-24 8:10:39 AM  deepikan@microsoft.com        User                    22
eastus2euap   LocalDemo234               22-Oct-24 9:05:37 AM  srinivas.alluri@microsoft.com User                    22
eastus2euap   TestDemoTime               22-Oct-24 9:19:58 AM  srinivas.alluri@microsoft.com User                    22
eastus2euap   deepika-neon-org-2                                                                                     23
eastus2euap   rj-test-1                  22-Oct-24 12:50:08 PM rajasinghal@microsoft.com     User                    22
eastus2euap   rj-test-2                  22-Oct-24 4:18:55 PM  rajasinghal@microsoft.com     User                    22
eastus2euap   DelOrg2                    22-Oct-24 4:38:10 PM  srinivas.alluri@microsoft.com User                    22
eastus2euap   DeleteTestOrg11            22-Oct-24 4:59:59 PM  srinivas.alluri@microsoft.com User                    22
eastus2euap   LocalDeleteTest12          22-Oct-24 5:30:57 PM  srinivas.alluri@microsoft.com User                    22
eastus2euap   TestORgCreate12            23-Oct-24 1:43:54 AM  srinivas.alluri@microsoft.com User                    23
eastus2euap   oldBranchORg                                                                                           23
eastus2euap   TestOrgNeon5               23-Oct-24 3:57:24 AM  srinivas.alluri@microsoft.com User                    23
eastus2euap   eus2euap-nt39              25-Oct-24 6:11:45 AM  srinivas.alluri@microsoft.com User                    25
eastus2euap   eus2euap-nt40              25-Oct-24 7:04:23 AM  srinivas.alluri@microsoft.com User                    25
eastus2euap   rj-test-org52                                                                                          25
eastus2euap   rj-test-53                 25-Oct-24 2:18:51 PM  rajasinghal@microsoft.com     User                    25
eastus2euap   rj-test-errLog             25-Oct-24 2:24:36 PM  rajasinghal@microsoft.com     User                    25
eastus2euap   rj-test-org55                                                                                          26
eastus2euap   rj-test-org57                                                                                          26
eastus2euap   rj-test-org58              26-Oct-24 10:22:40 AM rajasinghal@microsoft.com     User                    26
eastus2euap   rj-test-60                 28-Oct-24 5:18:53 AM  rajasinghal@microsoft.com     User                    28
eastus2euap   rj-test-org61              28-Oct-24 5:59:22 AM  rajasinghal@microsoft.com     User                    28
eastus2euap   rj-test-auth2                                                                                          28
eastus2euap   rj-test-org65              28-Oct-24 9:15:16 AM  rajasinghal@microsoft.com     User                    28
eastus2euap   rj-test-70                                                                                             29
centraluseuap TestConnector-1            18-Oct-24 7:38:13 AM  priyverma@microsoft.com       User                    18
centraluseuap serviceconnectortest       18-Oct-24 7:47:18 AM  chejian@microsoft.com         User                    18
centraluseuap abc                        18-Oct-24 8:50:34 AM  deepikan@microsoft.com        User                    18
centraluseuap testrg-0030                                                                                            18
centraluseuap sr_neon_org                                                                                            23
centraluseuap rj-test-12                 23-Oct-24 7:06:53 AM  rajasinghal@microsoft.com     User                    23
centraluseuap rj-test-delete                                                                                         23
centraluseuap neonorg-deepika-2310       23-Oct-24 8:05:29 AM  deepikan@microsoft.com        User                    23
centraluseuap org1-manish                23-Oct-24 8:36:17 AM  narulamanish@microsoft.com    User                    23
centraluseuap TestNeonOrgSr              23-Oct-24 9:10:49 AM  srinivas.alluri@microsoft.com User                    23
centraluseuap rj-test-30                 23-Oct-24 9:56:16 AM  rajasinghal@microsoft.com     User                    23
centraluseuap FinalTestOrgSr             23-Oct-24 9:58:11 AM  srinivas.alluri@microsoft.com User                    23
centraluseuap ntt                        24-Oct-24 5:21:18 AM  srinivas.alluri@microsoft.com User                    24
centraluseuap rj-test-org                24-Oct-24 5:26:44 AM  rajasinghal@microsoft.com     User                    24
centraluseuap test-123-neon              24-Oct-24 9:56:54 AM  priyverma@microsoft.com       User                    24
centraluseuap Sralluri-Neon-Postgres-Org 24-Oct-24 10:08:30 AM srinivas.alluri@microsoft.com User                    24
centraluseuap NP-Org-1                   24-Oct-24 10:24:17 AM srinivas.alluri@microsoft.com User                    24
centraluseuap rj-test-31                 24-Oct-24 10:41:33 AM rajasinghal@microsoft.com     User                    24
centraluseuap Test-Neon-Org-22           24-Oct-24 10:42:04 AM priyverma@microsoft.com       User                    24
centraluseuap neon-org-123               24-Oct-24 12:28:08 PM deepikan@microsoft.com        User                    24
centraluseuap test-org-1234-deepika      24-Oct-24 12:32:12 PM deepikan@microsoft.com        User                    24
centraluseuap neon-og-1234               24-Oct-24 12:51:17 PM deepikan@microsoft.com        User                    24
centraluseuap org-neon-123               24-Oct-24 12:59:06 PM deepikan@microsoft.com        User                    24
centraluseuap Sr-NT-Org-1                24-Oct-24 5:37:49 PM  srinivas.alluri@microsoft.com User                    24
centraluseuap Sr-NT-ORg-2                24-Oct-24 5:51:19 PM  srinivas.alluri@microsoft.com User                    24
centraluseuap neon-org121                                                                                            25
centraluseuap Sr-NP-Org-2                25-Oct-24 7:03:04 AM  srinivas.alluri@microsoft.com User                    25
centraluseuap Sr-NP-Org-3                25-Oct-24 7:08:43 AM  srinivas.alluri@microsoft.com User                    25
centraluseuap Sr-NP-Org-4                25-Oct-24 7:11:38 AM  srinivas.alluri@microsoft.com User                    25
centraluseuap org1234deepika2510         25-Oct-24 7:21:58 AM  deepikan@microsoft.com        User                    25
centraluseuap tags-test-deepika-2510     25-Oct-24 7:25:22 AM  deepikan@microsoft.com        User                    25
centraluseuap deeepika-no-tags-test      25-Oct-24 7:54:47 AM  deepikan@microsoft.com        User                    25
centraluseuap Sr-NP-Org-5                25-Oct-24 9:40:32 AM  srinivas.alluri@microsoft.com User                    25
centraluseuap tags-test-2-preview        25-Oct-24 10:09:02 AM deepikan@microsoft.com        User                    25
centraluseuap rj-test-55                 25-Oct-24 2:43:48 PM  rajasinghal@microsoft.com     User                    25
centraluseuap CentralUSEUAP-Test         29-Oct-24 5:27:57 AM  srinivas.alluri@microsoft.com User                    29
centraluseuap neon-org-1232910           29-Oct-24 5:41:42 AM  deepikan@microsoft.com        User                    29
centraluseuap rj-test-73                 29-Oct-24 5:49:26 AM  rajasinghal@microsoft.com     User                    29
centraluseuap rj-test-75                                                                                             29
centraluseuap rj-test-76                                                                                             29
centraluseuap testorg123                 29-Oct-24 2:30:05 PM  deepikan@microsoft.com        User                    29
centraluseuap neon-org                   05-Nov-24 6:05:23 AM  deepikan@microsoft.com        User                    05

```

This command will get all organization details for a subscription id

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
Type: Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Neon Organizations resource

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OrganizationName

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
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.INeonPostgresIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NeonPostgres.Models.IOrganizationResource

## NOTES

## RELATED LINKS

