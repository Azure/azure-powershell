// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSProjectTask.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataMigration.Common;
using Microsoft.Azure.Management.DataMigration.Models;
using System;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public class PSProjectTask
    {
        private ProjectTask task;
        private DmsResourceIdentifier ids;

        public PSProjectTask(ProjectTask task)
        {
            if(task == null)
            {
                throw new ArgumentNullException("project");
            }

            this.task = task;
            this.ids = new DmsResourceIdentifier(task.Id);
            this.ResourceGroupName = ids.ResourceGroupName;
            this.ServiceName = ids.ServiceName;
            this.ProjectName = ids.ProjectName;
        }

        public ProjectTask ProjectTask => task;

        public string ResourceGroupName { get; private set; }

        public string ServiceName { get; private set; }

        public string ProjectName { get; private set; }

        public string Name
        {
            get
            {
                return ProjectTask.Name;
            }
        }

    }
}
