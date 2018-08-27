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
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Commands.Storage.ScenarioTest.Util
{
    public class CloudTableUtil
    {
        private CloudStorageAccount account;
        private CloudTableClient client;
        private Random random;

        private CloudTableUtil()
        { }

        /// <summary>
        /// init cloud queue util
        /// </summary>
        /// <param name="account">storage account</param>
        public CloudTableUtil(CloudStorageAccount account)
        {
            this.account = account;
            client = account.CreateCloudTableClient();
            random = new Random();
        }

        /// <summary>
        /// create a container with random properties and metadata
        /// </summary>
        /// <param name="tableName">container name</param>
        /// <returns>the created container object with properties and metadata</returns>
        public CloudTable CreateTable(string tableName = "")
        {
            if (String.IsNullOrEmpty(tableName))
            {
                tableName = Utility.GenNameString("table");
            }

            CloudTable table = client.GetTableReference(tableName);
            table.CreateIfNotExists();

            return table;
        }

        /// <summary>
        /// create mutiple containers
        /// </summary>
        /// <param name="tableName">container names list</param>
        /// <returns>a list of container object</returns>
        public List<CloudTable> CreateTable(List<string> tableName)
        {
            List<CloudTable> tables = new List<CloudTable>();

            foreach (string name in tableName)
            {
                tables.Add(CreateTable(name));
            }

            tables = tables.OrderBy(table => table.Name).ToList();

            return tables;
        }

        /// <summary>
        /// remove specified container
        /// </summary>
        /// <param name="tableName">container name</param>
        public void RemoveTable(string tableName)
        {
            CloudTable table = client.GetTableReference(tableName);
            table.DeleteIfExists();
        }

        /// <summary>
        /// remove a list containers
        /// </summary>
        /// <param name="tableNames">container names</param>
        public void RemoveTable(List<string> tableNames)
        {
            foreach (string name in tableNames)
            {
                RemoveTable(name);
            }
        }

        public int GetExistingTableCount()
        {
            List<CloudTable> tables = client.ListTables().ToList();
            return tables.Count;
        }
    }
}
