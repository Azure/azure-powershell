using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.HDInsight.Models
{
    public class AzureHDInsightDataLakeDefaultStorageAccount : AzureHDInsightDefaultStorageAccount
    {
        public AzureHDInsightDataLakeDefaultStorageAccount(string storageAccountName,
            string applicationId, string tenantId,
            byte[] certificateContents, string certificatePassword, string resourceUri,
            string storageRootPath)
            : base(storageAccountName)
        {
            ApplicationId = applicationId;
            TenantId = tenantId;
            CertificateContents = certificateContents;
            CertificatePassword = certificatePassword;
            ResourceUri = resourceUri;
            StorageRootPath = storageRootPath;
        }

        public string ApplicationId { get; private set; }
        public string TenantId { get; private set; }
        public byte[] CertificateContents { get; private set; }
        public string CertificatePassword { get; private set; }
        public string ResourceUri { get; private set; }
        public string StorageRootPath { get; private set; }
    }
}
