namespace AbstractFactory_Conceptual;

class Program
{
    static void Main(string[] args)
    {
        // 추상 팩토리 #1
        // 1번 제품군 생성
        AbstractFactory factory1 = new ConcreteFactory1();
        Client client1 = new Client(factory1);
        client1.Run();
        
        // 추상 팩토리 #2
        // 2번 제품군 생성
        AbstractFactory factory2 = new ConcreteFactory2();
        Client client2 = new Client(factory2);
        client2.Run();
    }
    
    /**
     * - 추상 팩토리 클래스
     * - 제품군에는 제품 A와 제품 B가 존재
     */
    abstract class AbstractFactory
    {
        // 제품 A 생성
        public abstract AbstractProductA CreateProductA();
        // 제품 B 생성
        public abstract AbstractProductB CreateProductB();
    }

    /**
     * - 추상 팩토리 클래스를 구현한 구체 클래스 (1)
     * - 1번 제품군을 생성하는 역할
     */
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
    
    /**
     * - 추상 팩토리 클래스를 구현한 구체 클래스 (2)
     * - 2번 제품군을 생성하는 역할
     */
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    /**
     * - A 제품에 대한 추상 클래스
     */
    abstract class AbstractProductA
    {
    }
    
    /**
     * - B 제품에 대한 추상 클래스
     */
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }
    
    /**
     * - 1번 제품군의 A 제품을 구현한 클래스
     */
    class ProductA1 : AbstractProductA
    {
    }
    
    /**
     *  - 1번 제품군의 B 제품을 구현한 클래스
     */
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    /**
     * - 2번 제품군의 A 제품을 구현한 클래스
     */
    class ProductA2 : AbstractProductA
    {
    }
    
    /**
     * - 2번 제품군의 B 제품을 구현한 클래스
     */
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
              " interacts with " + a.GetType().Name);
        }
    }

    /**
     * - 클라이언트 클래스
     */
    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;
        
        // 특정 제품군에 대한 팩토리를 주입
        public Client(AbstractFactory factory)
        {
            // A 제품과 B 제품을 생성
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }
        public void Run()
        {
            // 같은 제품군의 제품끼리 상호작용
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}