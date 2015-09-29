using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class PSStorageService : StorageServicePropertiesOperationContext, IStorageContextProvider
    {
        private AzureStorageContext _context;
        public AzureStorageContext Context
        {
            get { return _context; }
        }

        public PSStorageService(AzureStorageContext context)
        {
            _context = context;
        }

        protected PSStorageService(StorageServicePropertiesOperationContext account, AzureStorageContext context)
            : this(context)
        {
            this.AccountType = account.AccountType;
            this.AffinityGroup = account.AffinityGroup;
            this.GeoPrimaryLocation = account.GeoPrimaryLocation;
            this.GeoReplicationEnabled = account.GeoReplicationEnabled;
            this.GeoSecondaryLocation = account.GeoSecondaryLocation;
            this.Label = account.Label;
            this.Location = account.Location;
            this.OperationDescription = account.OperationDescription;
            this.OperationId = account.OperationId;
            this.OperationStatus = account.OperationStatus;
            this.StatusOfPrimary = account.StatusOfPrimary;
            this.StatusOfSecondary = account.StatusOfSecondary;
            this.StorageAccountName = account.StorageAccountName;
            this.StorageAccountDescription = account.StorageAccountDescription;
            this.StorageAccountStatus = account.StorageAccountStatus;
            var endpointList = new List<string>();
            foreach (var endpoint in account.Endpoints)
            {
                endpointList.Add(endpoint);
            }

            this.Endpoints = endpointList;
        }

        public static PSStorageService Create(StorageManagementClient client,
            StorageServicePropertiesOperationContext account)
        {
            var cloudStorageAccount = StorageUtilities.GenerateCloudStorageAccount(client, account.StorageAccountName);
            return new PSStorageService(account, new AzureStorageContext(cloudStorageAccount));
        }
    }
}
 