$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzProviderHubNotificationRegistration-CRUD.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzProviderHubNotificationRegistration-CRUD' {
    It 'Create and get a NotificationRegistration' {
        $notificationEndpoint = @{Location = "", "East US"; NotificationDestination = "/subscriptions/ac6bcfb5-3dc1-491f-95a6-646b89bf3e88/resourceGroups/mgmtexp-eastus/providers/Microsoft.EventHub/namespaces/unitedstates-mgmtexpint/eventhubs/armlinkednotifications"}

        $notificationRegistration = New-AzProviderHubNotificationRegistration -ProviderNamespace $env.ProviderNamespace -Name "employeesNotificationRegistration" -NotificationMode "EventHub" -MessageScope "RegisteredSubscriptions" -IncludedEvent "*/write", "Microsoft.Contoso/employees/delete" -NotificationEndpoint $notificationEndpoint
        $notificationRegistration | Should -Not -BeNullOrEmpty

        $notificationRegistration = Get-AzProviderHubNotificationRegistration -ProviderNamespace $env.ProviderNamespace -Name "employeesNotificationRegistration"
        $notificationRegistration | Should -Not -BeNullOrEmpty

        $notificationRegistration = Remove-AzProviderHubNotificationRegistration -ProviderNamespace $env.ProviderNamespace -Name "employeesNotificationRegistration"
        $notificationRegistration | Should -BeNullOrEmpty

        $notificationRegistration = New-AzProviderHubNotificationRegistration -ProviderNamespace $env.ProviderNamespace -Name "employeesNotificationRegistration" -NotificationMode "EventHub" -MessageScope "RegisteredSubscriptions" -IncludedEvent "*/write", "Microsoft.Contoso/employees/delete" -NotificationEndpoint $notificationEndpoint
        $notificationRegistration | Should -Not -BeNullOrEmpty
    }
}
