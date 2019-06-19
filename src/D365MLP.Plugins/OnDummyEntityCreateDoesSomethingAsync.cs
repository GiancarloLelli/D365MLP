using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
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
                ExecuteLogic(dummyEntity, service, context.InitiatingUserId, context.RequestId.GetValueOrDefault(Guid.Empty));
        }

        private void ExecuteLogic(Entity dummyEntity, IOrganizationService service, Guid userId, Guid reqId)
        {
            var ai = new TelemetryClient(new TelemetryConfiguration("38765d3d-9ba0-4e85-aafe-e832f40cf44e"));
            ai.Context.User.AuthenticatedUserId = userId.ToString();
            ai.Context.Operation.Id = reqId.ToString();
            ai.TrackTrace($"Record Created with Id={dummyEntity.Id}");
        }
    }
}