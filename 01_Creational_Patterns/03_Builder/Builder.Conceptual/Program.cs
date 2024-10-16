namespace Builder.Conceptual;

class Program
{
    static void Main(string[] args)
    {
        // Create director and builders
        Director director = new Director();
        Builder b1 = new ConcreteBuilder1();
        Builder b2 = new ConcreteBuilder2();
        
        // Construct two products
        director.Construct(b1);
        Product p1 = b1.GetResult();
        p1.Show();
        
        director.Construct(b2);
        Product p2 = b2.GetResult();
        p2.Show();
    }
}

/**
 * - 디렉터 클래스 (선택사항)
 * - 빌더 인터페페이스를 통해 객체의 생성 순서를 정의하고 관리한다.
 */
class Director
{
    // 빌더를 통해서 객체의 생성 순서를 정의
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}
    
/**
 * - 추상화한 빌더 인터페이스
 * - 객체를 구성하는 단계별로 메서드를 정의한다.
 * - 공통적인 생성 단계들을 선언한다.
 */
abstract class Builder
{
    public abstract void BuildPartA();
    public abstract void BuildPartB();
    public abstract Product GetResult();
}

/**
 * - 빌더 인터페이스를 구현한 클래스
 * - 각 단계별로 객체를 구성하고 조립한다.
 */
class ConcreteBuilder1 : Builder
{
    private Product _product = new Product();
    public override void BuildPartA()
    {
        _product.Add("PartA");
    }
    public override void BuildPartB()
    {
        _product.Add("PartB");
    }
    public override Product GetResult()
    {
        return _product;
    }
}
    
/**
 * - 빌더 인터페이스를 구현한 클래스
 * - 각 단계별로 객체를 구성하고 조립한다.
 */
class ConcreteBuilder2 : Builder
{
    private Product _product = new Product();
    public override void BuildPartA()
    {
        _product.Add("PartX");
    }
    public override void BuildPartB()
    {
        _product.Add("PartY");
    }
    public override Product GetResult()
    {
        return _product;
    }
}

/**
 * - 빌더를 통해 만들어지는 객체(클래스)
 * - 실제 객체 생성에 필요한 과정과 표현이 들어있다.
 */
class Product
{
    private List<string> _parts = new List<string>();
    public void Add(string part)
    {
        _parts.Add(part);
    }
    public void Show()
    {
        Console.WriteLine("\nProduct Parts -------");
        foreach (string part in _parts)
            Console.WriteLine(part);
    }
}