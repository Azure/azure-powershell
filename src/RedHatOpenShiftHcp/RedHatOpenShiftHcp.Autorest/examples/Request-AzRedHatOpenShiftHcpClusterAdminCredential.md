### Example 1: Request an admin kubeconfig and merge it into ~/.kube/config
```powershell
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster -OutFile ~/.kube/config
```

Requests a temporary admin credential and writes a ready-to-use kubeconfig. The cmdlet generates an RSA-4096 key and CSR locally, sends only the CSR (the private key never leaves the machine), splices the signed key back into the returned kubeconfig, adds a context named `myCluster-admin`, and merges it into `~/.kube/config` (AKS-style) written with `0600` permissions. After this, `kubectl get nodes` works in one shot.

### Example 2: Print the kubeconfig to stdout instead of writing a file
```powershell
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster -OutFile -
```

```output
apiVersion: v1
kind: Config
clusters:
- cluster:
    server: https://api.myCluster.abcd1234.westeurope.aroapp.io:443
  name: myCluster
contexts:
- context:
    cluster: myCluster
    user: myCluster-admin
  name: myCluster-admin
current-context: myCluster-admin
users:
- name: myCluster-admin
  user:
    client-certificate-data: LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0t...
    client-key-data: LS0tLS1CRUdJTiBQUklWQVRFIEtFWS0tLS0t...
```

Passing `-OutFile -` prints the prepared kubeconfig (private key already embedded, context `myCluster-admin`) to stdout instead of writing or merging a file, handy for piping into another tool.
