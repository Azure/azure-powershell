---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azcdnprofile
schema: 2.0.0
---

# Get-AzCdnProfile

## SYNOPSIS
Gets an CDN profile with the specified profile name under the specified subscription and resource group.

## SYNTAX

### List (Default)
```
Get-AzCdnProfile [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzCdnProfile [-SubscriptionId <String[]>] -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzCdnProfile [-SubscriptionId <String[]>] -Name <String> -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCdnProfile -InputObject <ICdnIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an CDN profile with the specified profile name under the specified subscription and resource group.

## EXAMPLES

### Example 1: List AzureCDN profiles under the subscription
```powershell
Get-AzCdnProfile
```

```output
Location Name             Kind ResourceGroupName
-------- ----             ---- -----------------
Global   p-oln142         cdn  testps-rg-godj4q
Global   cdn001           cdn  testps-rg-da16jm
Global   cdn002           cdn  testps-rg-da16jm
```

List AzureCDN profiles under the subscription

### Example 2: List AzureCDN profiles under the resource group
```powershell
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
Global   cdn002 cdn  testps-rg-da16jm
```

List AzureCDN profiles under the resource group

### Example 3: Get an AzureCDN profile under the resource group
```powershell
Get-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
```

Get an AzureCDN profile under the resource group

### Example 4: Get an AzureCDN profile under the resource group via identity
```powershell
New-AzCdnProfile -ResourceGroupName testps-rg-da16jm -Name cdn001 -SkuName Standard_Microsoft -Location Global | Get-AzCdnProfile
```

```output
Location Name   Kind ResourceGroupName
-------- ----   ---- -----------------
Global   cdn001 cdn  testps-rg-da16jm
```

Get an AzureCDN profile under the resource group via identity

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

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
Azure Subscription ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IProfile

## NOTES

## RELATED LINKS
