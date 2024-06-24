using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    internal interface IConfigEventListener
    {
        void OnEvent(object sender, ConfigEventArgs arg);
    }
}
