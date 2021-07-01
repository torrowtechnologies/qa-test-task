# Тестовое задание TorrowTech на позицию QA Automation Engineer

## Задание:
> Написать несколько сценариев для процесса аутентификации.

Примеры сценариев:
 - Успешная аутент. по sms/email
 - Аутент. по sms/email с неправильным кодом, введенным один и более раз
 - Слишком большое ожидание ввода кода
 - Проверка sms/email на разных языках

# Приложение:
Приложение для тестирования находится по адресу https://dev1.torrow.net
Отправленный код на телефон/email можно получить по адресам:
- https://smsdev1.torrow.net/api/phone/{phoneNumber} (прим. https://smsdev1.torrow.net/api/phone/7911123456)
- https://emaildev1.torrow.net/api/email/{email} (прим. https://emaildev1.torrow.net/api/email/asdsad@dsfsdf.sdf)

# Требования:
- Тестовый проект должен быть написан на языке C# с использованием фреймворка SpecFlow (https://specflow.org/) и Selenium.
- Использовать паттерн PageObject (прим. https://docs.specflow.org/projects/specflow/en/latest/ui-automation/Selenium-with-Page-Object-Pattern.html)
