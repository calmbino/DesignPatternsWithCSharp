namespace Adapter.RealWorld;

public class Program
{
    public static void Main()
    {
        // Non-adapted chemical compound 
        var unknown = new Compound();
        unknown.Display();
        
        // Adapted chemical compounds
        var water = new RichCompound(Chemical.Water);
        water.Display();
        var benzene = new RichCompound(Chemical.Benzene);
        benzene.Display();
        var ethanol = new RichCompound(Chemical.Ethanol);
        ethanol.Display();
        
        // Wait for user
        Console.ReadKey();
    }
}

/// <summary>
/// 'Target' 클래스.
/// 클라이언트가 기대하는 인터페이스를 정의한다.
/// </summary>
public class Compound
{
    public Chemical Chemical { get; protected set; }
    public float BoilingPoint { get; protected set; } // 끊는 점
    public float MeltingPoint { get; protected set; } // 녹는 점
    public double MolecularWeight { get; protected set; } // 분자량
    public string? MolecularFormula { get; protected set; } // 분자구조
    
    public virtual void Display()
    {
        Console.WriteLine("\nCompound: Unknown ------ ");
    }
}

/// <summary>
/// 'Adapter' 클래스.
/// Target인 Compound를 상속받아 Adaptee의 기능을 Target 인터페이스에 맞게 변환한다.
/// 내부적으로 ChemicalDatabank를 사용해 데이터를 조회하고,
/// 이를 Target 인터페이스(Compound.DisPlay())에 맞게 변환한다.
/// </summary>
public class RichCompound : Compound
{
    // Adaptee
    private readonly ChemicalDatabank bank = new();
    
    // Constructor
    public RichCompound(Chemical chemical)
    {
        Chemical = chemical;
    }
    
    // 클라이원트가 원하는 인터페이스.
    // 화학 데이터 베이스(ChemicalDatabank)의 정보를
    // 클라이언트가 원하는 방식으로 사용할 수 있도록 Adapter 역할을 수행한다.
    public override void Display()
    {
        // Adaptee request methods
        BoilingPoint = bank.GetCriticalPoint(Chemical, State.Boiling);
        MeltingPoint = bank.GetCriticalPoint(Chemical, State.Melting);
        MolecularWeight = bank.GetMolecularWeight(Chemical);
        MolecularFormula = bank.GetMolecularStructure(Chemical);
        
        Console.WriteLine($"\nCompound: { Chemical} ------ ");
        Console.WriteLine($" Formula: {MolecularFormula}");
        Console.WriteLine($" Weight : {MolecularWeight}");
        Console.WriteLine($" Melting Pt: {MeltingPoint}");
        Console.WriteLine($" Boiling Pt: {BoilingPoint}");
    }
}

/// <summary>
/// 'Adaptee' 클래스. (기존의 데이터베이스 또는 라이브러리)
/// 화합물 데이터(화학적 성질)을 제공한다.
/// 그러나 클라이언트 Chemical에 대한 정보들을 표시하고 싶지만,
/// ChemicalDatabank에는 해당 기능을 제공하지 않는다.
/// </summary>
public class ChemicalDatabank
{
    // The databank 'legacy API'
    public float GetCriticalPoint(Chemical compound, State point)
    {
        // Melting Point
        if (point == State.Melting)
        {
            return compound switch
            {
                Chemical.Water => 0.0f,
                Chemical.Benzene => 5.5f,
                Chemical.Ethanol => -114.1f,
                _ => 0f,
            };
        }
        // Boiling Point
        else
        {
            return compound switch
            {
                Chemical.Water => 100.0f,
                Chemical.Benzene => 80.1f,
                Chemical.Ethanol => 78.3f,
                _ => 0f,
            };
        }
    }
    
    public string GetMolecularStructure(Chemical compound)
    {
        return compound switch
        {
            Chemical.Water => "H20",
            Chemical.Benzene => "C6H6",
            Chemical.Ethanol => "C2H5OH",
            _ => "",
        };
    }
    
    public double GetMolecularWeight(Chemical compound)
    {
        return compound switch
        {
            Chemical.Water => 18.015d,
            Chemical.Benzene => 78.1134d,
            Chemical.Ethanol => 46.0688d,
            _ => 0d
        };
    }
}

/// <summary>
/// Chemical enumeration
/// </summary>
public enum Chemical
{
    Water,
    Benzene,
    Ethanol
}

/// <summary>
/// State enumeration
/// </summary>
public enum State
{
    Boiling,
    Melting
}