using System.Diagnostics;

namespace PM_MVC.Utils
{
    public class TraceUtils : ITraceUtils
    {
        public void DoWork()
        {
            Trace.WriteLine("Hello trace");
        }
    }
}
