namespace D365MLP.ApplicationInsights
{
    public class TelemetryClient
    {
        private const string _uri = "https://dc.services.visualstudio.com/v2/track";
        private readonly string _instrumentationKey;

        public TelemetryClient(string instKey)
        {
            _instrumentationKey = instKey;
        }
    }
}
