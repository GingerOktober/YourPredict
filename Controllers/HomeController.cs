using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Models;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Data.Entity;
using static System.Net.WebRequestMethods;
using Humanizer;
using System.Xml.Linq;
using static App.Controllers.HomeController;
using System.Drawing.Drawing2D;
using System;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Numerics;
using System.Security.Policy;
using System.Runtime.CompilerServices;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public YourPredictContext db;
        public HomeController(YourPredictContext context)
        {
            db = context;
        }
        public IActionResult Index() => View(); //Метод - возвращаем представления
        public IActionResult Order() => View();
        public IActionResult About() => View();
        public IActionResult Registration() => View();
        public IActionResult Services()
        {
            return View(db.Goods.ToList());
        }
        public IActionResult _Partial() //Гадание выводится
        {
            return View(db.Taro_Cards.ToList());
        }
        public IActionResult Predict() //Основная страница гадания
        {
            return View(db.Taro_Cards.ToList());
        }
        public IActionResult Card(int GoodId) //Карточка товара, возвращаю представление с комбо моделью 
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            var users = db.Users.ToList();
            var goods = db.Goods.ToList();
            var comments = db.Comments.ToList();

            var comboModel2 = new ComboModelProfileANDGoodsCard
            {
                UsersData = users,
                GoodsData = goods,
                CommentData = comments,
                UserId = userId
            };

            TempData["myNumber"] = userId;
            return View(comboModel2);
        }
        
        [HttpPost]
        public ActionResult AddComment(string text, int goodid) //Метод - логика добавления комментария
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            var newComment = new Commentss
            {
                UserId = userId,
                DateCreate = DateTime.Now,
                GoodId = goodid,
                Text = text
            };
            db.Comments.Add(newComment);
            db.SaveChanges();

            TempData["myNumber"] = userId;
            return RedirectToAction("Card");
        }

        [HttpPost]
        public IActionResult AddToCart(int goodId) //метод - добавления в корзину
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            if (userId == 0)
            {
                TempData["myNumber"] = userId;
                return Json(new { exists = 0 });
            }
            else
            
            {
                bool isExist = db.Cart.Any(f => f.GoodId == goodId && f.UserId == userId);
                if(isExist)
                {
                    TempData["myNumber"] = userId;
                    return Json(new { exists = 1 });
                }
                var newCartItem = new Carts
                {
                    GoodId = goodId,
                    UserId = userId
                };

                db.Cart.Add(newCartItem);
                db.SaveChanges();

                TempData["myNumber"] = userId;
                return Json(new { exists = 1 });
            }
        }
        
        public IActionResult Cart() //Метод работы с корзиной
        {
            int userid = 0;
            if (TempData.TryGetValue("MyNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userid = myNumber;
            }
            var carts = db.Cart.ToList();

            var comboModel = new ComboModelCart
            {
                GoodsData = db.Goods.ToList(),
                CartData = carts,
                UserId = userid
            };

            TempData["myNumber"] = userid;
            return View(comboModel);
        }
        public IActionResult Favorite() //Метод работы с избранным
        {
            var favors = new List<Favorit>();
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            if (db.Favorite.Any()) //Если хоть что-то есть
            {
                favors = db.Favorite.ToList();
            }
            var ComboModel = new ComboModelFavorites
            {
                FavoritData = favors,
                GoodsData = db.Goods.ToList(),
                UserId = userId
            };
            TempData["myNumber"] = userId;
            return View(ComboModel);
        }

        public IActionResult Login() //Проверка на авторизацию
        {
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber && myNumber != 0)
            {
                return RedirectToAction("Profile");
            }

            return View();
        }
        public bool IsProductInFavorites(int GoodId) //Возвращение в избранном или нет
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            bool isFavorite = db.Favorite.Any(f => f.GoodId == GoodId && f.UserId == userId);

            TempData["myNumber"] = userId;
            return isFavorite;
        }


        public IActionResult Profile() //Метод работы с профилем
        {
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber && myNumber != 0)
            {
                var commentsData = new List<Commentss>();
                var ordersData = new List<Orderss>();
                if (db.Comments.Any())
                {
                    commentsData = db.Comments.ToList();
                }
                if (db.Orders.Any())
                {
                    ordersData = db.Orders.ToList();
                }
                var comboModel = new ComboModelProfileANDGoodsCard
                {
                    GoodsData = db.Goods.ToList(),
                    CommentData = commentsData,
                    UsersData = db.Users.ToList(),
                    OrdersData = ordersData,
                    UserId = myNumber
                };
                TempData["myNumber"] = comboModel.UserId;
                return View(comboModel);
            }
            else
            {
                TempData["myNumber"] = 0;
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public IActionResult AddToFavorites(int goodId) //Добавление в избранное
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            if(userId != 0)
            {
                var newFavorItem = new Favorit
                {
                    GoodId = goodId,
                    UserId = userId
                };

                db.Favorite.Add(newFavorItem);
                db.SaveChanges();
                TempData["myNumber"] = userId;
            }
            return View(); 
        }
        [HttpPost]
        public IActionResult RemoveFromFavorites(int goodId) //Обратное действие - удаление из избранного
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            var itemToDelete = db.Favorite.FirstOrDefault(g => g.UserId == userId && g.GoodId == goodId);
            db.Favorite.Remove(itemToDelete);
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int goodId) //Обратное действие - удаление из корзины
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            var itemToDelete = db.Cart.FirstOrDefault(g => g.UserId == userId && g.GoodId == goodId);
            db.Cart.Remove(itemToDelete);
            db.SaveChanges();
            TempData["myNumber"] = userId;
            return RedirectToAction("Cart", "Home");
        }
        [HttpPost]
        public ActionResult NewOrder(string address, string phone, string payment_method) //Оформление заказа
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            if (payment_method == "cash")
            {
                payment_method = "Наличными при получении.";
            }
            else
            {
                payment_method = "Оплата картой.";
            }
            foreach (var item in db.Cart.ToList())
            {
                if (item.UserId == userId)
                {
                     var newOrder = new Orderss
                     {
                        GoodId = item.GoodId,
                        UserId = userId,
                        Status = "Заказ собирается.",
                        OrderDate = DateTime.Now,
                        DeliveryDate = "Очень скоро.",
                        Address = address,
                        Phone = phone,
                        Payment = payment_method
                     };
                    db.Cart.Remove(item);
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                }
            }
            TempData["myNumber"] = userId;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UpdateDescription(string updatedDescription) 
        {
            
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            user.About = updatedDescription;
            db.SaveChanges();
            TempData["myNumber"] = userId;
            return RedirectToAction("Profile");
        }
        public IActionResult Goods() //Вывод представления с комбо моделью
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
                var goodsData = db.Goods.ToList();

                // Создаем список GoodWithFavoriteFlag, представляющий товар и его флаг избранности
                var goodsWithFavoriteFlags = new List<GoodWithFavoriteFlag>();
                foreach (var item in goodsData)
                {
                    var isFavorite = IsProductInFavorites(item.GoodId);
                    goodsWithFavoriteFlags.Add(new GoodWithFavoriteFlag
                    {
                        GoodsData = item,
                        IsFavorite = isFavorite
                    });
                }

                TempData["myNumber"] = userId;
                return View(goodsWithFavoriteFlags);
        }
        [HttpPost]
        public IActionResult Auth(string Email, string Password) //Вход
        {
            var user = db.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            if (user != null) //Если есть е мейл и пароль то пропускаем, иначе пошел вон
            {
                TempData["myNumber"] = user.UserId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Неверный email или пароль");
                return View("Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Userss model) //Метод осуществляющий регистрацию
        {
            if (ModelState.IsValid) //если полученная модель сформирована и не имеет ошибок
            {
                if (db.Users.Any(u => u.Email == model.Email)) //проверка нет ли такого е мейла уже
                {
                    ModelState.AddModelError("Email", "Такой email уже зарегистрирован.");
                    return View(model);
                }
                var newUser = new Userss //создается новый пользователь, заполнение модели
                {
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email,
                    BirthDate = model.BirthDate.Date,
                    image_link = "https://i.ibb.co/KjqRSjs/15639341723113.jpg",
                    Element = GetByDate.CalculateElement(model.BirthDate.Year),
                    Zodiac = GetByDate.CalculateZodiacSign(model.BirthDate),
                    TotemAnimal = GetByDate.GetAnimal(model.BirthDate),
                    ChinaAnimal = GetByDate.CalculateAnimal(model.BirthDate.Year),
                    Gem = GetByDate.CalculateDateDigitSum(model.BirthDate),
                    Tree = GetByDate.GetTreeByBirthDate(model.BirthDate),
                    Flower = GetByDate.GetFlower(model.BirthDate),
                    LuckyNumberPath = GetByDate.DigitPath(model.BirthDate),
                    LuckyNumberBirthDay = GetByDate.DigitDay(model.BirthDate),
                    Planet = GetByDate.CalculatePlanet(model.BirthDate.Day),
                    About = "Расскажите о себе"
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                TempData["myNumber"] = newUser.UserId;
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public IActionResult Logoff() //Выход из профиля
        {
            TempData["myNumber"] = 0;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveUser() //Удаление аккаунта пользователя
        {
            int userId = 0;
            if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
            {
                userId = myNumber;
            }
            var itemToDelete = db.Users.FirstOrDefault(g => g.UserId == userId);
            db.Users.Remove(itemToDelete);
            db.SaveChanges();
            TempData["myNumber"] = 0;
            return RedirectToAction("Index", "Home");
        }
    }


}