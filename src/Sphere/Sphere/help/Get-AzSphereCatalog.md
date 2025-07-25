---
external help file: Az.Sphere-help.xml
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azspherecatalog
schema: 2.0.0
---

# Get-AzSphereCatalog

## SYNOPSIS
Get a Catalog

## SYNTAX

### List (Default)
```
Get-AzSphereCatalog [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSphereCatalog -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzSphereCatalog -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSphereCatalog -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Catalog

## EXAMPLES

### Example 1: List all catalogs for a given resource group
```powershell
Get-AzSphereCatalog -ResourceGroupName test-sataneja-10
```

```output
Location Name                   SystemDataCreatedAt    SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName      
-------- ----                   -------------------    -------------------    ----------------------- ------------------------ ------------------------ ---------------------------- ----------- 
global   CAT43                  9/24/2022 12:54:16 PM  example@microsoft.com  User                    9/24/2022 12:54:16 PM    example@microsoft.com    User                         test-satan… 
global   CAT007                 9/26/2022 8:58:15 PM   example@microsoft.com  User                    9/26/2022 8:58:15 PM     example@microsoft.com    User                         test-satan… 
global   CAT10                  10/10/2022 4:23:53 PM  example@microsoft.com  User                    10/10/2022 4:23:53 PM    example@microsoft.com    User                         test-satan… 
global   TCAT01                 10/14/2022 12:12:22 AM example@microsoft.com  User                    10/14/2022 12:12:22 AM   example@microsoft.com    User                         test-satan… 
global   TestCatalog1x3         4/25/2023 10:00:52 PM  example@microsoft.com  User                    4/25/2023 10:00:52 PM    example@microsoft.com    User                         test-satan… 
global   TestCatalog1x3_Catalog 5/11/2023 6:12:50 PM   example@microsoft.com  User                    5/11/2023 6:12:50 PM     example@microsoft.com    User                         test-satan…
```

This command lists all catalogs for a given resource group.

### Example 2: Get specific catalog with specified resource group
```powershell
Get-AzSphereCatalog -Name "testcat" -ResourceGroupName "goyedokun"
```

```output
Id                           : /subscriptions/82f138e0-1c79-4708-bda1-5e224cd688b2/resourceGroups/goyedokun/providers/Microsoft.AzureSphere/catalogs/testcat
Location                     : global
Name                         : testcat
ProvisioningState            : Succeeded
ResourceGroupName            : goyedokun
RetryAfter                   : 
SystemDataCreatedAt          : 6/27/2023 6:49:50 PM
SystemDataCreatedBy          : example@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 6/27/2023 6:49:50 PM
SystemDataLastModifiedBy     : example@microsoft.com
SystemDataLastModifiedByType : User
Tag                          : {
                               }
Type                         : microsoft.azuresphere/catalogs
```

This command get specific catalog with specified resource group.

### Example 2: List all catalogs for connected subscription
```powershell
Get-AzSphereCatalog
```

```output
Location Name                           SystemDataCreatedAt    SystemDataCreatedBy                  SystemDataCreatedByType SystemDataLastModifiedAt SystemData
                                                                                                                                                     LastModifi 
                                                                                                                                                     edBy       
-------- ----                           -------------------    -------------------                  ----------------------- ------------------------ ---------- 
global   MyCatalog3                     4/21/2021 9:32:32 PM   example@microsoft.com                User                    8/10/2023 3:21:08 PM     example@m… 
global   MyCatalog2                     5/20/2021 4:44:38 PM   example@microsoft.com                User                    5/20/2021 4:44:38 PM     example@m… 
global   MyCatalog1                     5/20/2021 4:45:44 PM   example@microsoft.com                User                    5/20/2021 4:45:44 PM     example@m… 
global   CatalogARMSetup_39f85f04       8/18/2021 8:28:11 PM   5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             8/18/2021 8:28:11 PM     5223a8bc-… 
global   CatalogARMSetup_3b15f308       9/17/2021 6:41:41 PM   5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             9/17/2021 6:41:41 PM     5223a8bc-… 
global   mrarmcatalog1                  9/21/2021 7:27:16 PM   example@microsoft.com                User                    9/21/2021 7:27:16 PM     example@m… 
global   CatalogARMSetup_eb5cca0a       9/21/2021 10:06:28 PM  5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             9/21/2021 10:06:28 PM    5223a8bc-… 
global   CatalogARMSetup_f8c1fea7       9/21/2021 10:06:31 PM  5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             9/21/2021 10:06:31 PM    5223a8bc-… 
global   CatalogARMSetup_f2d88f81       9/21/2021 10:06:38 PM  5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             9/21/2021 10:06:38 PM    5223a8bc-… 
global   CatalogARMSetup_1711d4b8       9/21/2021 10:06:42 PM  5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             9/21/2021 10:06:42 PM    5223a8bc-… 
global   CatalogARMSetup_04744136       10/1/2021 7:14:04 PM   5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             10/1/2021 7:14:04 PM     5223a8bc-… 
global   CatalogARMSetup_bff4a3fe       10/5/2021 5:14:48 PM   5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             10/5/2021 5:14:48 PM     5223a8bc-… 
global   CatalogARMSetup_e05ad6ac       10/5/2021 5:15:05 PM   5223a8bc-448a-411c-bcd4-7d41745ed6ba Application             10/5/2021 5:15:05 PM     5223a8bc-… 
global   newCatalog                     8/15/2023 3:06:31 AM   example@microsoft.com                User                    8/15/2023 3:10:39 AM     example@m…
```

This command lists all catalogs for current subscription.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of catalog

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CatalogName

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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ICatalog

## NOTES

## RELATED LINKS
