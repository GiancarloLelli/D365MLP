if (typeof (D365MLP) == "undefined") { D365MLP = { __namespace: true }; }
if (typeof (D365MLP.mlp_dummyentity) == "undefined") { D365MLP.mlp_dummyentity = { __namespace: true }; }

D365MLP.mlp_dummyentity.Form = new function () {
    var _self = this;

    _self.OnLoad = function () {
        var ai = window.appInsights;
        ai.trackEvent({ name: 'some event' });
        ai.trackPageView({ name: 'some page' });
        ai.trackPageViewPerformance({ name: 'some page', url: 'some url' });
        ai.trackException({ exception: new Error('some error') });
        ai.trackTrace({ message: 'some trace' });
        ai.trackMetric({ name: 'some metric', average: 42 });
        ai.trackDependencyData({ absoluteUrl: 'some url', responseCode: 200, method: 'GET', id: 'some id' });
        ai.startTrackPage("pageName");
        ai.stopTrackPage("pageName", { customProp1: "some value" });
        ai.startTrackEvent("event");
        ai.stopTrackEvent("event", { customProp1: "some value" });
        ai.flush();

        var telemetryInitializer = (envelope) => {
            envelope.data.someField = 'This item passed through my telemetry initializer';
        };

        ai.addTelemetryInitializer(telemetryInitializer);
        ai.trackTrace({ message: 'This message will use a telemetry initializer' });

        ai.addTelemetryInitializer(() => false); // Nothing is sent after this is executed
        ai.trackTrace({ message: 'this message will not be sent' }); // Not sent
    }
}