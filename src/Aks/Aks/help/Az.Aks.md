---
Module Name: Az.Aks
Module Guid: a97e0c3e-e389-46a6-b73d-2b9bd6909bdb
Download Help Link: https://docs.microsoft.com/powershell/module/az.aks
Help Version: 0.0.1.0
Locale: en-US
---

# Az.Aks Module
## Description
Commands to interact with Azure managed Kubernetes clusters.

## Az.Aks Cmdlets
### [Disable-AzAksAddOn](Disable-AzAksAddOn.md)
Disable the addons for aks.

### [Enable-AzAksAddOn](Enable-AzAksAddOn.md)
Enable the addons for aks.

### [Get-AzAksCluster](Get-AzAksCluster.md)
List Kubernetes managed clusters.

### [Get-AzAksNodePool](Get-AzAksNodePool.md)
List node pools in specified cluster.

### [Get-AzAksNodePoolUpgradeProfile](Get-AzAksNodePoolUpgradeProfile.md)
Gets the details of the upgrade profile for an agent pool with a specified resource group and managed cluster name.

### [Get-AzAksUpgradeProfile](Get-AzAksUpgradeProfile.md)
Gets the details of the upgrade profile for a managed cluster with a specified resource group and name.

### [Get-AzAksVersion](Get-AzAksVersion.md)
List available version for creating managed Kubernetes cluster.
The operation returns properties of each orchestrator including version, available upgrades and whether that version or upgrades are in preview.

### [Import-AzAksCredential](Import-AzAksCredential.md)
Import and merge Kubectl config for a managed Kubernetes Cluster.

### [Install-AzAksKubectl](Install-AzAksKubectl.md)
Download and install kubectl, the Kubernetes command-line tool.

### [Invoke-AzAksRunCommand](Invoke-AzAksRunCommand.md)
Run a shell command (with kubectl, helm) on your aks cluster, support attaching files as well.

### [New-AzAksCluster](New-AzAksCluster.md)
Create a new managed Kubernetes cluster.

The cmdlet may call below Microsoft Graph API according to input parameters:

- POST /servicePrincipals

### [New-AzAksNodePool](New-AzAksNodePool.md)
Create a new node pool in specified cluster.

### [Remove-AzAksCluster](Remove-AzAksCluster.md)
Delete a managed Kubernetes cluster.

### [Remove-AzAksNodePool](Remove-AzAksNodePool.md)
Delete node pool from managed cluster.

### [Set-AzAksCluster](Set-AzAksCluster.md)
Update or create a managed Kubernetes cluster.

### [Set-AzAksClusterCredential](Set-AzAksClusterCredential.md)
Reset the ServicePrincipal of an existing AKS cluster.

### [Start-AzAksCluster](Start-AzAksCluster.md)
Starts a Stopped Managed Cluster

### [Start-AzAksDashboard](Start-AzAksDashboard.md)
Create a Kubectl SSH tunnel to the managed cluster's dashboard.

### [Stop-AzAksCluster](Stop-AzAksCluster.md)
Stops a Running Managed Cluster

### [Stop-AzAksDashboard](Stop-AzAksDashboard.md)
Stop the Kubectl SSH tunnel created in Start-AzKubernetesDashboard.

### [Update-AzAksNodePool](Update-AzAksNodePool.md)
Update node pool in a managed cluster.

