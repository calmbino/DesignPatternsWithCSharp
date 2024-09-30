/**
 * - 새로운 요구사항 및 기능을 추가할 때는 기존 클래스를 수정하지 않고 확장할 수 있는 구조여야 한다.
 * - 인터페이스(Interface)나 추상 클래스(Abstract Class)를 활용한 다형성을 통해 설계하는 것이 좋다.
 * - 새로운 형식의 파일 내보내기가 필요하다면 FileExporter 클래스를 상속하여 Export 메소드를 구현하기만 하면 된다.
 * - 이처럼 추상화된 개념에 의존하면 수정에 대해서는 폐쇄적이고, 추상화의 새로운 파생 클래스를 만드는 것으로 확장에 열려 있다.
 */
public abstract class FileExporter
{
    public abstract void Export(string filePath, DataTable data);
}
public class CsvFileExporter : FileExporter
{
    public override void Export(string filePath, DataTable data)
    {
        // Code logic to export data to a CSV file.
    }
}
public class ExcelFileExporter : FileExporter
{
    public override void Export(string filePath, DataTable data)
    {
        // Code logic to export data to an Excel file.
    }
}
public class JsonFileExporter : FileExporter
{
    public override void Export(string filePath, DataTable data)
    {
        // Code logic to export data to a JSON file.
    }
}