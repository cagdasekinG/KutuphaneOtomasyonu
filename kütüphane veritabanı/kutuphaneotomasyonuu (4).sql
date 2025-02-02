-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 27 May 2024, 10:48:01
-- Sunucu sürümü: 10.4.32-MariaDB
-- PHP Sürümü: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `kutuphaneotomasyonuu`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kitaplar`
--

CREATE TABLE `kitaplar` (
  `kitap_id` int(11) NOT NULL,
  `kitap_adi` varchar(100) DEFAULT NULL,
  `yazar` varchar(100) DEFAULT NULL,
  `yayinevi` varchar(100) DEFAULT NULL,
  `basim_yili` year(4) DEFAULT NULL,
  `sayfa_sayisi` int(11) DEFAULT NULL,
  `dil` varchar(50) DEFAULT NULL,
  `stok_sayisi` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `kitaplar`
--

INSERT INTO `kitaplar` (`kitap_id`, `kitap_adi`, `yazar`, `yayinevi`, `basim_yili`, `sayfa_sayisi`, `dil`, `stok_sayisi`) VALUES
(1, 'sefiller', 'victor hugo', 'kronik', '1920', 1500, 'türkçe', 1),
(2, 'uçan gemi', NULL, 'comu', '0000', 123, 'türkçe', 0),
(3, 'büyük fikirler', 'ian crafton', 'kronik', '2000', 150, 'türkçe', 0),
(4, 'öğretmen olmak', 'kamil akgün', 'can', '2024', 2000, 'türkçe', 0),
(5, 'arayı arayı', 'kemal alaçayır', 'ziraat', '2000', 15, 'türkçe', 0),
(6, 'öğrenci olmak', 'çağdaş ekin özçelik', 'can', '2024', 200, 'türkçe', 2),
(7, 'çeke çeke', 'kemal alaçayır', 'kronik', '2024', 120, 'türkçe', 4),
(8, 'sayısal sistemler', 'kamil akgün', 'ziraat', '2024', 120, 'ispanyolca', 2),
(9, 'proje yapmak', 'çağdaş ekin özçelik', 'kronik', '2024', 120, 'Türkçe', 2),
(10, 'özay baba', '', '', '2024', 1234, 'Ermenice', 4);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `oduncalinankitaplar`
--

CREATE TABLE `oduncalinankitaplar` (
  `odunc_id` int(11) NOT NULL,
  `adisoyadi` varchar(100) DEFAULT NULL,
  `kitap_adi` varchar(100) DEFAULT NULL,
  `alis_tarihi` date DEFAULT NULL,
  `iade_tarihi` date DEFAULT NULL,
  `durum` enum('Alındı','İade Edildi') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `oduncalinankitaplar`
--

INSERT INTO `oduncalinankitaplar` (`odunc_id`, `adisoyadi`, `kitap_adi`, `alis_tarihi`, `iade_tarihi`, `durum`) VALUES
(2, 'derya', '1', '2024-05-18', '2024-05-26', 'İade Edildi'),
(5, 'kamil akgün', 'sayısal sistemler', '2024-05-20', '0000-00-00', 'Alındı');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `uyeler`
--

CREATE TABLE `uyeler` (
  `uye_id` int(11) NOT NULL,
  `tc_kimlik_no` varchar(11) DEFAULT NULL,
  `adisoyadi` varchar(50) DEFAULT NULL,
  `cinsiyet` enum('Erkek','Kadın') DEFAULT NULL,
  `dogum_tarihi` date DEFAULT NULL,
  `uye_tarihi` date DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefon` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `uyeler`
--

INSERT INTO `uyeler` (`uye_id`, `tc_kimlik_no`, `adisoyadi`, `cinsiyet`, `dogum_tarihi`, `uye_tarihi`, `email`, `telefon`) VALUES
(1, '12345678910', 'derya', 'Kadın', '2003-08-15', '2024-05-06', 'derya@gmail.com', '05551404128'),
(2, '12345678911', 'kamil akgün', 'Erkek', '2000-05-18', '2024-05-18', 'kamil@gmail.com', '05496575214'),
(3, '51394332246', 'çağdaş ekin özçelik', 'Erkek', '2003-06-02', '2024-05-19', 'cagdaseking@gmail.com', '05438681060');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yayinevi`
--

CREATE TABLE `yayinevi` (
  `yayinevi_id` int(11) NOT NULL,
  `yayinevi` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `yayinevi`
--

INSERT INTO `yayinevi` (`yayinevi_id`, `yayinevi`) VALUES
(1, 'kronik'),
(2, 'can'),
(3, 'ziraat'),
(4, 'vakıf');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yazarlar`
--

CREATE TABLE `yazarlar` (
  `yazar_id` int(11) NOT NULL,
  `yazar` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Tablo döküm verisi `yazarlar`
--

INSERT INTO `yazarlar` (`yazar_id`, `yazar`) VALUES
(11, 'çağdaş ekin özçelik'),
(5, 'deniz genç'),
(4, 'derya yılmaz'),
(9, 'dünya özçelik'),
(8, 'kaan tangöze'),
(2, 'kamil akgün'),
(6, 'kemal alaçayır'),
(7, 'kemalettin baba'),
(1, 'ömer seyfettin'),
(12, 'özay bölüt'),
(3, 'victor hugo');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `kitaplar`
--
ALTER TABLE `kitaplar`
  ADD PRIMARY KEY (`kitap_id`);

--
-- Tablo için indeksler `oduncalinankitaplar`
--
ALTER TABLE `oduncalinankitaplar`
  ADD PRIMARY KEY (`odunc_id`);

--
-- Tablo için indeksler `uyeler`
--
ALTER TABLE `uyeler`
  ADD PRIMARY KEY (`uye_id`);

--
-- Tablo için indeksler `yayinevi`
--
ALTER TABLE `yayinevi`
  ADD PRIMARY KEY (`yayinevi_id`);

--
-- Tablo için indeksler `yazarlar`
--
ALTER TABLE `yazarlar`
  ADD PRIMARY KEY (`yazar_id`),
  ADD UNIQUE KEY `yazar` (`yazar`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `kitaplar`
--
ALTER TABLE `kitaplar`
  MODIFY `kitap_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `oduncalinankitaplar`
--
ALTER TABLE `oduncalinankitaplar`
  MODIFY `odunc_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `uyeler`
--
ALTER TABLE `uyeler`
  MODIFY `uye_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `yayinevi`
--
ALTER TABLE `yayinevi`
  MODIFY `yayinevi_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `yazarlar`
--
ALTER TABLE `yazarlar`
  MODIFY `yazar_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
