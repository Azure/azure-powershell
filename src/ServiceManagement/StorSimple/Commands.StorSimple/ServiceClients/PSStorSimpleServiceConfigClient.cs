
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class PSStorSimpleClient
    {
        public JobStatusInfo ConfigureService(ServiceConfiguration serviceConfig)
        {
            return GetStorSimpleClient().ServiceConfig.Create(serviceConfig, GetCustomRequestHeaders());
        }

        public JobResponse ConfigureServiceAsync(ServiceConfiguration serviceConfig)
        {
            return GetStorSimpleClient().ServiceConfig.BeginCreating(serviceConfig, GetCustomRequestHeaders());
        }

        public IList<AccessControlRecord> GetAllAccessControlRecords()
        {
            var sc = GetStorSimpleClient().ServiceConfig.Get(GetCustomRequestHeaders());
            if (sc == null || sc.AcrChangeList == null)
            {
                return null;
            }
            return sc.AcrChangeList.Updated;
        }

        public IList<StorageAccountCredentialResponse> GetAllStorageAccountCredentials()
        {
            var sc = GetStorSimpleClient().ServiceConfig.Get(GetCustomRequestHeaders());
            if (sc == null || sc.CredentialChangeList == null)
            {
                return null;
            }
            return sc.CredentialChangeList.Updated;
        }
    }
}
