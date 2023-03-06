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