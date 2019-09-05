using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TaskFamilyWeb.Models
{
    public static class SeekData
    {
        public static void EnsurePopulare(ApplicationDbContext context)
        {
            context.Database.Migrate();
            if (!context.Currencies.Any())
            {
                context.Currencies.AddRange(
                    new Currency
                    {
                        Description = "Российский рубль",
                        DigitalCode = "643",
                        CharacterCode = "руб."
                    },
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
                
             

            }
        }

    }
}
