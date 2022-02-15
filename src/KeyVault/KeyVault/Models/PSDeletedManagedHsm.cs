using Microsoft.Azure.Management.KeyVault.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSDeletedManagedHsm : PSManagedHsm
    {
        public PSDeletedManagedHsm(DeletedManagedHsm managedHsm)
        {
            Id = managedHsm.Id;
            Name = managedHsm.Name;
            ResourceId = managedHsm.Properties.MhsmId;
            Location = managedHsm.Properties.Location;
            DeletionDate = managedHsm.Properties.DeletionDate;
            ScheduledPurgeDate = managedHsm.Properties.ScheduledPurgeDate;
            EnablePurgeProtection = managedHsm.Properties.PurgeProtectionEnabled;
            Tags = managedHsm.Properties.Tags?.ConvertToHashtable();
        }
        public string Id { get; private set; }

        public DateTime? DeletionDate { get; private set; }

        public DateTime? ScheduledPurgeDate { get; private set; }
    }
}
