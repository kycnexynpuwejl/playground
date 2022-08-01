
### 1.Уровни изоляции транзакций, какие проблемы решают  

1. read uncommitted
   все проблемы присутствуют

2. read committed
   решает проблему dirty-read

3. repeatable read
   решает проблемы dirty-read + repeateble-read

4. serializable
   решает все вышеперечисленные + фантомы

> https://habr.com/ru/post/469415/