using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using MySql.Data.EntityFrameworkCore;

namespace TaskFamilyWeb.Models
{
    public static class SeekData
    {
        public static void EnsurePopulare(ApplicationDbContext context)
        {
            bool isNotNull = false;
            context.Database.Migrate();
            try
            {
                 isNotNull = context.Currencies.Count<Currency>() > 0;
            }
            catch(Exception ex)
            {
                int a = 10;
            };



            if (!isNotNull)
            {
                Currency ruble = new Currency
                {
                    Description = "Российский рубль",
                    DigitalCode = "643",
                    CharacterCode = "руб."
                };

                Family family = new Family
                {
                    Currency = ruble,
                    Description = "Test Family"
                };


                context.Currencies.AddRange(
                    ruble,
                    new Currency
                    {
                        Description = "Доллар США",
                        DigitalCode = "840",
                        CharacterCode = "USD"
                    },
                    new Currency
                    {
                        Description = "Евро",
                        DigitalCode = "978",
                        CharacterCode = "EUR"
                    }

                    );

                Purse PurseCash = new Purse
                {
                    Currency = ruble,
                    Family = family,
                    Description = "Cash"

                };

                context.Purses.Add(PurseCash);

                context.MovesMoney.AddRange(
                    new MoveMoney
                    {
                        Purse = PurseCash,
                        InMove = DirectMove.incoming,
                        Total = 300
                    },
                    new MoveMoney
                    {
                        Purse = PurseCash,
                        InMove = DirectMove.expense,
                        Total = 200
                    }


                    );

                context.SaveChanges();

            }
        }

    }
}
