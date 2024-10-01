/**
 * - 기존의 상위 클래스는 차량의 일반적인 속성과 행동만을 정의힌다.
 * - 문제가 됐던 엔진 기능을 별도의 인터페이스로 분리한다.
 * - 즉 전기차에선 불필요한 엔진 관련 메서드를 구현하지 않게 함으로써
 *   상위 클래스와 하위 클래스간의 대체 가능성이 보장되며, LSP를 준수하게 된다.
 */
public abstract class Vehicle
{
    // Common vehicle behavior and properties.
}
public interface IEnginePowered
{
    void StartEngine();
    void StopEngine();
}
public class Car : Vehicle, IEnginePowered
{
    public void StartEngine()
    {
        Console.WriteLine("Starting the car engine.");
        // Code to start the car engine.
    }
    public void StopEngine()
    {
        Console.WriteLine("Stopping the car engine.");
        // Code to stop the car engine.
    }
}
public class ElectricCar : Vehicle
{
    // Specific behavior for electric cars.
}

IEnginePowered car = new Car();
car.StartEngine(); // Outputs "Starting the car engine."

Vehicle electricCar = new ElectricCar();
//electricCar.StartEngine(); // This line won't compile because ElectricCar does not implement IEnginePowered