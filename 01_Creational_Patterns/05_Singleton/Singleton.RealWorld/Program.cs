namespace Singleton.RealWorld;

class Program
{
    static void Main(string[] args)
    {
        // 동일한(단 하나의) 로드밸런서를 사용하고 있는지 확인한다.
        var b1 = LoadBalancer.GetLoadBalancer();
        var b2 = LoadBalancer.GetLoadBalancer();
        var b3 = LoadBalancer.GetLoadBalancer();
        var b4 = LoadBalancer.GetLoadBalancer();
        
        if (b1 == b2 && b2 == b3 && b3 == b4)
        {
            Console.WriteLine("Same _instance\n");
        }
        
        // 로드밸런서가 들어오는 요청을 소유하고 있는 서버에 분배한다.
        var balancer = LoadBalancer.GetLoadBalancer();
        for (int i = 0; i < 15; i++)
        {
            var (serverName, serverIp) = balancer.NextServer;
            Console.WriteLine($"Dispatch request to: {serverName}({serverIp})");
        }
    }
}

/**
 * - 싱글턴으로 구현한 로드밸런서 클래스
 */
public sealed class LoadBalancer
{
    // 현재는 eagerly initialization(이른 초기화) 방식으로 인스턴스를 생성한다. (정적 멤버 변수 초기화!)
    // 로드 밸런서가 필요한 시점에 인스턴스를 생성하는 것이 아니라, 프로그램이 실행되면서 해당 클래스가 처음 로드되는 순간에 인스턴스를 미리 생성해놓는 것이다.
    // .NET에서는 정적 멤버가 클래스가 처음 로드되는 시점에 초기화되며, 스레드 안전성을 보장해 주기 때문에 추가적인 동기화 처리 없이도 안전하게 사용할 수 있다.
    private static readonly LoadBalancer Instance = new();
    private readonly List<Server> _servers;
    private readonly Random _random = new();
    
    private LoadBalancer()
    {
        // 로드밸런서가 생성될 때 사용 가능한 서버 목록을 함께 생성한다.
        // 즉, 모든 요청은 하나의 로드밸런서(인스턴스)를 통해서 각 서버로 분배된다.
        _servers = [
            new Server(Name: "ServerI", Ip: "120.14.220.18"),
            new Server(Name: "ServerII", Ip: "120.14.220.19" ),
            new Server(Name: "ServerIII", Ip: "120.14.220.20" ),
            new Server(Name: "ServerIV", Ip: "120.14.220.21" ),
            new Server(Name: "ServerV", Ip: "120.14.220.22" )
        ];
    }
    
    // 로드밸런서 인스턴스를 가져온다.
    public static LoadBalancer GetLoadBalancer()
    {
        return Instance;
    }
    
    // 실제 로드밸런서는 다양한 알고리즘을 이용하여 부하를 분산시킨다.
    public Server NextServer
    {
        get => _servers[_random.Next(_servers.Count)];
    }
}

/**
 * - 서버 정의
 */
public record Server (string Name, string Ip);