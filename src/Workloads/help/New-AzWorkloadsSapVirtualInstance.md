---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/new-azworkloadssapvirtualinstance
schema: 2.0.0
---

# New-AzWorkloadsSapVirtualInstance

## SYNOPSIS
Creates a Virtual Instance for SAP solutions (VIS) resource

## SYNTAX

### CreateWithDiscovery (Default)
```
New-AzWorkloadsSapVirtualInstance -Name <String> -ResourceGroupName <String> -CentralServerVmId <String>
 -Environment <SapEnvironmentType> -Location <String> -SapProduct <SapProductType> [-SubscriptionId <String>]
 [-IdentityType <ManagedServiceIdentityType>] [-ManagedResourceGroupName <String>]
 [-ManagedRgStorageAccountName <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithJsonTemplatePath
```
New-AzWorkloadsSapVirtualInstance -Name <String> -ResourceGroupName <String> -Configuration <String>
 -Environment <SapEnvironmentType> -Location <String> -SapProduct <SapProductType> [-SubscriptionId <String>]
 [-IdentityType <ManagedServiceIdentityType>] [-ManagedResourceGroupName <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a Virtual Instance for SAP solutions (VIS) resource

## EXAMPLES

### Example 1: Deploy infrastructure for a three-tier distributed SAP system using Virtual Instances for SAP solutions 
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L46 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -Configuration .\CreatePayload.json -Tag @{k1 = "v1"; k2 = "v2"} -IdentityType 'UserAssigned' -ManagedResourceGroupName "L46-rg" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                       Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                       ------ --------
L46  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     SoftwareInstallationPending        eastus
```

In this example, you Deploy the infrastructure for a three tier distributed SAP system.
A sample json payload is a linked here: https://go.microsoft.com/fwlink/?linkid=2230236

### Example 2: Install SAP software on the infrastructure deployed for the three-tier distributed SAP system using Virtual Instances for SAP solutions
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L46 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -Configuration .\InstallPayload.json -Tag @{k1 = "v1"; k2 = "v2"} -IdentityType 'UserAssigned' -ManagedResourceGroupName "L46-rg" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                ------ --------
L46  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     RegistrationComplete        eastus
```

In this example, you Install the SAP software on  the deployed infrastructure for a three tier Non-High Availability distributed SAP system.
A sample json payload is a linked here:https://go.microsoft.com/fwlink/?linkid=2230167

### Example 3: Deploy infrastructure for a three-tier distributed Highly Available (HA) SAP system using Virtual Instances for SAP solutions 
```powershell
 New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name SK1 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -Configuration .\CreatePayloadHACustomNames.json -IdentityType 'UserAssigned' -ManagedResourceGroupName "acss-mrg1" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                       Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                       ------ --------
SK1  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     SoftwareInstallationPending        eastus
```

In this example, you Deploy the infrastructure for a three tier distributed Highly Available (HA)  SAP system.
A sample json payload to use in this command is linked here: https://go.microsoft.com/fwlink/?linkid=2230402

### Example 4: Install SAP software on the infrastructure deployed for the three-tier distributed Highly Available (HA) SAP system using Virtual Instances for SAP solutions
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name SK1 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -Configuration .\CreatePayloadHACustomNamesInstall.json -IdentityType 'UserAssigned' -ManagedResourceGroupName "acss-mrg1" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                ------ --------
SK1  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     RegistrationComplete        eastus
```

In this example, you Install the SAP software on  the deployed infrastructure for a three tier distributed Highly Availabile SAP system with Transport directory and customized resource naming.
A sample json payload to use in this command is linked here: https://go.microsoft.com/fwlink/?linkid=2230340

### Example 5: Register an existing SAP system as a VIS
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'TestRG' -Name L46 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -CentralServerVmId '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/powershell-cli-testrg/providers/microsoft.compute/virtualmachines/l46ascsvm' -Tag @{k1 = "v1"; k2 = "v2"} -ManagedResourceGroupName "L46-rg" -ManagedRgStorageAccountName 'acssstoragel46' -IdentityType 'UserAssigned' -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                ------ --------
L46  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     RegistrationComplete        eastus
```

Use the New-AzWorkloadsSapVirtualInstance cmdlet with the suggested input parameters to register an existing SAP system as a Virtual Instance for SAP solutions resource.

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

### -CentralServerVmId
The virtual machine ID of the Central Server

```yaml
Type: System.String
Parameter Sets: CreateWithDiscovery
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Configuration
Configuration json path.

```yaml
Type: System.String
Parameter Sets: CreateWithJsonTemplatePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Environment
Defines the environment type - Production/Non Production.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapEnvironmentType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of manage identity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
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

### -ManagedResourceGroupName
Managed resource group name

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

### -ManagedRgStorageAccountName
The custom storage account name for the storage account created by the service in the managed resource group created as part of VIS deployment.

Refer to the storage account naming rules [here](https://learn.microsoft.com/azure/azure-resource-manager/management/resource-name-rules#microsoftstorage).

If not provided, the service will create the storage account with a random name

```yaml
Type: System.String
Parameter Sets: CreateWithDiscovery
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Virtual Instances for SAP solutions resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SapVirtualInstanceName

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

### -SapProduct
Defines the SAP Product type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapProductType
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
User assigned identities dictionary

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapVirtualInstance

## NOTES

ALIASES

## RELATED LINKS

