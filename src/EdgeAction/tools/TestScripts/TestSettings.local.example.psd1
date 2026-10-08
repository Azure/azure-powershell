@{
    # Brazilus overrides for the shared AzureCloud defaults.
    # Copy this file to the ignored TestSettings.local.psd1; edit only that copy.
    # Leave empty for playback. For Record/Live, set an authorized subscription
    # GUID in the local copy or pass -SubscriptionId to the runner.
    SubscriptionId = ''
    EnvironmentName = 'Brazilus'
    ResourceManagerUrl = 'https://brazilus.management.azure.com/'
    Audience = 'https://management.core.windows.net/'
    # Existing scenarios hardcode this group; overrides are not supported.
    ResourceGroupName = 'powershelltests'
    ApiVersion = '2026-10-01'
    # Optional absolute path to an installed Pester 4.10.1 manifest.
    PesterPath = ''
}
