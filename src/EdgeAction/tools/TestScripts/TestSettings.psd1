@{
    # Shared Azure public-cloud defaults; the runner defaults to playback.
    # Copy TestSettings.local.example.psd1 to TestSettings.local.psd1 for Brazilus overrides.
    # No subscription, tenant, credentials, or tokens belong in the tracked defaults.
    SubscriptionId = ''
    EnvironmentName = 'AzureCloud'
    ResourceManagerUrl = 'https://management.azure.com/'
    Audience = 'https://management.core.windows.net/'
    ResourceGroupName = 'powershelltests'
    ApiVersion = '2026-10-01'
    # Optional absolute path to an installed Pester 4.10.1 manifest.
    PesterPath = ''
}
