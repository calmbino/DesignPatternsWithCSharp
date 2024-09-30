/**
 * - 현재 FileExporter는 CSV 파일 내보내기만 가능하다.
 * - 하지만 추후에 JSON 또는 EXCEL과 같은 다양한 형식의 파일 내보내기가 필요하다면?
 * - FileExporter에 ExportToJson과 같이 새로운 메소드를 추가할 수 있다.
 * - 그러나 기존 클래스를 수정하게 되므로 OCP를 위반하게 된다.
 * - 또한, 여러 파일 형식에 대해 모두 책임을 지는 상황이 되므로 SRP도 위반하게 된다.
 */
public class FileExporter
{
    public void ExportToCsv(string filePath, DataTable data)
    {
        // Code to export data to a CSV file.
    }
}