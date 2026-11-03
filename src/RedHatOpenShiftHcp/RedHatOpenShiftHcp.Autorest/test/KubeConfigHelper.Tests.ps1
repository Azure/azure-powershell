# Offline unit tests for the C1 helper custom/KubeConfigHelper.cs.
# Pure YAML string -> string transforms: no Azure, no HTTP, no recording. The module must be imported (the
# harness does this) so the compiled type is available. The helper is BCL-only (no YAML package): it parses
# only the regular content it produces and block-splices into the user's existing config without re-serializing
# it, so these tests also guard that existing content (including exec auth-plugins) is preserved verbatim.

Describe 'KubeConfigHelper' {
    BeforeAll {
        $kh = [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom.KubeConfigHelper]

        # A minimal single cluster/user/context kubeconfig, shaped like what the RP returns (a file-path
        # client-key that PrepareKubeconfig must replace with embedded client-key-data).
        $returned = @'
apiVersion: v1
kind: Config
clusters:
- cluster:
    server: https://api.hcp.example.com:6443
    certificate-authority-data: Y2FkYXRh
  name: cluster
users:
- name: admin
  user:
    client-key: /tmp/placeholder/client.key
    client-certificate-data: Y2VydGRhdGE=
contexts:
- context:
    cluster: cluster
    user: admin
  name: default
current-context: default
'@

        $pem     = "-----BEGIN PRIVATE KEY-----`nMIIBVgIBADANB`n-----END PRIVATE KEY-----"
        $keyData = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes($pem))

        # An existing kubeconfig the admin credential gets merged into.
        $existing = @'
apiVersion: v1
kind: Config
clusters:
- cluster:
    server: https://other.example.com:6443
  name: other-cluster
users:
- name: other-user
  user:
    token: sometoken
contexts:
- context:
    cluster: other-cluster
    user: other-user
  name: other
current-context: other
'@
    }

    Context 'PrepareKubeconfig' {
        It 'embeds the private key as client-key-data and drops the file-path client-key' {
            $out = $kh::PrepareKubeconfig($returned, $pem, 'my-cluster')
            $out | Should -Match 'client-key-data'
            $out | Should -Match ([regex]::Escape($keyData))
            $out | Should -Not -Match '/tmp/placeholder/client.key'
        }

        It 'renames cluster/user/context and sets current-context to the given name' {
            $out = $kh::PrepareKubeconfig($returned, $pem, 'my-cluster')
            $out | Should -Match 'current-context: my-cluster'
            # the three sections are all renamed to the stable name
            @([regex]::Matches($out, 'name: my-cluster')).Count | Should -Be 3
        }

        It 'throws on empty kubeconfig input' {
            { $kh::PrepareKubeconfig('', $pem, 'my-cluster') } | Should -Throw 'empty'
        }
    }

    Context 'MergeKubeConfig' {
        It 'adds the new context while preserving existing entries, and adopts the new current-context' {
            $prepared = $kh::PrepareKubeconfig($returned, $pem, 'my-cluster')
            $merged   = $kh::MergeKubeConfig($existing, $prepared)
            $merged | Should -Match 'name: other'          # existing context preserved
            $merged | Should -Match 'name: my-cluster'     # new context added
            $merged | Should -Match 'current-context: my-cluster'
        }

        It 'lets additions win on a name collision' {
            # Prepare two configs that share the name 'dup'; the second (addition) should win.
            $a = $kh::PrepareKubeconfig($returned, $pem, 'dup')
            $b = $kh::PrepareKubeconfig(($returned -replace 'api.hcp.example.com', 'api.v2.example.com'), $pem, 'dup')
            $merged = $kh::MergeKubeConfig($a, $b)
            # only one 'dup' cluster entry survives, and it is the addition's server
            @([regex]::Matches($merged, 'name: dup')).Count | Should -Be 3   # 1 cluster + 1 user + 1 context
            $merged | Should -Match 'api.v2.example.com'
            $merged | Should -Not -Match 'api.hcp.example.com'
        }

        It 'preserves an existing exec auth-plugin (nested "- name:" is not treated as an item name)' {
            # A user entry whose exec plugin carries an env list with its own "- name:" lines. A naive
            # "find name:" / "split on '- '" merge would mangle these; the block-splice must leave them intact.
            $withExec = @'
apiVersion: v1
kind: Config
clusters:
- cluster:
    server: https://aks.example.com:443
  name: aks
users:
- name: aks-user
  user:
    exec:
      apiVersion: client.authentication.k8s.io/v1beta1
      command: kubelogin
      args:
      - get-token
      - --server-id
      env:
      - name: AAD_LOGIN_METHOD
        value: devicecode
      - name: KUBECACHEDIR
        value: /tmp/kubecache
contexts:
- context:
    cluster: aks
    user: aks-user
  name: aks
current-context: aks
'@
            $prepared = $kh::PrepareKubeconfig($returned, $pem, 'my-cluster')
            $merged   = $kh::MergeKubeConfig($withExec, $prepared)
            # existing exec plugin survives byte-for-byte
            $merged | Should -Match 'command: kubelogin'
            $merged | Should -Match 'name: AAD_LOGIN_METHOD'
            $merged | Should -Match 'name: KUBECACHEDIR'
            $merged | Should -Match 'devicecode'
            # existing aks user/cluster preserved and new one added
            $merged | Should -Match 'name: aks-user'
            $merged | Should -Match 'name: my-cluster'
            $merged | Should -Match 'current-context: my-cluster'
        }

        It 'appends a section that is absent from the existing kubeconfig' {
            # An existing config missing the 'contexts' section entirely; merge must add it.
            $noContexts = @'
apiVersion: v1
kind: Config
clusters:
- cluster:
    server: https://other.example.com:6443
  name: other-cluster
users:
- name: other-user
  user:
    token: sometoken
current-context: ""
'@
            $prepared = $kh::PrepareKubeconfig($returned, $pem, 'my-cluster')
            $merged   = $kh::MergeKubeConfig($noContexts, $prepared)
            $merged | Should -Match 'contexts:'
            $merged | Should -Match 'current-context: my-cluster'
            $merged | Should -Match 'name: other-user'   # existing content preserved
        }
    }
}
