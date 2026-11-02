@{
    # Shared Azure public-cloud defaults; the runner defaults to playback.
    # Copy TestSettings.local.example.psd1 to TestSettings.local.psd1 for Brazilus overrides.
    # No subscription, tenant, credentials, or tokens belong in these shareable defaults.
    SubscriptionId = ''
    EnvironmentName = 'AzureCloud'
    ResourceManagerUrl = 'https://management.azure.com/'
    Audience = 'https://management.core.windows.net/'
    # Compatibility only: old local overrides are accepted with a warning, not used.
    ResourceGroupName = ''
    ApiVersion = '2026-10-01'
    # Optional absolute path to an installed Pester 4.10.1 manifest.
    PesterPath = ''
}
