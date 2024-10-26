namespace Singleton.Conceptual;

class Program
{
    static void Main(string[] args)
    {
        // 싱글턴 클래스는 생성자(constructor) 사용할 수 없다.
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();
        
        if (s1 == s2)
        {
            // s1에서 최초로 인스턴스가 생성됐고, s2는 이미 만들어진 인스턴스를 사용한다.
            Console.WriteLine("Objects are the same instance");
            Console.WriteLine($"s1.GetType:  {s1.GetType()}");
            Console.WriteLine($"s2.GetType: {s2.GetType()}");
            Console.WriteLine($"s1.GetHashCode(): {s1.GetHashCode()}");
            Console.WriteLine($"s2.GetHashCode(): {s2.GetHashCode()}");
            Console.WriteLine($"s1.Equals(s2): {s1.Equals(s2)}");
        }
    }
}

public class Singleton
{
    static Singleton _instance;
    
    // / 싱글턴의 생성자는 `new` 연산자를 사용한 직접 생성 호출들을 방지하기 위해 항상 비공개여야 한다.
    private Singleton()
    {
    }
    
    // 싱글턴 인스턴스에 접근하기 위한 정적 메서드
    public static Singleton GetInstance()
    {
        // 현재는 lazy initialization 방식으로 인스턴스를 생성한다.
        // 이는 멀티스레딩 환경에선 안전하지 못하다.
        // 멀티스레딩을 지원하는 애플리케이션이라면, 이곳에서 스레드 잠금을 설정해야 한다.
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        
        return _instance;
    }
}
