using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instituicoes.Models.Data
{
    public class CreateDatabase
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any())
            {
                return;
            }

            var departaments = new Department[]
            {
                new Department(){Nome = "Engenharia de Computação"},
                new Department(){Nome = "Sistemas e Mídias Digitais"},
                new Department(){Nome = "Telemática"}
            };

            foreach(var department in departaments)
            {
                context.Departments.Add(department);
            }

            var institutions = new Institution[]
            {
                new Institution(){Nome = "Instituto Federal do Ceará", Endereco = "Avenida 13 de Maio"},
                new Institution(){Nome = "Universidade Federal do Ceará", Endereco = "Avenida Mister Hull"}
            };

            foreach (var institution in institutions)
            {
                context.Institutions.Add(institution);
            }

            context.SaveChanges();
        }
    }
}
