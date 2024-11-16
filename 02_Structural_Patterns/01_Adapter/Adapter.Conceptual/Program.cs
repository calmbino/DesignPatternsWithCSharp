namespace Adapter.Conceptual;

public class Program
{
    public static void Main(string[] args)
    {
        // 어댑터 생성 후 요청
        Target target = new Adapter();
        target.Request();
        
        // Wait for user
        Console.ReadKey();
    }
}

/// <summary>
/// "Target" 클래스.
/// 클라이언트(기존 시스템)이 기대하는 인터페이스
/// </summary>
public class Target
{
    public virtual void Request()
    {
        Console.WriteLine("Called Target Request()");
    }
}

/// <summary>
/// "Adapter" 클래스.
/// 두 클래스 간의 '중재자 역할'.
/// </summary>
public class Adapter : Target
{
    // 인터페이스가 호환되지 않는 클래스
    private Adaptee adaptee = new Adaptee();
    
    public override void Request()
    {
        // 기존 시스템의 방식(Request)으로 호출하여,
        // 호환되지 않던 인터페이스를 사용.
        adaptee.SpecificRequest();
    }
}

/// <summary>
/// "Adaptee" 클래스.
/// 인터페이스가 호환되지 않는 클래스.
/// 어댑터 클래스를 사용하여 다른 클래스로 변환되는 클래스.
/// </summary>
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Called SpecificRequest()");
    }
}