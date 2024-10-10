namespace FactoryMethod_RealWorld;

class Program
{
    static void Main(string[] args)
    {
        // Document Creator의 구현체들을 인스턴스화
        List<Document> documents = [new Resume(), new Report()];
        
        foreach (var document in documents)
        {
            document.CreatePages();  // 각 Document의 팩토리 메서드 호출
            Console.WriteLine($"{document} --");
            foreach (var page in document.Pages) Console.WriteLine($" {page}");
            Console.WriteLine();
        }

        Console.ReadKey();
    }
    
    /**
     * - Product를 추상화한 클래스
     */
    public abstract class Page
    {
        public override string ToString() => GetType().Name;
    }

    public class SkillsPage : Page
    {
    }

    public class EducationPage : Page
    {
    }

    public class ExperiencePage : Page
    {
    }

    public class IntroductionPage : Page
    {
    }
 
    public class ResultsPage : Page
    {
    }

    public class ConclusionPage : Page
    {
    }

    public class SummaryPage : Page
    {
    }

    public class BibliographyPage : Page
    {
    }

    /**
     * - Creator를 추상화한 클래스
     */
    public abstract class Document
    {
        public List<Page> Pages { get; protected set; } = null!;
        
        // 팩토리 메서드
        public abstract void CreatePages();
        
        public override string ToString() => GetType().Name;
    }

    public class Resume : Document
    {
        public override void CreatePages()
        {
            Pages =
            [
                new SkillsPage(),
                new EducationPage(),
                new ExperiencePage()
            ];
        }
    }

    public class Report : Document
    {
        public override void CreatePages()
        {
            Pages =
            [
                new IntroductionPage(),
                new ResultsPage(),
                new ConclusionPage(),
                new SummaryPage(),
                new BibliographyPage()
            ];
        }
    }
}