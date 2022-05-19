# MicroWebApp

Основным приложением является WebUI. Остальные на данный момент не используются.

Contollers:
- Home - стартовый
- Account - регистрация, логин, выход
- Roles - создание ролей, присоединение их к пользователям
- Bind - привязка/отвязка городов/домов от участков
- Все остальные - создание, изменение, удаление территориальных единиц и участков

Создание/изменение/удаление территориальных единиц:
![image](https://user-images.githubusercontent.com/48186612/169397580-fc97072e-e0d2-44c1-858a-f62ce7d11a43.png)
- пользователь обращается к странице нужной единицы
- заполняет поля
- js код оживляет select'ы и отвечает за отправку/получение данных через fetch
- сами страницы относятся к home контроллеру
- через fetch идёт обращение к api контроллерам, в которых реализованы интерфесы, через которые идёт обращение к репозиториям
- используется table.css для сдвига таблицы вправо и добавление ей скрола

Запросы:
- Get "api/{controller}" - получение всех единиц указанного типа
- Get "api/{controller}/{id}" - получение территории по Id
- Get "api/{controller}/{field}/{id}" - получение территорий по полю field со значением id (внутри делается через fromsqlrow) 
(если у территориальной единицы есть другие поля)
- Post "api/{controller}" + json нужного класса в body - добавление новой единицы, возвращает созданныый элемент
- Put "api/{controller}" + json нужного класса в body - изменение уже существующей единицы, возвращает изменённый элемент
- Delete "api/{controller}/{id}" - удаление элемента по Id, возвращает ResultOk в случае успеха

Только для city и house:
![image](https://user-images.githubusercontent.com/48186612/169403523-2c9f8f7f-f29a-424a-a028-685a0bf004eb.png)
- Put "api/{controller}/bind" + класс bindClasss в body - у всех ids устанавливает SpotId = bindClass.spotId
![image](https://user-images.githubusercontent.com/48186612/169403569-88c15a61-de4c-4962-9c1b-42a52e74c704.png)
- Put "api/{controller}/unbind" + класс unbindClasss в body - у всех ids устанавливает SpotId = NULL

Вопросы:
1) Logout у меня осуществляется через кнопку-форму, которая обращается к нужному методу контроллера account с токеном. 
Внешний вид кнопки несколько выбивается из внешнего вида ссылок на топ баре и я хз как исправить это т.к. банальное применение тех же стилей class="nav-link text-dark" эффекта не даёт.
2) Использовал в html атрибут required. С input работает нормально, а вот select у меня имеет значение по дефолту "selected disabled hidden" и required не срабатывает. Это можно как-то просто пофиксить?
*3) В целом интерфейс сильно хромает, а js на страницах представляет из себя костыли и велосипеды. Создателю надо уебать с ноги(осуждаю насилие)*
**4) Роли можно создать и добавить к аккаунтам, но сейчас ничего нигде не используется за исключеним минимального залогинен/нет для показа кнопок логина/выхода.
Сейчас там нет ввода области/района пользователя и я в целом не понимаю как это использовать т.е. повесить условного moderator на post запросы - да, 
а добавить к этому ещё проверку области например хз как.**
5) У Участков нужно/можно указать город, но в дальнейшем это никак не используется: при привязке участки выбираются на основании района. Делалось согласно файлу от Юры
6) У меня в принципе нет депутатов и взаимодействия участков с ними. В проге Юры - тоже нет. Но в его записке скрин с созданием депутата имеется. Нужен ли этот функционал? 

Не совсем по проге:
1) что из себя представляют схемы и плакаты? Нам скинули максимум штампы, но я не понимаю даже как мне сделать какой-то контент, не говоря уж про оформление. У тебя образцы остались?
2) за что отвечает консультант от кафедры? У меня консультантом стоит Волорова т.е это когда сдавать буду просто она сразу 2-3 подписи поставит или меня ещё как-то в@бут и мне лучше заранее к ней подойти?
