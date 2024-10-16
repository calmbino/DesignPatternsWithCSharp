namespace Builder.RealWorld;

class Program
{
    static void Main(string[] args)
    {
        // 디렉터 생성
        var shop = new Shop();
        
        // 디렉터를 통해서 다양한 빌더 구현체를 사용
        shop.Construct(new ScooterBuilder());
        shop.ShowVehicle();
        shop.Construct(new CarBuilder());
        shop.ShowVehicle();
        shop.Construct(new MotorCycleBuilder());
        shop.ShowVehicle();
    }
}

/**
 * - 디렉터 클래스
 */
public class Shop
{
    // 추상화된 (공통) 빌더 인터페이스 사용
    private VehicleBuilder? _builder;
    
    // 객체를 생성하는 순서를 정의
    // 다양한 빌더 구현체들이 일관성 있는 생성 프로세스를 가질 수 있다.
    public void Construct(VehicleBuilder vehicleBuilder)
    {
        _builder = vehicleBuilder;
        _builder.BuildFrame();
        _builder.BuildEngine();
        _builder.BuildWheels();
        _builder.BuildDoors();
    }
    public void ShowVehicle()
    {
        _builder?.Vehicle.Show();
    }
}

/**
 * - 추상화된 공통 빌더 인터페이스
 */
public abstract class VehicleBuilder(VehicleType vehicleType)
{
    public Vehicle Vehicle { get; private set; } = new Vehicle(vehicleType);
    public abstract void BuildFrame();
    public abstract void BuildEngine();
    public abstract void BuildWheels();
    public abstract void BuildDoors();
}

/**
 * - 빌더 구현체 (모터사이클)
 */
public class MotorCycleBuilder : VehicleBuilder
{
    public MotorCycleBuilder() : base(VehicleType.MotorCycle)
    {
    }
    
    public override void BuildFrame() => Vehicle[PartType.Frame] = "MotorCycle Frame";
    public override void BuildEngine() => Vehicle[PartType.Engine] = "500 cc";
    public override void BuildWheels() => Vehicle[PartType.Wheel] = "2";
    public override void BuildDoors() => Vehicle[PartType.Door] = "0";
}

/**
 * - 빌더 구현체 (자동차)
 */
public class CarBuilder : VehicleBuilder
{
    public CarBuilder() : base(VehicleType.Car)
    {
    }
    
    public override void BuildFrame() => Vehicle[PartType.Frame] = "Car Frame";
    public override void BuildEngine() => Vehicle[PartType.Engine] = "2500 cc";
    public override void BuildWheels() => Vehicle[PartType.Wheel] = "4";
    public override void BuildDoors() => Vehicle[PartType.Door] = "4";
}

/**
 * - 빌더 구현체 (스쿠터)
 */
public class ScooterBuilder : VehicleBuilder
{
    public ScooterBuilder() : base(VehicleType.Scooter)
    {
    }
    
    public override void BuildFrame() => Vehicle[PartType.Frame] = "Scooter Frame";
    public override void BuildEngine() => Vehicle[PartType.Engine] = "50 cc";
    public override void BuildWheels() => Vehicle[PartType.Wheel] = "2";
    public override void BuildDoors() => Vehicle[PartType.Door] = "0";
}

/**
 * - 운송수단 클래스
 * - 차량의 타입과 각각의 부품의 세부 정보를 관리
 */
public class Vehicle(VehicleType vehicleType)
{
    private readonly Dictionary<PartType, string> parts = [];
    private readonly VehicleType vehicleType = vehicleType;
    public string this[PartType key]
    {
        get => parts[key];
        set => parts[key] = value; 
    }
    
    public void Show()
    {
        Console.WriteLine("\n---------------------------");
        Console.WriteLine($"Vehicle Type: {vehicleType}");
        Console.WriteLine($" Frame  : {this[PartType.Frame]}");
        Console.WriteLine($" Engine : {this[PartType.Engine]}");
        Console.WriteLine($" #Wheels: {this[PartType.Wheel]}");
        Console.WriteLine($" #Doors : {this[PartType.Door]}");
    }
}

/**
 * - 운송 수단 부품
 */
public enum PartType
{
    Frame,
    Engine,
    Wheel,
    Door
}

/**
 * - 운송 수단 종류
 */
public enum VehicleType
{
    Car,
    Scooter,
    MotorCycle
}
