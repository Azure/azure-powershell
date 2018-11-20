using Microsoft.Azure.Commands.StorageSync.InternalObjects;
using System;

namespace Commands.StorageSync.Interop.DataObjects
{
    public class ServerRegistrationData
    {
        public string Id { get; set; }

        public byte[] ServerCertificate { get; set; }

        public string AgentVersion { get; set; }

        public string ServerOSVersion { get; set; }

        public ServerRoleType ServerRole { get; set; }

        public Guid? ClusterId { get; set; }

        public string ClusterName { get; set; }

        public Guid ServerId { get; set; }
    }
}
