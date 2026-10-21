# Offline unit tests for the C1 helper custom/KubeConfigHelper.cs.
# Pure YAML string -> string transforms: no Azure, no HTTP, no recording. The module must be imported (the
# harness does this) so the compiled type (and its YamlDotNet dependency) is available.

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
    }
}
