using WikiLoaderProvider;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Provider.EventHandlers
{
    [kCura.EventHandler.CustomAttributes.Description("Update WikiLoader Provider - On Every Install")]
    [kCura.EventHandler.CustomAttributes.RunOnce(false)]
    [Guid("0CD3CCEC-2133-4E9F-821B-7FE4E0480880")]
    public class RegisterWikiLoaderIntegrationPoint : kCura.IntegrationPoints.SourceProviderInstaller.IntegrationPointSourceProviderInstaller
    {
        public override IDictionary<Guid, kCura.IntegrationPoints.SourceProviderInstaller.SourceProvider> GetSourceProviders()
        {
            Dictionary<Guid, kCura.IntegrationPoints.SourceProviderInstaller.SourceProvider> sourceProviders = new Dictionary<Guid, kCura.IntegrationPoints.SourceProviderInstaller.SourceProvider>();
            var WikiLoaderProviderEntry = new kCura.IntegrationPoints.SourceProviderInstaller.SourceProvider();
            WikiLoaderProviderEntry.Name = "WikiLoader Provider";
            WikiLoaderProviderEntry.Url = string.Format("/%applicationpath%/CustomPages/{0}/Provider/Settings", GlobalConstants.APPLICATION_GUID);
            WikiLoaderProviderEntry.ViewDataUrl = string.Format("/%applicationpath%/CustomPages/{0}/%appId%/api/ProviderAPI/GetViewFields", GlobalConstants.APPLICATION_GUID);
            sourceProviders.Add(Guid.Parse(GlobalConstants.WIKILOADER_GUID), WikiLoaderProviderEntry);

            return sourceProviders;
        }
    }
}