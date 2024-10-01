/**
 * - Vehicle은 일반 차량(운송 수단)을 표현하는 추상 클래스이며, 엔진의 동작과 정지를 위한 추상 메서드를 가지고 있다.
 * - Car는 Vehicle을 상속받아 엔진과 관련된 기능들을 구현한 구상 클래스(Concrete class)이다.
 * - ElectricCar는 Vehicle의 새로운 하위 타입으로 정의하면 LSP를 위반하게 된다.
 * - 왜냐하면 전기차는 엔진이 없기 때문에 엔진 관련 메소드를 호출하는 순간, 에러가 발생한다.
 * - 즉 하위 클래스(ElectricCar)가 상위 클래스(Vehicle)의 역할을 제대로 수행하지 못한다.
 */
public abstract class Vehicle
{
    public abstract void StartEngine();
    public abstract void StopEngine();
}

public class Car : Vehicle
{
    public override void StartEngine()
    {
        Console.WriteLine("Starting the car engine.");
        // Code to start the car engine
    }
    public override void StopEngine()
    {
        Console.WriteLine("Stopping the car engine.");
        // Code to stop the car engine
    }
}

public class ElectricCar : Vehicle
{
    public override void StartEngine()
    {
        throw new InvalidOperationException("Electric cars do not have engines.");
    }
    public override void StopEngine()
    {
        throw new InvalidOperationException("Electric cars do not have engines.");
    }
}

Vehicle car = new Car();
car.StartEngine(); // Outputs "Starting the car engine."
Vehicle electricCar = new ElectricCar();
electricCar.StartEngine(); // Throws InvalidOperationException
