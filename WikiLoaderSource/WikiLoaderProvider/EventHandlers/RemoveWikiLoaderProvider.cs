﻿using System.Runtime.InteropServices;

namespace Provider.EventHandlers
{
    [kCura.EventHandler.CustomAttributes.Description("Update WikiLoader provider - Uninstall")]
    [kCura.EventHandler.CustomAttributes.RunOnce(false)]
    [Guid("5BAE6D1B-9F47-4C65-949B-1B57DF535B57")]
    public class RemoveWikiLoaderProvider : kCura.IntegrationPoints.SourceProviderInstaller.IntegrationPointSourceProviderUninstaller
    {
    }
}