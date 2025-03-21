using Commands.StorageSync.Interop.Interfaces;
using Microsoft.Azure.Commands.StorageSync.Interop.Enums;
using Microsoft.Azure.Commands.StorageSync.Interop.ManagedIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.StorageSync.Test.Common
{
    internal class MockServerManagedIdentityProvider : IServerManagedIdentityProvider
    {
        /// <summary>
        /// Gets the name of the test.
        /// </summary>
        /// <value>The name of the test.</value>
        protected string TestName;

        public MockServerManagedIdentityProvider(string testName)
        {
            this.TestName = testName;
        }

        public bool EnableMIChecking { get; set; }

        public Guid GetServerApplicationId(LocalServerType serverType, bool throwIfNotFound = true, bool validateSystemAssignedManagedIdentity = true)
        {
            return Guid.Empty;
        }

        public LocalServerType GetServerType(IEcsManagement ecsManagement)
        {
            if(TestName == "TestPatchRegisteredServer")
            {
                return LocalServerType.ArcEnabledHybridServer;
            }
            return LocalServerType.HybridServer;
        }
    }
}
