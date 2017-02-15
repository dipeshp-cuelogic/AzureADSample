namespace SampleSPAAzureAD.API.Services
{
    public class FakeService : IFakeService
    {
        public string GetData()
        {
            return "fake data";
        }
    }
}