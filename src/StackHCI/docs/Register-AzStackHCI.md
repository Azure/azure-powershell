---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/register-azstackhci
schema: 2.0.0
---

# Register-AzStackHCI

## SYNOPSIS
Register-AzStackHCI creates a Microsoft.AzureStackHCI cloud resource representing the on-premises cluster and registers the on-premises cluster with Azure.

## SYNTAX

```
Register-AzStackHCI [-SubscriptionId] <String> [-Region] <String> [[-ResourceName] <String>]
 [[-Tag] <Hashtable>] [[-TenantId] <String>] [[-ResourceGroupName] <String>] [[-ArmAccessToken] <String>]
 [[-AccountId] <String>] [[-EnvironmentName] <String>] [[-ComputerName] <String>]
 [[-CertificateThumbprint] <String>] [[-Credential] <PSCredential>] [[-ArcServerResourceGroupName] <String>]
 [[-ArcSpnCredential] <PSCredential>] [-IsWAC] [-RepairRegistration] [-UseDeviceAuthentication] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Register-AzStackHCI creates a Microsoft.AzureStackHCI cloud resource representing the on-premises cluster and registers the on-premises cluster with Azure.

## EXAMPLES

### Example 1:
```powershell
Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -Region "eastus"
```

```output
Result: Success
ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster1-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster1
PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster1-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster1/overview
PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/980be58d-578c-4cff-b4cd-43e9c3a77826/isMSAApp/
```

Invoking on one of the cluster node.

### Example 2: 
```powershell
Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ComputerName ClusterNode1 -Region "eastus"
```

```output
Result: Success
ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster2-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster2
PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCICluster2-rg/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster2/overview
PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/950be58d-578c-4cff-b4cd-43e9c3a77866/isMSAApp/
```

Invoking from the management node.

### Example 3: 
```powershell
Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -ArmAccessToken etyer..ere= -AccountId user1@corp1.com -Region westus -ResourceName DemoHCICluster3 -ResourceGroupName DemoHCIRG 
```

```output
Result: PendingForAdminConsent
ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCIRG/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster3
PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/DemoHCIRG/providers/Microsoft.AzureStackHCI/clusters/DemoHCICluster3/overview
PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/980be58d-578c-4cff-b4cd-43e9c3a77866/isMSAApp/
```

Invoking from WAC.

### Example 4: 
```powershell
Register-AzStackHCI -SubscriptionId "12a0f531-56cb-4340-9501-257726d741fd" -Region westus -ResourceName HciCluster1 -TenantId "c31c0dbb-ce27-4c78-ad26-a5f717c14557" -ResourceGroupName HciRG -ArcServerResourceGroupName HciRG -ArmAccessToken eerrer..ere= -AccountId user1@corp1.com -EnvironmentName AzureCloud -ComputerName node1hci -Credential Get-Credential
```

```output
Result: Success
ResourceId: /subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/HciRG/providers/Microsoft.AzureStackHCI/clusters/HciCluster1
PortalResourceURL: https://portal.azure.com/#@c31c0dbb-ce27-4c78-ad26-a5f717c14557/resource/subscriptions/12a0f531-56cb-4340-9501-257726d741fd/resourceGroups/HciRG/providers/Microsoft.AzureStackHCI/clusters/HciCluster1/overview
PortalAADAppPermissionsURL: https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/CallAnAPI/appId/990be58d-578c-4cff-b4cd-43e9c3a77866/isMSAApp/
```

Invoking with all the parameters.

## PARAMETERS

### -AccountId
Specifies the Account Id.
Specifying this along with ArmAccessToken will avoid Azure interactive logon.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArcServerResourceGroupName
Specifies the Arc Resource Group name.
If not specified, cluster resource group name will be used.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 12
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArcSpnCredential
Specifies the credentials to be used for onboarding ARC agent.
If not specified, new set of credentials will be generated.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: 13
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ArmAccessToken
Specifies the ARM access token.
Specifying this along with AccountId will avoid Azure interactive logon.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateThumbprint
Specifies the thumbprint of the certificate available on all the nodes.
User is responsible for managing the certificate.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputerName
Specifies the cluster name or one of the cluster node in on-premise cluster that is being registered to Azure.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Specifies the credential for the ComputerName.
Default is the current user executing the Cmdlet.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: 11
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
Specifies the Azure Environment.
Default is AzureCloud.
Valid values are AzureCloud, AzureChinaCloud, AzurePPE, AzureCanary, AzureUSGovernment

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsWAC
Registrations through Windows Admin Center specifies this parameter to true.

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

### -Region
Specifies the Region to create the resource.
Region is a Mandatory parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RepairRegistration
Repair the current Azure Stack HCI registration with the cloud.
This cmdlet deletes the local certificates on the clustered nodes and the remote certificates in the Azure AD application in the cloud and generates new replacement certificates for both.
The resource group, resource name, and other registration choices are preserved.

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
Specifies the Azure Resource Group name.
If not specified \<LocalClusterName\>-rg will be used as resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
Specifies the resource name of the resource created in Azure.
If not specified, on-premises cluster name is used.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Specifies the Azure Subscription to create the resource.
SubscriptionId is a Mandatory parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Specifies the resource tags for the resource in Azure in the form of key-value pairs in a hash table.
For example: @{key0="value0";key1=$null;key2="value2"}

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TenantId
Specifies the Azure TenantId.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseDeviceAuthentication
Use device code authentication instead of an interactive browser prompt.

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

### PSCustomObject. Returns following Properties in PSCustomObject
Result: Success or Failed or Cancelled.
ResourceId: Resource ID of the resource created in Azure.
PortalResourceURL: Azure Portal Resource URL.

## NOTES

ALIASES

## RELATED LINKS

