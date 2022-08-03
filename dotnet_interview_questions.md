
### 1. How does the .NET framework work?

- .NET framework-based applications that are written in supportive languages like C#, F#, or Visual basic are compiled to Common Intermediate Language (CIL).
- Compiled code is stored in the form of an assembly file that has a .dll or .exe file extension.
- When the .NET application runs, Common Language Runtime (CLR) takes the assembly file and converts the CIL into machine code with the help of the Just In Time(JIT) compiler.
- Now, this machine code can execute on the specific architecture of the computer it is running on.


### 2. Сложность алгоритма добавления элемента в List и LinkedList. От чего зависит

- **List**
  Если **Count** значение меньше **Capacity**, этот метод является операцией **O(1)**. Если емкость должна быть увеличена для размещения нового элемента, этот метод становится операцией **O(n)**, где n — Count.
  > https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.generic.list-1.add?view=net-6.0

- **LinkedList**
  Всегда O(1)
  > https://docs.microsoft.com/ru-ru/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0


### 3. IEnumerable vs IQueryable

**IEnumerable in C#:**
1. IEnumerable is an interface that is available in the System.Collections namespace.
2. While querying the data from the database, the IEnumerable executes the “select statement” on the server-side (i.e. on the database), loads data into memory on the client-side, and then only applied the filters on the retrieved data.
3. So you need to use the IEnumerable when you need to query the data from in-memory collections like List, Array, and so on.
4. The IEnumerable is mostly used for LINQ to Object and LINQ to XML queries.
5. The IEnumerable collection is of type forward only. That means it can only move in forward, it can’t move backward and between the items.
6. IEnumerable supports deferred execution.
7. It doesn’t support custom queries.
8. The IEnumerable doesn’t support lazy loading. Hence, it is not suitable for paging-like scenarios.

**IQueryable in C#:**
1. The IQueryable is an interface that exists in the System.Linq Namespace.
2. While querying the data from a database, the IQueryable executes the “select query” with the applied filter on the server-side i.e. on the database and then retrieves data.
3. So you need to use the IQueryable when you want to query the data from out-memory such as remote database, service, etc.
4. IQueryable is mostly used for LINQ to SQL and LINQ to Entities queries.
5. The collection of type IQueryable can move only forward, it can’t move backward and between the items.
6. IQueryable supports deferred execution.
7. It also supports custom queries using CreateQuery and Executes methods.
8. IQueryable supports lazy loading and hence it is suitable for paging-like scenarios.

> https://dotnettutorials.net/lesson/differences-between-ienumerable-and-iqueryable/


### 4. Server-side pagination with EntityFramework and raw SQL

1. EntityFramework - DbContext.DbSet.Skip(a).Take(b)
   
2. Raw SQL
   1. LIMIT(a) OFFSET(b) - **MySQL/PosetgreSQL**
   2. OFFSET (a) ROWS FETCH FIRST (b) ROWS ONLY - **MSSQL**

### 5.Уровни изоляции транзакций, какие проблемы решают  

1. **read uncommitted**  
   все проблемы присутствуют

2. **read committed**  
   решает dirty-read

3. **repeatable read**  
   решает dirty-read + non-repeateble-read

4. **serializable**  
   решает dirty-read + non-repeateble-read + phantom-read

> https://habr.com/ru/post/469415/
> https://ru.wikipedia.org/wiki/%D0%A3%D1%80%D0%BE%D0%B2%D0%B5%D0%BD%D1%8C_%D0%B8%D0%B7%D0%BE%D0%BB%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%BD%D0%BE%D1%81%D1%82%D0%B8_%D1%82%D1%80%D0%B0%D0%BD%D0%B7%D0%B0%D0%BA%D1%86%D0%B8%D0%B9


### 6.Оконные функции SQL

**Оконная функция в SQL** - функция, которая работает с выделенным набором строк (окном, партицией) и выполняет вычисление для этого набора строк в отдельном столбце. 

**Партиции (окна из набора строк)** - это набор строк, указанный для оконной функции по одному из столбцов или группе столбцов таблицы. Партиции для каждой оконной функции в запросе могут быть разделены по различным колонкам таблицы.

При использовании агрегирующих функций предложение **GROUP BY** сокращает количество строк в запросе с помощью их группировки.

При использовании оконных функций количество строк в запросе не уменьшается по сравнении с исходной таблицей.

Классы оконных функций:

