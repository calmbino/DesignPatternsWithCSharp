namespace Prototype.Conceptual;

class Program
{
    static void Main(string[] args)
    {
        // ID가 서로 다른 두 인스턴스를 생성한 후 각각 복사를 수행한다.
        // 복사된 객체의 ID를 확인해보면 원본 객체와 동일하다.
        ConcretePrototype1 p1 = new ConcretePrototype1("I");
        ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
        
        Console.WriteLine("Cloned: {0}", c1.Id);
        
        ConcretePrototype2 p2 = new ConcretePrototype2("II");
        ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
        
        Console.WriteLine("Cloned: {0}", c2.Id);
    }
}

/**
 * - 프로토타입 추상 클래스
 */
public abstract class Prototype
{
    private string _id;
    
    public Prototype(string id)
    {
        this._id = id;
    }
    
    public string Id
    {
        get { return _id; }
    }
    
    // 복제를 위한 메서드
    public abstract Prototype Clone();
}

/**
 * - 프로토타입 구현 클래스
 */
public class ConcretePrototype1 : Prototype
{
    public ConcretePrototype1(string id)
        : base(id)
    {
    }
    
    // MemberwiseClone을 통해 얕은 복사 수행
    public override Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}

/**
 * - 프로토타입 구현 클래스
 */
public class ConcretePrototype2 : Prototype
{
    public ConcretePrototype2(string id)
        : base(id)
    {
    }
    
    // MemberwiseClone을 통해 얕은 복사 수행
    public override Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}