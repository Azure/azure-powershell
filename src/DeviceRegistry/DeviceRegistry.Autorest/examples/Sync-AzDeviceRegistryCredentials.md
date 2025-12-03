### Example 1: Sync credentials to connected services
```powershell
Sync-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group
```

```output
Status    : Succeeded
Message   : Credentials successfully synchronized to IoT Hub and DPS
Timestamp : 12/2/2024 11:40:15 AM
```

Synchronizes the namespace credentials with connected IoT Hub and Device Provisioning Service (DPS) instances. This operation ensures that the credential certificates are propagated to all connected services for device authentication.

### Example 2: Sync credentials with verbose output
```powershell
Sync-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Verbose
```

```output
VERBOSE: Initiating credential synchronization...
VERBOSE: Syncing to IoT Hub: my-hub.azure-devices.net
VERBOSE: Syncing to DPS: my-dps.azure-devices-provisioning.net
VERBOSE: Synchronization completed successfully
Status    : Succeeded
Message   : Credentials successfully synchronized to IoT Hub and DPS
Timestamp : 12/2/2024 11:42:33 AM
```

Synchronizes credentials with verbose logging to track the synchronization process across connected services.

### Example 3: Sync credentials using pipeline input
```powershell
Get-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group | Sync-AzDeviceRegistryCredentials
```

```output
Status    : Succeeded
Message   : Credentials successfully synchronized to IoT Hub and DPS
Timestamp : 12/2/2024 11:45:08 AM
```

Retrieves credentials and pipes them to the sync operation, synchronizing the credentials to all connected IoT services.
