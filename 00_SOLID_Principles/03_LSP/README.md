# Liskov Substitution Principle (리스코프 치환 법칙)

>_"Objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program."Robert c. Martin_

## What
- 상위 클래스(Super-class) 타입의 객체가 **하위 클래스(Sub-class) 타입의 객체로 대체**되더라도, **프로그램의 기능이 정상적으로 동작**해야 한다는 의미이다. 
- 즉 상위 클래스가 제공하는 메서드나 기능이 하위 클래에서도 동일하게 사용될 수 있어야 하며, 이를 통해 `다형성(Polymorphism)`이 자연스럽게 유지되도록 하는 것이다.

## Why?
- 하위 클래스를 상위 클래스 대신 사용할 때, **코드의 다른 부분에서 수정할 필요 없이 정상적으로 동작**하므로 유지보수가 용이하다.
- 하위 클래스는 상위 클래스의 모든 행동과 기능을 보존하기 때문에, 상위 클래스가 하위 클래스로 교체되더라도 **코드의 안정성을 보장**받을 수 있다.
- 즉 LSP를 준수하면 상위 클래스와 하위 클래스 간의 **대체 가능성을 보장**하여 **다형성을 안전하고 일관되게 활용**할 수 있고, 이를 통해 파생 클래스를 확장하는 과정에서 **기존 코드의 안정성을 유지하며 신뢰할 수 있는 프로그램**을 만들 수 있다.