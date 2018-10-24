using Commands.StorageSync.Interop.Clients;
using Commands.StorageSync.Interop.Interfaces;

namespace Commands.StorageSync.Interop
{
    public static class InteropClientFactory
    {
        public static IEcsManagement CreateEcsManagement()
        {
            return new EcsManagementInteropClient();
        }

        public static ISyncServerRegistration CreateSyncServerRegistrationClient(IEcsManagement ecsManagementClient)
        {
            return new SyncServerRegistrationClient(ecsManagementClient);
        }
    }
}
