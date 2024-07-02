### Example 1: Deploy infrastructure for a three-tier distributed SAP system using Virtual Instances for SAP solutions 
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L46 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -Configuration .\CreatePayload.json -Tag @{k1 = "v1"; k2 = "v2"} -IdentityType 'UserAssigned' -ManagedResourceGroupName "L46-rg" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                       Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                       ------ --------
L46  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     SoftwareInstallationPending        eastus
```

In this example, you Deploy the infrastructure for a three tier distributed SAP system. A sample json payload is a linked here: https://go.microsoft.com/fwlink/?linkid=2230236

### Example 2: Install SAP software on the infrastructure deployed for the three-tier distributed SAP system using Virtual Instances for SAP solutions
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name L46 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -Configuration .\InstallPayload.json -Tag @{k1 = "v1"; k2 = "v2"} -IdentityType 'UserAssigned' -ManagedResourceGroupName "L46-rg" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                ------ --------
L46  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     RegistrationComplete        eastus
```

In this example, you Install the SAP software on  the deployed infrastructure for a three tier Non-High Availability distributed SAP system. A sample json payload is a linked here:https://go.microsoft.com/fwlink/?linkid=2230167

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

### Example 5: Register an existing SAP system as a VIS
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'TestRG' -Name L46 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -CentralServerVmId '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/powershell-cli-testrg/providers/microsoft.compute/virtualmachines/l46ascsvm' -Tag @{k1 = "v1"; k2 = "v2"} -IdentityType 'UserAssigned' -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                ------ --------
L46  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     RegistrationComplete        eastus
```

Use the New-AzWorkloadsSapVirtualInstance cmdlet with the suggested input parameters to register an existing SAP system as a Virtual Instance for SAP solutions resource.

### Example 6: Register an existing SAP system as a Virtual Instance for SAP solutions resource (VIS) with a custom Managed Resource Group and Managed Storage Account Name, and Managed Storage Account Network Access Type setting.
```powershell
New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'TestRG' -Name L46 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -CentralServerVmId '/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/powershell-cli-testrg/providers/microsoft.compute/virtualmachines/l46ascsvm' -Tag @{k1 = "v1"; k2 = "v2"} -ManagedResourceGroupName "L46-rg" -ManagedRgStorageAccountName 'acssstoragel46' -ManagedResourcesNetworkAccessType 'Private' -IdentityType 'UserAssigned' -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                ------ --------
L46  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     RegistrationComplete        eastus
```

Use the New-AzWorkloadsSapVirtualInstance cmdlet with the suggested input parameters to register an existing SAP system as a Virtual Instance for SAP solutions resource with a custom Managed Resource Group and Managed Storage Account Name, and specify the Managed Storage Account Network Access Type setting as per your security requirements. Learn More: https://go.microsoft.com/fwlink/?linkid=2256933

### Example 7: Deploy infrastructure for a three-tier distributed Highly Available (HA) SAP system with Azure Compute Gallary Image 
```powershell
 New-AzWorkloadsSapVirtualInstance -ResourceGroupName 'PowerShell-CLI-TestRG' -Name SK1 -Location eastus -Environment 'NonProd' -SapProduct 'S4HANA' -Configuration .\CreatePayloadHACustomNames.json -IdentityType 'UserAssigned' -ManagedResourceGroupName "acss-mrg1" -UserAssignedIdentity @{'/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourcegroups/SAP-E2ETest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/E2E-RBAC-MSI'= @{}}
```

```output
Name ResourceGroupName     Health Environment ProvisioningState SapProduct State                       Status Location
---- -----------------     ------ ----------- ----------------- ---------- -----                       ------ --------
SK1  PowerShell-CLI-TestRG        NonProd     Succeeded         S4HANA     SoftwareInstallationPending        eastus
```

In this example, you Deploy infrastructure for a three-tier distributed Highly Available (HA) SAP system with Azure Compute Gallary Image. See sample json payload here: https://go.microsoft.com/fwlink/?linkid=2263420