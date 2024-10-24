using System.Text.Json;
using System.Threading.Channels;

namespace Prototype.RealWorld;

class Program
{
    static void Main(string[] args)
    {
        var manager = new ColorManager();
        
        // 표준 색상 추가
        manager[ColorType.Red] = new Color { Red = 255, Blue = 0, Green = 0 };
        manager[ColorType.Green] = new Color { Red = 0, Blue = 255, Green = 0 };
        manager[ColorType.Blue] = new Color { Red = 0, Blue = 0, Green = 255 };
        
        // 커스텀 색상 추가
        manager[ColorType.Angry] = new Color { Red = 255, Blue = 54, Green = 0 };
        manager[ColorType.Peace] = new Color { Red = 128, Blue = 211, Green = 128 };
        manager[ColorType.Flame] = new Color { Red = 211, Blue = 34, Green = 20 };
        
        // 필요할 땐 복사된 색상 객체를 사용
        _ = manager[ColorType.Red].Clone();
        _ = manager[ColorType.Peace].Clone();
        _ = manager[ColorType.Flame].Clone(false); // 깊은 복사

    }
}

/**
 * - 객체 복사를 위한 프로토타입 인터페이스
 * - .net에는 기본적으로 ICloneable이라는 인터페이스가 존재
 * - https://learn.microsoft.com/ko-kr/dotnet/api/system.icloneable?view=net-8.0
 */
public interface ICloneableObject: ICloneable
{
    object Clone();
}

/**
 * - 프로토타입 구현 클래스
 */
public class Color : ICloneableObject
{
    public byte Red { get; set; }
    public byte Green { get; set; }
    public byte Blue { get; set; }
    
    // shallow 여부에 따라 얕은 또는 깊은 복사 수행
    public object? Clone(bool shallow)
    {
        return shallow ? Clone() : DeepCopy();
    }
    
    // 얕은 복사
    public object Clone()
    {
        Console.WriteLine(
            "Shallow copy of color RGB: {0,3},{1,3},{2,3}",
            Red, Green, Blue);
        
        // 값 형식의 데이터는 깊은 복사가 되지만, 참조 형식의 데이터는 얕은 복사가 수행된다.
        return MemberwiseClone();
    }
    
    // 깊은 복사
    // 일반적으로 new를 이용하여 새로운 객체를 생성하는 방법이 있지만, 새로운 filed가 추가될 때마다 해당 메소드도 수정해야하는 불편함이 존재한다.
    // 또다른 방법으론 직렬화/역직렬화를 통해 깊은 복사(deep copy)를 수행하는 방법이 있다.
    // "직렬화"는 객체의 상태를 저장하거나 전송할 수 있도록 객체를 연속적인 바이트로 변환하는 과정이다.
    // 이때 객체의 모든 필드 데이터가 직렬화되며, 참조 타입(객체 속성)도 함께 직렬화 된다. 즉, 객체의 구조와 상태를 완전히 기록하는 것과 같다.
    // "역직렬화"는 직렬화된 바이트 스트림을 다시 원래의 객체 상태로 복원하는 과정이다.
    // 이 과정에서 객체의 필드와 속성들이 직렬화된 데이터에 따라 새로운 메모리 공간에 할당된다. 즉, 이전 객체와 동일한 구조와 데이터를 가진 새로운 객체가 생성된다.
    public object? DeepCopy()
    {
        var serialized = JsonSerializer.Serialize(this); // 해당 인스턴스를 직렬화
        var copy = JsonSerializer.Deserialize<Color>(serialized); // 직렬화된 인스턴스를 다시 역직렬화
        
        if (copy is not null)
        {
            Console.WriteLine(
                "*Deep* copy of color RGB: {0,3},{1,3},{2,3}",
                (copy as Color).Red, (copy as Color).Green, (copy as Color).Blue
            );
        }
        
        return copy;
    }
}

/**
 * - 컬러 클래스의 프로토타입 관리 클래스
 */
public record ColorManager
{
    private readonly Dictionary<ColorType, Color> _colors = [];

    // 인덱서
    public Color this[ColorType type]
    {
        get => _colors[type]; 
        set => _colors.Add(type, value); 
    }
}

/**
 * - 색상 종류를 정의하기 위한 Enum 타입
 */
public enum ColorType
{
    Red,
    Green,
    Blue,
    Angry,
    Peace,
    Flame
}