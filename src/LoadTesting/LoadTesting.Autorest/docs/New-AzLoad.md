---
external help file:
Module Name: Az.LoadTesting
online version: https://learn.microsoft.com/powershell/module/az.loadtesting/new-azload
schema: 2.0.0
---

# New-AzLoad

## SYNOPSIS
Create LoadTest resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzLoad -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-EnableSystemAssignedIdentity] [-EncryptionIdentity <String>] [-EncryptionKey <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzLoad -Name <String> -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzLoad -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create LoadTest resource.

## EXAMPLES

### Example 1: Create an Azure Load Testing resource
```powershell
New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US.

### Example 2: Create an Azure Load Testing resource with Managed Identity
```powershell
$userAssigned = @("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1", "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2")

New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -EnableSystemAssignedIdentity -UserAssignedIdentity $userAssigned
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US, with System-Assigned and 2 provided User-Assigned managed identities.

### Example 3: Create an Azure Load Testing resource with Customer Managed key encryption
```powershell
$userAssigned = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1"

New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -EnableSystemAssignedIdentity -UserAssignedIdentity $userAssigned -EncryptionIdentity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" -EncryptionKey "https://sample-akv.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde"
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US, with the provided User-Assigned managed identity and uses the Encryption Identity to access the Encryption Key for CMK encryption.

### Example 4: Create an Azure Load Testing resource with tags
```powershell
$tag = @{"key1" = "value1"; "key2" = "value2"}
New-AzLoad -Name sampleres -ResourceGroupName sample-rg -Location eastus -Tag $tag
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command creates a new Azure Load Testing resource named sampleres in resource group named sample-rg and in the region East US with the provided tags.

## PARAMETERS

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionIdentity
The managed identity for Customer-managed key settings defining which identity should be used to authenticate to Key Vault.

Ex: 'SystemAssigned' uses system-assigned managed identity, whereas '/subscriptions/fa5fc227-a624-475e-b696-cdd604c735bc/resourceGroups/\<resource group\>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId' uses the given user-assigned managed identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKey
key encryption key Url, versioned.
Ex: https://contosovault.vault.azure.net/keys/contosokek/562a4bb76b524a1493a6afe8e536ee78 or https://contosovault.vault.azure.net/keys/contosokek.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Load Test name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LoadTestName

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.LoadTesting.Models.ILoadTestResource

## NOTES

## RELATED LINKS

