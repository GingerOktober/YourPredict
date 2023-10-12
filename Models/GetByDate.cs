using Humanizer;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
namespace App.Models
{
        public static class GetByDate
        {

            private static string[] elements = new string[]
            {
        "Дерево", "Огонь", "Металл", "Вода"
            };
            public static string CalculateElement(int year)
            {
                int startYear = 1925;
                int yearOffset = year - startYear;
                int cycleLength = elements.Length * 2;
                int cycleIndex = yearOffset % cycleLength;
                if (cycleIndex % cycleLength == 0)
                {
                    return "Земля";
                }
                int elementIndex = (cycleIndex - 1) / 2;
                return elements[elementIndex];
            }
            private static string[] animal = new string[]
            {
        "Крыса", "Бык", "Тигр", "Кролик", "Дракон", "Змея",
        "Лошадь", "Коза", "Обезьяна", "Петух", "Собака", "Свинья"
            };

            public static string CalculateAnimal(int year)
            {
                int startYear = 1925;
                int yearOffset = year - startYear;
                int animalIndex = yearOffset % animal.Length;
                return animal[animalIndex + 1];
            }

            private static string[] Gem = new string[]
            {
        "Авантюрин", "Жемчуг", "Рубин", "Сапфир", "Циркон", "Бриллиант",
        "Бирюза", "Агат", "Горный хрусталь"
            };
            public static string CalculateDateDigitSum(DateTime birthDate)
            {
                string dateString = (birthDate.Day.ToString() +
                                     birthDate.Month.ToString() +
                                     birthDate.Year.ToString());

                int sum = 0;
                foreach (char digitChar in dateString)
                {
                    if (char.IsDigit(digitChar))
                    {
                        int digit = int.Parse(digitChar.ToString());
                        sum += digit;
                    }
                }
                while (sum > Gem.Length) { sum = sum / 10 + sum % 10; }

                return Gem[sum - 1];
            }
            public static string CalculateZodiacSign(DateTime birthDate)
            {
                int day = birthDate.Day;
                int month = birthDate.Month;

                switch (month)
                {
                    case 1:
                        return day <= 20 ? "Козерог" : "Водолей";
                    case 2:
                        return day <= 19 ? "Водолей" : "Рыбы";
                    case 3:
                        return day <= 20 ? "Рыбы" : "Овен";
                    case 4:
                        return day <= 20 ? "Овен" : "Телец";
                    case 5:
                        return day <= 21 ? "Телец" : "Близнецы";
                    case 6:
                        return day <= 21 ? "Близнецы" : "Рак";
                    case 7:
                        return day <= 22 ? "Рак" : "Лев";
                    case 8:
                        return day <= 23 ? "Лев" : "Дева";
                    case 9:
                        return day <= 23 ? "Дева" : "Весы";
                    case 10:
                        return day <= 23 ? "Весы" : "Скорпион";
                    case 11:
                        return day <= 22 ? "Скорпион" : "Стрелец";
                    default:
                        return "Козерог";
                }
            }
            public static string GetTreeByBirthDate(DateTime BirthDate)
            {

                int month = BirthDate.Month;
                int day = BirthDate.Day;

                if ((month == 12 && day >= 23) || (month == 1 && day <= 1) || (month == 6 && day >= 25) || (month == 7 && day <= 4))
                {
                    return "Яблоня";
                }
                else if ((month == 1 && day >= 2) || (month == 7 && day >= 5) || (month == 1 && day <= 11) || (month == 7 && day <= 14))
                {
                    return "Пихта";
                }
                else if ((month == 1 && day >= 12) || (month == 7 && day >= 15) || (month == 1 && day <= 24) || (month == 7 && day <= 25))
                {
                    return "Вяз";
                }
                else if ((month == 1 && day >= 25) || (month == 2 && day <= 3) || (month == 7 && day >= 26) || (month == 8 && day <= 4))
                {
                    return "Кипарис";
                }
                else if ((month == 2 && day >= 4) || (month == 2 && day <= 8) || (month == 8 && day >= 5) || (month == 8 && day <= 13))
                {
                    return "Тополь";
                }
                else if ((month == 2 && day >= 9) || (month == 2 && day <= 18) || (month == 8 && day >= 14) || (month == 8 && day <= 23))
                {
                    return "Кедр";
                }
                else if ((month == 2 && day >= 19) || (month == 2 && day <= 28) || (month == 2 && day == 29) || (month == 8 && day >= 24) || (month == 8 && day <= 25) || (month == 9 && day >= 1) || (month == 9 && day <= 2))
                {
                    return "Сосна";
                }
                else if ((month == 3 && day >= 1) || (month == 3 && day <= 10) || (month == 9 && day >= 3) || (month == 9 && day <= 12))
                {
                    return "Ива";
                }
                else if ((month == 3 && day >= 11) || (month == 3 && day <= 20) || (month == 9 && day >= 13) || (month == 9 && day <= 22))
                {
                    return "Липа";
                }
                else if ((month == 3 && day >= 22) || (month == 3 && day <= 31) || (month == 9 && day >= 24) || (month == 9 && day <= 3) || (month == 10 && day >= 24) || (month == 10 && day <= 2))
                {
                    return "Орешник";
                }
                else if ((month == 4 && day >= 1) || (month == 4 && day <= 10) || (month == 10 && day >= 4) || (month == 10 && day <= 13))
                {
                    return "Рябина";
                }
                else if ((month == 4 && day >= 11) || (month == 4 && day <= 20) || (month == 10 && day >= 14) || (month == 10 && day <= 23))
                {
                    return "Клен";
                }
                else if ((month == 4 && day >= 21) || (month == 4 && day <= 30) || (month == 10 && day >= 24) || (month == 10 && day <= 2) || (month == 11 && day >= 24) || (month == 11 && day <= 2))
                {
                    return "Орех";
                }
                else if ((month == 5 && day >= 1) || (month == 5 && day <= 14) || (month == 11 && day >= 3) || (month == 11 && day <= 11))
                {
                    return "Жасмин";
                }
                else if ((month == 5 && day >= 15) || (month == 5 && day <= 24) || (month == 11 && day >= 12) || (month == 11 && day <= 21))
                {
                    return "Каштан";
                }
                else if ((month == 5 && day >= 25) || (month == 6 && day <= 3) || (month == 11 && day >= 22) || (month == 12 && day <= 1))
                {
                    return "Ясень";
                }
                else if ((month == 6 && day >= 4) || (month == 6 && day <= 13) || (month == 12 && day >= 2) || (month == 12 && day <= 11))
                {
                    return "Граб";
                }
                else if ((month == 6 && day >= 14) || (month == 6 && day <= 23) || (month == 12 && day >= 12) || (month == 12 && day <= 20))
                {
                    return "Инжир";
                }
                else if ((month == 3 && day == 21))
                {
                    return "Дуб";
                }
                else if ((month == 6 && day == 24))
                {
                    return "Береза";
                }
                else if ((month == 9 && day == 23))
                {
                    return "Маслина";
                }
                else if ((month == 12 && day == 21) || (month == 12 && day == 22))
                {
                    return "Бук";
                }
                else
                {
                    return "Яблоня";
                }
            }
            public static string CalculatePlanet(int day)
            {

                if (day % 9 == 0)
                {
                    return "Солнце";
                }
                else if (day % 8 == 0)
                {
                    return "Луна";
                }
                else if (day % 7 == 0)
                {
                    return "Юпитер";
                }
                else if (day % 6 == 0)
                {
                    return "Уран";
                }
                else if (day % 5 == 0)
                {
                    return "Меркурий";
                }
                else if (day % 4 == 0)
                {
                    return "Венера";
                }
                else if (day % 3 == 0)
                {
                    return "Нептун";
                }
                else if (day % 2 == 0)
                {
                    return "Сатурн";
                }
                else
                    return "Марс";
            }
            public static string GetAnimal(DateTime BirthDate)
            {
                int month = BirthDate.Month;
                int day = BirthDate.Day;
                if ((month == 12 && day >= 10) || (month == 1 && day <= 14))
                {
                    return "Медведь";
                }
                else if(month==1 && day == 23)
                {
                return "Божья коровка";
                }
                else if (month == 3 && day == 8)
                {
                    return "Бык";
                }
                else if ((month == 1 && day >= 15) || (month == 2 && day <= 9))
                {
                    return "Росомаха";
                }
                else if ((month == 2 && day >= 10) || (month == 3 && day <= 9))
                {
                    return "Ворон";
                }
                else if ((month == 3 && day >= 10) || (month == 4 && day <= 9))
                {
                    return "Горностай";
                }
                else if ((month == 4 && day >= 10) || (month == 5 && day <= 9))
                {
                    return "Жаба";
                }
                else if ((month == 5 && day >= 10) || (month == 6 && day <= 9))
                {
                    return "Кузнечик";
                }
                else if ((month == 6 && day >= 10) || (month == 7 && day <= 9))
                {
                    return "Хомяк";
                }
                else if ((month == 7 && day >= 10) || (month == 8 && day <= 9))
                {
                    return "Улитка";
                }
                else if ((month == 8 && day >= 10) || (month == 9 && day <= 9))
                {
                    return "Муравей";
                }
                else if ((month == 9 && day >= 10) || (month == 10 && day <= 9))
                {
                    return "Сорока";
                }
                else if ((month == 10 && day >= 10) || (month == 11 && day <= 9))
                {
                    return "Бобёр";
                }
                else if ((month == 11 && day >= 10) || (month == 12 && day <= 9))
                {
                    return "Собака";
                }
                else
                {
                    return "Росомаха";
                }
            }
            public static string GetFlower(DateTime BirthDate)
            {
                int month = BirthDate.Month;
                int day = BirthDate.Day;

                if ((month == 1 && day >= 1 && day <= 10) || (month == 12 && day >= 23))
                {
                    return "Горечавка желтая";
                }
                else if ((month == 1 && day >= 11 && day <= 20) || (month == 1 && day <= 20))
                {
                    return "Чертополох";
                }
                else if ((month == 1 && day >= 21 && day <= 31) || (month == 12 && day <= 31))
                {
                    return "Бессмертник";
                }
                else if ((month == 2 && day >= 1 && day <= 10) || (month == 2 && day <= 10))
                {
                    return "Омела";
                }
                else if ((month == 2 && day >= 11 && day <= 19) || (month == 2 && day <= 19))
                {
                    return "Красавка";
                }
                else if ((month == 2 && day >= 20 && day <= 29) || (month == 2 && day <= 29))
                {
                    return "Мимоза";
                }

                else if ((month == 3 && day >= 1 && day <= 10) || (month == 3 && day <= 10))
                {
                    return "Мак";
                }
                else if ((month == 3 && day >= 11 && day <= 20) || (month == 3 && day <= 20))
                {
                    return "Лилия";
                }
                else if ((month == 3 && day >= 21 && day <= 31) || (month == 3 && day <= 31))
                {
                    return "Наперстянка";
                }
                else if ((month == 4 && day >= 1 && day <= 10) || (month == 4 && day <= 10))
                {
                    return "Магнолия";
                }
                else if ((month == 4 && day >= 11 && day <= 20) || (month == 4 && day <= 20))
                {
                    return "Гортензия";
                }
                else if ((month == 4 && day >= 21 && day <= 30) || (month == 4 && day <= 30))
                {
                    return "Георгин";
                }
                else if ((month == 5 && day >= 1 && day <= 10) || (month == 5 && day <= 10))
                {
                    return "Ландыш";
                }
                else if ((month == 5 && day >= 11 && day <= 21) || (month == 5 && day <= 21))
                {
                    return "Портулак";
                }
                else if ((month == 5 && day >= 22 && day <= 31) || (month == 5 && day <= 31))
                {
                    return "Ромашка";
                }
                else if ((month == 6 && day >= 1 && day <= 11) || (month == 6 && day <= 11))
                {
                    return "Колокольчик";
                }
                else if ((month == 6 && day >= 12 && day <= 21) || (month == 6 && day <= 21))
                {
                    return "Маргаритка";
                }
                else if ((month == 6 && day >= 22 && day <= 30) || (month == 6 && day <= 30))
                {
                    return "Тюльпан";
                }
                else if ((month == 7 && day >= 2 && day <= 12) || (month == 7 && day <= 12))
                {
                    return "Кувшинка";
                }
                else if ((month == 7 && day >= 13 && day <= 23) || (month == 7 && day <= 23))
                {
                    return "Фиалка";
                }
                else if ((month == 7 && day >= 24 && day <= 2) || (month == 8 && day <= 2))
                {
                    return "Шиповник";
                }
                else if ((month == 8 && day >= 3 && day <= 13) || (month == 8 && day <= 13))
                {
                    return "Подсолнечник";
                }
                else if ((month == 8 && day >= 14 && day <= 23) || (month == 8 && day <= 23))
                {
                    return "Роза";
                }
                else if ((month == 8 && day >= 24 && day <= 2) || (month == 9 && day <= 2))
                {
                    return "Дельфиниум";
                }
                else if ((month == 9 && day >= 3 && day <= 11) || (month == 9 && day <= 11))
                {
                    return "Гвоздика";
                }
                else if ((month == 9 && day >= 12 && day <= 22) || (month == 9 && day <= 22))
                {
                    return "Астра";
                }
                else if ((month == 9 && day >= 23 && day <= 2) || (month == 10 && day <= 2))
                {
                    return "Вереск";
                }
                else if ((month == 10 && day >= 3 && day <= 13) || (month == 10 && day <= 13))
                {
                    return "Камелия";
                }
                else if ((month == 10 && day >= 14 && day <= 23) || (month == 10 && day <= 23))
                {
                    return "Сирень";
                }
                else if ((month == 10 && day >= 24 && day <= 2) || (month == 11 && day <= 2))
                {
                    return "Фрезия";
                }
                else if ((month == 11 && day >= 3 && day <= 12) || (month == 11 && day <= 12))
                {
                    return "Орхидея";
                }
                else if ((month == 11 && day >= 13 && day <= 22) || (month == 11 && day <= 22))
                {
                    return "Пион";
                }
                else if ((month == 11 && day >= 23 && day <= 2) || (month == 12 && day <= 2))
                {
                    return "Гладиолус";
                }
                else if ((month == 12 && day >= 3 && day <= 12) || (month == 12 && day <= 12))
                {
                    return "Одуванчик";
                }

                else if ((month == 12 && day >= 13 && day <= 22) || (month == 12 && day <= 22))
                {
                    return "Лотос";
                }
                else if ((month == 12 && day >= 23 && day <= 31) || (month == 12 && day <= 31))
                {
                    return "Эдельвейс";
                }
                else
                {
                    return "Мать-и-Мачеха";
                }
            }
            public static int DigitPath(DateTime birthDate)
            {
                int day = birthDate.Day;
                int month = birthDate.Month;
                int year = birthDate.Year;

                int dateSum = day + month + year;

                int digitSum = 0;
                while (dateSum > 0)
                {
                    digitSum += dateSum % 10;
                    dateSum /= 10;
                }

                return digitSum;
            }
            public static int DigitDay(DateTime birthDate)
            {
                int day = birthDate.Day;
                if (day < 10)
                {
                    return day;
                }
                else
                {
                    int day1 = day % 10;
                    int day2 = day / 10;
                    return day1 + day2;
                }

            }

    }
}
