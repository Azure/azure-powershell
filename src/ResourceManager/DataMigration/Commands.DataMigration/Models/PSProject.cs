// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSProject.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Management.DataMigration.Models;
using System;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public class PSProject
    {
        private Project project;
        private DmsResourceIdentifier ids;

        public PSProject(Project project)
        {
            if(project == null)
            {
                throw new ArgumentNullException("project");
            }

            this.project = project;
            this.ids = new DmsResourceIdentifier(project.Id);
            this.ResourceGroupName = ids.ResourceGroupName;
            this.ServiceName = ids.ServiceName;
        }

        public Project Project => project;

        public string ResourceGroupName { get; private set; }

        public string ServiceName { get; private set; }

        public string Location
        {
            get
            {
                return project.Location;
            }
        }

        public string Name
        {
            get
            {
                return Project.Name;
            }
        }
    }
}
