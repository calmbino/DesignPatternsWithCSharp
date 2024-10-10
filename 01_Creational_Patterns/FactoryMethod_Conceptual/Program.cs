namespace FactoryMethod_Conceptual;

class Program
{
    /**
     * - Creator 클래스는 Product 클래스의 객체를 리턴하는 팩토리 메서드를 선언한다.
     * - Creator의 서브 클래스들은 팩토리 메서드의 구현을 제공한다.
     */
    abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        /**
         * - 팩토리 메서드를 통해 Product 객체를 얻고, 이를 사용하여 비즈니스 로직을 수행한다.
         * - 클라이언트(Client)는 구체적인 객체 생성 방식을 몰라도 객체를 사용할 수 있다.
         */
        public string SomeOperation()
        {
            var product = FactoryMethod();
            var result = "Creator: The same creator's code has just worked with " + product.Operation();

            return result;
        }
    }

    /**
     * - 팩토리 메서드를 오버라이드 하여 Product 타입의 결과물을 리턴한다.
     */
    class ConcreteCreator1 : Creator
    {
        /**
         * - 리턴 타입으로 인터페이스를 사용하기 때문에
         * - 구체적인 Product 클래스로부터 독립적이다.
         */
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }
    
    
    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }
    
    /**
     * - 인터페이스를 통해서 Product 구상(구체) 클래스들이 구현해야할 동작을 정의한다.
     */
    public interface IProduct
    {
        /**
         * - 일관된 방식으로 다양한 Product 객체를 사용할 수 있다.
         */
        string Operation();
    }

    /**
     * - Prodcut 인테페이스의 다양한 구현을 제공한다.
     */
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }

    /**
     * - Creator의 구체적인 구현을 받아서 SomeOperation 메서드를 실행한다.
     * - Product 객체 생성 로직에 의존하지 않으면서, 다양한 Product 객체를 다형성으로 활용할 수 있다.
     */
    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());
            
            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
        }
        
        /**
         * - Creator의 구체 클래스에 의존하지 않고, 추상 클래스 Creator의 메서드를 호출함으로써 다형성을 활용하낟.
         */
        public void ClientCode(Creator creator)
        {
            // ...
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                              "but it still works.\n" + creator.SomeOperation());
            // ...
        }
    }
    
    static void Main(string[] args)
    {
        new Client().Main();
    }
}