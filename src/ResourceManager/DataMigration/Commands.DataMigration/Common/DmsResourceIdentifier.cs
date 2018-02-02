// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DmsResourceIdentifier.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
