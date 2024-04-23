---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/get-azpurviewaccount
schema: 2.0.0
---

# Get-AzPurviewAccount

## SYNOPSIS
Get an account

## SYNTAX

### List1 (Default)
```
Get-AzPurviewAccount [-SubscriptionId <String[]>] [-SkipToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPurviewAccount -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzPurviewAccount -ResourceGroupName <String> [-SubscriptionId <String[]>] [-SkipToken <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPurviewAccount -InputObject <IPurviewIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get an account

## EXAMPLES

### Example 1: List All Purview Accounts
```powershell
Get-AzPurviewAccount
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name          SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType 
-------------------                  ----------------                     ------------   -------- ----          -------------------  -------------------      -------- 
xxxxxxxx-a087-43aa-8a7f-c17a4bbd4d36 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   pvac          8/4/2021 8:34:28 AM  xxx@microsoft.com        User     
xxxxxxxx-bbe7-4506-a9c4-4d602d8e4e1c xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   purview-test  8/9/2021 9:38:47 AM  xxxxxxxxx@microsoft.com  User     
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa       8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User
```

List all purview accounts.

### Example 2: Get Purview Account by Resource Group Name and Name
```powershell
Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5…
```

Get the purview account name test-rg in resource group test-pa

### Example 3: List Purview Accounts in a Specified Resource Group
```powershell
Get-AzPurviewAccount -ResourceGroupName test-rg
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5…
```

List the purview accounts in resource group test-pa

### Example 4: Get Purview Account by InputObject
```powershell
$got = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
Get-AzADDomainService -InputObject $got
```

```output
IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5…
```

Get the purview account by InputObject

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the account.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
The skip token.

```yaml
Type: System.String
Parameter Sets: List1, List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount

## NOTES

## RELATED LINKS
