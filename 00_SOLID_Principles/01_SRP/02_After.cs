/**
 * - 책임을 나누어 개별 클래스로 분리한다.
 * - 유지보수와 테스트가 용이하다.
 * - 수정 및 확장이 보다 쉬워졌다.
 */
public class UserValidator
{
    public bool ValidateEmail(string email)
    {
        // Validation logic
    }
}

public class UserRepository
{
    public void SaveUser(string username, string email, string password)
    {
        // Database persistence logic
    }
}

public class UserCreator
{
    private readonly UserValidator _validator;
    private readonly UserRepository _repository;
    
    public UserCreator(UserValidator validator, UserRepository repository)
    {
        _validator = validator;
        _repository = repository;
    }
    
    public void CreateUser(string username, string email, string password)
    {
        if (!_validator.ValidateEmail(email))
        {
            throw new ArgumentException("Invalid email format.");
        }
        // Business rules
        _repository.SaveUser(username, email, password);
    }
}