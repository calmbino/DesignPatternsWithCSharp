/**
 * - UserController 클래스는 (concrete, 구체적인)Database 클래스와 강하게 결합하여 직접적인 의존성(dependency)을 생성한다.
 * - 기존 데이터베이스 구현을 수정하거나 새로운 데이터베이스를 도입하기로 했다면, UserController 클래스도 함께 수정해야 한다.
 * - 또한 OCP(개방-폐쇄 원칙)을 위반하게 된다.
 */
public class UserController
{
    private Database database;
    public UserController()
    {
        this.database = new Database();
    }
    // ...
}