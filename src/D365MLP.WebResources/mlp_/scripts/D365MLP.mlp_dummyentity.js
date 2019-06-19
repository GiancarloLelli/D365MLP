if (typeof (D365MLP) == "undefined") { D365MLP = { __namespace: true }; }
if (typeof (D365MLP.mlp_dummyentity) == "undefined") { D365MLP.mlp_dummyentity = { __namespace: true }; }

D365MLP.mlp_dummyentity.Form = new function () {
    var _self = this;

    _self.OnLoad = function (executionContext) {
        debugger;
        var ai = window.appInsights;
        ai.setAuthenticatedUserContext(Xrm.Page.context.getUserId());

        ai.startTrackEvent("eventDetailDiscovery");
        var formCtx = executionContext.getFormContext();
        var entityReference = formCtx.entityReference;
        ai.stopTrackEvent("event", { logicalName: entityReference.entityType, id: entityReference.id });
        ai.flush();

        /*
        ai.trackEvent({ name: 'some event' });
        ai.trackPageView({ name: 'page name' });
        ai.trackPageViewPerformance({ name: 'some page', url: 'some url' });
        ai.trackException({ exception: new Error('some error') });
        ai.trackTrace({ message: 'some trace' });
        ai.trackMetric({ name: 'some metric', average: 42 });
        ai.trackDependencyData({ absoluteUrl: 'some url', responseCode: 200, method: 'GET', id: 'some id' });
        ai.startTrackPage("pageName");
        ai.stopTrackPage("pageName", { customProp1: "some value" });

        var telemetryInitializer = (envelope) => {
            envelope.data.someField = 'This item passed through my telemetry initializer';
        };

        ai.addTelemetryInitializer(telemetryInitializer);
        ai.trackTrace({ message: 'This message will use a telemetry initializer' });

        ai.addTelemetryInitializer(() => false); // Nothing is sent after this is executed
        ai.trackTrace({ message: 'this message will not be sent' }); // Not sent
        */
    }
}