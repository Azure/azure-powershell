// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Security;
using System.Xml.Linq;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities
{
    public class SqlDatabaseTestSettings
    {
        /// <summary>
        /// The singleton accessor for the test settings.
        /// </summary>
        public static SqlDatabaseTestSettings Instance = new SqlDatabaseTestSettings();

        /// <summary>
        /// Username to use for running the tests.
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Password to use for running the tests.
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Password as secure string.
        /// </summary>
        public SecureString SecurePassword { get; private set; }

        /// <summary>
        /// ManageUrl to use when running the tests.
        /// </summary>
        public string ManageUrl { get; private set; }

        /// <summary>
        /// Subscription Id to use when running the tests.
        /// </summary>
        public string SubscriptionId { get; private set; }

        /// <summary>
        /// Serialized Certificate to use when running the tests.
        /// </summary>
        public string SerializedCert { get; private set; }

        /// <summary>
        /// The server name to use when running the tests.
        /// </summary>
        public string ServerName { get; private set; }
        
        /// <summary>
        /// The name of the v2 server for running the tests
        /// </summary>
        public object ServerV2 { get; set; }

        /// <summary>
        /// The database name to use when running the tests.
        /// </summary>
        public string SourceDatabaseName { get; private set; }

        /// <summary>
        /// The database name to use when running the tests.
        /// </summary>
        public string TargetDatabaseName { get; private set; }

        /// <summary>
        /// The location of the server.
        /// </summary>
        public string ServerLocation { get; private set; }

        /// <summary>
        /// The name of the storage account.
        /// </summary>
        public string StorageName { get; private set; }

        /// <summary>
        /// The access key to the storage account
        /// </summary>
        public string AccessKey { get; private set; }

        /// <summary>
        /// The name of the storage container.
        /// </summary>
        public string ContainerName { get; private set; }

        private SqlDatabaseTestSettings()
        {
            XElement root = XElement.Load("SqlDatabaseSettings.xml");
            this.ServerLocation = root.Element("ServerLocation").Value;
            this.UserName = root.Element("SqlAuthUserName").Value;
            this.Password = root.Element("SqlAuthPassword").Value;
            this.SecurePassword = ToSecureString(this.Password);
            this.ManageUrl = root.Element("ManageUrl").Value;
            this.SerializedCert = root.Element("SerializedCert").Value;
            this.SubscriptionId = root.Element("SubscriptionId").Value;
            this.ServerName = new Uri(this.ManageUrl).Host.Split('.').First();
            this.ServerV2 = root.Element("ServerV2").Value;
            this.SourceDatabaseName = root.Element("SourceDatabaseName").Value;
            this.TargetDatabaseName = root.Element("TargetDatabaseName").Value;
            this.StorageName = root.Element("StorageName").Value;
            this.AccessKey = root.Element("AccessKey").Value;
            this.ContainerName = root.Element("ContainerName").Value;
        }

        private static SecureString ToSecureString(string plaintext)
        {
            SecureString secure = new SecureString();
            foreach (char c in plaintext.ToCharArray())
            {
                secure.AppendChar(c);
            }

            return secure;
        }
    }
}
