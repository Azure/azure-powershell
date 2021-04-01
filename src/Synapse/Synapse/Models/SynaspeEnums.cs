using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynaspeEnums
    {
        public enum WorkspaceItemType
        {
            ApacheSparkPool, 
            IntegrationRuntime, 
            LinkedService, 
            Credential
        }
        public static String GetItemTypeString(SynaspeEnums.WorkspaceItemType? itemType)
        {
            string itemTypeString = null;
            switch (itemType)
            {
                case SynaspeEnums.WorkspaceItemType.ApacheSparkPool:
                    itemTypeString = "bigDataPools";
                    break;
                case SynaspeEnums.WorkspaceItemType.IntegrationRuntime:
                    itemTypeString = "integrationRuntimes";
                    break;
                case SynaspeEnums.WorkspaceItemType.LinkedService:
                    itemTypeString = "linkedServices";
                    break;
                case SynaspeEnums.WorkspaceItemType.Credential:
                    itemTypeString = "credentials";
                    break;
            }

            return itemTypeString;
        }
    }
}
