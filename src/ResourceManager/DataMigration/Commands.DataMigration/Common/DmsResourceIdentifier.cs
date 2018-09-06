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

namespace Microsoft.Azure.Commands.DataMigration.Common
{
    public class DmsResourceIdentifier
    {
        private string[] tokens;
        private string idFromServer;
        private string serviceName = null;
        private string projectName = null;
        private string taskName = null;

        public string ResourceGroupName { get; private set; }

        public string Subscription { get; }

        public DmsResourceIdentifier() { }

        public DmsResourceIdentifier(string idFromServer)
        {
            if (string.IsNullOrEmpty(idFromServer))
            {
                throw new ArgumentNullException("IdFromServer");
            }

            this.idFromServer = idFromServer;

            tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length < 8)
            {
                throw new ArgumentException("Invalid format of the resource identifier.", "idFromServer");
            }
            Subscription = tokens[1];
            ResourceGroupName = tokens[3];
        }

        public string ServiceName
        {
            get
            {
                if (serviceName == null)
                {
                    if (tokens.Length < 8)
                    {
                        throw new ArgumentException("Invalid format of the resource identifier. Cannot retrieve ServiceName", "idFromServer");
                    }

                    serviceName = this.tokens[7];
                }

                return serviceName;
            }
        }

        public string ProjectName
        {
            get
            {
                if (projectName == null)
                {
                    if (tokens.Length < 10)
                    {
                        throw new ArgumentException("Invalid format of the resource identifier. Cannot retrieve ProjectName", "idFromServer");
                    }

                    projectName = this.tokens[9];
                }

                return projectName;
            }
        }

        public string TaskName
        {
            get
            {
                if (taskName == null)
                {
                    if (tokens.Length < 12)
                    {
                        throw new ArgumentException("Invalid format of the resource identifier. Cannot retrieve TaskName", "idFromServer");
                    }

                    taskName = this.tokens[11];
                }

                return taskName;
            }
        }
    }
}
