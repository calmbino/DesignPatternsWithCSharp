/**
 * - 추상화 계층을 도입하여 상위 모듈과 하위 모듈의 의존 관계 방향을 바꿨다.
 * -- 전) UserController -> Database
 * -- 후) UserController -> IDataStorage <- Database
 * - 즉 상위 모듈과 하위 모듈 모두 추상화에 의존하게 됐다
 * - 그리고 세부 사항(Database)이 추상화에 의존해야 한다는 조건도 부합한다.
 * - 하위 모듈을 새로 추가하거나 수정하는 작업을 하더라도 상위 모듈은 변경할 필요가 없다. 
 */
public interface IDataStorage
{
    // Define the contract for data storage operations.
    void SaveData(string data);
    string RetrieveData();
}

public class Database : IDataStorage
{
    public void SaveData(string data)
    {
        // Implementation for saving data to a database.
    }
    public string RetrieveData()
    {
        // Implementation for retrieving data from a database.
    }
}

public class UserController
{
    private IDataStorage dataStorage;
    public UserController(IDataStorage dataStorage)
    {
        this.dataStorage = dataStorage;
    }
    // ...
}