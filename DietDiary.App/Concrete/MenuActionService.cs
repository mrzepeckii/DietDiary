﻿using DietDiary.App.Common;
using DietDiary.Domain.Common;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> resultAction = new List<MenuAction>();
            foreach (var action in Items)
                if (action.MenuName == menuName)
                    resultAction.Add(action);
            return resultAction;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Dane uzytkownika", "Main"));
            AddItem(new MenuAction(2, "Produkty", "Main"));
            AddItem(new MenuAction(3, "Dodaj posiłek", "Main"));
            AddItem(new MenuAction(4, "Usuń posiłek", "Main"));
            AddItem(new MenuAction(5, "Wyświetl aktualne posiłki", "Main"));
            AddItem(new MenuAction(6, "Pomiary ciała", "Main"));
            AddItem(new MenuAction(0, "Zamknij aplikację", "Main"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "UserDataMenu"));
            AddItem(new MenuAction(1, "Zaktualizuj dane", "UserDataMenu"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "ProductsMenu"));
            AddItem(new MenuAction(1, "Wyświetl wszystkie produkty", "ProductsMenu"));
            AddItem(new MenuAction(2, "Wyświetl aktualną listę produktów z danej kategorii", "ProductsMenu"));
            AddItem(new MenuAction(3, "Pokaż szczegółowe dane o danym produkcie", "ProductsMenu"));
            AddItem(new MenuAction(4, "Dodaj produkt", "ProductsMenu"));
            AddItem(new MenuAction(5, "Zaktualizuj dane o produkcie", "ProductsMenu"));
            AddItem(new MenuAction(6, "Usuń produkt", "ProductsMenu"));

            //AddItem(new MenuAction(0, "Powrót do menu listy produktów", "ProductsCategory"));
            for (int i = 1; i < 6; i++)
            {
                AddItem(new MenuAction(i, ((CategoryOfProducts)i).ToString(), "ProductsCategory"));
            }

            AddItem(new MenuAction(0, "Powrót do głównego menu", "AddNewMealMenu"));
            for (int i = 1; i < 6; i++)
            {
                AddItem(new MenuAction(i, ((NameOfMeal)i).ToString(), "AddNewMealMenu"));
            }

            AddItem(new MenuAction(0, "Powrót do głównego menu", "BodyMeasurementsMenu"));
            AddItem(new MenuAction(1, "Zaktualizuj pomiary", "BodyMeasurementsMenu"));
        }
    }
}
