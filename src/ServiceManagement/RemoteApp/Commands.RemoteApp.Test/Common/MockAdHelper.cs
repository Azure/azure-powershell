using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;

namespace Microsoft.WindowsAzure.Commands.RemoteApp.Test.Common
{
    class MockAdHelper : IAdHelper
    {
        internal const string CN = "cn";

        internal IList<DirectoryEntry> entries = new List<DirectoryEntry>();

        public class MockDirectoryEntry : DirectoryEntry
        {
            private string cn;

            public MockDirectoryEntry(string cn)
            {
                this.cn = cn;
            }

            public string MockCN
            {
                get
                {
                    return cn;
                }
            }
        }

        public IList<DirectoryEntry> GetVmAdEntries(string domainName, string OU, string vmNamePrefix, PSCredential credential)
        {
            return entries;
        }


        public string GetCN(DirectoryEntry dirEntry)
        {
            string entryCN = null;
            if(dirEntry is MockDirectoryEntry)
            {
                entryCN = (dirEntry as MockDirectoryEntry).MockCN;
            }
            else
            {
                entryCN = dirEntry.Properties[MockAdHelper.CN][0].ToString();
            }

            return entryCN;
        }

        public void DeleteEntry(DirectoryEntry dirEntry)
        {
            // do nothing
        }

        public void SetEntries(string[] ObjNames)
        {
            entries.Clear();
            foreach(string objName in ObjNames)
            {
                entries.Add(new MockDirectoryEntry(objName));
            }
        }
    }
}
