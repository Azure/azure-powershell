﻿using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using User = Microsoft.Azure.Management.DataBoxEdge.Models.User;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeUser
    {
        [Ps1Xml(Label = "User name", Target = ViewControl.Table,
            ScriptBlock = "$_.user.Name")]
        [Ps1Xml(Label = "Type", Target = ViewControl.Table,
            ScriptBlock = "$_.user.UserType")]
        public User User;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table)]
        public string ResourceGroupName;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table)]
        public string DeviceName;


        public string Id;
        public string Name;

        public PSStackEdgeUser()
        {
            User = new User();
        }

        public PSStackEdgeUser(User user)
        {
            this.User = user ?? throw new ArgumentNullException(nameof(user));
            this.Id = user.Id;
            var resourceIdentifier = new StackEdgeResourceIdentifier(user.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
        }
    }
}