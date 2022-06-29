---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.dll-Help.xml
Module Name: Az.ServiceBus
online version: https://docs.microsoft.com/powershell/module/az.servicebus/new-azservicebusnamespace
schema: 2.0.0
---

# New-AzServiceBusNamespace

## SYNOPSIS
Creates a new Service Bus namespace.

## SYNTAX

```
New-AzServiceBusNamespace [-ResourceGroupName] <String> [-Location] <String> [-Name] <String>
 [-SkuName <String>] [-SkuCapacity <Int32>] [-Tag <Hashtable>] [-ZoneRedundant] [-DisableLocalAuth]
 [-IdentityType <String>] [-IdentityId <String[]>] [-EncryptionConfig <PSEncryptionConfigAttributes[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzServiceBusNamespace** cmdlet creates a new Service Bus namespace. Once created, the namespace resource manifest is immutable. This operation is idempotent.

## EXAMPLES

### Example 1
```powershell
New-AzServiceBusNamespace -ResourceGroupName Default-ServiceBus-WestUS -Name SB-Example1 -Location WestUS -SkuName "Standard" -Tag @{Tag1="Tag1Value"}
```

```output
Name               : SB-Example1
Id                 : /subscriptions/{SubscriptionId}/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.ServiceBus/namespaces/SB-Example1
ResourceGroupName  : Default-ServiceBus-WestUS
Location           : West US
Tags               : {TesttingTags, TestingTagValue, TestTag, TestTagValue}
Sku                : Name : Standard , Tier : Standard
ProvisioningState  : Succeeded
CreatedAt          : 1/20/2017 2:07:33 AM
UpdatedAt          : 1/20/2017 2:07:56 AM
ServiceBusEndpoint : https://SB-Example1.servicebus.windows.net:443/
```

Creates a new Service Bus namespace within the specified resource group.

### Example 2 - ZoneRedundant and DisableLocalAuth
```powershell
New-AzServiceBusNamespace -ResourceGroupName Default-ServiceBus-WestUS -Name SB-Example1 -Location WestUS2 -SkuName "Premium" -Tag @{Tag1="Tag1Value"} -ZoneRedundant -DisableLocalAuth
```

```output
Name               : SB-Example1
Id                 : /subscriptions/{SubscriptionId}/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.ServiceBus/namespaces/SB-Example1
ResourceGroupName  : Default-ServiceBus-WestUS
Location           : West US
Tags               : {TesttingTags, TestingTagValue, TestTag, TestTagValue}
Sku                : Name : Premium , Tier : Premium
ProvisioningState  : Succeeded
CreatedAt          : 9/27/2021 2:07:33 AM
UpdatedAt          : 9/27/2021 2:07:56 AM
ServiceBusEndpoint : https://SB-Example1.servicebus.windows.net:443/
```

Creates a new Service Bus namespace within the specified resource group.

### Example 3 - Create namespace with user assigned identity encryption enabled
```powershell
$config1 = New-AzServiceBusEncryptionConfig -KeyName key1 -KeyVaultUri https://myvaultname.vault.azure.net -UserAssignedIdentity '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName'

$config2 = New-AzServiceBusEncryptionConfig -KeyName key2 -KeyVaultUri https://myvaultname.vault.azure.net -UserAssignedIdentity '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName'

$id1 = '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName'

$id2 = '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName2'

New-AzServiceBusNamespace -ResourceGroupName Default-ServiceBus-WestUS -Name SB-Example1 -Location WestUS2 -SkuName "Premium" -IdentityType UserAssigned -IdentityId $id1,$id2 -EncryptionConfig $config1,$config2
```

```output
Name               : SB-Example1
Id                 : /subscriptions/{subscriptionId}/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.ServiceBus/namespaces/SB-Example1
ResourceGroupName  : Default-ServiceBus-WestUS
Location           : WestUS2
Sku                : Name : Premium , Tier : Premium, Capacity : 1
Tags               :
ProvisioningState  : Succeeded
CreatedAt          : 1/4/2022 7:36:35 AM
UpdatedAt          : 2/5/2022 6:44:14 AM
ServiceBusEndpoint : https://SB-Example1.servicebus.windows.net:443/
ZoneRedundant      : False
DisableLocalAuth   : False
Identity           : PrinicipalId : , TenantId:
IdentityType       : UserAssigned
IdentityId         : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName,
                     /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName2
EncryptionConfigs  : {{ KeyName: key1,
                     KeyVaultUri: https://myvaultname.vault.azure.net,
                     KeyVersion: ,
                     UserAssignedIdentity: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName
                     },
                     {
                     KeyName: key2,
                     KeyVaultUri: https://myvaultname.vault.azure.net,
                     KeyVersion: ,
                     UserAssignedIdentity: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName2
                     }}
```

Creates a new Service Bus namespace with UserAssigned Encryption Enabled. IdentityType can take values "SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None"

### Example 4 - Create namespace with system assigned identity enabled.
```powershell
New-AzServiceBusNamespace -ResourceGroupName Default-ServiceBus-WestUS -Name SB-Example1 -Location WestUS2 -SkuName "Premium" -IdentityType SystemAssigned
```

```output
Name               : SB-Example1
Id                 : /subscriptions/{subscriptionId}/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.ServiceBus/namespaces/SB-Example1
ResourceGroupName  : Default-ServiceBus-WestUS
Location           : WestUS2
Sku                : Name : Premium , Tier : Premium, Capacity : 1
Tags               :
ProvisioningState  : Succeeded
CreatedAt          : 1/4/2022 7:36:35 AM
UpdatedAt          : 2/5/2022 6:44:14 AM
ServiceBusEndpoint : https://SB-Example1.servicebus.windows.net:443/
ZoneRedundant      : False
DisableLocalAuth   : False
Identity           : PrinicipalId : 000000000, TenantId: 00000000
IdentityType       : SystemAssigned
IdentityId         :
EncryptionConfigs  :
```

Creates a new Service Bus namespace with SystemAssigned identity enabled. IdentityType can take values "SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None"

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableLocalAuth
enabling or disabling SAS authentication for the Service Bus namespace

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EncryptionConfig
Key Property

```yaml
Type: Microsoft.Azure.Commands.ServiceBus.Models.PSEncryptionConfigAttributes[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityId
List of user assigned Identity Ids

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityType
Identity Type

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: SystemAssigned, UserAssigned, SystemAssigned, UserAssigned, None

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
ServiceBus Namespace Location

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
ServiceBus Namespace Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuCapacity
The Service Bus premium namespace throughput units, allowed values 1 or 2 or 4

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuName
Namespace Sku Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Basic, Standard, Premium

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtables which represents resource Tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ZoneRedundant
enabling or disabling Zone Redundant for namespace

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]

### System.Collections.Hashtable

### System.Management.Automation.SwitchParameter

### System.String[]

### Microsoft.Azure.Commands.ServiceBus.Models.PSEncryptionConfigAttributes[]

## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes

## NOTES

## RELATED LINKS
