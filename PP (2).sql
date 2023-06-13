-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 13 2023 г., 11:13
-- Версия сервера: 8.0.30
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `PP`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Avt`
--

CREATE TABLE `Avt` (
  `id` int NOT NULL,
  `login` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `last_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `father_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `date_r` date DEFAULT NULL,
  `pasport` varchar(1200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `exam` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `obraz` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ych` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `predm` varchar(10000) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `Avt`
--

INSERT INTO `Avt` (`id`, `login`, `password`, `number`, `email`, `last_name`, `name`, `father_name`, `date_r`, `pasport`, `exam`, `obraz`, `ych`, `predm`) VALUES
(1, '12345', '12345', '+7(900) 124-24-54', 'luyba595@gmail.com', 'Косарева', 'Любовь', 'Олеговна', '2004-09-29', 'AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAmU84kn1DDkSBqVsO/07W1gAAAAACAAAAAAAQZgAAAAEAACAAAACbQ+tDlW9sAoU87St0yKJbd6Jq46N0dJd1WYesYCFoRgAAAAAOgAAAAAIAACAAAAByh4HvNyOCrA/Vqbh4whV1fMDQz9SpFWMxtP151xy1bRAAAADnKCsZFfMXHZSe8SO1wn8vQAAAAORMOl28InR1IFG1tW9m1C2as4f5vcgDD1Lm6NQwP+gb6UILpbFP7LaYzKrzVeomSkrBecPwq6Cv0Q9i9UPgHL4=', 'ЕГЭ', 'ССУЗ', 'ркси', 'Математика,История,'),
(2, 'qwerov', '000', '+7(666) 666-66-66', 'justamailforrobots@gmail.com', NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, ''),
(4, 'admin', 'root', '', '', NULL, NULL, NULL, NULL, NULL, '', NULL, NULL, ''),
(11, '123', '000', '+7(928) 122-36-59', 'mortvvnutri@gmail.com', 'Иванов', 'Иван', 'Иванович', '2004-03-10', 'AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAmU84kn1DDkSBqVsO/07W1gAAAAACAAAAAAAQZgAAAAEAACAAAAAyzvI07NwMHuBtdi9bNoR2rQQrAqkykWAKBNHh+uxqNQAAAAAOgAAAAAIAACAAAAAFRnnEz3l02OfpxyhQtB0zLYpyefLE2xMOBilIafCXcxAAAAA9dBuIUk2INEhbgEJwi+PTQAAAAKjGAd+wDdkaURA2M2PPpVSvjKJSOwQxhGt9U5unwXjqiqR46qZpulZGh/irZ5bpGY6pvFfmmVuck+iZ1ktwnsA=', 'ОГЭ', 'Школа', 'Школа №10', 'Русский язык,Математика,Обществознание,');

-- --------------------------------------------------------

--
-- Структура таблицы `group`
--

CREATE TABLE `group` (
  `group_id` int NOT NULL,
  `group_name` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `group`
--

INSERT INTO `group` (`group_id`, `group_name`) VALUES
(1, '9 класс'),
(2, '11 класс'),
(3, '7 класс'),
(4, '10 класс'),
(5, '8 класс');

-- --------------------------------------------------------

--
-- Структура таблицы `group_avt`
--

CREATE TABLE `group_avt` (
  `group_id` int DEFAULT NULL,
  `id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `group_avt`
--

INSERT INTO `group_avt` (`group_id`, `id`) VALUES
(1, 2),
(1, 4),
(1, 1),
(2, 11);

-- --------------------------------------------------------

--
-- Структура таблицы `group_prepod`
--

CREATE TABLE `group_prepod` (
  `group_id` int NOT NULL,
  `prepod_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `group_prepod`
--

INSERT INTO `group_prepod` (`group_id`, `prepod_id`) VALUES
(1, 4),
(2, 5),
(3, 6),
(5, 4);

-- --------------------------------------------------------

--
-- Структура таблицы `prepod`
--

CREATE TABLE `prepod` (
  `prepod_id` int NOT NULL,
  `prepod_name` varchar(255) DEFAULT NULL,
  `predmet` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `prepod`
--

INSERT INTO `prepod` (`prepod_id`, `prepod_name`, `predmet`) VALUES
(4, 'Преподаватель 1', 'Математика'),
(5, 'Преподаватель 2', 'Русский язык'),
(6, 'Преподаватель 3', 'Английский язык'),
(9, 'Верещагина', 'История'),
(11, 'Мирошниченко', 'География');

-- --------------------------------------------------------

--
-- Структура таблицы `raspis`
--

CREATE TABLE `raspis` (
  `day_id` int NOT NULL,
  `date` datetime DEFAULT NULL,
  `kab` varchar(100) NOT NULL,
  `group_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Дамп данных таблицы `raspis`
--

INSERT INTO `raspis` (`day_id`, `date`, `kab`, `group_id`) VALUES
(1, '2023-05-30 00:00:00', 'большая', 1),
(5, '2023-05-30 00:00:00', 'большая', 1),
(7, '2023-05-29 00:00:00', 'малая', 2),
(8, '2023-05-31 00:00:00', 'малая', 4),
(10, '2023-06-01 00:00:00', 'малая', 1),
(11, '2023-06-03 00:00:00', 'малая', 1);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Avt`
--
ALTER TABLE `Avt`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `group`
--
ALTER TABLE `group`
  ADD PRIMARY KEY (`group_id`);

--
-- Индексы таблицы `group_avt`
--
ALTER TABLE `group_avt`
  ADD KEY `group_id` (`group_id`),
  ADD KEY `avt_id` (`id`);

--
-- Индексы таблицы `group_prepod`
--
ALTER TABLE `group_prepod`
  ADD KEY `fk_group_prepod_group` (`group_id`),
  ADD KEY `fk_group_prepod_pepod` (`prepod_id`);

--
-- Индексы таблицы `prepod`
--
ALTER TABLE `prepod`
  ADD PRIMARY KEY (`prepod_id`);

--
-- Индексы таблицы `raspis`
--
ALTER TABLE `raspis`
  ADD PRIMARY KEY (`day_id`),
  ADD KEY `raspis_ibfk` (`group_id`) USING BTREE;

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Avt`
--
ALTER TABLE `Avt`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT для таблицы `group`
--
ALTER TABLE `group`
  MODIFY `group_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `prepod`
--
ALTER TABLE `prepod`
  MODIFY `prepod_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `raspis`
--
ALTER TABLE `raspis`
  MODIFY `day_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `group_avt`
--
ALTER TABLE `group_avt`
  ADD CONSTRAINT `group_avt_ibfk_1` FOREIGN KEY (`group_id`) REFERENCES `group` (`group_id`),
  ADD CONSTRAINT `group_avt_ibfk_2` FOREIGN KEY (`id`) REFERENCES `Avt` (`id`);

--
-- Ограничения внешнего ключа таблицы `group_prepod`
--
ALTER TABLE `group_prepod`
  ADD CONSTRAINT `fk_group_prepod_group` FOREIGN KEY (`group_id`) REFERENCES `group` (`group_id`),
  ADD CONSTRAINT `fk_group_prepod_pepod` FOREIGN KEY (`prepod_id`) REFERENCES `prepod` (`prepod_id`);

--
-- Ограничения внешнего ключа таблицы `raspis`
--
ALTER TABLE `raspis`
  ADD CONSTRAINT `raspis_ibfk_1` FOREIGN KEY (`group_id`) REFERENCES `group` (`group_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
