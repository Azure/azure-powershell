$vaultName = 'AzKV'
$secretName = 'test'

# Add an unknown type Secret $secretName via portal

Describe "Get unknown type secret" {
    It "should write secrets in plain text if -AsPlainText" {
        $secret = Get-SecretInfo -Vault $vaultName -Name $secretName
        $secret.Type | Should -Be "Unknown"
    }
}