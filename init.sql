-- Active: 1675493335826@@127.0.0.1@3306@ASP_web_empty
USE ASP_web_empty;

CREATE TABLE students (
    id INT PRIMARY KEY AUTO_INCREMENT,
    fname VARCHAR(50),
    lname VARCHAR(50),
    dob DATE NOT NULL,
    email VARCHAR(20),
    address VARCHAR(50)
);

INSERT INTO `students` VALUES(DEFAULT, "Pham", "Duy", "2003/12/10", "mail@gmail", "Ha Dong");

INSERT INTO `students` VALUES(DEFAULT, "Anh", "Hoang", "2003/12/02", "no-mail@gmail", "Ha Dong");
INSERT INTO `students`
VALUES
(
        DEFAULT,
        "Do",
        "Dat",
        "2003/12/10",
        "mail@gmail",
        "Ha Nam");
INSERT INTO `students`
VALUES
(
        DEFAULT,
        "Ngyen",
        "Duy",
        "2004/12/10",
        "mail@gmail",
        "Ha Noi"
    );

);