- **Агрегирующие** (Aggregate)  
- **Ранжирующие** (Ranking)  
- **Функции смещения** (Value)  

> https://habr.com/ru/post/664000/


### 7. Триггеры SQL

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


### 8. Функции и хранимые процедуры SQL, применение и отличия

|   Функция	|   Хранимая процедура	|
|:-:	|:-:	|
|  Функция должна возвращать значение 	|   Хранимая процедура может как возвращать, так и не возвращать значение.	|
|   Функции не могут возвращать несколько результирующих наборов	|  Хранимая процедура может сформировать и вернуть несколько результирующих наборов данных 	|
|  Функции можно использовать в операторе SELECT 	|  Процедуры нельзя использовать в операторе SELECT и во всех его секциях (WHERE, JOIN, HAVING и т.д.), так как процедуры вызываются с помощью команды EXECUTE или EXEC 	|
|  В функциях можно использовать только оператор SELECT на выборку данных, операторы DML (INSERT, UPDATE, DELETE) для модификации данных использовать нельзя 	|  В хранимых процедурах можно использовать оператор SELECT, а также операторы DML (INSERT, UPDATE, DELETE) для модификации данных 	|
|   Из функции нельзя вызвать хранимые процедуры	|   В хранимых процедурах можно вызывать и функции, и другие хранимые процедуры	|
|  Конструкцию для обработки ошибок TRY CATCH нельзя использовать в функциях. Так же как нельзя использовать инструкцию RAISERROR 	|   В хранимых процедурах можно использовать и конструкцию TRY CATCH, и инструкцию RAISERROR	|
|   В функциях запрещено использование транзакций	|  В хранимых процедурах транзакции разрешены 	|
|   В функциях можно использовать только табличные переменные, временные таблицы использовать не получится	|   В хранимых процедурах можно использовать как табличные переменные, так и временные таблицы	|
|  В функциях нельзя использовать динамический SQL 	|   В процедурах можно использовать динамический SQL	|
|  В функциях можно использовать только входные параметры 	|   В хранимых процедурах можно использовать как входные, так и выходные параметры	|

> https://info-comp.ru/differences-between-functions-and-procedures-in-t-sql


### 9. lock под капотом, почему нельзя await

код, написанный между вызовами Monitor.Enter и Monitor.Exit на одном ресурсе может быть выполнен в один момент времени лишь одним потоком. Оператор lock является синтаксическим сахаром вокруг вызовов Enter/Exit обернутых в try-finally.

внутри оператора lock нельзя использовать оператор await, код после await совершенно не обязательно будет выполнен на том же потоке, что и код до await, это зависит от контекста синхронизации и наличия или отсутствия вызова ConfigureAwait. Из этого следует, что Monitor.Exit может выполниться на потоке отличном от Monitor.Enter, что приведет к выбросу **SynchronizationLockException**.

> https://habr.com/ru/post/459514/


### 10. Saga pattern, способы координации саг

Сага представляет собой набор локальных транзакций. Каждая локальная транзакция обновляет базу данных и публикует сообщение или событие, инициируя следующую локальную транзакцию в саге. Если транзакция завершилась неудачей, например, из-за нарушения бизнес правил, тогда сага запускает компенсирующие транзакции, которые откатывают изменения, сделанные предшествующими локальными транзакциями.

Существует два способа координации саг:


- **Хореография (Choreography)** — каждая транзакция публикует события, которые запускают транзакции в других сервисах.
- **Оркестрация (Orchestration)** — оркестратор говорит участникам, какие транзакции должны быть запущены.

Сага имеет следующие преимущества

- Позволяет приложению поддерживать согласованность данных между сервисами без использования распределенных транзакций.

Сага имеет следующие недостатки

- Модель программирования становится более сложной. Например, разработчики должны проектировать компенсирующие транзакции, которые отменяют изменения, сделанные ранее в саге.

> https://habr.com/ru/post/427705/


### 11. Способы конфигурации моделей и сущностей при подходе code-first в EF

- **Code convention**
- **DataAnnotation**
- **Fluent API**

> https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/conventions/built-in
> https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/conventions/custom
> https://www.ecanarys.com/Blogs/ArticleID/228/Entity-Framework-CodeFirst-Approach


### 12. Процесс сборки мусора, этапы

**Этап маркировки**

Во время этого этапа CLR должна найти все живые объекты.


