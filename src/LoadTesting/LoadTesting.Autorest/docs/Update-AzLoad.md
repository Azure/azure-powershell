---
external help file:
Module Name: Az.LoadTesting
online version: https://learn.microsoft.com/powershell/module/az.loadtesting/update-azload
schema: 2.0.0
---

# Update-AzLoad

## SYNOPSIS
Update LoadTest resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzLoad -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EncryptionIdentity <String>] [-EncryptionKey <String>] [-IdentityType <String>]
 [-IdentityUserAssigned <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzLoad -InputObject <ILoadTestingIdentity> [-EnableSystemAssignedIdentity <Boolean?>]
 [-EncryptionIdentityResourceId <String>] [-EncryptionIdentityType <String>] [-EncryptionKey <String>]
 [-IdentityUserAssigned <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update LoadTest resource.

## EXAMPLES

### Example 1: Update an Azure Load Testing resource with tags
```powershell
$tag = @{"key0" = "value0"}
Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -Tag $tag
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg with the provided tags.

### Example 2: Update an Azure Load Testing resource to use System-Assigned identity for CMK encryption
```powershell
Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -IdentityType "SystemAssigned" -EncryptionIdentity "SystemAssigned" -EncryptionKey "https://sample-akv.vault.azure.net/keys/cmk/2d1ccd5c50234ea2a0858fe148b69cde"
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg, to use System-assigned identity for accessing the encryption key for CMK encryption.

### Example 3: Update an Azure Load Testing resource to remove an existing User-Assigned managed identity
```powershell
$userAssigned = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity1" = @{}; "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" = $null}

Update-AzLoad -Name sampleres -ResourceGroupName sample-rg -IdentityType "SystemAssigned,UserAssigned" -IdentityUserAssigned $userAssigned
```

```output
Name      Resource group Location DataPlane URL
----      -------------- -------- -------------
sampleres sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command updates the Azure Load Testing resource named sampleres in resource group named sample-rg, to remove the user-assigned managed identity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity2" if already assigned to the resource.

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
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionIdentityResourceId
user assigned identity to use for accessing key encryption key Url.
Ex: /subscriptions/fa5fc227-a624-475e-b696-cdd604c735bc/resourceGroups/\<resource group\>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionIdentityType
Managed identity type to use for accessing encryption key Url

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssigned
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LoadTesting.Models.ILoadTestingIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Azure Load Testing resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.LoadTesting.Models.ILoadTestingIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LoadTesting.Models.ILoadTestResource

## NOTES

## RELATED LINKS

