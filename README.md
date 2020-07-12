# TestApplication
Тестовое задание для собеседования ASP.NET CORE WEB-API.
</br></br>
Для работы с реляционной базой данных DataBase СУБД SqlLie3 использован ОRM фреймворк Entity Framework в режиме CodeFirst.
За непосредственное взаимодействие с базой данных отвечает класс контекста ModelContext. 
Таблицам базы данных сопоставляются объекты классов Accounting, Category.
Для создания и изменения структуры БД использовался механизм миграций.
</br></br>
<h2> Описание команд</h2>

| URL | Описание | Пример отправляемых данны JSON           |
|----------------|:---------:|----------------|
|GET: api/Accountings |  Получение всех доходов/расходов |  |
|GET: api/Accountings/5 |  Получение дохода/расхода с ID=5 | |
|PUT: api/Accountings/5| Обновление данных дохода/расхода с ID=5|{<br>"Sum": 232,<br> "Description": "Описане расхода",<br> "CategoryId":2<br>}|
|POST: api/Accountings|Добавление нового дохода/расхода|{<br>"Sum": 232,<br> "Description": "Описане расхода",<br> "CategoryId":2<br>}|
|DELETE: api/Accountings/5|Удаление дохода/расхода с ID=5||
|POST: api/Accountings/report|Получение отчёта по доходам/расходам за указанный период|{<br>"DateTimeStart": "2019-07-01T21:25:46.0784198+03:00", <br>"DateTimeEnd": "2021-07-20T21:25:46.0784198+03:00",<br> "GroupByCategoryId":false, <br>"GroupByMonthNum":true<br>}|
|GET: api/Categories|Получение всех категорий||
|GET: api/Categories/5|Получение категории с ID=5||
|PUT: api/Categories/5|Обновление данных категории с ID=5|{<br>"name": "Category name"<br> }|
|POST: api/Categories|Добавление категории|{<br>"name": "Category name"<br> }|
|DELETE: api/Categories/5|Удаление категории с ID=5||

<br>

Формат получаеммых данных для отчёта описан в классе Question.<br>
Формат отправляемых данных описан в описан в классе GroupedReport.
