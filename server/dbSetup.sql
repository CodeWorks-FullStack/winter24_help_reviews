-- Active: 1711167878661@@127.0.0.1@3306@adaptable_shaman_540684_db
CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

CREATE TABLE
  restaurants (
    id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    imgUrl VARCHAR(1000) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    visits INT NOT NULL DEFAULT 0,
    isShutdown BOOLEAN NOT NULL DEFAULT false,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

CREATE TABLE
  reports (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    title VARCHAR(255) NOT NULL,
    body VARCHAR(1000),
    pictureOfDisgust VARCHAR(1000),
    restaurantId INT NOT NULL,
    creatorId VARCHAR(255) NOT NULL,
    FOREIGN KEY (restaurantId) REFERENCES restaurants (id) ON DELETE CASCADE,
    FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
  );

DROP TABLE restaurants;

SELECT
  restaurant.*,
  COUNT(report.id) AS reportCount
FROM
  restaurants restaurant
  LEFT JOIN reports report ON report.restaurantId = restaurant.id
GROUP BY
  (restaurant.id);

SELECT
  *
FROM
  reports;