/**
 * - 인터페이스를 더 작고 집중된 인터페이스로 분리한다.
 * - 클라이언트 클래스는 필요한 기능에만 집중하면 구현할 수 있게 됐다.
 * - 불필요한 종속성을 업애고 확장성과 유지보수성을 향상 시킨다.
 * - 테스트 및 수정이 더 쉬운 깔끔한 코드가 됐다.
 */

인터페이스를 분리함으로써 이제 고객이 특정 요구사항에 따라 구현할 수 있는 더 작고 집중적인 인터페이스를 갖추게 되었습니다.
이러한 접근 방식은 불필요한 종속성을 없애고 확장성과 유지보수성을 향상시킵니다.
클라이언트는 필요한 인터페이스만 구현할 수 있으므로 이해, 테스트 및 수정이 더 쉬운 깔끔한 코드를 만들 수 있습니다.
    
public interface IOrder
{
    void PlaceOrder();
    void CancelOrder();
    void UpdateOrder();
}

public interface IOrderProcessing
{
    void CalculateTotal();
}

public interface IInvoiceGenerator
{
    void GenerateInvoice();
}

public interface IEmailSender
{
    void SendConfirmationEmail();
}

public interface ILabelPrinter
{
    void PrintLabel();
}

// Implement only the necessary interfaces in client classes.
public class OnlineOrder : IOrder, IOrderProcessing, IInvoiceGenerator, IEmailSender
{
    // Implementation of required methods.
}

public class InStoreOrder : IOrder, IOrderProcessing, ILabelPrinter
{
    // Implementation of required methods.
}