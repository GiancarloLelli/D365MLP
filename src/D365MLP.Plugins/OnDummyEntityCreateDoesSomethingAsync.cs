using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
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
            var trace = serviceProvider.GetService(typeof(ITracingService)) as ITracingService;
            var factory = serviceProvider.GetService(typeof(IOrganizationServiceFactory)) as IOrganizationServiceFactory;
            var service = factory.CreateOrganizationService(context.InitiatingUserId);

            var dummyEntity = context.InputParameters.ContainsKey("Target") ? context.InputParameters["Target"] as Entity : null;

            var appInsights = new TelemetryClient(new TelemetryConfiguration("38765d3d-9ba0-4e85-aafe-e832f40cf44e"));
            appInsights.Context.User.Id = context.InitiatingUserId.ToString();
            appInsights.Context.Operation.Id = context.RequestId.GetValueOrDefault(Guid.Empty).ToString();

            appInsights.TrackTrace(new TraceTelemetry($"Record Created with Id={dummyEntity.Id}", SeverityLevel.Information));
        }
    }
}