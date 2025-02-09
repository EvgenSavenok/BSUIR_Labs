using System.Net.NetworkInformation;

namespace Ping;

public class CustomPing : ICommand
{
    private void StartPing(string ipAddress)
    {
        const int timeout = 5000;
        try
        {
            using (System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping())
            {
                PingOptions options = new ();
                options.DontFragment = true;
                for (int i = 0; i < 4; i++)
                {
                    PingReply reply = pingSender.Send(ipAddress, timeout, new byte[32], options);
                    if (reply.Status == IPStatus.Success)
                    {
                        Console.WriteLine(
                            $"Response from {reply.Address}: bytes={reply.Buffer.Length} time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {reply.Status}");
                    }
                }
            }
        }
        catch (PingException ex)
        {
            Console.WriteLine($"Ping exception: {ex.Message}");
        }
    }

    public void ExecuteCommand(string ipAddress)
    {
        StartPing(ipAddress);
    }
}
