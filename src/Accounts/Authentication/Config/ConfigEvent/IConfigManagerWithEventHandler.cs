using Microsoft.Azure.PowerShell.Common.Config;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    public interface IConfigManagerWithEventHandler: IConfigManager
    {
        void RegisterHandler(EventHandler<ConfigEventArgs> handlerInitializer);
        void UnregisterHandler(EventHandler<ConfigEventArgs> handlerInitializer);
        void ClearHandlers();
    }
}
