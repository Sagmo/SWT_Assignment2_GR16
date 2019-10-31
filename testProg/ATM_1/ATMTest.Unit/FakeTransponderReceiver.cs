
namespace ATM_1.Unit
{
    public class FakeTransponderReceiver : ITransponderReceiver
    {
        private string FakeTransponderReceiver(string tag)
        {
            return tag;
        }
    }
}
