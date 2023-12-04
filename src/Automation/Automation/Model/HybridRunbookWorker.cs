﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Commands.Automation.Model
{
    public class HybridRunbookWorker
    {
        public HybridRunbookWorker()
        {

        }
        public HybridRunbookWorker(Azure.Management.Automation.Models.HybridRunbookWorker worker)
        {
            this.IpAddress = worker.IP;
            this.Name = worker.Name;
            this.LastSeenDateTime = worker.LastSeenDateTime;
        }
        public string IpAddress { get; set; }
        //
        // Summary:
        //     Optional. Gets or sets the worker machine name.
        public string Name { get; set; }
        //
        // Summary:
        //     Optional. Gets or sets the registration time of the worker machine.
        public DateTimeOffset RegistrationTime { get; set; }

        public DateTimeOffset LastSeenDateTime { get; set; }

    }
}