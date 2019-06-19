using D365MLP.ApplicationInsights;
using Microsoft.Xrm.Sdk;
using System;

namespace D365MLP.Plugins
{
    public class OnDummyEntityCreateDoesSomethingAsync : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService(typeof(IPluginExecutionContext)) as IPluginExecutionContext;
            var factory = serviceProvider.GetService(typeof(IOrganizationServiceFactory)) as IOrganizationServiceFactory;
            var service = factory.CreateOrganizationService(context.InitiatingUserId);
            var dummyEntity = context.InputParameters.ContainsKey("Target") ? context.InputParameters["Target"] as Entity : null;

            if (dummyEntity != null)
                ExecuteLogic(dummyEntity, service);
        }

        private void ExecuteLogic(Entity dummyEntity, IOrganizationService service)
        {
            var ai = new TelemetryClient("38765d3d-9ba0-4e85-aafe-e832f40cf44e");
        }
    }
}