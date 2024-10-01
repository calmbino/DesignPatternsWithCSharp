/**
 * - 클라이언트 클래스들(OnlineOrder, InStoreOrder)이 인터페이스(IOrder)를 구현했지만, 모든 메서드들이 필요한 것은 아니다.
 * - 클라이언트 클래스가 불필요한 메서드에 의존하게 됐으니, 이는 ISP를 위반한 것이다.
 */
public interface IOrder
{
    void PlaceOrder();
    void CancelOrder();
    void UpdateOrder();
    void CalculateTotal();
    void GenerateInvoice();
    void SendConfirmationEmail();
    void PrintLabel();
}

public class OnlineOrder : IOrder
{
    // Implementation of all methods.
}

public class InStoreOrder : IOrder
{
    // Implementation of all methods.
}