Преимущество сборщика с поддержкой поколений заключается в его способности убирать мусор только в части кучи, вместо того, чтобы всё время наблюдать за всеми объектами. Собирая мусор в эфемерных поколениях, сборщик должен получить у среды исполнения информацию о том, какие объекты в этих поколениях по-прежнему используются программой. Кроме того, объекты в старших поколениях могут использовать объекты в младших поколениях, ссылаясь на них.


Чтобы пометить старые объекты, ссылающиеся на новые, сборщик мусора использует специальные биты. Биты устанавливаются механизмом JIT-компилятора во время операций присвоения. Если объект принадлежит к эфемерному поколению, JIT-компилятор установит байт, содержащий бит, указывающий на исходное положение. Собирая мусор в эфемерных поколениях, сборщик может использовать эти биты для всей оставшейся кучи и просмотреть только те объекты, которым эти биты соответствуют.


**Этап планирования**

На этом этапе моделируется сжатие, чтобы определить его эффективность. Если результат оказывается продуктивным, сборщик начинает фактическое сжатие. В противном случае он просто производит уборку.


**Этап перемещения**

Если сборщик выполняет сжатие, это приведёт к перемещению объектов. В этом случае необходимо обновить ссылки на эти объекты. Во время этапа перемещения сборщик должен найти все ссылки, указывающие на объекты в тех поколениях, где проводится сборка мусора. Напротив, во время стадии маркировки сборщик помечает только живые объекты, поэтому ему не нужно рассматривать слабые ссылки.


**Этап сжатия**

Этот этап достаточно прост, поскольку сборщик уже определил новые адреса для перемещения объектов во время этапа планирования. При сжатии объекты будут скопированы по этим адресам.


**Этап уборки**

Во время этого этапа сборщик ищет неиспользуемое пространство между живыми объектами. Вместо этого пространства он создаёт свободные объекты. Неиспользуемые объекты, находящиеся рядом, становятся одним свободным объектом. Все свободные объекты помещаются в список свободных объектов.

> https://habr.com/ru/company/clrium/blog/463293/


### 13. Action Filters

An action filter is an attribute that you can apply to a controller action -- or an entire controller -- that modifies the way in which the action is executed.

You also can create your own custom action filters. For example, you might want to create a custom action filter in order to implement a custom authentication system. Or, you might want to create an action filter that modifies the view data returned by a controller action.

The ASP.NET MVC framework supports four different types of filters:

1. **Authorization filters** – Implements the IAuthorizationFilter attribute.
2. **Action filters** – Implements the IActionFilter attribute.
3. **Result filters** – Implements the IResultFilter attribute.
4. **Exception filters** – Implements the IExceptionFilter attribute.


### 14. Git Merge vs Git Rebase

**Способ слияния (merge)**

Слияние (merge) — это отличная неразрушающая операция. Существующие ветки никак не изменяются. Эта операция позволяет избегать потенциальных проблем, связанных с выполнением команды rebase.

С другой стороны, это означает, что каждый раз, когда вам будет необходимо включить вышестоящие изменения, в функциональную ветку feature будет попадать внешний коммит слияния. Если работа в главной ветке main ведется активно, история вашей функциональной ветки быстро засорится. Хотя эту проблему можно устранить, используя продвинутые варианты команды git log, другим разработчикам будет тяжело разобраться в истории проекта.

**Способ перебазирования (rebase)**

Если вместо команды merge при коммитах используется rebase, эта команда перезаписывает историю проекта, создавая новые коммиты для каждого коммита в исходной ветке.

> https://www.edureka.co/blog/git-rebase-vs-merge/#:~:text=Git%20Merge%20Vs%20Git%20Rebase%3A&text=Git%20merge%20is%20a%20command,of%20the%20merging%20of%20commits.
> https://www.atlassian.com/ru/git/tutorials/merging-vs-rebasing


### 15. Что выведет?

Console.WriteLine(~1);
Console.WriteLine(6 ^ 2);

> -2
> 4


### 16. Принудительное завершение Task

The Task class supports cooperative cancellation and is fully integrated with the System.Threading.CancellationTokenSource and System.Threading.CancellationToken classes, which were introduced in the .NET Framework 4. Many of the constructors in the System.Threading.Tasks.Task class take a CancellationToken object as an input parameter. Many of the StartNew and Run overloads also include a CancellationToken parameter.

You can create the token, and issue the cancellation request at some later time, by using the CancellationTokenSource class. Pass the token to the Task as an argument, and also reference the same token in your user delegate, which does the work of responding to a cancellation request.

> https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming


