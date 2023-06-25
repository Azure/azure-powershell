---
external help file:
Module Name: Az.Qumulo
online version: https://learn.microsoft.com/powershell/module/az.qumulo/new-azqumulofilesystem
schema: 2.0.0
---

# New-AzQumuloFileSystem

## SYNOPSIS
Create a file system resource

## SYNTAX

```
New-AzQumuloFileSystem -Name <String> -ResourceGroupName <String> -AdminPassword <SecureString>
 -DelegatedSubnetId <String> -InitialCapacity <Int32> -Location <String> -MarketplaceOfferId <String>
 -MarketplacePlanId <String> -MarketplacePublisherId <String> -StorageSku <StorageSku> -UserEmail <String>
 [-SubscriptionId <String>] [-AvailabilityZone <String>] [-ClusterLoginUrl <String>]
 [-IdentityType <ManagedServiceIdentityType>] [-MarketplaceSubscriptionId <String>] [-PrivateIP <String[]>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a file system resource

## EXAMPLES

### Example 1: Create a minimum set file system resource
```powershell
$password = ConvertTo-SecureString "1qaz@WSX" -AsPlainText

New-AzQumuloFileSystem -Name qumulo01 -ResourceGroupName ps-joyer-test -DelegatedSubnetId /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/ps-joyer-test/providers/Microsoft.Network/virtualNetworks/eastus-ps-virtualnetwork/subnets/qumulo-vn -InitialCapacity 50 -Location eastus -MarketplaceOfferId "qumulo-saas-mpp" -MarketplacePlanId "qumulo-on-azure-v1%%gmz7xq9ge3py%%P1M" -MarketplacePublisherId qumulo1584033880660 -StorageSku Standard -UserEmail user@organization.com -AdminPassword $password
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus   qumulo01           5/24/2023 7:27:12 AM user@organization.com User                    5/24/2023 7:42:17 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test
```

Create a file system resource.
The password must contain at least 8 characters and have at least 1 letter, 1 number and 1 special character.

### Example 2: Create a file system resource with other settings
```powershell
$password = ConvertTo-SecureString "2wsx#EDC" -AsPlainText

New-AzQumuloFileSystem -Name qumulo02 -ResourceGroupName ps-joyer-test -AdminPassword $password -DelegatedSubnetId /subscriptions/fc35d936-3b89-41f8-8110-a24b56826c37/resourceGroups/ps-joyer-test/providers/Microsoft.Network/virtualNetworks/eastus-ps-virtualnetwork/subnets/qumulo-vn -InitialCapacity 50 -Location eastus -MarketplaceOfferId "qumulo-saas-mpp" -MarketplacePlanId "qumulo-on-azure-v1%%gmz7xq9ge3py%%P1M" -MarketplacePublisherId qumulo1584033880660 -StorageSku Standard -UserEmail user@organization.com -AvailabilityZone 1 -Tag @{"123"="abc"}
```

```output
Location Name               SystemDataCreatedAt  SystemDataCreatedBy   SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName  
-------- ----               -------------------  -------------------   ----------------------- ------------------------ ------------------------             ---------------------------- -----------------  
eastus   qumulo02           5/24/2023 9:31:50 AM user@organization.com User                    5/24/2023 9:41:10 AM     13c34964-a135-4390-aa53-32f3c7251982 Application                  ps-joyer-test
```

Create a file system resource with a maximum set

## PARAMETERS

### -AdminPassword
Initial administrator password of the resource

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityZone
Availability zone

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterLoginUrl
File system Id of the resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DelegatedSubnetId
Delegated subnet id for Vnet injection

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitialCapacity
Storage capacity in TB

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -MarketplaceOfferId
Offer Id

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

### -MarketplacePlanId
Plan Id

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

### -MarketplacePublisherId
Publisher Id

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

### -MarketplaceSubscriptionId
Marketplace Subscription Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the File System resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FileSystemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateIP
Private IPs of the resource

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSku
Storage Sku

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Support.StorageSku
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEmail
User Email

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResource

## NOTES

ALIASES

## RELATED LINKS

