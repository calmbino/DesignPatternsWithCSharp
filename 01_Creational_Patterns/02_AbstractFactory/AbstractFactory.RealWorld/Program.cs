namespace AbstractFactory.RealWorld;

class Program
{
    static void Main(string[] args)
    {
        // 아프리카 대륙의 동물 세계를 생성한 후 실행
        var africa = new AnimalWorld<Africa>();
        africa.RunFoodChain();
        
        // 아메리카 대륙의 동물 세계를 생성한 후 실행
        var america = new AnimalWorld<America>();
        america.RunFoodChain();
    }
}

/**
 * - 추상 팩토리 인터페이스
 * - 한 대륙의 초식 및 육식 동물을 생성
 */
public interface IContinentFactory
{
    // 초식 동물 생성
    IHerbivore CreateHerbivore();
    // 육식 동물 생성
    ICarnivore CreateCarnivore();
}

/**
 * - 추상 팩토리를 구현한 클래스
 * - 아프리카 대륙 생성
 */
public class Africa : IContinentFactory
{
    // 영양 생성
    public IHerbivore CreateHerbivore() => new Wildebeest();
    // 사자 생성
    public ICarnivore CreateCarnivore() => new Lion();
}

/**
 * - 추상 팩토리를 구현한 클래스
 * - 아메리카 대륙 생성
 */
public class America : IContinentFactory
{
    // 들소 생성
    public IHerbivore CreateHerbivore() => new Bison();
    // 늑대 생성
    public ICarnivore CreateCarnivore() => new Wolf();
}

/**
 * - 초식 동물을 정의한 인터페이스
 */
public interface IHerbivore
{
}

/**
 * - 육식 동물을 정의한 인터페이스
 */
public interface ICarnivore
{
    // 초식 동물을 잡아 먹는 행위
    void Eat(IHerbivore h);
}

/**
 * - 초식 동물인 영양을 구현한 클래스
 */
public class Wildebeest : IHerbivore
{
}

/**
 * - 육식 동물인 사자를 구현한 클래스
 */
public class Lion : ICarnivore
{
    // 사자는 같은 대륙에 있는 영양을 잡아 먹는다.
    public void Eat(IHerbivore h) =>
        Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
}

/**
 * - 초식 동물인 들소를 구현한 클래스 
 */
public class Bison : IHerbivore
{
}

/**
 * - 육식 동물인 늑대를 구현한 클래스
 */
public class Wolf : ICarnivore
{
    // 늑대는 같은 대륙에 있는 들소를 잡아 먹는다.
    public void Eat(IHerbivore h) =>
        Console.WriteLine($"{GetType().Name} eats {h.GetType().Name}");
}

/**
 * - 동물의 세계(Client)를 정의한 인터페이스
 */
public interface IAnimalWorld
{
    // 먹이사슬
    void RunFoodChain();
}

/**
 * - 동물의 세계(Client)를 구현하는 클래스
 * - AnimalWorld 클래스는 IAnimalWorld 인터페이스를 구현한다.
 * - T는 IContinentFactory 인터페이스를 구현해야 하며, 기본 생성자를 가져야 한다.
 */
public class AnimalWorld<T> : IAnimalWorld where T : IContinentFactory, new()
{
    private readonly IHerbivore _herbivore;
    private readonly ICarnivore _carnivore;
    public AnimalWorld()
    {
        // 특정 대륙을 인스턴스화
        var factory = new T();
        
        // 대륙별 초식 동물과 육식 동물을 생성
        _carnivore = factory.CreateCarnivore();
        _herbivore = factory.CreateHerbivore();
    }

    // 특정 대륙의 먹이사슬을 확인 
    public void RunFoodChain()
    {
        _carnivore.Eat(_herbivore);
    }
}