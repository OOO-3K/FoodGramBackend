# Readme
## Описание проекта

Бэкенд-часть проекта FoodGram.

> Здесь будет больше описания в будущем =)

## Описание действий для запуска проекта

Для начала работы с проектом необходимо поднять базу данных. В папке **PgDockerCompose** содержится файл **docker-compose.yaml**, при выполнении которого подымутся докер-контейнеры с **PostgreSQL** и **PgAdmin**.

Параметры входа в **PgAdmin**:
- *email*: pgAdmin@pg.com
- *password*: Password1234

Регистрация сервера **PostgreSQL** в **PgAdmin**:
- *Host name/address*: host.docker.internal
- *Port*: 5432
- *Maintenance database*: postgres
- *Username*: postgres
- *Password*: 12345

> Здесь будет про скрипты создания базы данных =)

После чего можно собирать проект, запустив **FoodGramBackend.sln**.