using System.Net.NetworkInformation;
using System.Text;

namespace Ping;

public class CustomTracer : ICommand
{
    private List<TracerouteResult> StartTrace(string ipAddress, int ttl)
    {
        System.Net.NetworkInformation.Ping pinger = new System.Net.NetworkInformation.Ping();
        PingOptions options = new (ttl, true);
        const int timeout = 5000;
        const string data = "Tracer";
        byte[] buffer = Encoding.ASCII.GetBytes(data);
        PingReply reply = pinger.Send(ipAddress, timeout, buffer, options);
        List<TracerouteResult> result = [];
        if (reply.Status == IPStatus.Success)
        {
            result.Add(new TracerouteResult { IpAddress = reply.Address});
            Console.WriteLine($"Roundtrip time: {reply.RoundtripTime} ms");
        }
        else if (reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.TimedOut)
        {
            if (reply.Status == IPStatus.TtlExpired) 
            {
                result.Add(new TracerouteResult { IpAddress = reply.Address});
            }
            Console.WriteLine($"IP: {result[result.Count - 1].IpAddress}");
            result.AddRange(StartTrace(ipAddress, ttl + 1));
        }
        return result;
    }
    public void ExecuteCommand(string ipAddress)
    {
        StartTrace(ipAddress, 1);
    }
}
