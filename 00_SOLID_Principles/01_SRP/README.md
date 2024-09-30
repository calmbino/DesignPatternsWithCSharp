# Single Responsibility Principle (단일 책임 원칙)

## What?
> _“A class should only have a single responsibility, that is, only changes to one part of the software’s specification should be able to affect the specification of the class.” -Robert C. Martin_
- 클래스는 한 가지 이유로만 변경되어야 한다.
- 즉 클래스는 전체 프로그램에서 하나의 책임(목적, 업무, 기능..)만 가지며, 그 책임을 완전히 캡슐화해서 클래스 내부에 숨겨야 한다.

## Why?
- 클래스가 가지는 역할이 명확해지므로, 코드의 **복잡성은 줄어**들고 **가독성은 향상**된다.
- 클래스가 한 가지 관심사에만 집중하면 **변경의 이유가 명확**하여 **코드 수정 범위가 줄어**들고 그만큼 **수정에 따른 부작용도 함께 감소**한다.
- 독립적인 단위 테스트 작성이 가능해지므로 **테스트가 용이**해진다.
- 클래스간 의존성이 줄어들어 **결합도가 낮아**지므로 **변경에 민감하지 않은 구조**로 만들 수 있다.
