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

using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using System;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class Connection
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="accountAcccountName">
        /// The account name.
        /// </param>
        /// <param name="connection">
        /// The connection.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public Connection(string accountAcccountName, WindowsAzure.Management.Automation.Models.Connection connection)
        {
            Requires.Argument("connection", connection).NotNull();
            this.AutomationAccountName = accountAcccountName;
            this.Name = connection.Name;

            if (connection.Properties == null) return;

            this.Description = connection.Properties.Description;
            this.CreationTime = connection.Properties.CreationTime.ToLocalTime();
            this.LastModifiedTime = connection.Properties.LastModifiedTime.ToLocalTime();
            this.ConnectionTypeName = connection.Properties.ConnectionType.Name;
            this.FieldDefinitionValues = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
            foreach (var kvp in connection.Properties.FieldDefinitionValues)
            {
                this.FieldDefinitionValues.Add(kvp.Key, kvp.Value.ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        public Connection()
        {
        }

        /// <summary>
        /// Gets or sets the automaiton account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public DateTimeOffset LastModifiedTime { get; set; }

        public string ConnectionTypeName { get; set; }

        public Hashtable FieldDefinitionValues { get; set; }
    }
}
