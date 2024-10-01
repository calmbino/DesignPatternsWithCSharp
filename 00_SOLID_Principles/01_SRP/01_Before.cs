/*
 * - UserCreator 클래스는 유효성 검사 및 데이터베이스 지속성과 같은 여러 가지 책임을 가졌기 때문에 SRP를 위반한다.
 * - 클래스가 긴밀하게 결합되어 테스트하기 어렵고 불필요한 수정이 발생하기 쉽다.
 */
public class UserCreator
{
    public void CreateUser(string username, string email, string password)
    {
        // Validation logic
        if (!ValidateEmail(email))
        {
            throw new ArgumentException("Invalid email format.");
        }
        // Business rules
        // Database persistence
        SaveUserToDatabase(username, email, password);
    }
    
    private bool ValidateEmail(string email)
    {
        // Validation logic
    }
    
    private void SaveUserToDatabase(string username, string email, string password)
    {
        // Database persistence logic
    }
}