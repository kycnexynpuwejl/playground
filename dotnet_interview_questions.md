
### 1.Уровни изоляции транзакций, какие проблемы решают  

1. read uncommitted  
   все проблемы присутствуют

2. read committed  
   решает dirty-read

3. repeatable read  
   решает dirty-read + non-repeateble-read

4. serializable  
   решает dirty-read + non-repeateble-read + phantom-read

> https://habr.com/ru/post/469415/

### 2.Оконные функции SQL

***Оконная функция в SQL*** - функция, которая работает с выделенным набором строк (окном, партицией) и выполняет вычисление для этого набора строк в отдельном столбце. 

***Партиции (окна из набора строк)*** - это набор строк, указанный для оконной функции по одному из столбцов или группе столбцов таблицы. Партиции для каждой оконной функции в запросе могут быть разделены по различным колонкам таблицы.

При использовании агрегирующих функций предложение ***GROUP BY*** сокращает количество строк в запросе с помощью их группировки.

При использовании оконных функций количество строк в запросе не уменьшается по сравнении с исходной таблицей.

Классы оконных функций:

-Агрегирующие (Aggregate)  
-Ранжирующие (Ranking)  
-Функции смещения (Value)  

> https://habr.com/ru/post/664000/

### 3. IEnumerable vs IQueryable

***IEnumerable in C#:***
1. IEnumerable is an interface that is available in the System.Collections namespace.
2. While querying the data from the database, the IEnumerable executes the “select statement” on the server-side (i.e. on the database), loads data into memory on the client-side, and then only applied the filters on the retrieved data.
3. So you need to use the IEnumerable when you need to query the data from in-memory collections like List, Array, and so on.
4. The IEnumerable is mostly used for LINQ to Object and LINQ to XML queries.
5. The IEnumerable collection is of type forward only. That means it can only move in forward, it can’t move backward and between the items.
6. IEnumerable supports deferred execution.
7. It doesn’t support custom queries.
8. The IEnumerable doesn’t support lazy loading. Hence, it is not suitable for paging-like scenarios.

***IQueryable in C#:***
1. The IQueryable is an interface that exists in the System.Linq Namespace.
2. While querying the data from a database, the IQueryable executes the “select query” with the applied filter on the server-side i.e. on the database and then retrieves data.
3. So you need to use the IQueryable when you want to query the data from out-memory such as remote database, service, etc.
4. IQueryable is mostly used for LINQ to SQL and LINQ to Entities queries.
5. The collection of type IQueryable can move only forward, it can’t move backward and between the items.
6. IQueryable supports deferred execution.
7. It also supports custom queries using CreateQuery and Executes methods.
8. IQueryable supports lazy loading and hence it is suitable for paging-like scenarios.

> https://dotnettutorials.net/lesson/differences-between-ienumerable-and-iqueryable/

### 4. Триггеры SQL

Триггеры представляют специальный тип хранимой процедуры, которая вызывается автоматически при выполнении определенного действия над таблицей или представлением, в частности, при добавлении, изменении или удалении данных, то есть при выполнении команд INSERT, UPDATE, DELETE.

Формальное определение триггера:

> CREATE TRIGGER имя_триггера  
> ON {имя_таблицы | имя_представления}  
> {AFTER | INSTEAD OF} [INSERT | UPDATE | DELETE]  
> AS выражения_sql  

Для создания триггера применяется выражение CREATE TRIGGER, после которого идет имя триггера. Как правило, имя триггера отражает тип операций и имя таблицы, над которой производится операция.

Каждый триггер ассоциируется с определенной таблицей или представлением, имя которых указывается после слова ON.

Затем устанавливается тип триггера. Мы можем использовать один из двух типов:

AFTER: выполняется после выполнения действия. Определяется только для таблиц.

INSTEAD OF: выполняется вместо действия (то есть по сути действие - добавление, изменение или удаление - вообще не выполняется). Определяется для таблиц и представлений

> https://metanit.com/sql/sqlserver/12.1.php

### 5. Server-side pagination with EntityFramework and raw SQL

1. EntityFramework - dbSet.Skip(a).Take(b)
   
2. Raw SQL
   1. LIMIT(a) OFFSET(b) - **MySQL/PosetgreSQL**
   2. OFFSET (a) ROWS FETCH FIRST (b) ROWS ONLY - **MSSQL**

### 6. How does the .NET framework work?

- .NET framework-based applications that are written in supportive languages like C#, F#, or Visual basic are compiled to Common Intermediate Language (CIL).
- Compiled code is stored in the form of an assembly file that has a .dll or .exe file extension.
- When the .NET application runs, Common Language Runtime (CLR) takes the assembly file and converts the CIL into machine code with the help of the Just In Time(JIT) compiler.
- Now, this machine code can execute on the specific architecture of the computer it is running on.

### 7. Differences between value type and reference type

- A Value Type holds the actual data directly within the memory location and a reference type contains a pointer which consists of the address of another memory location that holds the actual data.
- Value type stores its contents on the stack memory and reference type stores its contents on the heap memory.
- Assigning a value type variable to another variable will copy the value directly and assigning a reference variable to another doesn’t copy the value, instead, it creates a second copy of the reference.
- Predefined data types, structures, enums are examples of value types. Classes, Objects, Arrays, Indexers, Interfaces, etc are examples of reference types.

### 8. SOLID

- single responsibility principle
  > для каждого класса должно быть определено единственное назначение. Все ресурсы, необходимые для его осуществления, должны быть инкапсулированы в этот класс и подчинены только этой задаче
- open-closed principle
  > программные сущности … должны быть открыты для расширения, но закрыты для модификации
- Liskov substitution principle
  > функции, которые используют базовый тип, должны иметь возможность использовать подтипы базового типа не зная об этом
- interface segregation principle
  > много интерфейсов, специально предназначенных для клиентов, лучше, чем один интерфейс общего назначения
- dependency inversion principle
  > зависимость на абстракциях, нет зависимости на что-то конкретное