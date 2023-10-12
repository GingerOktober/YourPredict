/*
[HttpPost]

public IActionResult changedescription(string newdescription)
{   
    userid = 0;
    if (TempData.TryGetValue("myNumber", out object myNumberObj) && myNumberObj is int myNumber)
    {
        userid = myNumber;
    }
    var descr  = db.Users.FirstOrDefault(b => b.UserId == userid);
    descr.About = newdescription;
    db.User.Remove(descr);
    var ggg = new cartss
    {
        GoodId = goodid;
        UserId = userid;
    }
    db.Users.Add(ggg);
    db.SaveChanges;
return RedirectToAction("Profile");
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
                    About = "Расскажите о себе"
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                TempData["myNumber"] = newUser.UserId;
                return RedirectToAction("Index", "Home");
            }
            return View(model);
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


}*/