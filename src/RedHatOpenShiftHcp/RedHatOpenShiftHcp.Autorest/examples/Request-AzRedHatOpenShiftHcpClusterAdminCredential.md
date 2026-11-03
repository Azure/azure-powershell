### Example 1: Request an admin kubeconfig as a standalone file
```powershell
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster -OutFile ./myCluster.kubeconfig
```

Requests a temporary admin credential and writes a ready-to-use, standalone kubeconfig. The cmdlet generates an RSA-4096 key and CSR locally, sends only the CSR (the private key never leaves the machine), splices the signed key back into the returned kubeconfig, and adds a context named `myCluster-admin`, written with `0600` permissions. After this, `kubectl --kubeconfig ./myCluster.kubeconfig get nodes` works in one shot. Writing is the default; an existing non-empty target is left untouched unless you pass `-Merge` or `-Force`.

### Example 2: Merge the credential into your existing kubeconfig
```powershell
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster -Merge
```

Passing `-Merge` adds the `myCluster-admin` cluster/user/context into your existing kubeconfig (`$env:KUBECONFIG` or `~/.kube/config`) AKS-style, preserving every other entry, and switches the current context to it. Without `-Merge`, the cmdlet writes a standalone file and refuses to overwrite an existing one.

### Example 3: Print the kubeconfig to stdout instead of writing a file
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
