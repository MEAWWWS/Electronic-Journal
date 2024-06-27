# Разработка "Система электронного журнала"
![image](https://github.com/MEAWWWS/Electronic-Journal/assets/114382568/74aafb4a-5c70-47d7-bcb8-8d3f0611132a)

Окно "Студент"

![image](https://github.com/MEAWWWS/Electronic-Journal/assets/114382568/4f8a8042-04e1-49b8-b8b1-6023a48c2adf)

Окно "Преподаватель"

![image](https://github.com/MEAWWWS/Electronic-Journal/assets/114382568/0d1ca2d2-9a0c-41c5-858a-2404fe68a2a2)

Окно "Администратор"

## Функциональность
1. **Ведение журнала посещаемости.** Присутствует возможноность занесения информации о присутствии/отсутствии учеников на уроках, пометка причин пропусков.
2. **Ввод и хранение оценок.** Занесение оценок по различным предметам и видам работ.
3. **Хранение учебного плана.** Занесение информации о предметах, учителях, расписании уроков.
4. **Генерация расписания.** Создание расписания уроков для отдельных классов или групп.
4. **Изменение расписания.** Возможность оперативного изменения расписания в случае необходимости.
4. **Создание и назначение домашних заданий.** Ввод информации о домашнем задании, сроке его выполнения.
5. **Проверка и оценка домашних заданий.** Возможность проверки выполнения заданий учителем, выставлять оценки.

## Технические детали 
- **Разработано на**: WPF
- **База данных**: MSSQL
## Создание таблиц 
``` SQL
CREATE TABLE Role (
    idRole INT PRIMARY KEY,
    nameRole VARCHAR(255)
);

CREATE TABLE Class (
    idClass INT PRIMARY KEY,
    nameClass VARCHAR(255)
);

CREATE TABLE User (
    idUser INT PRIMARY KEY,
    login VARCHAR(255),
    pass VARCHAR(255),
    idRole INT,
    FOREIGN KEY (idRole) REFERENCES Role(idRole)
);

CREATE TABLE Student (
    idStudent INT PRIMARY KEY,
    nameStudent VARCHAR(255),
    surnameStudent VARCHAR(255),
    middleNameStudent VARCHAR(255),
    idUser INT,
    idClass INT,
    FOREIGN KEY (idUser) REFERENCES User(idUser),
    FOREIGN KEY (idClass) REFERENCES Class(idClass)
);

CREATE TABLE Teacher (
    idTeacher INT PRIMARY KEY,
    nameTeacher VARCHAR(255),
    surnameTeacher VARCHAR(255),
    middleNameTeacher VARCHAR(255),
    idDiscipline INT,
    FOREIGN KEY (idDiscipline) REFERENCES Discipline(idDiscipline)
);
CREATE TABLE Discipline (
    idDiscipline INT PRIMARY KEY,
    nameDiscipline VARCHAR(255)
);

CREATE TABLE Homework (
    idHomework INT PRIMARY KEY,
    idClass INT,
    idTeacher INT,
    task TEXT,
    deadline DATE,
    FOREIGN KEY (idClass) REFERENCES Class(idClass),
    FOREIGN KEY (idTeacher) REFERENCES Teacher(idTeacher)
);

CREATE TABLE Assessment (
    idAssessment INT PRIMARY KEY,
    idStudent INT,
    idDiscipline INT,
    mark DECIMAL(5, 2),
    date DATE,
    idType INT,
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idDiscipline) REFERENCES Discipline(idDiscipline),
    FOREIGN KEY (idType) REFERENCES Type(idType)
);

CREATE TABLE Type (
    idType INT PRIMARY KEY,
    nameType VARCHAR(255)
);

CREATE TABLE Pass (
    idPass INT PRIMARY KEY,
    idStudent INT,
    idType INT,
    data DATE,
    idDiscipline INT,
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent),
    FOREIGN KEY (idType) REFERENCES Type(idType),
    FOREIGN KEY (idDiscipline) REFERENCES Discipline(idDiscipline)
);

CREATE TABLE Schedule (
    idSchedule INT PRIMARY KEY,
    idClass INT,
    day VARCHAR(50),
    idTeacher INT,
    FOREIGN KEY (idClass) REFERENCES Class(idClass),
    FOREIGN KEY (idTeacher) REFERENCES Teacher(idTeacher)
);

CREATE TABLE Rating (
    idRating INT PRIMARY KEY,
    idDiscipline INT,
    assessment DECIMAL(5, 2),
    idStudent INT,
    FOREIGN KEY (idDiscipline) REFERENCES Discipline(idDiscipline),
    FOREIGN KEY (idStudent) REFERENCES Student(idStudent)
);

```
## Таблицы базы данных

- Таблица «Role» (idRole, nameRole) содержит информацию о ролях
- Таблица «Users» (idUser, login, pass, idRole) содержит информацию о пользователях
- Таблица «Student» (idStudent, nameStudent, surnameStudent, middleNameStudent, idUser, idClass) содержит информацию о студентах
- Таблица «Teacher» (idTeacher, nameTeacher, surnameTeacher, middleNameTeacher, idDiscipline) содержит информацию о преподавателях
- Таблица «Class» (idClass, nameClass) содержит информацию о классах
- Таблица «Discipline» (idDiscipline, nameDiscipline) содержит информацию о дисциплинах
- Таблица «Homework» (idHomework, idClass, idTeacher, task, deadline) содержит информацию о домашних заданиях
- Таблица «Assessment» (idAssessment, idStudent, idDiscipline, mark, date, idType) содержит информацию об оценках
- Таблица «Type» (idType, nameType) содержит информацию о типах пропусков/видов работ
- Таблица «Pass» (idPass, idStudent, idType, data, idDiscipline) содержит информацию о пропусках
- Таблица «Schedule» (idSchedule, idClass, day, idTeacher) содержит информацию о расписании
- Таблица «Rating» (idRating, idDiscipline, assessment, idStudent) содержит информацию о средних оценок по предметам

## База данных SQL
![image](https://github.com/MEAWWWS/Electronic-Journal/assets/114382568/b50db357-93b9-4c0c-bf7f-ff958462aeeb)
## Видео


https://github.com/MEAWWWS/Electronic-Journal/assets/114382568/b21bbda4-542b-4f65-88bd-b4ea3e63b8c1


## Автор программы
### Зимин.М
