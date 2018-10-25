using Commands.StorageSync.Interop.Clients;
using Commands.StorageSync.Interop.Interfaces;

namespace Commands.StorageSync.Interop
{
    public static class InteropClientFactory
    {
        public static IEcsManagement CreateEcsManagement(bool isTestMode)
        {
            return isTestMode ? new MockEcsManagementInteropClient() as IEcsManagement : new EcsManagementInteropClient();
        }

        public static ISyncServerRegistration CreateSyncServerRegistrationClient(IEcsManagement ecsManagementClient)
        {
            return new SyncServerRegistrationClient(ecsManagementClient);
        }
    }
}
